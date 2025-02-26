using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class DeleteSupplier : Form
    {

        #region Essential data
        readonly Suppliers callerForm;

        public DeleteSupplier(Suppliers r)
        {
            InitializeComponent();
            callerForm = r;
            Shared.TextBoxAutoCompleteFromColumnGuna("Supplier", "id", SupplierIdTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Supplier", "name", SupplierNameTextBox);
        }
        #endregion

        #region validation functions
        public bool At_Least_Input_Requriements()
        {
            if (SupplierIdTextBox.Text == "" && SupplierNameTextBox.Text == "")
            {
                Shared.ErrorOccuredMessageBox("Please type a name or an id at least to perform this action");
                return false;
            }
            if (SupplierNameTextBox.Text == "" && !int.TryParse(SupplierIdTextBox.Text, out int a))
            {
                Shared.ErrorOccuredMessageBox("Please type a valid value for supplier's id");
                return false;
            }
            return true;
        }
        private bool Check_If_Supplier_Already_Exists()
        {
            string checkQuery = "SELECT COUNT(*) FROM Supplier WHERE name = @name OR  id = @id";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, Shared.conn))
            {
                checkCmd.Parameters.AddWithValue("@id", SupplierIdTextBox.Text);
                checkCmd.Parameters.AddWithValue("@name", SupplierNameTextBox.Text);

                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);

                if (productCount > 0)
                {
                    return true;
                }
                return false;
            }
        }

        #endregion

        #region Events

        private void DeleteUserBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            DialogResult delete;
            if (At_Least_Input_Requriements())
                if (Check_If_Supplier_Already_Exists())
                {

                    delete = MessageBox.Show($"Are you sure ? ", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (delete == DialogResult.Yes)
                        try
                        {
                            using (SqlCommand cmd = Shared.conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.Text;
                                if (!(SupplierIdTextBox.Text == ""))
                                {
                                    cmd.CommandText = "DELETE FROM Supplier WHERE id = @id";
                                    cmd.Parameters.AddWithValue("@id", SupplierIdTextBox.Text);
                                }
                                else
                                {
                                    cmd.CommandText = "DELETE FROM Supplier WHERE name = @name";
                                    cmd.Parameters.AddWithValue("@name", SupplierNameTextBox.Text);
                                }
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                    Shared.ProcessIsDoneMessageBox("supplier", "deleted");
                                else
                                    Shared.ErrorOccuredMessageBox("No Supplier found with the specified name or id.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Shared.ErrorOccuredMessageBox(ex.Message);
                        }
                        finally
                        {
                            Shared.conn.Close();
                        }
                }
                else
                    Shared.ErrorOccuredMessageBox("The supplier doesn't exists");
        }

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.FadeOutEffect(this, 5);
        }

        private void AddNewUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            callerForm.ShowData();
        }

        #endregion

    }
}
