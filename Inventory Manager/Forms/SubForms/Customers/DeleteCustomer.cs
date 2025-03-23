using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class DeleteCustomer : Form
    {

        #region Essential Data
        readonly Customers callerForm;

        public DeleteCustomer(Customers r)
        {
            InitializeComponent();
            callerForm = r;
            Shared.TextBoxAutoCompleteFromColumnGuna("Customer", "id", CustomerIdTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Customer", "name", CustomerNameTextBox);
        }
        #endregion

        #region Validation Functions
        public bool IsDataEnteredCorrectly()
        {
            if (CustomerNameTextBox.Text is "" && !int.TryParse(CustomerIdTextBox.Text, out int a))
            {
                Shared.ErrorOccuredMessageBox("Please type a valid value for customer's id");
                return false;
            }
            return true;
        }
        private bool DoesCustomerAlreadyExist()
        {
            using (SqlCommand checkCmd = new SqlCommand("GetExistedCustomersNumberByNameOrId", Shared.conn))
            {
                checkCmd.CommandType = CommandType.StoredProcedure;
                checkCmd.Parameters.AddWithValue("@id", CustomerIdTextBox.Text);
                checkCmd.Parameters.AddWithValue("@name", CustomerNameTextBox.Text);

                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);
                return productCount > 0;
            }
        }

        #endregion

        #region Events

        #region Delete Button
        private void DeleteUserBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            if (IsDataEnteredCorrectly())
                if (DoesCustomerAlreadyExist())
                {
                   DialogResult delete = MessageBox.Show($"Are you sure ? ", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (delete == DialogResult.Yes)
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("", Shared.conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                if (CustomerIdTextBox.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@id", CustomerIdTextBox.Text);
                                    cmd.CommandText = "DeleteCustomerById";
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@name", CustomerNameTextBox.Text);
                                    cmd.CommandText = "DeleteCustomerByName";
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
        #endregion

        private void AddNewUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            callerForm.ShowData();
        }
        private void CustomerIdTextBox_TextChanged(object sender, EventArgs e)
        {
            CustomerNameTextBox.Enabled = CustomerIdTextBox.TextLength == 0;
           DeleteBtn.Enabled = CustomerIdTextBox.TextLength > 0;
        }

        private void CustomerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            CustomerIdTextBox.Enabled = CustomerNameTextBox.TextLength == 0;
            DeleteBtn.Enabled = CustomerNameTextBox.TextLength > 0;
        }

        #endregion

    }
}
