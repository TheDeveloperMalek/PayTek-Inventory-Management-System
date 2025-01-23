using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class InventoryReport : Form
    {
        #region essential_data

        public InventoryReport()
        {
            InitializeComponent();
            Shared.ConnectionInitializer();
            this.inventoryReportTableAdapter.Connection.ConnectionString = Shared.conn.ConnectionString;

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
            this.inventoryReportTableAdapter.Fill(this.inventoryReportDataSet.InventoryReport);
            ShowData();
            Shared.AutoCompleteForTextBox("Product", "ID", product_id_text_box);
            Shared.AutoCompleteForTextBox("Product", "Barcode", product_barcode_text_box);
            Shared.AutoCompleteForTextBox("Product", "Name", product_name_text_box);
        }

        #endregion

        #region Startup Functions


        //Update the data of customer's table
        public void ShowData()
        {
            Shared.ShowAllData(dataGridView1, "InventoryReport", "Product ID");
        }

        //Shortcuts for window
        private void KeysShortcuts(object sender, KeyEventArgs e)
        {
            Shared.KeysShortcuts(sender, e, this);
            if (e.Control && e.KeyCode == Keys.P) //print
            {
                exportbtn_Click(sender, e);
                return;
            }
        }

        #endregion

        #region buttons

        #region Reset_Filter_button
        private void searchBtn_Click(object sender, EventArgs e)
        {
            product_id_text_box.Text =
            product_barcode_text_box.Text =
            product_name_text_box.Text = "";
            ShowData();
        }
        #endregion

        #region Export_button
        private void exportbtn_Click(object sender, EventArgs e)
        {
            Shared.SaveDataGridViewASExcelFile("Inventory Report", dataGridView1, dateTimePickerStart, dateTimePickerEnd);
        }
        #endregion

        #endregion

        #region Events_For_Searching
        private void product_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandWitDateAssembler(dataGridView1, product_name_text_box, "InventoryReport", "Product Name", "Product ID", dateTimePickerStart, dateTimePickerEnd, ProductReport: false);
        }

        private void product_barcode_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandWitDateAssembler(dataGridView1, product_barcode_text_box, "InventoryReport", "Product Barcode", "Product ID", dateTimePickerStart, dateTimePickerEnd, false, "product barcode", ProductReport: false);
        }
        private void product_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandWitDateAssembler(dataGridView1, product_id_text_box, "InventoryReport", "Product ID", "Product ID", dateTimePickerStart, dateTimePickerEnd, false, "product id", ProductReport: false);
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            Shared.ShowAllInventoryReportDataWithDate(dataGridView1 , "Product ID" , dateTimePickerStart , dateTimePickerEnd );
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            Shared.ShowAllInventoryReportDataWithDate(dataGridView1, "Product ID", dateTimePickerStart, dateTimePickerEnd);
        }

        #endregion

        #region Click on a cell
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            product_id_text_box.Text =
            product_barcode_text_box.Text =
            product_name_text_box.Text = "";

            var text = dataGridView1.CurrentCell.Value.ToString();
            var columnIndex = dataGridView1.CurrentCellAddress.X;
            var rowIndex = dataGridView1.CurrentCellAddress.Y;
            var c = new KeyEventArgs(Keys.NoName);

            switch (columnIndex)
            {
                case 0:
                    product_id_text_box.Text = text;
                    product_id_text_box_KeyUp(sender, c);
                    break;
                case 1:
                    product_barcode_text_box.Text = text;
                    product_barcode_text_box_KeyUp(sender, c);
                    break;
                case 2:
                    product_name_text_box.Text = text;
                    product_name_text_box_KeyUp(sender, c);
                    break;
            }
        }
        #endregion
    }
}