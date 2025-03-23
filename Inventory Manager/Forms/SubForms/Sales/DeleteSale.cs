using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class DeleteSale : Form
    {

        #region Essential data
        readonly Sales callerForm;

        public DeleteSale(Sales r)
        {
            InitializeComponent();
            callerForm = r;
            Shared.TextBoxAutoCompleteFromColumnGuna("Sale", "id", SaleIdTextBox);
        }
        #endregion

        #region validation functions
        private bool User_Entered_Sale_Id()
        {
            if (String.IsNullOrEmpty(SaleIdTextBox.Text))
            {
                Shared.ErrorOccuredMessageBox("Please enter the Sale id to perform this action");
                return false;
            }
            else if (!int.TryParse(SaleIdTextBox.Text, out int id) || id < 0)
            {
                Shared.ErrorOccuredMessageBox("Please enter a valid value for product's id field");
                return false;
            }
            else
                return true;
        }

        private bool DoesSaleAlreadyExist()
        {
            using (SqlCommand checkCmd = new SqlCommand("GetExistedSalesNumberById", Shared.conn))
            {
                checkCmd.CommandType = CommandType.StoredProcedure;
                checkCmd.Parameters.AddWithValue("@id", SaleIdTextBox.Text);
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

            if (User_Entered_Sale_Id())
                if (DoesSaleAlreadyExist())
                {
                    DialogResult delete = MessageBox.Show($"Are you sure ?", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (delete == DialogResult.Yes)
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("DeleteSale" , Shared.conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@id", int.Parse(SaleIdTextBox.Text));
                                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                                cmd.Parameters.AddWithValue("@status", Sales.status);
                                

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                    Shared.ProcessIsDoneMessageBox("sale", "returned");
                                else
                                    Shared.ErrorOccuredMessageBox("No record found with the specified id.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Shared.ErrorOccuredMessageBox("Error: " + ex.Message);
                        }
                        finally
                        {
                            Shared.conn.Close();
                        }
                    }
                }
                    else
                        Shared.ErrorOccuredMessageBox("The Sale doesn't exists");
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


        private void SaleIdTextBox_TextChanged(object sender, EventArgs e)
        {
            DeleteBtn.Enabled = SaleIdTextBox.TextLength > 0;
        }
        #endregion
    }
}
