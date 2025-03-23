using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class AddNewCustomer : Form
    {

        #region Essential Data
        readonly Customers callerForm;

        public AddNewCustomer(Customers c)
        {
            InitializeComponent();
            callerForm = c;
        }
        #endregion

        #region Validation Functions
        private bool DoesCustomerNameAlreadyExist()
        {
            using (SqlCommand checkCmd = new SqlCommand("GetExistedCustomersNumberByName", Shared.conn))
            {
                checkCmd.CommandType = CommandType.StoredProcedure;
                checkCmd.Parameters.AddWithValue("@name", CustomerNameTextBox.Text);

                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);
                return productCount > 0;
            }
        }
        #endregion

        #region Events

        #region Button Click
        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            if (!DoesCustomerNameAlreadyExist())
            {
                try
                {
                    using (var cmd = new SqlCommand("AddNewCustomer", Shared.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@name", CustomerNameTextBox.Text);
                        cmd.ExecuteNonQuery();
                    }
                    Shared.ProcessIsDoneMessageBox("customer", "added");
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
                Shared.IgnoredProcess("The customer already exists , please edit it using edit button");

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
        private void CustomerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            AddBtn.Enabled = CustomerNameTextBox.TextLength > 0;
        }
        #endregion

    }
}
