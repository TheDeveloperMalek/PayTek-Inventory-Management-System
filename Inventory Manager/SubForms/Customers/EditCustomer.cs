using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class EditCustomer : Form
    {

        #region Essential data
        readonly Customers callerForm;

        public EditCustomer(Customers r)
        {
            InitializeComponent();
            callerForm = r;
            Shared.TextBoxAutoCompleteFromColumnGuna("Customer", "id", CustomerIdTextBox);
        }
        #endregion

        #region Validation Functions
        private bool Check_If_CustomerId_Already_Exists()
        {
            string checkQuery = "SELECT COUNT(*) FROM Customer WHERE id = @id";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, Shared.conn))
            {
                checkCmd.Parameters.AddWithValue("@id", CustomerIdTextBox.Text);

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

        private void EditUserBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
                if (int.TryParse(CustomerIdTextBox.Text, out int x))
                    if (Check_If_CustomerId_Already_Exists())
                    {
                        using (SqlCommand updateCmd = Shared.conn.CreateCommand())
                        {
                            updateCmd.CommandType = CommandType.Text;
                            updateCmd.Parameters.AddWithValue("@id", CustomerIdTextBox.Text);
                            updateCmd.Parameters.AddWithValue("@name", CustomerNameTextBox.Text);
                            if (!(CustomerNameTextBox.Text == ""))
                            {
                                updateCmd.CommandText = "UPDATE customer SET name = @name WHERE id = @id";
                                updateCmd.ExecuteNonQuery();
                            }
                            else
                            {
                                Shared.ErrorOccuredMessageBox("Please type the new name");
                                return;
                            }

                            int.TryParse(updateCmd.ExecuteNonQuery().ToString(), out int rowsAffected);

                            if (rowsAffected > 0)
                                Shared.ProcessIsDoneMessageBox("customer's name", "edited");
                            else
                                Shared.IgnoredProcess("No customer was updated");
                        }
                    }
                    else
                        Shared.ErrorOccuredMessageBox("The customer doesn't exists");
                else
                    Shared.ErrorOccuredMessageBox("Please enter a valid value for the id field");
            Shared.conn.Close();
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
