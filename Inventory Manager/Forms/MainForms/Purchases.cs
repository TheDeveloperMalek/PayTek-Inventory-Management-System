using System;
using System.Windows.Forms;

namespace Inventory_Manager
{

    public partial class Purchases : Form
    {
        #region Essential Data

        public static readonly string status = "Purchase";

        public Purchases()
        {
            InitializeComponent();
            Shared.ConnectionInitializer();
            this.purchaseTableAdapter.Connection.ConnectionString = Shared.conn.ConnectionString;
            this.dataGridView1.Columns[7].Visible = Shared.isJustVisibleForNonUserType;
        }

        private void Purchases_Load(object sender, EventArgs e)
        {
            this.purchaseTableAdapter.Fill(this.purchaseDataSet.Purchase);
            ShowData();
            Shared.TextBoxAutoCompleteFromColumn("Product" , "ID" , product_id_text_box);
            Shared.TextBoxAutoCompleteFromColumn("Product" , "Barcode" , product_barcode_text_box);
            Shared.TextBoxAutoCompleteFromColumn("Product" , "Name" , product_name_text_box);
            Shared.TextBoxAutoCompleteFromColumn("Supplier" , "ID" , supplier_id_text_box);
            Shared.TextBoxAutoCompleteFromColumn("Supplier" , "Name" , supplier_name_text_box);
            Shared.TextBoxAutoCompleteFromColumn("Purchase" ,"ID"  , purchase_id_text_box);
        }
        #endregion

        #region Startup Functions
        public void ShowData()
        {
            Shared.ShowAllTableData(dataGridView1, "Purchase", "ID");
        }

        #endregion

        #region Events
        #region Button Click

        #region Add Button
        private void saveBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var add = new AddNewPurchase(this);
            add.Show();
        }
        #endregion

        #region Edit Button
        private void updateBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var edit = new EditPurchase(this);
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
            var delete = new DeletePurchase(this);
            delete.Show();
        }
        #endregion

        #endregion

        #region Searching

        private void purchase_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, purchase_id_text_box, "Purchase", "ID", "ID", false, "purchase id");
        }

        private void product_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, product_name_text_box, "Purchase", "Product Name", "ID");
        }

        private void product_barcode_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, product_barcode_text_box, "Purchase", "Product Barcode", "ID", false, "product barcode");
        }

        private void product_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, product_id_text_box, "Purchase", "Product ID", "ID", false, "product id");
        }

        private void product_quantity_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, product_quantity_text_box, "Purchase", "Quantity", "ID", false, "quantity");
        }

        private void supplier_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, supplier_name_text_box, "Purchase", "Supplier Name", "ID");
        }

        private void supplier_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, supplier_id_text_box, "Purchase", "Supplier ID", "ID", false, "supplier id");
        }


        #endregion

        #region Cell Click
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ResetFields(groupBox1);
            var text = dataGridView1.CurrentCell.Value.ToString();
            var columnIndex = dataGridView1.CurrentCellAddress.X;
            var rowIndex = dataGridView1.CurrentCellAddress.Y;
            var c = new KeyEventArgs(Keys.NoName);

            switch (columnIndex)
            {
                case 0:
                    purchase_id_text_box.Text = text;
                    purchase_id_text_box_KeyUp(sender, c);
                    break;
                case 1:
                    supplier_id_text_box.Text = text;
                    supplier_id_text_box_KeyUp(sender, c);
                    break;
                case 2:
                    supplier_name_text_box.Text = text;
                    supplier_name_text_box_KeyUp(sender, c);
                    break;
                case 3:
                    product_id_text_box.Text = text;
                    product_id_text_box_KeyUp(sender, c);
                    break;
                case 4:
                    product_barcode_text_box.Text = text;
                    product_barcode_text_box_KeyUp(sender, c);
                    break;
                case 5:
                    product_name_text_box.Text = text;
                    product_name_text_box_KeyUp(sender, c);
                    break;
                case 6:
                    product_quantity_text_box.Text = text;
                    product_quantity_text_box_KeyUp(sender, c);
                    break;
            }
        }
        #endregion
        #endregion

    }
}