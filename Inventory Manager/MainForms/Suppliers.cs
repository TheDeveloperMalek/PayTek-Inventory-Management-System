using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Suppliers : Form
    {
        #region essential_data

        //holding data that will affect on the database
        private int id_value;
        private string name_value;

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
        //Update the data of customer's table
        public void ShowData()
        {
            Shared.ShowAllTableData(dataGridView1, "supplier", "id");
        }
        #endregion

        #region validation_functions
        //Check if the text boxes were empty
        private bool Chech_If_Text_Boxes_Were_Empty()
        {
            if (supplierIdTextBox.Text == "" || String.IsNullOrEmpty(supplierNameTextBox.Text))
            {
                if (supplierIdTextBox.Text == "")
                {
                    Shared.ErrorOccuredMessageBox("Please Enter Id ");
                    return true;
                }
                if (String.IsNullOrEmpty(supplierNameTextBox.Text))
                {
                    Shared.ErrorOccuredMessageBox("Please Enter name of the supplier");
                    return true;
                }
            }
            return false;
        }

        //Check the validity of user input
        public bool Validation_of_input()
        {
            Shared.ConnectionInitializer();
            if (!Chech_If_Text_Boxes_Were_Empty())
            {
                name_value = supplierNameTextBox.Text;
                if (!int.TryParse(supplierIdTextBox.Text, out id_value) || id_value < 0)
                {
                    Shared.ErrorOccuredMessageBox("Please enter a valid value for the id field");
                    return false;
                }
                return true;
            }
            return false;
        }
        //At least requriements to update or delete records
        public bool At_Least_Input_Requriements()
        {
            if (supplierIdTextBox.Text == "" && supplierNameTextBox.Text == "")
            {
                Shared.ErrorOccuredMessageBox("Please type a name or an id at least to perform this action");
                return false;
            }
            if (!int.TryParse(supplierIdTextBox.Text, out id_value) && supplierNameTextBox.Text == "")
            {
                Shared.ErrorOccuredMessageBox("Please enter a valid value for the id field");
                return false;
            }
            name_value = supplierNameTextBox.Text;
            return true;
        }
        //At least requriements to update or delete records
        public bool At_Least_Input_Name()
        {
            if (supplierNameTextBox.Text == "")
            {
                Shared.ErrorOccuredMessageBox("Please type a name at least to add new supplier");
                return false;
            }
            name_value = supplierNameTextBox.Text;
            return true;
        }

        //Chech if the current customer exists or not
        private bool Check_If_Supplier_Already_Exists()
        {
            string checkQuery = "SELECT COUNT(*) FROM Supplier WHERE name = @name OR  id = @id";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, Shared.conn))
            {
                checkCmd.Parameters.AddWithValue("@id", id_value);
                checkCmd.Parameters.AddWithValue("@name", name_value);

                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);

                if (productCount > 0)
                {
                    return true;
                }
                return false;
            }
        }

        //Chech if the current customer exists or not
        private bool Check_If_Supplier_Name_Already_Exists()
        {
            string checkQuery = "SELECT COUNT(*) FROM Supplier WHERE name = @name";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, Shared.conn))
            {
                checkCmd.Parameters.AddWithValue("@name", name_value);

                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);

                if (productCount > 0)
                {
                    return true;
                }
                return false;
            }
        }

        private bool Check_If_SupplierId_Already_Exists()
        {
            string checkQuery = "SELECT COUNT(*) FROM Supplier WHERE id = @id";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, Shared.conn))
            {
                checkCmd.Parameters.AddWithValue("@id", id_value);

                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);

                if (productCount > 0)
                {
                    return true;
                }
                return false;
            }
        }
        #endregion

        #region buttons

        #region save_button
        private void saveBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var add = new AddNewSupplier(this);
            add.Show();
        }
        #endregion

        #region update_button
        private void updateBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var edit = new EditSupplier(this);
            edit.Show();

        }
        #endregion

        #region delete_button
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var delete = new DeleteSupplier(this);
            delete.Show();
        }
        #endregion

        #region Reset_button
        //Reset filters and view
        private void searchBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ResetFields(groupBox1);
            ShowData();
        }
        #endregion

        #endregion

        #region Events For Searching

        private void supplier_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, supplierIdTextBox, "Supplier", "id", "ID", false, "supplier id");
        }

        private void supplier_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, supplierNameTextBox, "Supplier", "name", "ID");
        }

        #endregion

        #region Click on a cell
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            supplierIdTextBox.Text = supplierNameTextBox.Text = "";
            var text = dataGridView1.CurrentCell.Value.ToString();
            var columnIndex = dataGridView1.CurrentCellAddress.X;
            var rowIndex = dataGridView1.CurrentCellAddress.Y;
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
    }
}
