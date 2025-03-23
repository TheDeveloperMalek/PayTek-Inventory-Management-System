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
        private bool DoesCustomerAlreadyExist()
        {
            using (var checkCmd = new SqlCommand("GetExistedCustomersNumberById", Shared.conn))
            {
                checkCmd.CommandType = CommandType.StoredProcedure;
                checkCmd.Parameters.AddWithValue("@id", CustomerIdTextBox.Text);
                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);
                return productCount > 0;
            }
        }
        #endregion

        #region Events

        #region Click Button
        private void EditUserBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            if (int.TryParse(CustomerIdTextBox.Text, out int x) && x > 0)
                if (DoesCustomerAlreadyExist())
                    try
                    {
                        using (var updateCmd = new SqlCommand("EditCustomerName", Shared.conn))
                        {
                            updateCmd.CommandType = CommandType.StoredProcedure;
                            updateCmd.Parameters.AddWithValue("@id", CustomerIdTextBox.Text);
                            updateCmd.Parameters.AddWithValue("@name", CustomerNameTextBox.Text);
                            if (CustomerNameTextBox.Text is "")
                            {
                                Shared.ErrorOccuredMessageBox("Please type the new name");
                                return;
                            }
                            else
                            {
                                updateCmd.CommandText = "EditCustomerName";
                                int.TryParse(updateCmd.ExecuteNonQuery().ToString(), out int rowsAffected);

                                if (rowsAffected > 0)
                                    Shared.ProcessIsDoneMessageBox("customer's name", "edited");
                                else
                                    Shared.IgnoredProcess("No customer was updated");
                            }
                        }
                    }
                    catch(Exception exc )
                    {
                        Shared.ErrorOccuredMessageBox(exc.Message);
                    }
                    finally
                    {
                        Shared.conn.Close();
                    }
                else
                    Shared.ErrorOccuredMessageBox("The customer doesn't exists");
            else
                Shared.ErrorOccuredMessageBox("Please enter a valid value for the id field");
        }

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.FadeOutEffect(this, 5);
        }

        #endregion

        private void AddNewUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            callerForm.ShowData();
        }
        private void CustomerIdTextBox_TextChanged(object sender, EventArgs e)
        {
            ChangeBtn.Enabled = CustomerIdTextBox.TextLength > 0 && CustomerNameTextBox.TextLength > 0;
        }

        private void CustomerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ChangeBtn.Enabled = CustomerIdTextBox.TextLength > 0 && CustomerNameTextBox.TextLength > 0;
        }
        #endregion
    }
}
