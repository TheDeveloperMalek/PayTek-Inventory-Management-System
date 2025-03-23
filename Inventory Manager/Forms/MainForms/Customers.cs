using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Customers : Form
    {
        #region Essential Data
        public Customers()
        {
            InitializeComponent();
            Shared.ConnectionInitializer();
            this.customerTableAdapter.Connection.ConnectionString = Shared.conn.ConnectionString;
        }
        private void Customer_Load(object sender, EventArgs e)
        {
            this.customerTableAdapter.Fill(this.customerDataSet.Customer);
            ShowData();
        }
        #endregion

        #region Startup Functions
        public void ShowData()
        {
            Shared.ShowAllTableData(CustomerDataGridView, "customer", "id");
        }
        #endregion

        #region Events
        #region Button Click

        #region Add Button
        private void saveBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var add = new AddNewCustomer(this);
            add.Show();
        }
        #endregion

        #region Edit Button
        private void updateBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var add = new EditCustomer(this);
            add.Show();
        }
        #endregion

        #region Delete Button
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var delete = new DeleteCustomer(this);
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

        private void customer_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(CustomerDataGridView, customer_id_text_box, "Customer", "id", "ID" , false , "customer id");
        }

        private void customer_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(CustomerDataGridView, customer_name_text_box, "Customer", "name", "ID");
        }

        #endregion

        #region Cell Click
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ResetFields(groupBox1);
            var text = CustomerDataGridView.CurrentCell.Value.ToString();
            var columnIndex = CustomerDataGridView.CurrentCellAddress.X;
            var c = new KeyEventArgs(Keys.NoName);

            switch (columnIndex)
            {
                case 0:
                    customer_id_text_box.Text = text;
                    customer_id_text_box_KeyUp(sender, c);
                    break;
                case 1:
                   customer_name_text_box.Text = text;
                    customer_name_text_box_KeyUp(sender, c);
                    break;
            }
        }
        #endregion
        #endregion

    }
}
