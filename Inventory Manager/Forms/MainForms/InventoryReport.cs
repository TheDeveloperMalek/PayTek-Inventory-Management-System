using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class InventoryReport : Form
    {
        #region Essential Data

        public InventoryReport()
        {
            InitializeComponent();
            Shared.ConnectionInitializer();
            this.inventoryReportTableAdapter.Connection.ConnectionString = Shared.conn.ConnectionString;
            FinishingDateTimePicker.Value = DateTime.Now;
            BeginningDateTimePicker.Value = DateTime.Now.AddMonths(-5);

            #region DataPicker Set
            BeginningDateTimePicker.MaxDate = DateTime.Now.AddDays(-1);
            FinishingDateTimePicker.MaxDate = DateTime.Now;
            #endregion

        }

        private void InventoryReport_Load(object sender, EventArgs e)
        {
            this.inventoryReportTableAdapter.Fill(this.inventoryReportDataSet.InventoryReport);
            ShowData();
            Shared.TextBoxAutoCompleteFromColumn("Product", "ID", ProductIdTextBox);
            Shared.TextBoxAutoCompleteFromColumn("Product", "Barcode", ProductBarcodeTextBox);
            Shared.TextBoxAutoCompleteFromColumn("Product", "Name", ProductNameTextBox);
        }

        #endregion

        #region Startup Functions
        public void ShowData()
        {
            Shared.ShowAllInventoryReportTableDataWithDate(InventoryReportDataGridView, "Product ID", BeginningDateTimePicker, FinishingDateTimePicker);
        }

        #endregion

        #region Events
        #region Button Click

        #region Reset Button
        private void searchBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ResetFields(groupBox1);
            ShowData();
        }
        #endregion

        #region Export Button
        private void exportbtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.SaveDataGridViewASExcelFile("Inventory Report", InventoryReportDataGridView, BeginningDateTimePicker, FinishingDateTimePicker);
        }
        #endregion

        #endregion

        #region Searching
        private void product_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandWitDateAssembler(InventoryReportDataGridView, ProductNameTextBox, "InventoryReport", "Product Name", "Product ID", BeginningDateTimePicker, FinishingDateTimePicker, ProductReport: false);
        }

        private void product_barcode_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandWitDateAssembler(InventoryReportDataGridView, ProductBarcodeTextBox, "InventoryReport", "Product Barcode", "Product ID", BeginningDateTimePicker, FinishingDateTimePicker, false, "product barcode", ProductReport: false);
        }
        private void product_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandWitDateAssembler(InventoryReportDataGridView, ProductIdTextBox, "InventoryReport", "Product ID", "Product ID", BeginningDateTimePicker, FinishingDateTimePicker, false, "product id", ProductReport: false);
        }
        private void BeginningDateTimePicker_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ShowAllInventoryReportTableDataWithDate(InventoryReportDataGridView , "Product ID" , BeginningDateTimePicker , FinishingDateTimePicker );

        }

        private void FinishingDateTimePicker_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ShowAllInventoryReportTableDataWithDate(InventoryReportDataGridView, "Product ID", BeginningDateTimePicker, FinishingDateTimePicker);
        }
        #endregion

        #region Cell Click
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ResetFields(groupBox1);

            var text = InventoryReportDataGridView.CurrentCell.Value.ToString();
            var columnIndex = InventoryReportDataGridView.CurrentCellAddress.X;
            var rowIndex = InventoryReportDataGridView.CurrentCellAddress.Y;
            var c = new KeyEventArgs(Keys.NoName);

            switch (columnIndex)
            {
                case 0:
                    ProductIdTextBox.Text = text;
                    product_id_text_box_KeyUp(sender, c);
                    break;
                case 1:
                    ProductBarcodeTextBox.Text = text;
                    product_barcode_text_box_KeyUp(sender, c);
                    break;
                case 2:
                    ProductNameTextBox.Text = text;
                    product_name_text_box_KeyUp(sender, c);
                    break;
            }
        }
        #endregion

        #endregion
    }
}