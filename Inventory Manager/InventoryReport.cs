using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class InventoryReport : Form
    {
        #region essential_data
        //establish connection to the server
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        //holding data that will affect on the database
        private int id_value, barcode_value;
        private string name_value;

        public InventoryReport()
        {
            InitializeComponent();

            #region for DatePicker
            dateTimePickerStart.MaxDate = DateTime.Now.AddDays(-1);
            dateTimePickerEnd.MaxDate = DateTime.Now;
            #endregion

            #region For Shrotcuts
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
            #endregion
        }

        private void InventoryReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.InventoryReport' table. You can move, or remove it, as needed.
            this.inventoryReportTableAdapter1.Fill(this.testDataSet.InventoryReport);
            #region establish_Connection

            if (conn.State == ConnectionState.Open)
                conn.Close();

            conn.ConnectionString = ("Data Source=DESKTOP-CM5BM88;Initial Catalog=Public;Integrated Security=True;Encrypt=False;");
            ShowData();
            #endregion

            #region For ORM(auto Complete)

            var t1 = new Thread(() =>
            {
                using (var db = new PublicEntities1())
                {
                    var products = db.Product.ToList();

                    var AutoCompleteProductId = new AutoCompleteStringCollection();
                    var AutoCompleteProductBarcode = new AutoCompleteStringCollection();
                    var AutoCompleteProductName = new AutoCompleteStringCollection();

                    foreach (Product p in products)
                    {
                        AutoCompleteProductId.Add(p.id.ToString());
                        AutoCompleteProductBarcode.Add(p.barcode.ToString());
                        AutoCompleteProductName.Add(p.name);
                    }

                    if (product_id_text_box.IsHandleCreated)
                    {
                        if (product_id_text_box.InvokeRequired)
                        {
                            product_id_text_box.Invoke(new Action(() =>
                            {
                                product_id_text_box.AutoCompleteCustomSource = AutoCompleteProductId;
                            }));
                        }
                        else
                        {
                            product_id_text_box.AutoCompleteCustomSource = AutoCompleteProductId;
                        }
                    }

                    if (product_name_text_box.IsHandleCreated)
                    {
                        if (product_name_text_box.InvokeRequired)
                        {
                            product_name_text_box.Invoke(new Action(() =>
                            {
                                product_name_text_box.AutoCompleteCustomSource = AutoCompleteProductName;
                            }));
                        }
                        else
                        {
                            product_name_text_box.AutoCompleteCustomSource = AutoCompleteProductName;
                        }
                    }
                    if (product_barcode_text_box.IsHandleCreated)
                    {
                        if (product_name_text_box.InvokeRequired)
                        {
                            product_barcode_text_box.Invoke(new Action(() =>
                            {
                                product_barcode_text_box.AutoCompleteCustomSource = AutoCompleteProductBarcode;
                            }));
                        }
                        else
                        {
                            product_barcode_text_box.AutoCompleteCustomSource = AutoCompleteProductBarcode;
                        }
                    }
                }
            });

            t1.Start();
            #endregion

        }

        #endregion

        #region startup_functions
        private void Open_Connection_If_Was_Closed()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
        }

        //Update the data of customer's table
        public void ShowData()
        {
            Open_Connection_If_Was_Closed();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM InventoryReport";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        //Shortcuts for window
        private void KeysShortcuts(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F) //make full screen
            {
                if (this.FormBorderStyle == FormBorderStyle.None)
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Normal;
                    this.Location = new System.Drawing.Point(0, 0);
                    this.Size = Screen.PrimaryScreen.Bounds.Size;
                }
                return;
            }

            if (e.Control && e.KeyCode == Keys.E) //exit
            {
                this.Close();
                return;
            }

            if (e.Control && e.KeyCode == Keys.M) //minimize
            {
                this.WindowState = FormWindowState.Minimized;
                return;
            }

            if (e.Control && e.KeyCode == Keys.P) //print excel file
            {
                exportbtn_Click(sender, e);
                return;
            }

            if (e.Control && e.KeyCode == Keys.I) // show information about the devleoper
            {
                ShowToast("The Developer: Muhammad Malek Alset");
                return;
            }
        }

        //showing a message as a toast
        private void ShowToast(string message)
        {
            ToolTip toast = new ToolTip();
            int screenWidth = Screen.PrimaryScreen.Bounds.Width,
            screenHeight = Screen.PrimaryScreen.Bounds.Height,
            toastWidth = 300,
            toastHeight = 50,
            x = (screenWidth - toastWidth) / 2,
            y = screenHeight - toastHeight - 75;
            toast.Show(message, this, x, y, 1500);
        }


        #endregion

        #region Functions_For_Events
        void SearchCommand(string command, SqlCommand objCmd)
        {
            if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
            {
                MessageBox.Show("Starting date should not be after ending date");
                dateTimePickerStart.Value = dateTimePickerEnd.Value.AddDays(-1);
                return;
            }

            cmd = conn.CreateCommand();
            cmd.CommandText = command;
            cmd.Parameters.AddWithValue("@StartDate", dateTimePickerStart.Value);
            cmd.Parameters.AddWithValue("@EndDate", dateTimePickerEnd.Value);
            cmd.Parameters.AddWithValue("@id", id_value + "%");
            cmd.Parameters.AddWithValue("@barcode", barcode_value + "%");
            cmd.Parameters.AddWithValue("@name", "%" + name_value + "%");
            cmd.ExecuteNonQuery();
            ShowDataSearching(objCmd);
            cmd.Parameters.Clear();
            cmd.Dispose();
        }

        void ShowDataSearching(SqlCommand objCmd)
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        #endregion

        #region buttons

        #region Reset_Filter_button
        private void searchBtn_Click(object sender, EventArgs e)
        {
            product_id_text_box.Text =
            product_barcode_text_box.Text =
            product_name_text_box.Text = "";

            var command = $@"SELECT  id , barcode , name , SUM(quantity) AS quantity , CAST (@EndDate as date) as date
                                      FROM InventoryReport
                                      WHERE date 
                                      BETWEEN @StartDate
                                      AND @EndDate
                                      GROUP BY  id , barcode , name
                                      ORDER BY barcode";
            SearchCommand(command, cmd);
        }
        #endregion

        #region Export_button
        private void exportbtn_Click(object sender, EventArgs e)
        {
            DataTable dataTable = dataGridView1.DataSource as DataTable;

            if (dataTable != null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {

                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Save an Excel File";
                    saveFileDialog.FileName = "Inventory Report.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            workbook.Properties.Author = "Muhammad Malek Alset";
                            workbook.Properties.Manager = "Mansour Alset & Waseem Alshmaa";
                            workbook.Properties.Category = "Reports";
                            workbook.Properties.Title = $"Inventory Report";
                            workbook.Properties.Comments = $@"Report:
from: {dateTimePickerStart.Value.ToShortDateString()}
to: {dateTimePickerEnd.Value.ToShortDateString()} ";
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
        #endregion

        #endregion

        #region autocomplete textbox Functions

        #region complete for id
        private void product_id_text_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (PublicEntities1 db = new PublicEntities1())
                {
                    productBindingSource.DataSource = db.Product.Where(p => p.id.ToString().Contains(product_id_text_box.Text)).ToList();
                }
            }
        }
        #endregion

        #region complete for name
        private void product_name_text_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (PublicEntities1 db = new PublicEntities1())
                {
                    productBindingSource.DataSource = db.Product.Where(p => p.name.Contains(product_name_text_box.Text)).ToList();
                }
            }
        }
        #endregion

        #endregion

        #region Events_For_Searching
        private void product_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            var command = $@"SELECT  id , barcode , name , SUM(quantity) AS quantity , CAST (@EndDate as date) as date
                                        FROM InventoryReport
                                        WHERE date 
                                        BETWEEN @StartDate
                                        AND @EndDate
                                        AND name LIKE @name
                                        GROUP BY  id , barcode , name
                                        ORDER BY barcode";
            name_value = product_name_text_box.Text;

            SearchCommand(command, cmd);
        }

        private void product_barcode_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            if (int.TryParse("0" + product_barcode_text_box.Text, out barcode_value) && barcode_value >= 0)
            {
                var command = $@"SELECT  id , barcode , name , SUM(quantity) AS quantity , CAST (@EndDate as date) as date
                                             FROM InventoryReport
                                             WHERE date 
                                             BETWEEN @StartDate
                                             AND @EndDate 
                                             AND barcode LIKE @barcode
                                             GROUP BY  id , barcode , name
                                             ORDER BY barcode";
                SearchCommand(command, cmd);
            }
            else
            {
                MessageBox.Show("Enter a valid value for barcode");
                product_barcode_text_box.Text = "0";
                return;
            }
        }

        private void product_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            if (int.TryParse("0" + product_id_text_box.Text, out id_value) && id_value >= 0)
            {
                var command = $@"SELECT  id , barcode , name , SUM(quantity) AS quantity , CAST (@EndDate as date) as date
                                             FROM InventoryReport
                                             WHERE date 
                                             BETWEEN @StartDate
                                             AND @EndDate 
                                             AND id LIKE @id
                                             GROUP BY  id , barcode , name
                                             ORDER BY barcode";
                SearchCommand(command, cmd);
            }
            else
            {
                MessageBox.Show("Enter a valid value for id");
                product_id_text_box.Text = "0";
                return;
            }
        }

        #endregion

        #region entities
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e) { }
        private void product_name_text_box_TextChanged(object sender, EventArgs e) { }
        private void product_id_text_box_TextChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void product_barcode_text_box_TextChanged(object sender, EventArgs e) { }
        private void product_name_text_box_KeyDown(object sender, KeyPressEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void product_name_text_box_KeyPressed(object sender, KeyPressEventArgs e) { }
        #endregion

    }
}
