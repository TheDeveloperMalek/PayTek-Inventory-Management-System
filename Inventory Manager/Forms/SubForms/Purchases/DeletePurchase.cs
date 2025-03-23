using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class DeletePurchase : Form
    {

        #region Essential data
        readonly Purchases callerForm;

        public DeletePurchase(Purchases r)
        {
            InitializeComponent();
            callerForm = r;
            Shared.TextBoxAutoCompleteFromColumnGuna("Purchase", "id", PurchaseIdTextBox);
        }
        #endregion

        #region validation functions

        private bool User_Entered_Purchase_Id()
        {
            if (String.IsNullOrEmpty(PurchaseIdTextBox.Text))
            {
                Shared.ErrorOccuredMessageBox("Please enter the purchase id to perform this action");
                return false;
            }
            else if (!int.TryParse(PurchaseIdTextBox.Text, out int id) || id < 0)
            {
                Shared.ErrorOccuredMessageBox("Please enter a valid value for product's id field");
                return false;
            }
            else
                return true;
        }

        private bool Check_If_Purchase_Already_Exists()
        {
            using (SqlCommand checkCmd = new SqlCommand("GetExistedPurchasesNumberById", Shared.conn))
            {
                checkCmd.CommandType = CommandType.StoredProcedure;
                checkCmd.Parameters.AddWithValue("@id", PurchaseIdTextBox.Text);
                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);
                return productCount > 0;
            }
        }
        #endregion

        #region Events

        #region Button Click
        private void DeleteUserBtn_Click(object sender, EventArgs e)
        {
                Shared.ConnectionInitializer();

                if (User_Entered_Purchase_Id())
                    if (Check_If_Purchase_Already_Exists())
                    {
                        DialogResult delete = MessageBox.Show($"Are you sure? ", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (delete == DialogResult.Yes)
                        {
                            try
                            {
                                using (SqlCommand cmd =new SqlCommand("DeletePurchase" , Shared.conn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@id", PurchaseIdTextBox.Text);
                                    cmd.Parameters.AddWithValue("@status", Purchases.status);
                                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                                    int rowsAffected = cmd.ExecuteNonQuery();
                                    if (rowsAffected > 0)
                                        Shared.ProcessIsDoneMessageBox("purchase", "canceled");
                                    else
                                        Shared.ErrorOccuredMessageBox("No record found with the specified id");
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
                     }
                        else
                            Shared.ErrorOccuredMessageBox("The Purchase doesn't exists");
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

        private void PurchaseIdTextBox_TextChanged(object sender, EventArgs e)
        {
            DeleteBtn.Enabled = PurchaseIdTextBox.TextLength > 0;
        }
        #endregion

    }
}
