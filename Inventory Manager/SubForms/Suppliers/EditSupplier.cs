using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class EditSupplier : Form
    {

        #region Essential data
        readonly Suppliers callerForm;

        public EditSupplier(Suppliers r)
        {
            InitializeComponent();
            callerForm = r;
            Shared.TextBoxAutoCompleteFromColumnGuna("Supplier", "id", SupplierIdTextBox);
        }
        #endregion

        #region Validation Functions
        private bool Check_If_SupplierId_Already_Exists()
        {
            string checkQuery = "SELECT COUNT(*) FROM Supplier WHERE id = @id";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, Shared.conn))
            {
                checkCmd.Parameters.AddWithValue("@id", SupplierIdTextBox.Text);

                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);

                if (productCount > 0)
                    return true;
                return false;
            }
        }
        #endregion

        #region Events

        private void EditUserBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
                if (int.TryParse(SupplierIdTextBox.Text, out int a))
                    if (Check_If_SupplierId_Already_Exists())
                        using (SqlCommand updateCmd = Shared.conn.CreateCommand())
                        {
                            updateCmd.CommandType = CommandType.Text;
                            updateCmd.Parameters.AddWithValue("@id", SupplierIdTextBox.Text);
                            updateCmd.Parameters.AddWithValue("@name", SupplierNameTextBox.Text);
                            if (!(SupplierNameTextBox.Text == ""))
                            {
                                updateCmd.CommandText = "UPDATE Supplier SET name = @name WHERE id = @id";
                                updateCmd.ExecuteNonQuery();
                            }
                            else
                            {
                                Shared.ErrorOccuredMessageBox("Type the new name");
                                return;
                            }

                            int.TryParse(updateCmd.ExecuteNonQuery().ToString(), out int rowsAffected);

                            if (rowsAffected > 0)
                                Shared.ProcessIsDoneMessageBox("supplier", "edited");
                            else
                                Shared.IgnoredProcess("No supplier was edited");
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

        private void AddNewUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            callerForm.ShowData();
        }
        #endregion

    }
}
