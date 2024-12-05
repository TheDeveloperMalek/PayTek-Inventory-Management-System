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
        private int id_value , barcode_value;
        private string name_value;

        public InventoryReport()
        {
            InitializeComponent();

            #region for shrotcuts
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
            #endregion
        }

        private void InventoryReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.InventoryReport' table. You can move, or remove it, as needed.
            this.inventoryReportTableAdapter1.Fill(this.testDataSet.InventoryReport);
            #region establish_Connection
            conn.ConnectionString = ("Data Source=DESKTOP-CM5BM88;Initial Catalog=Public;Integrated Security=True;Encrypt=False;");
            if (conn.State != ConnectionState.Open)
            {
                ShowData();
                Open_Connection_If_Was_Closed();
            }
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
            cmd.CommandText = "SELECT * FROM InventoryReport ORDER BY date DESC";
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

        void QueryShow(string style)
        {
            {
                Open_Connection_If_Was_Closed();
                DateTime startDate = dateTimePickerStart.Value;
                DateTime endDate = dateTimePickerEnd.Value;

                cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM InventoryReport WHERE date BETWEEN @StartDate AND @EndDate ORDER BY date {style}";
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                if (product_name_text_box.Text != "")
                {
                    name_value = product_name_text_box.Text;
                    cmd.Parameters.AddWithValue("@name", "%" + name_value + "%");
                    cmd.CommandText = $"SELECT * FROM InventoryReport WHERE date BETWEEN @StartDate AND @EndDate AND name LIKE @name ORDER BY date {style}";
                }
                if (product_id_text_box.Text != "")
                {
                    if (!int.TryParse(product_id_text_box.Text, out id_value) || id_value < 0)
                    {
                        MessageBox.Show("Please enter a valid value for the id field");
                        return;
                    }
                    cmd.Parameters.AddWithValue("@id", id_value);
                    cmd.CommandText = $"SELECT * FROM InventoryReport WHERE date BETWEEN @StartDate AND @EndDate AND id = @id ORDER BY date {style}";
                }
                if (product_barcode_text_box.Text != "")
                {
                    if (!int.TryParse(product_barcode_text_box.Text, out barcode_value) || barcode_value < 0)
                    {
                        MessageBox.Show("Please enter a valid value for the id field");
                        return;
                    }
                    cmd.Parameters.AddWithValue("@barcode", barcode_value);
                    cmd.CommandText = $"SELECT * FROM InventoryReport WHERE date BETWEEN @StartDate AND @EndDate AND barcode = @barcode ORDER BY date {style}";
                }
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        #endregion

        #region buttons

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

        #region entities
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e) { }
        private void product_name_text_box_TextChanged(object sender, EventArgs e) { }
        private void product_id_text_box_TextChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void product_barcode_text_box_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e){ }
        #endregion

    }
}
