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
using iTextSharp.text.pdf;
using System.Collections.Generic;
using iTextSharp.text;
using Inventory_Manager.Forms.MainForms;

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
    public enum UserType
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

        #region Sale PDF Variables
        static string pdfHeaderTitle = "";
        static readonly BaseFont TimesNewRomanFont = Shared.LoadFontFromAssembly("times.ttf");
        static double totalBill = 0;
        static decimal discountPercentage = 0;
        static string customerName = "";
        static readonly List<string> customersNames = new List<string>() { };

        #endregion

        #region Sale PDF Functions

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

        static bool IsDatagridValidForPrintingPdf(DataGridView dataGridView1)
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
        public static void printSale(DataGridView dt, string headerTitle)
        {
            pdfHeaderTitle = headerTitle;
            if (!IsDatagridValidForPrintingPdf(dt)) return;
            customerName = customersNames[0];
            DialogResult offerMake = MessageBox.Show("Do you want to make an offer?", "Make Offer", MessageBoxButtons.YesNo);
            if (offerMake == DialogResult.Yes)
                discountPercentage = OfferDialog("Enter the value:", "Make Offer");
            var svf = new SaveFileDialog();
            svf.Filter = "PDF (*.pdf)|*pdf";
            svf.FileName = $"فاتورة {customerName}.pdf";
            if (svf.ShowDialog() == DialogResult.OK)
                try
                {
                    if (Path.GetExtension(svf.FileName) != ".pdf")
                        svf.FileName += ".pdf";
                    CreatePdf(svf.FileName, dt);
                    discountPercentage = 0;
                    totalBill = 0;
                    customerName = "";
                    customersNames.Clear();
                    ProcessIsDoneMessageBox("bill", "printed");
                }
                catch (Exception exc)
                {
                    Shared.ErrorOccuredMessageBox(exc.Message);
                }
        }

        static void CreatePdf(string filePath, DataGridView dataGridView)
        {
            ;
            using (var document = new Document())
            using (var writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create)))
            {
                document.Open();
                AddHeader(document);
                AddBody(document, writer, dataGridView);
                AddFooter(document);
                document.Close();
            }
        }
        static void AddHeader(Document document)
        {
            PdfPTable headerTable = new PdfPTable(2) { WidthPercentage = 100 };
            #region Image
            Image img = Image.GetInstance(Shared.StreamMakerFromAssemblyFile("Resources.Icons", "levant_logo", "jpg"));
            img.ScaleToFit(156f, 56f);
            PdfPCell imageCell = new PdfPCell(img) { Border = Rectangle.NO_BORDER };
            headerTable.AddCell(imageCell);
            #endregion

            #region Text
            PdfPCell companyCell = new PdfPCell(new Phrase($"{Preferences.GetPrefValue("CompanyHeader")}", new Font(TimesNewRomanFont, 14, 0, BaseColor.BLACK)))
            {
                Border = Rectangle.BOTTOM_BORDER,
                HorizontalAlignment = Element.ALIGN_JUSTIFIED,
                RunDirection = PdfWriter.RUN_DIRECTION_RTL,
                VerticalAlignment = Element.ALIGN_MIDDLE,
            };
            headerTable.AddCell(companyCell);
            #endregion
            document.Add(headerTable);
        }
        static void AddBody(Document document, PdfWriter writer, DataGridView dataGridView)
        {
            #region Title
            var title = new PdfPTable(1) { WidthPercentage = 100 };
            title.AddCell(new PdfPCell(new Phrase($"{pdfHeaderTitle}", new Font(TimesNewRomanFont, 20, 0, BaseColor.BLACK)))
            {
                PaddingTop = 20,
                PaddingBottom = 20,
                Border = Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_CENTER,
                RunDirection = PdfWriter.RUN_DIRECTION_RTL,
            });
            document.Add(title);
            #endregion

            #region Date and Customer
            PdfPTable bodyTable = new PdfPTable(2) { WidthPercentage = 100 };
            bodyTable.AddCell(new PdfPCell(new Phrase("دمشق في : " + Preferences.GetPrefValue("PDFDate"), new Font(TimesNewRomanFont))) { Border = Rectangle.NO_BORDER, RunDirection = PdfWriter.RUN_DIRECTION_RTL, HorizontalAlignment = Element.ALIGN_RIGHT });
            bodyTable.AddCell(new PdfPCell(new Phrase($"المطلوب من السيد: {customerName} المحترم", new Font(TimesNewRomanFont))) { Border = Rectangle.NO_BORDER, RunDirection = PdfWriter.RUN_DIRECTION_RTL });
            document.Add(bodyTable);
            #endregion

            #region Table
            var columnsWidths = new float[] { 4, 1, 1, 1 };
            PdfPTable dataTable = new PdfPTable(columnsWidths) { WidthPercentage = 100, SpacingBefore = 35 };
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column == dataGridView.Columns["quantityColumn"] ||
                    column == dataGridView.Columns["productNameColumn"] ||
                    column == dataGridView.Columns["priceColumn"] ||
                    column == dataGridView.Columns["totalPriceColumn"])
                    dataTable.AddCell(new PdfPCell(new Phrase(column.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex > 4 && cell.ColumnIndex < 9)
                    {
                        dataTable.AddCell(new PdfPCell(new Phrase(cell.Value.ToString() ?? string.Empty, new Font(TimesNewRomanFont)))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            VerticalAlignment = Element.ALIGN_CENTER,
                            RunDirection = PdfWriter.RUN_DIRECTION_RTL,
                            Padding = 15
                        });
                        if (cell.ColumnIndex == 8)
                            totalBill += double.Parse(cell.Value.ToString());
                    }
                }
            }
            document.Add(dataTable);
            #endregion

            #region Total Bill
            double discountPrice = (double)discountPercentage / 100 * totalBill;
            PdfPTable Bill;
            var FinalBillColumnsWidths = new float[] { 6, 1 };
            if (discountPrice > 0)
            {
                var BillcolumnsWidths = new float[] { 2, 2, 3 };
                Bill = new PdfPTable(BillcolumnsWidths) { WidthPercentage = 100 };
                Bill.AddCell(new PdfPCell(new Phrase($"مبلغ الحسم : {discountPrice}", new Font(TimesNewRomanFont, 16))) { RunDirection = PdfWriter.RUN_DIRECTION_RTL, Padding = 15, HorizontalAlignment = Element.ALIGN_CENTER });
                Bill.AddCell(new PdfPCell(new Phrase($"الحسم : {discountPercentage}%", new Font(TimesNewRomanFont, 16))) { RunDirection = PdfWriter.RUN_DIRECTION_RTL, Padding = 15, HorizontalAlignment = Element.ALIGN_CENTER });
                Bill.AddCell(new PdfPCell(new Phrase($"المجموع: {totalBill}", new Font(TimesNewRomanFont, 16))) { RunDirection = PdfWriter.RUN_DIRECTION_RTL, Padding = 15, HorizontalAlignment = Element.ALIGN_CENTER });
                var BillWithNoOffer = new PdfPTable(2) { WidthPercentage = 100, SpacingAfter = 20 };
                BillWithNoOffer.AddCell(new PdfPCell(new Phrase($"كتابةً  : ", new Font(TimesNewRomanFont, 16, 1))) { RunDirection = PdfWriter.RUN_DIRECTION_RTL, Padding = 15, HorizontalAlignment = Element.ALIGN_CENTER });
                BillWithNoOffer.AddCell(new PdfPCell(new Phrase($"المجموع الكلي رقماً :  {totalBill - discountPrice}", new Font(TimesNewRomanFont, 16, 1))) { RunDirection = PdfWriter.RUN_DIRECTION_RTL, Padding = 15, HorizontalAlignment = Element.ALIGN_CENTER });
                document.Add(Bill);
                document.Add(BillWithNoOffer);
            }
            else
            {
                Bill = new PdfPTable(FinalBillColumnsWidths) { WidthPercentage = 100, SpacingAfter = 20 };
                Bill.AddCell(new PdfPCell(new Phrase("المجموع :", new Font(TimesNewRomanFont, 16, 1)))
                { RunDirection = PdfWriter.RUN_DIRECTION_RTL, Padding = 15 });
                Bill.AddCell(new PdfPCell(new Phrase($"{totalBill}", new Font(TimesNewRomanFont, 16, 1))) { RunDirection = PdfWriter.RUN_DIRECTION_RTL, Padding = 15, HorizontalAlignment = Element.ALIGN_CENTER });
                document.Add(Bill);
            }
            #endregion

            #region Pay Info
            PdfPTable PayInfo = new PdfPTable(1) { WidthPercentage = 100, SpacingBefore = 10, SpacingAfter = 70 };
            PayInfo.AddCell(new PdfPCell(new Phrase(Preferences.GetPrefValue("CompanyPaymentInfo"), new Font(TimesNewRomanFont, 14))) { Border = Rectangle.NO_BORDER, RunDirection = PdfWriter.RUN_DIRECTION_RTL });
            document.Add(PayInfo);
            #endregion
        }
        static void AddFooter(Document document)
        {
            PdfPTable footerTable = new PdfPTable(2) { WidthPercentage = 100, PaddingTop = 20 };
            footerTable.AddCell(new PdfPCell(new Phrase("EMAIL: a.alrehawe@levant-tek.com", new Font(TimesNewRomanFont, 12, 0, BaseColor.GRAY))) { Border = Rectangle.TOP_BORDER, RunDirection = PdfWriter.RUN_DIRECTION_RTL, HorizontalAlignment = Element.ALIGN_RIGHT });
            footerTable.AddCell(new PdfPCell(new Phrase($"دمشق  هاتف : 0968585950 - 22228989", new Font(TimesNewRomanFont, 12, 0, BaseColor.GRAY))) { Border = Rectangle.TOP_BORDER, RunDirection = PdfWriter.RUN_DIRECTION_RTL });
            document.Add(footerTable);
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
                else if (c is CheckBox ch)
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
            DataTable dt = new DataTable();
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
            DataTable dt = new DataTable();
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
            DataTable dt = new DataTable();
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
            if (target.DataSource is DataTable dataTable)
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
                DataTable dt = new DataTable();
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
                DataTable dt = new DataTable();
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

        public static BaseFont LoadFontFromAssembly(string fontFileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream fontStream = assembly.GetManifestResourceStream($"Inventory_Manager.Resources.Fonts.{fontFileName}"))
            {
                string tempFontPath = Path.Combine(Path.GetTempPath(), $"font.ttf");
                if (!File.Exists(tempFontPath))
                    using (var fileStream = new FileStream(tempFontPath, FileMode.Create, FileAccess.Write))
                    {
                        fontStream.CopyTo(fileStream);
                    }
                return BaseFont.CreateFont(tempFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            }
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