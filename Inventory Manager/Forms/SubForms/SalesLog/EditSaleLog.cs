using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class EditSaleLog : Form
    {

        #region Essential data
        readonly SalesLog callerForm;

        public EditSaleLog(SalesLog r)
        {
            InitializeComponent();
            callerForm = r;
            Shared.TextBoxAutoCompleteFromColumnGuna("SaleLog", "id", SaleIdTextBox);
        }
        #endregion

        #region Validation Functions

        private bool CheckIfThereIsEnoughProductQuantityUpdate(int wanted_quantity)
        {
            using (var cmd  = new SqlCommand("" , Shared.conn))
            {
            cmd.CommandText = $@"SELECT ""Product Name"" from SaleLog WHERE id = {SaleIdTextBox.Text}";
            var name = Convert.ToString(cmd.ExecuteScalar());
            cmd.CommandText = $@"SELECT quantity FROM SaleLog WHERE id = {SaleIdTextBox.Text}";
            var old_quantity_of_Sale = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.CommandText = $@"SELECT p.quantity from Product p JOIN SaleLog pu ON pu.""Product ID"" = p.id WHERE pu.id = {SaleIdTextBox.Text}";
            var quantity = Convert.ToInt32(cmd.ExecuteScalar());
            if (quantity >= wanted_quantity - old_quantity_of_Sale)
                return true;
            Shared.ErrorOccuredMessageBox($@"Unavailabe because the available quantity of product ""{name}"" is {quantity}");
            return false;
            }
        }


        private bool User_Entered_Sale_Id()
        {
            if (String.IsNullOrEmpty(SaleIdTextBox.Text))
            {
                Shared.ErrorOccuredMessageBox("Please enter the Sale id to perform this action");
                return false;
            }
            else if (!int.TryParse(SaleIdTextBox.Text, out int saleid) || saleid < 0)
            {
                Shared.ErrorOccuredMessageBox("Please enter a valid value for product's id field");
                return false;
            }
            else
                return true;
        }


        private bool User_Entered_Quantity()
        {
            if (String.IsNullOrEmpty(QuantityTextBox.Text))
            {
                Shared.ErrorOccuredMessageBox("Please enter the quantity to perform this action");
                return false;
            }
            else if (!int.TryParse(QuantityTextBox.Text, out int  q) || q < 0)
            {
                Shared.ErrorOccuredMessageBox("Please enter a valid value for product's quantity field");
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
        private void EditUserBtn_Click(object sender, EventArgs e)
        {
            if (User_Entered_Sale_Id())
                if (User_Entered_Quantity())
                    if (DoesSaleAlreadyExist())
                    {
                        if (CheckIfThereIsEnoughProductQuantityUpdate(int.Parse(QuantityTextBox.Text)))
                            try
                            {
                                using (SqlCommand cmd = new SqlCommand("EditSaleLogQuantity" , Shared.conn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@product_quantity", int.Parse(QuantityTextBox.Text));
                                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@id", int.Parse(SaleIdTextBox.Text));
                                    int rowsAffected = cmd.ExecuteNonQuery();
                                    if (rowsAffected > 0)
                                        Shared.ProcessIsDoneMessageBox("sale", "edited");
                                    else
                                        Shared.ErrorOccuredMessageBox("No record found with the specified id.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Shared.ErrorOccuredMessageBox("Error: " + ex.Message);
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
            ChangeQuantityBtn.Enabled = SaleIdTextBox.TextLength > 0 && QuantityTextBox.TextLength > 0;
        }

        private void QuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            ChangeQuantityBtn.Enabled = SaleIdTextBox.TextLength > 0 && QuantityTextBox.TextLength > 0;
        }      
  #endregion
    }
}
