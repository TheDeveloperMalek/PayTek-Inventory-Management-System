using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class DeleteCustomer : Form
    {

        #region Essential data
        readonly Customers callerForm;

        public DeleteCustomer(Customers r)
        {
            InitializeComponent();
            callerForm = r;
            Shared.TextBoxAutoCompleteFromColumnGuna("Customer", "id", CustomerIdTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Customer", "name", CustomerNameTextBox);
        }
        #endregion

        #region validation functions
        public bool At_Least_Input_Requriements()
        {
            if (CustomerIdTextBox.Text == "" && CustomerNameTextBox.Text == "")
            {
                Shared.ErrorOccuredMessageBox("Please type a name or an id at least to perform this action");
                return false;
            }
            if (CustomerNameTextBox.Text == "" &&  !int.TryParse(CustomerIdTextBox.Text, out int a))
            {
                Shared.ErrorOccuredMessageBox("Please type a valid value for customer's id");
                return false;
            }
            return true;
        }
        private bool Check_If_Customer_Already_Exists()
        {
            string checkQuery = "SELECT COUNT(*) FROM Customer WHERE name = @name OR  id = @id";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, Shared.conn))
            {
                checkCmd.Parameters.AddWithValue("@id", CustomerIdTextBox.Text);
                checkCmd.Parameters.AddWithValue("@name", CustomerNameTextBox.Text);

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

            if (At_Least_Input_Requriements())
                if (Check_If_Customer_Already_Exists())
                {
                    DialogResult delete;
                    delete = MessageBox.Show($"Are you sure ? ", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (delete == DialogResult.Yes)
                        try
                        {
                            using (SqlCommand cmd = Shared.conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.Text;
                                if (!(CustomerIdTextBox.Text == ""))
                                {
                                    cmd.CommandText = "DELETE FROM Customer WHERE id = @id";
                                    cmd.Parameters.AddWithValue("@id", CustomerIdTextBox.Text);
                                }

                                else
                                {
                                    cmd.CommandText = "DELETE FROM Customer WHERE name = @name";
                                    cmd.Parameters.AddWithValue("@name", CustomerNameTextBox.Text);
                                }

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                    Shared.ProcessIsDoneMessageBox("customer", "deleted");
                                else
                                    Shared.ErrorOccuredMessageBox("No customer found with the specified name or id");
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
                    Shared.ErrorOccuredMessageBox("The customer doesn't exists");
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
