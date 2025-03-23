using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Suppliers : Form
    {
        #region Essential Data

        public Suppliers()
        {
            InitializeComponent();
            Shared.ConnectionInitializer();
            this.supplierTableAdapter.Connection.ConnectionString = Shared.conn.ConnectionString;
        }
        private void Supplier_Load(object sender, EventArgs e)
        {
            this.supplierTableAdapter.Fill(this.supplierDataSet.Supplier);
            ShowData();
        }
        #endregion

        #region Startup Functions
        public void ShowData()
        {
            Shared.ShowAllTableData(dataGridView1, "supplier", "id");
        }
        #endregion

        #region Events
        #region Click Button

        #region Add Button
        private void saveBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var add = new AddNewSupplier(this);
            add.Show();
        }
        #endregion

        #region Edit Button
        private void updateBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var edit = new EditSupplier(this);
            edit.Show();

        }
        #endregion

        #region Delete Button
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var delete = new DeleteSupplier(this);
            delete.Show();
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

        #endregion

        #region Searching

        private void supplier_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, supplierIdTextBox, "Supplier", "id", "ID", false, "supplier id");
        }

        private void supplier_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, supplierNameTextBox, "Supplier", "name", "ID");
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
                    supplierIdTextBox.Text = text;
                    supplier_id_text_box_KeyUp(sender, c);
                    break;
                case 1:
                    supplierNameTextBox.Text = text;
                    supplier_name_text_box_KeyUp(sender, c);
                    break;
            }
        }
        #endregion
        #endregion
    }
}
