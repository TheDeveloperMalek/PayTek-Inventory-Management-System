using ClosedXML.Excel;
using Guna.UI2.WinForms;
using static System.Environment;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using static System.Math;
using System.Media;
using System.Collections.Generic;
using Inventory_Manager.Forms.MainForms;
using Microsoft.Office.Interop.Word;

namespace Inventory_Manager
{
    class FormTimerFadeEffectNeeds
    {
        public Form form;
        public Timer timer = new Timer();
        public FormTimerFadeEffectNeeds(Form f, int interval)
        {
            timer.Interval = interval;
            form = f;
        }
    }
    enum UserType
    {
        Developer,
        Admin,
        User
    }
    internal class Shared
    {
        public static SqlConnection conn = new SqlConnection();
        private static SqlCommand cmd = new SqlCommand();
        #region Usertype And Password
        public static UserType defaultUserType = UserType.User;
        public static string currentUserName = "";
        public static string currentUserPassword = "";
        public static string currentUserType = "";
        static readonly int minimumPasswordLength = 3;
        static readonly int maximumPasswordLength = 30;
        public static readonly string documentsPath = GetFolderPath(SpecialFolder.MyDocuments);
        #endregion

        #region Excel Variables
        public static string programDirectoryName = "PayTek Inventory Management System";
        public static readonly string folderPath = Path.Combine(documentsPath, programDirectoryName);
        static readonly string reportsAuthor = currentUserName;
        static readonly string reportsManager = "Mansour Alset & Waseem Alshmaa";
        #endregion

        #region Show And Hide Components
        public static bool isVisibleForDeveloper = false;
        public static bool isVisibleForAdmin = false;
        public static bool isVisibleForUser = false;
        public static bool isJustVisibleForNonUserType = false;
        #endregion

        #region Sale Word Variables
        static string customerName = "";
        static string headertitle = "";
        static double totalBill = 0;
        static decimal discountPercentage = 0;
        static readonly List<string> customersNames = new List<string>() { };

        #endregion

        #region Sale Word Functions

        static decimal OfferDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 200,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            NumericUpDown numericUpDown = new NumericUpDown() { Minimum = 0, Maximum = 100, Value = 5, Left = 50, Top = 50, Width = 100, Height = 100 };
            Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(numericUpDown);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? numericUpDown.Value : 0;
        }

        static bool IsDatagridValidForPrintingWord(DataGridView dataGridView1)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                    if (cell.ColumnIndex == 2)
                        customersNames.Add((string)cell.Value);
            if (!customersNames.TrueForAll((name) => name == customersNames[0]))
            {
                ErrorOccuredMessageBox("There is more than one customer's name inside of the datagrid");
                customersNames.Clear();
                return false;
            }
            if (dataGridView1.Rows.Count == 0)
            {
                ErrorOccuredMessageBox("There is no data to print");
                return false;
            }

