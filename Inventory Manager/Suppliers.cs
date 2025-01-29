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
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
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
            Shared.ShowAllData(dataGridView1, "supplier", "id");
        }
        //Shortcuts for window
        private void KeysShortcuts(object sender, KeyEventArgs e)
        {
            Shared.KeysShortcuts(sender, e, this);
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
                    MessageBox.Show("Please Enter Id ", "Inventory Management System");
                    return true;
                }
                if (String.IsNullOrEmpty(supplierNameTextBox.Text))
                {
                    MessageBox.Show("Please Enter name of the supplier", "Inventory Management System");
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
                    MessageBox.Show("Please enter a valid value for the id field");
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
                MessageBox.Show("Please type a name or an id at least to perform this action", "Inventory Management System");
                return false;
            }
            if (!int.TryParse(supplierIdTextBox.Text, out id_value) && supplierNameTextBox.Text == "")
            {
                MessageBox.Show("Please enter a valid value for the id field");
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
                MessageBox.Show("Please type a name at least to add new supplier", "Inventory Management System");
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
            Shared.ConnectionInitializer();
            if (At_Least_Input_Name())
                if (!Check_If_Supplier_Name_Already_Exists())
                {
                    string name_value = supplierNameTextBox.Text;
                    try
                    {
                        using (SqlCommand cmd = Shared.conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "INSERT INTO Supplier (name) VALUES (@name_value)";

                            // Add parameters
                            cmd.Parameters.AddWithValue("@name_value", name_value);

                            cmd.ExecuteNonQuery(); // Execute the command
                        }

                        MessageBox.Show("Data inserted successfully!");
                        ShowData();
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        Shared.conn.Close(); // Ensure the connection is closed
                    }
                    ShowData();
                    return;
                }
                else if (Check_If_Supplier_Name_Already_Exists())
                {
                    MessageBox.Show("The supplier already exists , please update it using update button");
                }
        }
        #endregion

        #region update_button
        private void updateBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            {
                if (int.TryParse(supplierIdTextBox.Text, out id_value))
                {
                    if (Check_If_SupplierId_Already_Exists())
                    {
                        using (SqlCommand updateCmd = Shared.conn.CreateCommand())
                        {
                            name_value = supplierNameTextBox.Text;
                            updateCmd.CommandType = CommandType.Text;
                            updateCmd.Parameters.AddWithValue("@id", id_value);
                            updateCmd.Parameters.AddWithValue("@name", name_value);
                            if (!(supplierNameTextBox.Text == ""))
                            {
                                updateCmd.CommandText = "UPDATE Supplier SET name = @name WHERE id = @id";
                                updateCmd.ExecuteNonQuery();
                            }
                            else
                            {
                                MessageBox.Show("Type atleast something to update the data");
                                return;
                            }

                            int.TryParse(updateCmd.ExecuteNonQuery().ToString(), out int rowsAffected);

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Supplier updated successfully.");
                            }
                            else
                            {
                                MessageBox.Show("No supplier was updated.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("The supplier doesn't exists");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid value for the id field");
                    return;
                }
            }
            ShowData();
            Shared.conn.Close();
            return;
        }
        #endregion

        #region delete_button
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            DialogResult delete;
            delete = MessageBox.Show($"Are you sure ? ", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (delete == DialogResult.Yes)
            {
                if (At_Least_Input_Requriements())
                    if (Check_If_Supplier_Already_Exists())
                    {
                        try
                        {
                            using (SqlCommand cmd = Shared.conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.Text;
                                if (!(supplierIdTextBox.Text == ""))
                                {
                                    cmd.CommandText = "DELETE FROM Supplier WHERE id = @id";
                                    cmd.Parameters.AddWithValue("@id", id_value);
                                }

                                else if (!(supplierNameTextBox.Text == ""))
                                {
                                    cmd.CommandText = "DELETE FROM Supplier WHERE name = @name";
                                    cmd.Parameters.AddWithValue("@name", name_value);
                                }

                                int rowsAffected = cmd.ExecuteNonQuery(); // Execute the command

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Supplier deleted successfully.");
                                }
                                else
                                {
                                    MessageBox.Show("No Supplier found with the specified name or id.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        finally
                        {
                            Shared.conn.Close();
                        }
                        ShowData();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("The supplier doesn't exists");
                    }
            }
            else
            {
                MessageBox.Show("Nothing has been changed", "Inventory Management System");
                ShowData();
            }
        }
        #endregion

        #region Reset_button
        //Reset filters and view
        private void searchBtn_Click(object sender, EventArgs e)
        {
            supplierIdTextBox.Text =
            supplierNameTextBox.Text = "";
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
