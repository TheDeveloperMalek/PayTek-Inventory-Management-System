using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Inventory_Manager
{
    public partial class EditPurchase : Form
    {

        #region Essential data
        readonly Purchases callerForm;

        public EditPurchase(Purchases r)
        {
            InitializeComponent();
            callerForm = r;
            CostTextBox.Visible = Shared.isJustVisibleForNonUserType;
            if(Shared.currentUserType == "user")
            {
                ChangeBtn.Location = new Point(153, 335);
                Size = new Size(474 , 414);
            }
            Shared.TextBoxAutoCompleteFromColumnGuna("Purchase", "ID", PurchaseIdTextBox);
        }
        #endregion

        #region Validation Functions
        private bool PurchaseIdValid()
        {

            if (!int.TryParse(PurchaseIdTextBox.Text, out int a) || a < 0)
            {
                Shared.ErrorOccuredMessageBox("Please enter a valid value for product's id field");
                return false;
            }
            return true;
        }


        private bool IsQuantityValueValid()
        {
            if (!int.TryParse(QuantityTextBox.Text, out int q) || q < 0)
            {
                Shared.ErrorOccuredMessageBox("Please enter a valid value for product's quantity field");
                return false;
            }
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

        private void EditUserBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            if (PurchaseIdValid())
                if (Check_If_Purchase_Already_Exists())
                {
                    if (QuantityTextBox.TextLength > 0)
                        if (IsQuantityValueValid())
                            try
                            {
                                using (SqlCommand cmd = new SqlCommand("EditPurchaseQuantity", Shared.conn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@product_quantity", QuantityTextBox.Text);
                                    cmd.Parameters.AddWithValue("@status", Purchases.status);
                                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@id", PurchaseIdTextBox.Text);
                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                        Shared.ProcessIsDoneMessageBox("purchase's product's quantity", "edited");
                                    else
                                        Shared.ErrorOccuredMessageBox("No record found with the specified id.");
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
                    if (CostTextBox.TextLength > 0)
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("EditPurchaseCost", Shared.conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@product_cost", CostTextBox.Text);
                                cmd.Parameters.AddWithValue("@id", PurchaseIdTextBox.Text);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                    Shared.ProcessIsDoneMessageBox("purchase's cost", "edited");
                                else
                                    Shared.ErrorOccuredMessageBox("No record found with the specified id.");
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
                    Shared.ErrorOccuredMessageBox("The purchase doesn't exists");
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
            ChangeBtn.Enabled = PurchaseIdTextBox.TextLength > 0 && (QuantityTextBox.TextLength > 0 || CostTextBox.TextLength > 0);
        }

        private void QuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            ChangeBtn.Enabled = PurchaseIdTextBox.TextLength > 0 && (QuantityTextBox.TextLength > 0 || CostTextBox.TextLength > 0);
        }

        private void CostTextBox_TextChanged(object sender, EventArgs e)
        {
            ChangeBtn.Enabled = PurchaseIdTextBox.TextLength > 0 && (QuantityTextBox.TextLength > 0 || CostTextBox.TextLength > 0);
        }
        #endregion
    }
}