            return true;
        }
        public static void PrintSale(DataGridView dt, string headerTitle)
        {
            if (!IsDatagridValidForPrintingWord(dt)) return;
             customerName = customersNames[0];
            DialogResult offerMake = MessageBox.Show("Do you want to make a discount?", "Make discount", MessageBoxButtons.YesNo);
            if (offerMake == DialogResult.Yes)
                discountPercentage = OfferDialog("Enter the value:", "Make Discount");
            var svf = new SaveFileDialog { Filter = "Word (*.docx)|*docx", FileName = $"{headerTitle} {customerName}.docx" };
            if (svf.ShowDialog() == DialogResult.OK)
                try
                {
                    if (Path.GetExtension(svf.FileName) != ".docx")
                        svf.FileName += ".docx";
                    var word = new Microsoft.Office.Interop.Word.Application();
                    Document doc = word.Documents.Add();
                    headertitle = headerTitle;
                    CreateWord(word , doc , dt);
                    doc.SaveAs2(svf.FileName);

                    string targetCopyFolderPath = $"{folderPath}";
                    string CurrentSNO = "";
                    if(headertitle == "عرض")
                    {
                         CurrentSNO = Preferences.GetPrefValue("CurrentOfferNO");
                         targetCopyFolderPath+= @"\العروض";
                        if (!Directory.Exists(targetCopyFolderPath))
                            Directory.CreateDirectory(targetCopyFolderPath);
                  Preferences.SetPrefValue("CurrentOfferNO", (int.Parse(CurrentSNO) + 1).ToString("D4"));
                    }
                    else
                    {
                        CurrentSNO = Preferences.GetPrefValue("CurrentSaleNO");
                        targetCopyFolderPath += @"\الفواتير";
                        if (!Directory.Exists(targetCopyFolderPath))
                            Directory.CreateDirectory(targetCopyFolderPath);
                        Preferences.SetPrefValue("CurrentSaleNO", (int.Parse(CurrentSNO) + 1).ToString("D4"));
                    }
                    var wordCopyFilePath = $@"{targetCopyFolderPath}\{headertitle} {customerName} NO{CurrentSNO}.docx";
                    doc.SaveAs2(wordCopyFilePath);
                    discountPercentage = 0;
                    totalBill = 0;
                    customerName = "";
                    headertitle = "";
                    customersNames.Clear();
                    doc.Close();
                    ProcessIsDoneMessageBox("bill", "printed");
                    Preferences.SetPrefValue("WordDate", DateTime.Now.ToShortDateString());
                }
                catch (Exception exc)
                {
                    ErrorOccuredMessageBox(exc.Message);
                }
        }

        static void CreateWord(Microsoft.Office.Interop.Word.Application word, Document doc , DataGridView datatable)
        {
            double price = 0;

            #region Header
            Range headerRange = doc.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            Table headerTable = headerRange.Tables.Add(headerRange, 1, 2);
            headerTable.Borders.Enable = 0;
            using (Stream stream = Shared.StreamMakerFromAssemblyFile("Resources.Icons", "levant_logo", "jpg"))
            {
                string tempFilePath = Path.Combine(Path.GetTempPath(), "tempImage.png");
                if (!File.Exists(tempFilePath))
                    using (FileStream fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                        stream.CopyTo(fileStream);

                headerTable.Cell(1, 1).Range.InlineShapes.AddPicture(tempFilePath, LinkToFile: false, SaveWithDocument: true);
                headerTable.Cell(1, 1).Width = 20;
                headerTable.Cell(1, 1).Height = 60;
                headerTable.Cell(1, 1).RightPadding = 215;
                headerTable.Cell(1, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            }

            var textCell = headerTable.Cell(1, 2);
            textCell.Range.Text = Preferences.GetPrefValue("CompanyHeader");
            textCell.Range.Font.SizeBi = 15;
            textCell.Range.Font.BoldBi = 1;
            textCell.Column.AutoFit();
            textCell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            textCell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            #endregion

            #region Title Date NO  Customer's Name
            Range titleRange = doc.Content;
            titleRange.Collapse(WdCollapseDirection.wdCollapseEnd);
            titleRange.Text = headertitle ;
            titleRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            titleRange.Font.BoldBi = 1;
            titleRange.Font.SizeBi = 19;
            titleRange.InsertParagraphAfter();

            Range dateRange = doc.Content;
            dateRange.Collapse(WdCollapseDirection.wdCollapseEnd);
            dateRange.InsertParagraphAfter();
            dateRange.Text = "دمشق في : " + Preferences.GetPrefValue("WordDate");
            dateRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            dateRange.Font.SizeBi = 14;
            dateRange.InsertParagraphAfter();

            Range SerialNumberRange = doc.Content;
            SerialNumberRange.Collapse(WdCollapseDirection.wdCollapseEnd);
            SerialNumberRange.InsertParagraphAfter();
            SerialNumberRange.Text = (headertitle is "عرض") ? "NO :  " + Preferences.GetPrefValue("CurrentOfferNO") : "NO :  " + Preferences.GetPrefValue("CurrentSaleNO");
            SerialNumberRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            SerialNumberRange.Font.SizeBi = 14;
            SerialNumberRange.InsertParagraphAfter();

            Range billRange = doc.Content;
            billRange.Collapse(WdCollapseDirection.wdCollapseEnd);
            billRange.InsertParagraphAfter();
            billRange.Text = $"المطلوب من : {customerName} المحترم";
            billRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            billRange.Font.SizeBi = 14;
            billRange.InsertParagraphAfter();
            #endregion

            #region Description Table
            var dt = datatable.DataSource as System.Data.DataTable;
            int numberOfColumns = 4;
            var tableRange = doc.Content;
            tableRange.Collapse(WdCollapseDirection.wdCollapseEnd);
            tableRange.InsertParagraphAfter();
            var descTable = word.Application.ActiveDocument.Tables.Add(tableRange, datatable.Rows.Count + 1, numberOfColumns, Type.Missing);
            foreach (Cell cell in descTable.Range.Cells)
            {
                cell.Borders.Enable = 1;
                cell.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                cell.Range.Font.SizeBi = 14;
                cell.Range.Font.Size = 14;
                cell.TopPadding = 11;
                cell.BottomPadding = 3;
            }
            for (int i = 0; i < numberOfColumns; i++)
            {
                var headerCell = descTable.Cell(1, i + 1);
                headerCell.Range.Text = datatable.Columns[i + 5].HeaderText;
                headerCell.Range.Font.Bold = 1;
                headerCell.Range.Font.Size = 14;
                headerCell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                headerCell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
            }
            for (int i = 0; i < datatable.Rows.Count; i++)
                for (int j = 0; j < numberOfColumns; j++)
                {
                    descTable.Cell(i + 2, j + 1).Range.Text = dt.Rows[i][j + 5].ToString();
                    descTable.Cell(i + 2, j + 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    if (j == numberOfColumns - 1)
                        price += double.Parse(dt.Rows[i][j + 5].ToString());
                }
            descTable.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitWindow);
            descTable.Columns.AutoFit();
            #endregion

            if(discountPercentage == 0)
            {
            #region Pay Table With No Discount
            Range newTableRange = doc.Content;
            newTableRange.Collapse(WdCollapseDirection.wdCollapseEnd);
            Table newTable = doc.Tables.Add(newTableRange, 1, 2);
            newTable.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitWindow);
            newTable.Borders.Enable = 1;
            var numCell = newTable.Cell(descTable.Rows.Count, 2);
            var txtCell = newTable.Cell(descTable.Rows.Count, 1);
            numCell.Range.Text = $"{price}";
            txtCell.Range.Text = " : المجموع";
            numCell.TopPadding = txtCell.TopPadding = 11;
            numCell.BottomPadding = txtCell.BottomPadding = 3;
            numCell.Range.Font.Size = txtCell.Range.Font.Size = 14;
            numCell.Range.Font.SizeBi = txtCell.Range.Font.SizeBi = 14;
            numCell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            numCell.Width =  descTable.Cell(1 , 4).Width;
            txtCell.Width = descTable.Cell(1, 1).Width + descTable.Cell(1, 2).Width + descTable.Cell(1, 3).Width;
            numCell.Range.Bold = 1;
            txtCell.Range.BoldBi = 1;
            #endregion
            }

            else
            {
                #region PayTable With Discount
                Range discountRange = doc.Content;
                discountRange.Collapse(WdCollapseDirection.wdCollapseEnd);
                Table discountTable = doc.Tables.Add(discountRange, 1, 2);
                discountTable.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitWindow);
                discountTable.Borders.Enable = 1;
                var discountNumCell = discountTable.Cell(descTable.Rows.Count, 2);
                var discountTxtCell = discountTable.Cell(descTable.Rows.Count, 1);
                var negativeValueOfDiscount = - price * (double)discountPercentage / 100;
                discountNumCell.Range.Text = $"{negativeValueOfDiscount}";
                discountTxtCell.Range.Text = $"{discountPercentage}% : الحسم";
                discountNumCell.TopPadding = discountTxtCell.TopPadding = 11;
                discountNumCell.BottomPadding = discountTxtCell.BottomPadding = 3;
                discountNumCell.Range.Font.Size = discountTxtCell.Range.Font.Size = 14;
                discountNumCell.Range.Font.SizeBi = discountTxtCell.Range.Font.SizeBi = 14;
                discountNumCell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                discountNumCell.Width = descTable.Cell(1, 4).Width;
                discountTxtCell.Width = descTable.Cell(1, 1).Width + descTable.Cell(1, 2).Width + descTable.Cell(1, 3).Width;
                discountNumCell.Range.Bold = 1;
                discountTxtCell.Range.Bold = 1;
                discountTxtCell.Range.BoldBi = 1;

                Range priceTableRange = doc.Content;
            priceTableRange.Collapse(WdCollapseDirection.wdCollapseEnd);
            Table priceTable = doc.Tables.Add(priceTableRange, 1, 2);
            priceTable.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitWindow);
            priceTable.Borders.Enable = 1;
            var numCell = priceTable.Cell(descTable.Rows.Count, 2);
            var txtCell = priceTable.Cell(descTable.Rows.Count, 1);
            numCell.Range.Text = $"{price + negativeValueOfDiscount}";
            txtCell.Range.Text = " : المجموع";
            numCell.TopPadding = txtCell.TopPadding = 11;
            numCell.BottomPadding = txtCell.BottomPadding = 3;
            numCell.Range.Font.Size = txtCell.Range.Font.Size = 14;
            numCell.Range.Font.SizeBi = txtCell.Range.Font.SizeBi = 14;
            numCell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            numCell.Width = descTable.Cell(1, 4).Width;
            txtCell.Width = descTable.Cell(1, 1).Width + descTable.Cell(1, 2).Width + descTable.Cell(1, 3).Width;
            numCell.Range.Bold = 1;
            txtCell.Range.BoldBi = 1;
            #endregion
            }

            #region PayInfo
            Range PayInfo = doc.Content;
            PayInfo.Collapse(WdCollapseDirection.wdCollapseEnd);
            PayInfo.Text = "\n" + Preferences.GetPrefValue("CompanyPaymentInfo");
            PayInfo.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            PayInfo.Font.SizeBi = 14;
            PayInfo.InsertParagraphAfter();
            #endregion

            #region Footer
            Range footerRange = doc.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            Table footerTable = doc.Tables.Add(footerRange, 1, 2);
            footerTable.Cell(1, 1).Range.Text = "EMAIL: a.alrehawe@levant-tek.com";
            footerTable.Cell(1, 2).Range.Text = "دمشق  هاتف : 0968585950 - 22228989";
            footerTable.Cell(1, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            footerTable.Cell(1, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            footerTable.Borders.Enable = 0;
            footerTable.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
            footerTable.Borders[WdBorderType.wdBorderTop].LineWidth = WdLineWidth.wdLineWidth300pt;
            footerTable.Borders[WdBorderType.wdBorderTop].Color = WdColor.wdColorDarkRed;
            #endregion
        }
        #endregion

        public static void HideComponentsByUserType()
        {
            isVisibleForDeveloper =
            isVisibleForAdmin =
            isJustVisibleForNonUserType =
            isVisibleForUser = false;
            switch (defaultUserType)
            {
                case UserType.Developer:
                    isJustVisibleForNonUserType =
                    isVisibleForDeveloper = true;
                    break;
                case UserType.Admin:
                    isJustVisibleForNonUserType =
                    isVisibleForAdmin = true;
                    break;
                case UserType.User:
                    isVisibleForUser = true;
                    break;
            }
        }

        public static void KeysShortcuts(object sender, KeyEventArgs e, Form window, bool enableFullScreenShortcut = true)
        {
            if (enableFullScreenShortcut && e.Control && e.KeyCode == Keys.F)
            {
                if (window.FormBorderStyle == FormBorderStyle.None)
                {
                    window.FormBorderStyle = FormBorderStyle.Sizable;
                    window.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    window.FormBorderStyle = FormBorderStyle.None;
                    window.WindowState = FormWindowState.Normal;
                    window.Location = new System.Drawing.Point(0, 0);
                    window.Size = Screen.PrimaryScreen.Bounds.Size;
                }
                e.SuppressKeyPress = true;
                return;
            }

            if (e.Control && e.KeyCode == Keys.E)
            {
                FadeOutEffect(window);
                e.SuppressKeyPress = true;
                return;
            }

            if (e.Control && e.KeyCode == Keys.M)
            {
                window.WindowState = FormWindowState.Minimized;
                e.SuppressKeyPress = true;
                return;
            }

            e.SuppressKeyPress = false;
        }
        public static void ShowToast(string message, object window)
        {
            var thisWindow = window as Form;
            ToolTip toast = new ToolTip();
            int screenWidth = Screen.PrimaryScreen.Bounds.Width,
            screenHeight = Screen.PrimaryScreen.Bounds.Height,
            toastWidth = 110,
            toastHeight = 50,
            x = (screenWidth - toastWidth) / 2,
            y = screenHeight - toastHeight - 150;
            toast.Show(message, thisWindow, x, y, 2500);
        }

        public static string ProductBarcodeGetter(string targetColumn, TextBox tb)
        {

            cmd = conn.CreateCommand();
            cmd.CommandText = $@"SELECT  barcode
                                             FROM Product
                                             WHERE
                                             {$"\"{targetColumn}\""} = N'{tb.Text}'";
            if (cmd.ExecuteScalar() != null)
                return cmd.ExecuteScalar().ToString();
            return null;
        }
        public static string ProductBarcodeGetterGuna(string targetColumn, Guna2TextBox tb)
        {

            cmd = conn.CreateCommand();
            cmd.CommandText = $@"SELECT  barcode
                                             FROM Product
                                             WHERE
                                             {$"\"{targetColumn}\""} = N'{tb.Text}'";
            if (cmd.ExecuteScalar() != null)
                return cmd.ExecuteScalar().ToString();
            return null;
        }

        public static void ConnectionInitializer()
        {
            conn.Close();
            if (conn.State != ConnectionState.Open)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Inventory_Manager.Properties.Settings.PublicConnectionString"].ConnectionString;
                conn.ConnectionString = connectionString.Replace("{MachineName}", Environment.MachineName);
                conn.Close();
                conn.Open();
            }
            cmd.Parameters.Clear();
        }

        public static void ResetFields(GroupBox gp)
        {
            foreach (Control c in gp.Controls)
                if (c is TextBox t)
                    t.Text = "";
                else if (c is RichTextBox rb)
                    rb.Text = "";
                else if (c is System.Windows.Forms.CheckBox ch)
                    ch.Checked = false;
        }

        public static void GeneralConnectionInitializer()
        {
            if (conn.State != ConnectionState.Open)
            {
                string connectionString = $"Data Source={MachineName};Initial Catalog= ;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
                conn.ConnectionString = connectionString;
                conn.Close();
                conn.Open();
            }
        }

        public static void ShowAllTableData(DataGridView target, string tableName, string orderBy, bool excludeRow = false, string excludedBy = "", string excludedValue = "", Guna2DateTimePicker startDate = default, Guna2DateTimePicker endDate = default)
        {
            ConnectionInitializer();
            cmd.Connection = conn;
            if (excludeRow)
            {
                cmd.CommandText = $@"SELECT * FROM {tableName} WHERE ""{excludedBy}"" != '{excludedValue}'";
                if (startDate != default)
                    cmd.CommandText += $@" AND date BETWEEN @startDate AND @endDate";
            }
            else
            {
                cmd.CommandText = $@"SELECT * FROM {tableName}";
                if (startDate != default)
                    cmd.CommandText += $@" WHERE date BETWEEN @startDate AND @endDate";

            }
            if (startDate != default)
            {
                cmd.Parameters.AddWithValue("@startDate", startDate.Value);
                cmd.Parameters.AddWithValue("@endDate", endDate.Value);
            }
            cmd.CommandText += $@" ORDER BY ""{orderBy}""";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            target.DataSource = dt;
        }

        public static void ShowAllInventoryReportTableDataWithDate(DataGridView target, string orderBy, Guna2DateTimePicker startDate, Guna2DateTimePicker endDate)

        {
            DateValidityChecker(startDate, endDate);
            ConnectionInitializer();
            cmd = conn.CreateCommand();
            cmd.Parameters.AddWithValue("@startDate", startDate.Value);
            cmd.Parameters.AddWithValue("@endDate", endDate.Value);
            cmd.CommandText = $@"SELECT  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , SUM(quantity) AS quantity , CAST (@EndDate as date) as date
                                      FROM InventoryReport
                                      WHERE date 
                                      BETWEEN @startDate
                                      AND @endDate
                                      GROUP BY  ""Product ID"" , ""Product Barcode"" , ""Product Name""
                                      ORDER BY ""{orderBy}""";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            target.DataSource = dt;
            cmd.Parameters.Clear();
        }

        public static void ShowAllProductReportTableDataWithDate(DataGridView target, string orderBy, Guna2DateTimePicker startDate, Guna2DateTimePicker endDate)

        {
            DateValidityChecker(startDate, endDate);
            ConnectionInitializer();
            cmd = conn.CreateCommand();
            cmd.Parameters.AddWithValue("@startDate", startDate.Value);
            cmd.Parameters.AddWithValue("@endDate", endDate.Value);
            cmd.CommandText = $@"SELECT  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , Status , SUM(quantity) AS quantity ,date
                                      FROM  ProductReport
                                      WHERE date 
                                      BETWEEN @startDate
                                      AND @endDate
                                      GROUP BY  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , Status , date
                                      ORDER BY ""{orderBy}""";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            target.DataSource = dt;
            cmd.Parameters.Clear();
        }

        public static bool IsTextBoxHasNotEnoughData(TextBox tb)
        {
            return tb.Text == "" || tb.Text.StartsWith(" ");
        }

        public static void SaveDataGridViewASExcelFile(string reportTitle, DataGridView target, Guna2DateTimePicker startDate, Guna2DateTimePicker endDate)
        {
            if (target.DataSource is System.Data.DataTable dataTable)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Save an Excel File";
                    saveFileDialog.FileName = $"{reportTitle}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            workbook.Properties.Author = reportsAuthor;
                            workbook.Properties.Manager = reportsManager;
                            workbook.Properties.Category = "Reports";
                            workbook.Properties.Title = reportTitle;
                            workbook.Properties.Comments = $@"Report:
from: {startDate.Value.ToShortDateString()}
to: {endDate.Value.ToShortDateString()} ";
                            workbook.Properties.Company = "PayTek Company";
                            workbook.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            workbook.RowHeight = 33;
                            workbook.ColumnWidth = 28;
                            workbook.Style.Font.FontSize = 28;
                            workbook.Worksheets.Add(dataTable, "Sheet1");
                            workbook.SaveAs(saveFileDialog.FileName);
                        }

                        MessageBox.Show("Excel file created successfully at: \n" + saveFileDialog.FileName, "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No data available to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string SearchCommandGenerator(TextBox tb, string targetTable, string targetColumn, string orderby, bool skipCheckNumericDataValidation = true, string ItemNameForErrorMessage = "", string excludedBy = "", string excludedValue = "", DateTime startDate = default, DateTime endDate = default)
        {
            if (excludedBy != "")
            {
                return $@"SELECT  *
                                     FROM ""{targetTable}""
                                     WHERE ""{targetColumn}""
                                     LIKE N'%{tb.Text}%'
                                     AND ""{excludedBy}"" != '{excludedValue}'
                                     ORDER BY ""{orderby}""";
            }
            if (skipCheckNumericDataValidation || int.TryParse("0" + tb.Text, out int outputValue) && outputValue >= 0)
            {
                if (startDate != default && endDate != default)
                {
                    return $@"SELECT  *
                                     FROM ""{targetTable}""
                                     WHERE ""{targetColumn}""
                                     LIKE N'%{tb.Text}%'
                                     AND date BETWEEN @startDate
                                     AND @endDate
                                     ORDER BY ""{orderby}""";
                }

                return $@"SELECT  *
                                     FROM ""{targetTable}""
                                     WHERE ""{targetColumn}""
                                     LIKE N'%{tb.Text}%'
                                     ORDER BY ""{orderby}""";
            }


            else
            {
                ErrorOccuredMessageBox($"Enter a valid value for {ItemNameForErrorMessage}");
                tb.Text = "";
                return "";
            }
        }

        public static void SearchCommandApply(DataGridView targetTable, string command, DateTime startDate = default, DateTime endDate = default)
        {
            ConnectionInitializer();
            cmd = conn.CreateCommand();
            cmd.CommandText = command;
            if (command != "")
            {
                if (startDate != default)
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                }
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                targetTable.DataSource = dt;
            }
            cmd.Parameters.Clear();
            cmd.Dispose();
        }


        public static void SearchCommandAssembler(DataGridView targetTable, TextBox tb, string tableName, string targetColumn, string orderBy, bool skipCheckNumericDataValidation = true, string ErrorParsing = "", bool excludeRow = false, string excludedBy = "", string excludedValue = "", DateTime startDate = default, DateTime endDate = default)
        {
            if (IsTextBoxHasNotEnoughData(tb))
            {
                ShowAllTableData(targetTable, tableName, orderBy, excludeRow, excludedBy, excludedValue);
                return;
            }
            var command = SearchCommandGenerator(tb, tableName, targetColumn, orderBy, skipCheckNumericDataValidation, ErrorParsing, excludedBy, excludedValue, startDate, endDate);
            SearchCommandApply(targetTable, command, startDate, endDate);
        }

        public static string SearchCommandGeneratorWithDateForProductReport(TextBox tb, string targetTable, string targetColumn, bool skipCheckNumericDataValidation = true, string ItemNameForErrorMessage = "")
        {
            if (skipCheckNumericDataValidation)
            {
                return $@"SELECT  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , Status , SUM(quantity) AS quantity , date
                                      FROM  ""{targetTable}""
                                      WHERE ""{targetColumn}""
                                      LIKE N'%{tb.Text}%'
                                      AND  date 
                                      BETWEEN @StartDate
                                      AND @EndDate
                                      GROUP BY  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , Status , date
                                      ORDER BY ""Product ID""";
            }
            else if (int.TryParse("0" + tb.Text, out int outputValue) && outputValue >= 0)
            {
                return $@"SELECT  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , Status , SUM(quantity) AS quantity , CAST (@EndDate as date) as date
                                      FROM  ""{targetTable}""
                                      WHERE ""{targetColumn}""
                                      LIKE N'{tb.Text}%'
                                      AND  date 
                                      BETWEEN @StartDate
                                      AND @EndDate
                                      GROUP BY  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , Status
                                      ORDER BY ""Product ID""";
            }
            else
            {
                MessageBox.Show($"Enter a valid value for {ItemNameForErrorMessage}");
                tb.Text = "";
                return "";
            }
        }

        public static string SearchCommandGeneratorWithDateForInventoryReport(TextBox tb, string targetTable, string targetColumn, bool skipCheckNumericDataValidation = true, string ItemNameForErrorMessage = "")
        {
            if (skipCheckNumericDataValidation)
            {
                return $@"SELECT  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , SUM(quantity) AS quantity , CAST (@EndDate as date) as date
                                      FROM ""{targetTable}""
                                      WHERE ""{targetColumn}""
                                      LIKE N'%{tb.Text}%'
                                      AND  date 
                                      BETWEEN @StartDate
                                      AND @EndDate
                                      GROUP BY  ""Product ID"" , ""Product Barcode"" , ""Product Name""
                                      ORDER BY ""Product ID""";
            }
            else if (int.TryParse("0" + tb.Text, out int outputValue) && outputValue >= 0)
            {
                return $@"SELECT  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , SUM(quantity) AS quantity , CAST (@EndDate as date) as date
                                      FROM ""{targetTable}""
                                      WHERE ""{targetColumn}""
                                      LIKE N'{tb.Text}%'
                                      AND  date 
                                      BETWEEN @StartDate
                                      AND @EndDate
                                      GROUP BY  ""Product ID"" , ""Product Barcode"" , ""Product Name""
                                      ORDER BY ""Product ID""";
            }
            else
            {
                MessageBox.Show($"Enter a valid value for {ItemNameForErrorMessage}");
                tb.Text = "";
                return "";
            }
        }

        public static void SearchCommandApplyWithDate(DataGridView targetTable, string command, Guna2DateTimePicker startDate, Guna2DateTimePicker endDate)
        {
            ConnectionInitializer();
            cmd = conn.CreateCommand();
            cmd.Parameters.AddWithValue("@StartDate", startDate.Value);
            cmd.Parameters.AddWithValue("@EndDate", endDate.Value);
            cmd.CommandText = command;
            if (command != "")
            {
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                targetTable.DataSource = dt;
            }
            cmd.Parameters.Clear();
            cmd.Dispose();
        }

        public static void SearchCommandWitDateAssembler(DataGridView targetTable, TextBox tb, string tableName, string targetColumn, string orderBy, Guna2DateTimePicker startDate, Guna2DateTimePicker endDate, bool skipCheckNumericDataValidation = true, string ErrorParsing = "", bool ProductReport = true)
        {
            if (IsTextBoxHasNotEnoughData(tb))
            {
                ShowAllTableData(targetTable, tableName, orderBy);
                return;
            }
            string command;
            if (ProductReport)
                command = SearchCommandGeneratorWithDateForProductReport(tb, tableName, targetColumn, skipCheckNumericDataValidation, ErrorParsing);
            else
                command = SearchCommandGeneratorWithDateForInventoryReport(tb, tableName, targetColumn, skipCheckNumericDataValidation, ErrorParsing);
            SearchCommandApplyWithDate(targetTable, command, startDate, endDate);
        }

        public static void DateValidityChecker(Guna2DateTimePicker startDate, Guna2DateTimePicker endDate)
        {
            if (startDate.Value > endDate.Value)
            {
                startDate.Value = endDate.Value.AddDays(-1);
                return;
            }
        }

        public static bool CheckIfDataBaseAlreadyExists()
        {
            GeneralConnectionInitializer();
            cmd.Connection = conn;
            cmd.CommandText = $@"IF DB_ID('public') IS NOT NULL
                                SELECT 'true'
                                ELSE 
                                SELECT 'false'";
            return bool.Parse(cmd.ExecuteScalar().ToString());
        }

        public static bool DoesUserExists(string username)
        {
            ConnectionInitializer();
            using (SqlCommand cmd = new SqlCommand("DoesUserExist", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usrname", username);
                return bool.Parse(cmd.ExecuteScalar().ToString());
            }
        }

        public static bool DoesUserWantToInstallFromSpecificBakFile()
        {
            DialogResult wantFromSpecificFile;
            wantFromSpecificFile = MessageBox.Show($"Do you want to install data from a backup instead of installing the default version ? ", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return wantFromSpecificFile == DialogResult.Yes;
        }

        public static void CreateDBIfNotExists()
        {
            try
            {
                if (!CheckIfDataBaseAlreadyExists())
                {
                    try
                    {
                        GeneralConnectionInitializer();
                        cmd.Connection = conn;
                        cmd.CommandText = @"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Public')
                                BEGIN
                                    CREATE DATABASE [Public];
                                END";
                        cmd.ExecuteNonQuery();
                        string RestoreFromBakFileMessage = "";
                        if (DoesUserWantToInstallFromSpecificBakFile())
                        {
                            RestoreFromBakFileMessage = RestoreDBFromBakFile("Public");
                            PlayNotificationSound();
                            MessageBox.Show(RestoreFromBakFileMessage, "Info");
                        }
                        if (RestoreFromBakFileMessage != "\nDatabase restored successfully!")
                        {
                            Assembly assembly = Assembly.GetExecutingAssembly();
                            string resourceName = "Inventory_Manager.DBTemplate.TemplateScript.sql";
                            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                            {
                                if (stream != null)
                                    using (StreamReader reader = new StreamReader(stream))
                                    {
                                        var DBTemplateCommands = reader.ReadToEnd().Replace("GO", "~").Split('~');
                                        foreach (var command in DBTemplateCommands)
                                        {
                                            cmd.CommandText = command;
                                            cmd.ExecuteNonQuery();
                                        }
                                        ProcessIsDoneMessageBox("default schema", "installed");
                                    }
                                else
                                    MessageBox.Show("The SQL file resource was not found.", "Resource Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading SQL file: " + ex.Message);
                    }
                }
            }
            catch (Exception exc)
            {
                Shared.ErrorOccuredMessageBox(exc.Message);
            }
        }

        public static Stream StreamMakerFromAssemblyFile(string folderName, string fileName, string FileExtension)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = $"Inventory_Manager.{folderName}.{fileName}.{FileExtension}";
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            if (stream != null)
                return stream;
            else
                return null;
        }

        public static void TextBoxAutoCompleteFromColumn(string table, string columnName, TextBox tb)
        {
            ConnectionInitializer();
            cmd.CommandText = $@"SELECT ""{columnName}""
                                FROM {table}";
            var suggestion = new AutoCompleteStringCollection();
            using (SqlDataReader myreader = cmd.ExecuteReader())
                while (myreader.Read())
                    suggestion.Add(myreader.GetValue(0).ToString());

            tb.AutoCompleteCustomSource = suggestion;
            tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb.AutoCompleteMode = AutoCompleteMode.Suggest;
        }
        public static void TextBoxAutoCompleteFromColumnGuna(string table, string columnName, Guna2TextBox tb)
        {
            ConnectionInitializer();
            cmd.CommandText = $@"SELECT ""{columnName}""
                                FROM {table}";
            var suggestion = new AutoCompleteStringCollection();
            using (SqlDataReader myreader = cmd.ExecuteReader())
                while (myreader.Read())
                    suggestion.Add(myreader.GetValue(0).ToString());

            tb.AutoCompleteCustomSource = suggestion;
            tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        public static void SetDirPerminssionForSavingDB(string dirPath)
        {
            var serviceAccount = @"NT SERVICE\MSSQLSERVER";
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
            DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
            directorySecurity.AddAccessRule(new FileSystemAccessRule(serviceAccount, FileSystemRights.FullControl, AccessControlType.Allow));
            directoryInfo.SetAccessControl(directorySecurity);
        }

        public static void PlaySound(Stream sound)
        {
            if (sound != null)
                using (SoundPlayer player = new SoundPlayer(sound))
                    player.Play();
        }

        public static void ProcessIsDoneMessageBox(string target, string doneProcess)
        {
            PlaySuccededSound();
            MessageBox.Show($"The {target} has been {doneProcess} successfully!", "Done");
        }

        public static void ErrorOccuredMessageBox(string message)
        {
            PlayFailedSound();
            MessageBox.Show(message, "An error occured");
        }

        public static void IgnoredProcess(string message)
        {
            PlayNotificationSound();
            MessageBox.Show(message, "Ignored");
        }

        public static void PlayWrongPasswordSound()
        {
            PlaySound(StreamMakerFromAssemblyFile("Resources.Sounds", "ErrorLogIN", "wav"));
        }

        public static void PlaySuccededSound()
        {
            PlaySound(StreamMakerFromAssemblyFile("Resources.Sounds", "Successed", "wav"));
        }

        public static void PlayStartupSound()
        {
            PlaySound(StreamMakerFromAssemblyFile("Resources.Sounds", "StartUp", "wav"));
        }

        public static void PlayNotificationSound()
        {
            PlaySound(StreamMakerFromAssemblyFile("Resources.Sounds", "Notification", "wav"));
        }

        public static void PlayClickSound()

        {
            PlaySound(StreamMakerFromAssemblyFile("Resources.Sounds", "Click", "wav"));
        }

        public static void PlayFailedSound()
        {
            PlaySound(StreamMakerFromAssemblyFile("Resources.Sounds", "Error", "wav"));
        }

        public static void SetFilePermissionReading(string filePath)
        {
            string sqlServiceAccount = @"NT SERVICE\MSSQLSERVER";
            FileSecurity fileSecurity = File.GetAccessControl(filePath);
            fileSecurity.AddAccessRule(new FileSystemAccessRule(sqlServiceAccount, FileSystemRights.Read, AccessControlType.Allow));
            File.SetAccessControl(filePath, fileSecurity);
        }

        public static string CreateDBBackup(string targetDB)
        {
            try
            {
                ConnectionInitializer();
                cmd = conn.CreateCommand();
                var targetPath = $@"{documentsPath}\{programDirectoryName}\backups";
                var file = $@"PayTekDbBackupAt{DateTime.Now
                                            .ToShortDateString()
                                            .Replace('/', '-')}.bak";
                SetDirPerminssionForSavingDB(targetPath);
                if (File.Exists($@"{targetPath}\{file}"))
                    File.Delete($@"{targetPath}\{file}");
                cmd.CommandText = $@"BACKUP DATABASE 
                                                    [{targetDB}] TO DISK = 
                                                    '{targetPath}\{file}'
                                                    WITH FORMAT, INIT ;";
                cmd.ExecuteNonQuery();
                return $"\nSaved backup at \"{targetPath}\"";
            }
            catch (Exception exc)
            {
                return $"\n{exc.Message}";
            }
        }

        public static string RestoreDBFromBakFile(string DBName)
        {
            GeneralConnectionInitializer();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Backup files (*.bak)|*.bak|All files (*.*)|*.*";
                openFileDialog.Title = "Select a Backup File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = openFileDialog.FileName;
                    SetFilePermissionReading(backupFilePath);

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
                        {
                            connection.Open();

                            using (SqlCommand cmd = new SqlCommand($@"USE master; 
                                                                      ALTER DATABASE ""{DBName}"" 
                                                                      SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", connection))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd = new SqlCommand($@"USE master; 
                                                                     RESTORE DATABASE ""{DBName}"" 
                                                                     FROM DISK = '{backupFilePath}' WITH REPLACE;", connection))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd = new SqlCommand($@"USE master; 
                                                                      ALTER DATABASE ""{DBName}"" 
                                                                      SET MULTI_USER;", connection))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        return $"\nDatabase restored successfully!";
                    }
                    catch (Exception exc)
                    {
                        return $"\n{exc.Message}";
                    }
                }
                else
                    return "\nYou did not choose a .bak file \n the default db schema will be installed ^_^";
            }

        }

        private static void fadeInTimer_Tick_1(object sender, EventArgs e)
        {
            var targetForm = sender as FormTimerFadeEffectNeeds;
            if (targetForm.form.Opacity < 1)
                targetForm.form.Opacity += 0.025;
            else targetForm.timer.Stop();
        }

        public static void FadeInEffect(Form f, int interval = 5)
        {
            var fadeNeeds = new FormTimerFadeEffectNeeds(f, interval);
            fadeNeeds.timer.Tick += new EventHandler((object sender, EventArgs e) => fadeInTimer_Tick_1(fadeNeeds, e));
            fadeNeeds.timer.Start();
        }

        private static void fadeOutTimer_Tick_1(object sender, EventArgs e)
        {
            var targetForm = sender as FormTimerFadeEffectNeeds;
            if (targetForm.form.Opacity > 0)
                targetForm.form.Opacity -= 0.025;
            else
            {
                targetForm.timer.Stop();
                targetForm.form.Close();
            }
        }

        public static void FadeOutEffect(Form f, int interval = 5)
        {
            var fadeNeeds = new FormTimerFadeEffectNeeds(f, interval);
            fadeNeeds.timer.Tick += new EventHandler((object sender, EventArgs e) => fadeOutTimer_Tick_1(fadeNeeds, e));
            fadeNeeds.timer.Start();
        }

        #region password algorithms
        public static string Encrypt(string plaintext, int shift = 3)
        {
            StringBuilder asciiValues = new StringBuilder();

            foreach (char c in plaintext)
            {
                char encryptedChar;

                if (char.IsUpper(c))
                    encryptedChar = (char)(((c + shift - 'A') % 26) + 'A');
                else if (char.IsLower(c))
                    encryptedChar = (char)(((c + shift - 'a') % 26) + 'a');
                else
                    encryptedChar = c;

                asciiValues.Append((int)encryptedChar + " ");
            }

            return asciiValues.ToString().Trim();
        }

        public static bool ArePasswordConditionsFulfilled(string password)
        {
            int length = password.Length;
            if (length >= minimumPasswordLength && length <= maximumPasswordLength)
                return true;
            ErrorOccuredMessageBox($"Password length is {length} , it should be between {minimumPasswordLength} and {maximumPasswordLength}");
            return false;
        }

        public static string Decrypt(string asciiValues, int shift = 3)
        {
            StringBuilder decryptedText = new StringBuilder();
            string[] asciiArray = asciiValues.Split(' ');

            foreach (string asciiValue in asciiArray)
            {
                if (int.TryParse(asciiValue, out int value))
                {
                    char decryptedChar;

                    if (value >= 'A' && value <= 'Z')
                        decryptedChar = (char)((((value - 'A') - shift + 26) % 26) + 'A');
                    else if (value >= 'a' && value <= 'z')
                        decryptedChar = (char)((((value - 'a') - shift + 26) % 26) + 'a');
                    else
                        decryptedChar = (char)value; // Non-alphabetic characters remain unchanged

                    decryptedText.Append(decryptedChar);
                }
            }

            return decryptedText.ToString(); // Return the decrypted string
        }

        private static bool DeveloperPasswordMustBeUpdated()
        {
            if (!DoesUserExists("malek"))
            {
                cmd.Parameters.AddWithValue("@username", "malek");
                cmd.Parameters.AddWithValue("@pass", Encrypt("anders"));
                cmd.Parameters.AddWithValue("@usertype", "Developer");
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.CommandText = @"INSERT INTO ROLES
                                    VALUES(@username , @pass , @usertype , @date)";
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return false;
            }

            ConnectionInitializer();
            cmd.Connection = conn;

            cmd.CommandText = @"SELECT ""Last modified"" 
                                FROM Roles
                                WHERE usertype = 'developer' ";
            var lastTimeOfGettingPrivatePasswordFromWeb =
                DateTime.Parse(cmd.ExecuteScalar().ToString());

            var TimeOfNow = DateTime.Now;

            var DifferenceBetwenLastUpdateOfPrivatePasswordAndNow = Abs
                ((TimeOfNow - lastTimeOfGettingPrivatePasswordFromWeb).TotalDays);

            return DifferenceBetwenLastUpdateOfPrivatePasswordAndNow > 30;
        }

        public static void DeveloperPasswordSetter(bool forceUpdate = false)
        {
            var inputToDataBasePrivatePassword = "";

            if (DeveloperPasswordMustBeUpdated() || forceUpdate)
            {
                string path = $@"{documentsPath}\{programDirectoryName}\";
                var file = $@"{path}private.txt";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var a = new WebClient();
                a.DownloadFile("https://drive.google.com/uc?export=download&id=1rBeJ9wz3WI6A4Ut-Vcyul-1BUzHYHU5d", file);

                var k = new StreamReader(file);

                inputToDataBasePrivatePassword = Encrypt(k.ReadToEnd());

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE Roles
                                        SET password = @password
                                        WHERE usertype = 'developer' ";
                cmd.Parameters.AddWithValue("@password", inputToDataBasePrivatePassword);
                cmd.ExecuteNonQuery();


                cmd.CommandText = @"UPDATE Roles
                                        SET ""last modified"" = @UpDate
                                        WHERE usertype = 'developer' ";
                cmd.Parameters.AddWithValue("@UpDate", DateTime.Now);
                cmd.ExecuteNonQuery();


                cmd.Parameters.Clear();
                k.Dispose();

                File.Delete(file);
            }


        }
        #endregion

    }
}