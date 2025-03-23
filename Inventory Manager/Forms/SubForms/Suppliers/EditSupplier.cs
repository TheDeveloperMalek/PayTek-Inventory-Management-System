using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class EditSupplier : Form
    {

        #region Essential Data
        readonly Suppliers callerForm;

        public EditSupplier(Suppliers r)
        {
            InitializeComponent();
            callerForm = r;
            Shared.TextBoxAutoCompleteFromColumnGuna("Supplier", "id", SupplierIdTextBox);
        }
        #endregion

        #region Validation Functions
        private bool DoesSupplierIdAlreadyExist()
        {
            using (SqlCommand checkCmd = new SqlCommand("GetExistedSuppliersNumberById", Shared.conn))
            {
                checkCmd.CommandType = CommandType.StoredProcedure;
                checkCmd.Parameters.AddWithValue("@id", SupplierIdTextBox.Text);
                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);
                return productCount > 0;
            }
        }
        #endregion

        #region Events

        #region Button Click

        private void EditUserBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            if (int.TryParse(SupplierIdTextBox.Text, out int a) && a > 0)
                if (DoesSupplierIdAlreadyExist())
                    try
                    {
                        using (SqlCommand updateCmd = new SqlCommand("EditSupplierName", Shared.conn))
                        {
                            updateCmd.CommandType = CommandType.StoredProcedure;
                            updateCmd.Parameters.AddWithValue("@id", SupplierIdTextBox.Text);
                            updateCmd.Parameters.AddWithValue("@name", NewSupplierNameTextBox.Text);
                            if (NewSupplierNameTextBox.Text is "")
                            {
                                Shared.ErrorOccuredMessageBox("Type the new name");
                                return;
                            }
                            else
                            {
                                updateCmd.ExecuteNonQuery();
                                Shared.ProcessIsDoneMessageBox("supplier", "edited");
                            }

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
                else
                    Shared.ErrorOccuredMessageBox("The supplier doesn't exists");
            else
                Shared.ErrorOccuredMessageBox("Please enter a valid value for the id field");
            Shared.conn.Close();
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
           ChangeSupplerNameBtn.Enabled = SupplierIdTextBox.TextLength > 0 && NewSupplierNameTextBox.TextLength > 0;
        }

        private void NewSupplierNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ChangeSupplerNameBtn.Enabled = SupplierIdTextBox.TextLength > 0 && NewSupplierNameTextBox.TextLength > 0;
        }
        #endregion

    }
}
