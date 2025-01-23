using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class ProductsReport : Form
    {
        #region essential_data
        public ProductsReport()
        {
            InitializeComponent();
            Shared.ConnectionInitializer();
            this.productReportTableAdapter.Connection.ConnectionString = Shared.conn.ConnectionString;

            #region For DatePicker
            dateTimePickerStart.MaxDate = DateTime.Now.AddDays(-1);
            dateTimePickerEnd.MaxDate = DateTime.Now;
            #endregion

            #region For Shortcuts
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
            #endregion
        }

        private void ProductsReport_Load(object sender, EventArgs e)
        {
            this.productReportTableAdapter.Fill(this.productReportDataSet.ProductReport);
            ShowData();
            Shared.AutoCompleteForTextBox("Product", "ID", product_id_text_box);
            Shared.AutoCompleteForTextBox("Product", "Barcode", product_barcode_text_box);
            Shared.AutoCompleteForTextBox("Product", "Name", product_name_text_box);
        }

        #endregion

        #region startup_functions
        //Update the data of customer's table
        public void ShowData()
        {
            Shared.ShowAllData(dataGridView2, "ProductReport", "Product ID");
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

        #region export_button
        private void exportbtn_Click(object sender, EventArgs e)
        {
            Shared.SaveDataGridViewASExcelFile("Products Report" , dataGridView2 , dateTimePickerStart , dateTimePickerEnd);
        }
        #endregion

        #region Reset_Filter_button
        private void searchBtn_Click_1(object sender, EventArgs e)
        {
            product_id_text_box.Text =
            product_barcode_text_box.Text =
            product_name_text_box.Text = "";
            ShowData();
        }
        #endregion

        #endregion

        #region Events For Searching
        private void product_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandWitDateAssembler(dataGridView2 , product_name_text_box , "ProductReport" , "Product Name" , "Product ID" , dateTimePickerStart , dateTimePickerEnd);
        }

        private void product_barcode_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandWitDateAssembler(dataGridView2, product_barcode_text_box, "ProductReport", "Product Barcode", "Product ID" , dateTimePickerStart, dateTimePickerEnd  , false , "product barcode");
        }
        private void product_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandWitDateAssembler(dataGridView2, product_id_text_box, "ProductReport", "Product ID", "Product ID", dateTimePickerStart, dateTimePickerEnd , false , "product id");
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            Shared.ShowAllProductReportDataWithDate(dataGridView2, "Product ID", dateTimePickerStart, dateTimePickerEnd);
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            Shared.ShowAllProductReportDataWithDate(dataGridView2, "Product ID", dateTimePickerStart, dateTimePickerEnd);
        }

        #endregion

    }
}