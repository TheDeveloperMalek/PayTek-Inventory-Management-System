using System;
using System.Windows.Forms;

namespace Inventory_Manager
{

    public partial class Sales : Form
    {
        #region Essential Data
        public static readonly string status = "Sale";

        public Sales()
        {
            InitializeComponent();
            Shared.ConnectionInitializer();
            this.saleTableAdapter.Connection.ConnectionString = Shared.conn.ConnectionString;
            this.dataGridView1.Columns[7].Visible = printBillBtn.Visible = Shared.isJustVisibleForNonUserType;
            dateTimePickerEnd.Value = DateTime.Now;
            dateTimePickerStart.Value = DateTime.Now.AddMonths(-5);

            #region DatePicker Set
            dateTimePickerStart.MaxDate = DateTime.Now.AddDays(-1);
            dateTimePickerEnd.MaxDate = DateTime.Now;
            #endregion
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            this.saleTableAdapter.Fill(this.saleDataSet.Sale);
            ShowData();
            Shared.TextBoxAutoCompleteFromColumn("Product", "ID", ProductIDTextBox);
            Shared.TextBoxAutoCompleteFromColumn("Product", "Barcode", ProductBarcodeTextBox);
            Shared.TextBoxAutoCompleteFromColumn("Product", "Name", ProductNameTextBox);
            Shared.TextBoxAutoCompleteFromColumn("Customer", "ID", CustomerIDTextBox);
            Shared.TextBoxAutoCompleteFromColumn("Customer", "Name", CustomerNameTextBox);
            Shared.TextBoxAutoCompleteFromColumn("Sale", "ID", SaleIDTextBox);
        }
        #endregion

        #region Startup Functions
        public void ShowData()
        {
            Shared.ShowAllTableData(dataGridView1, "Sale", "ID", startDate: dateTimePickerStart, endDate: dateTimePickerEnd);
        }

        #endregion

        #region Events
        #region Click Button

        #region Add Button
        private void saveBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var add = new AddNewSale(this);
            add.Show();
        }
        #endregion

        #region Update Button
        private void updateBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var edit = new EditSale(this);
            edit.Show();
        }
        #endregion

        #region Reset Button
        private void searchBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ResetFields(groupBox1);
            ShowData();
        }
        #endregion

        #region Delete Button
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var d = new DeleteSale(this);
            d.Show();
        }
        #endregion

        #region PDF Button
        private void pdfButton_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.printSale(dataGridView1 , "فاتورة");
        }

        #endregion

        #endregion

        #region Searching

        private void Sale_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, SaleIDTextBox, "Sale", "ID", "ID", false, "sale id", startDate: dateTimePickerStart.Value, endDate: dateTimePickerEnd.Value);
        }

        private void product_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, ProductNameTextBox, "Sale", "Product Name", "ID", startDate: dateTimePickerStart.Value, endDate: dateTimePickerEnd.Value);
        }

        private void product_barcode_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, ProductBarcodeTextBox, "Sale", "Product Barcode", "ID", false, "product barcode", startDate: dateTimePickerStart.Value, endDate: dateTimePickerEnd.Value);
        }

        private void product_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, ProductIDTextBox, "Sale", "Product ID", "ID", false, "product id", startDate: dateTimePickerStart.Value, endDate: dateTimePickerEnd.Value);
        }

        private void product_quantity_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, ProductQuantityTextBox, "Sale", "Quantity", "ID", false, "quantity", startDate: dateTimePickerStart.Value, endDate: dateTimePickerEnd.Value);
        }

        private void customer_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, CustomerNameTextBox, "Sale", "Customer Name", "ID", startDate: dateTimePickerStart.Value, endDate: dateTimePickerEnd.Value);
        }

        private void customer_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, CustomerIDTextBox, "Sale", "Customer ID", "ID", false, "customer id", startDate: dateTimePickerStart.Value, endDate: dateTimePickerEnd.Value);
        }

        #endregion

        #region Cell Click
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ResetFields(groupBox1);
            var text = dataGridView1.CurrentCell.Value.ToString();
            var columnIndex = dataGridView1.CurrentCellAddress.X;
            var c = new KeyEventArgs(Keys.NoName);

            switch (columnIndex)
            {
                case 0:
                    SaleIDTextBox.Text = text;
                    Sale_id_text_box_KeyUp(sender, c);
                    break;
                case 1:
                    CustomerIDTextBox.Text = text;
                    customer_id_text_box_KeyUp(sender, c);
                    break;
                case 2:
                    CustomerNameTextBox.Text = text;
                    customer_name_text_box_KeyUp(sender, c);
                    break;
                case 3:
                    ProductIDTextBox.Text = text;
                    product_id_text_box_KeyUp(sender, c);
                    break;
                case 4:
                    ProductBarcodeTextBox.Text = text;
                    product_barcode_text_box_KeyUp(sender, c);
                    break;
                case 5:
                    ProductNameTextBox.Text = text;
                    product_name_text_box_KeyUp(sender, c);
                    break;
                case 6:
                    ProductQuantityTextBox.Text = text;
                    product_quantity_text_box_KeyUp(sender, c);
                    break;
            }
        }

        #endregion

        #region ChangeDate
        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            Shared.ShowAllTableData(dataGridView1, "Sale", "ID", startDate: dateTimePickerStart, endDate: dateTimePickerEnd);
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            Shared.ShowAllTableData(dataGridView1, "Sale", "ID", startDate: dateTimePickerStart, endDate: dateTimePickerEnd);
        }
        #endregion
        #endregion
    }
}