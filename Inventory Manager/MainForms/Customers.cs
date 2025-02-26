using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Customers : Form
    {
        #region essential_data
        public Customers()
        {
            InitializeComponent();
            Shared.ConnectionInitializer();
            this.customerTableAdapter.Connection.ConnectionString = Shared.conn.ConnectionString;
            this.NoticeLabel.Text = Shared.NoticeModifier("customer");
        }
        private void Customer_Load(object sender, EventArgs e)
        {
            this.customerTableAdapter.Fill(this.customerDataSet.Customer);
            ShowData();
        }
        #endregion

        #region Startup Functions

        //Update the data of customer's table
        public void ShowData()
        {
            Shared.ShowAllTableData(CustomerDataGridView, "customer", "id");
        }
        #endregion

        #region buttons

        #region save_button
        private void saveBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var add = new AddNewCustomer(this);
            add.Show();
        }
        #endregion

        #region update_button
        private void updateBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var add = new EditCustomer(this);
            add.Show();
        }
        #endregion

        #region delete_button
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

        #region Events For Searching

        private void customer_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(CustomerDataGridView, customer_id_text_box, "Customer", "id", "ID" , false , "customer id");
        }

        private void customer_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(CustomerDataGridView, customer_name_text_box, "Customer", "name", "ID");
        }

        #endregion

        #region Click on a cell
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            customer_id_text_box.Text = customer_name_text_box.Text = "";
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
    }
}
