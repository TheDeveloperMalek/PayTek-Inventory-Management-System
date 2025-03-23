using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class DeleteSupplier : Form
    {

        #region Essential Data
        readonly Suppliers callerForm;

        public DeleteSupplier(Suppliers r)
        {
            InitializeComponent();
            callerForm = r;
            Shared.TextBoxAutoCompleteFromColumnGuna("Supplier", "id", SupplierIdTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Supplier", "name", SupplierNameTextBox);
        }
        #endregion

        #region Validation Functions
        public bool DataWasEnteredCorrectly()
        {
            if (SupplierIdTextBox.Text is "" && SupplierNameTextBox.Text is "")
            {
                Shared.ErrorOccuredMessageBox("Please type a name or an id at least to perform this action");
                return false;
            }
            if (SupplierNameTextBox.Text is "" && !int.TryParse(SupplierIdTextBox.Text, out int a) && a < 0)
            {
                Shared.ErrorOccuredMessageBox("Please type a valid value for supplier's id");
                return false;
            }
            return true;
        }
        private bool DoesSupplierAlreadyExist()
        {
            using (SqlCommand checkCmd = new SqlCommand("GetExistedSuppliersNumberByNameOrId", Shared.conn))
            {
                checkCmd.CommandType = CommandType.StoredProcedure;
                checkCmd.Parameters.AddWithValue("@id", SupplierIdTextBox.Text);
                checkCmd.Parameters.AddWithValue("@name", SupplierNameTextBox.Text);
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
            if (DataWasEnteredCorrectly())
                if (DoesSupplierAlreadyExist())
                {
            DialogResult  delete = MessageBox.Show($"Are you sure ? ", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (delete is DialogResult.Yes)
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand ("" , Shared.conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                if (SupplierIdTextBox.Text != "")
                                {
                                    cmd.CommandText = "DeleteSupplierById";
                                    cmd.Parameters.AddWithValue("@id", SupplierIdTextBox.Text);
                                }
                                else
                                {
                                    cmd.CommandText = "DeleteSupplierByName";
                                    cmd.Parameters.AddWithValue("@name", SupplierNameTextBox.Text);
                                }
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                    Shared.ProcessIsDoneMessageBox("supplier", "deleted");
                                else
                                    Shared.ErrorOccuredMessageBox("No supplier found with the specified name or id");
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
        #endregion

        private void AddNewUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            callerForm.ShowData();
        }

      

        private void SupplierIdTextBox_TextChanged(object sender, EventArgs e)
        {
            SupplierNameTextBox.Enabled = SupplierIdTextBox.TextLength == 0;
            DeleteBtn.Enabled = SupplierIdTextBox.TextLength > 0;
        }

        private void SupplierNameTextBox_TextChanged(object sender, EventArgs e)
        {
            SupplierIdTextBox.Enabled = SupplierNameTextBox.TextLength == 0;
            DeleteBtn.Enabled = SupplierNameTextBox.TextLength > 0;
        }
        #endregion
    }
}
