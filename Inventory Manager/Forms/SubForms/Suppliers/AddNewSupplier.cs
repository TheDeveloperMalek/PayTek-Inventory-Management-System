using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class AddNewSupplier : Form
    {

        #region Essential Data
        readonly Suppliers callerForm;

        public AddNewSupplier(Suppliers c)
        {
            InitializeComponent();
            callerForm = c;
        }
        #endregion

        #region Validation Functions
        private bool DoesSupplierNameAlreadyExist()
        {
            using (SqlCommand checkCmd = new SqlCommand("GetExistedSuppliersByName", Shared.conn))
            {
                checkCmd.CommandType = CommandType.StoredProcedure;
                checkCmd.Parameters.AddWithValue("@name", SupplierNameTextBox.Text);
                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);
                return productCount > 0;
            }
        }

        public bool NameWasEntered()
        {
            if (SupplierNameTextBox.Text is "")
                Shared.ErrorOccuredMessageBox("Please type a name ");
            return SupplierNameTextBox.Text != "";
        }
        #endregion

        #region Events
        #region Button Click
        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            if (NameWasEntered())
                if (!DoesSupplierNameAlreadyExist())
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("AddNewSupplier" , Shared.conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@name", SupplierNameTextBox.Text);
                            cmd.ExecuteNonQuery();
                        }

                        Shared.ProcessIsDoneMessageBox("supplier", "added");
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
                    Shared.IgnoredProcess("The supplier already exists , please update it using update button");
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

        private void SupplierNameTextBox_TextChanged(object sender, EventArgs e)
        {
           AddBtn.Enabled = SupplierNameTextBox.TextLength > 0;
        }
        #endregion

    }
}
