using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class AddNewSale : Form
    {

        #region Essential data
        readonly Sales callerForm;

        public AddNewSale(Sales c)
        {
            InitializeComponent();
            UnitPriceTextBox.Visible = Shared.isJustVisibleForNonUserType;
            Shared.TextBoxAutoCompleteFromColumnGuna("Product", "ID", ProductIdTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Product", "Barcode", ProductBarcodeTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Product", "Name", ProductNameTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Customer", "ID", CustomerIdTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Customer", "Name", CustomerNameTextBox);
            callerForm = c;
        }
        #endregion

        #region validation_functions
        //Check if the text boxes were empty
        private bool At_Least_Input()
        {
            if (
                (ProductIdTextBox.Text == ""
                && String.IsNullOrEmpty(ProductNameTextBox.Text)
                && ProductBarcodeTextBox.Text == "")
                ||
                QuantityTextBox.Text == ""
                || (CustomerIdTextBox.Text == "" && String.IsNullOrEmpty(CustomerNameTextBox.Text
                ))
                )
            {
                if (ProductIdTextBox.Text == ""
                    && String.IsNullOrEmpty(ProductNameTextBox.Text)
                    && ProductBarcodeTextBox.Text == "")
                {
                    Shared.ErrorOccuredMessageBox("Please Enter product's id , barcode , or name");
                    return false;
                }
                if (CustomerIdTextBox.Text == "" && String.IsNullOrEmpty(CustomerNameTextBox.Text))
                {
                    Shared.ErrorOccuredMessageBox("Please Enter customer's id or name ");
                    return false;
                }
                if (QuantityTextBox.Text == "")
                {
                    Shared.ErrorOccuredMessageBox("Please Enter quantity");
                    return false;
                }
            }
            return true;
        }

        private bool Check_If_There_Is_Enough_Product_Quantity(int wanted_quantity)
        {
            using (var cmd = new SqlCommand("", Shared.conn))
            {
                if (ProductIdTextBox.Text != "")
                {
                    cmd.CommandText = $"SELECT name from Product WHERE id = {ProductIdTextBox.Text}";
                    var name = Convert.ToString(cmd.ExecuteScalar());

                    cmd.CommandText = $"SELECT quantity from Product WHERE id = {ProductIdTextBox.Text}";
                    var quantity = Convert.ToInt32(cmd.ExecuteScalar());
                    if (quantity >= wanted_quantity)
                        return true;
                    Shared.ErrorOccuredMessageBox($@"Unavailabe because the available quantity of product ""{name}\"" is {quantity}");
                    return false;
                }

                if (ProductNameTextBox.Text != "")
                {
                    cmd.CommandText = $"SELECT quantity from Product WHERE name = N\'{ProductNameTextBox.Text}\'";
                    var quantity = Convert.ToInt32(cmd.ExecuteScalar());
                    if (quantity >= wanted_quantity)
                    {
                        return true;
                    }
                    Shared.ErrorOccuredMessageBox($"Unavailabe because the available quantity of product \"{ProductNameTextBox.Text}\" is {quantity}");
                    return false;
                }

                if (ProductBarcodeTextBox.Text != "")
                {
                    cmd.CommandText = $"SELECT name from Product WHERE barcode = {ProductBarcodeTextBox.Text}";
                    var name = Convert.ToString(cmd.ExecuteScalar());

                    cmd.CommandText = $"SELECT quantity from Product WHERE barcode = {ProductBarcodeTextBox.Text}";
                    var quantity = Convert.ToInt32(cmd.ExecuteScalar());
                    if (quantity >= wanted_quantity)
                    {
                        return true;
                    }
                    Shared.ErrorOccuredMessageBox($"Unavailabe because the available quantity of product \"{name}\" is {quantity}");
                    return false;
                }
            }
            return true;
        }


        private bool User_Entered_Quantity()
        {
            if (String.IsNullOrEmpty(QuantityTextBox.Text))
            {
                Shared.ErrorOccuredMessageBox("Please enter the quantity to perform this action");
                return false;
            }
            else if (!int.TryParse(QuantityTextBox.Text, out int q) || q < 0)
            {
                Shared.ErrorOccuredMessageBox("Please enter a valid value for product's quantity field");
                return false;
            }
            else
                return true;
        }

        public bool Validation_of_input()
        {
            Shared.ConnectionInitializer();
            if (At_Least_Input())
            {
                if (ProductNameTextBox.Text == "")
                {
                    if (ProductBarcodeTextBox.Text == "")
                        if (!int.TryParse(ProductIdTextBox.Text, out int id) || id < 0)
                        {
                            Shared.ErrorOccuredMessageBox("Please enter a valid value for product's id field");
                            return false;
                        }
                    if (ProductIdTextBox.Text == "")
                        if (!int.TryParse(ProductBarcodeTextBox.Text, out int b) || b < 0)
                        {
                            Shared.ErrorOccuredMessageBox("Please enter a valid value for product's barcode field");
                            return false;
                        }
                }

                if (CustomerNameTextBox.Text == "")
                    if (!int.TryParse(CustomerIdTextBox.Text, out int cid) || cid < 0)
                    {
                        Shared.ErrorOccuredMessageBox("Please enter a valid value for customer's id field");
                        return false;
                    }

                if (!int.TryParse(QuantityTextBox.Text, out int q) || q <= 0)
                {
                    Shared.ErrorOccuredMessageBox("Please enter a valid value for the quantity field");
                    return false;
                }
            }
            else return false;
            return true;
        }

        private bool Check_If_Customer_Already_Exists()
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

        private bool Check_If_Product_Already_Exists()

        {
            using (SqlCommand checkCmd = new SqlCommand("dbo.GetExistedProductsNumberByIdBarcodeName", Shared.conn))
            {
                checkCmd.CommandType = CommandType.StoredProcedure;
                int.TryParse(ProductIdTextBox.Text, out int id);
                int.TryParse(ProductBarcodeTextBox.Text, out int barcode);
                checkCmd.Parameters.AddWithValue("@id", id);
                checkCmd.Parameters.AddWithValue("@barcode", barcode);
                checkCmd.Parameters.AddWithValue("@name", ProductNameTextBox.Text);
                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);
                return productCount > 0;
            }
        }

        #endregion

        #region Events
        #region Button Click
        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            if (Validation_of_input())
            {
                if (!Check_If_Customer_Already_Exists())
                {
                    if (!String.IsNullOrEmpty(CustomerNameTextBox.Text))
                    {
                        using (var cmd = new SqlCommand("AddNewCustomer", Shared.conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@name", CustomerNameTextBox.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        Shared.ErrorOccuredMessageBox("Please enter a name or an existed customer's id to continue process");
                        return;
                    }
                }
            }
            else
                return;

            if (Check_If_Product_Already_Exists())
            {
                if (Check_If_There_Is_Enough_Product_Quantity(int.Parse(QuantityTextBox.Text)))
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("", Shared.conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@product_quantity", QuantityTextBox.Text);
                            cmd.Parameters.AddWithValue("@price", UnitPriceTextBox.Text);
                            cmd.Parameters.AddWithValue("@status", Sales.status);
                            cmd.Parameters.AddWithValue("@date", DateTime.Today);

                            if (String.IsNullOrEmpty(CustomerNameTextBox.Text))
                            {
                                cmd.Parameters.AddWithValue("@customer_id", CustomerIdTextBox.Text);

                                if (ProductNameTextBox.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@product_name", ProductNameTextBox.Text);
                                    cmd.CommandText = "AddNewSaleByCustomerIdAndProductName";
                                }

                                else if (ProductIdTextBox.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@product_id", ProductIdTextBox.Text);
                                    cmd.CommandText = "AddNewSaleByCustomerIdAndProductId";
                                }

                                else if (ProductBarcodeTextBox.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@product_barcode", ProductBarcodeTextBox.Text);
                                    cmd.CommandText = "AddNewSaleByCustomerIdAndProductBarcode";
                                }
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@customer_name", CustomerNameTextBox.Text);

                                if (ProductNameTextBox.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@product_name", ProductNameTextBox.Text);
                                    cmd.CommandText = "AddNewSaleByCustomerNameAndProductName";
                                }

                                else if (ProductIdTextBox.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@product_id", ProductIdTextBox.Text);
                                    cmd.CommandText = "AddNewSaleByCustomerNameAndProductID";

                                }

                                else if (ProductBarcodeTextBox.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@product_barcode", ProductBarcodeTextBox.Text);
                                    cmd.CommandText = "AddNewSaleByCustomerNameAndProductBarcode";
                                }
                            }
                            cmd.ExecuteNonQuery();
                            Shared.ProcessIsDoneMessageBox("sale", "added");
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
                Shared.ErrorOccuredMessageBox("The Product is not exists");
        }
        #endregion

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.FadeOutEffect(this, 5);
        }

        private void AddNewUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            callerForm.ShowData();
        }

        private void ProductIdTextBox_TextChanged(object sender, EventArgs e)
        {
            ProductBarcodeTextBox.Enabled = ProductNameTextBox.Enabled = ProductIdTextBox.TextLength == 0;
            AddBtn.Enabled = ProductIdTextBox.TextLength > 0 &&
                (CustomerNameTextBox.TextLength > 0 || CustomerIdTextBox.TextLength > 0) && QuantityTextBox.TextLength > 0;
        }

        private void ProductBarcodeTextBox_TextChanged(object sender, EventArgs e)
        {
            ProductIdTextBox.Enabled = ProductNameTextBox.Enabled = ProductBarcodeTextBox.TextLength == 0;
            AddBtn.Enabled = ProductBarcodeTextBox.TextLength > 0 &&
                (CustomerNameTextBox.TextLength > 0 || CustomerIdTextBox.TextLength > 0) && QuantityTextBox.TextLength > 0;
        }

        private void ProductNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ProductBarcodeTextBox.Enabled = ProductIdTextBox.Enabled = ProductNameTextBox.TextLength == 0;
            AddBtn.Enabled = ProductNameTextBox.TextLength > 0 &&
                (CustomerNameTextBox.TextLength > 0 || CustomerIdTextBox.TextLength > 0) && QuantityTextBox.TextLength > 0;
        }

        private void CustomerIdTextBox_TextChanged(object sender, EventArgs e)
        {
            CustomerNameTextBox.Enabled = CustomerIdTextBox.TextLength == 0;
            AddBtn.Enabled = CustomerIdTextBox.TextLength > 0 &&
                (ProductBarcodeTextBox.TextLength > 0 || ProductIdTextBox.TextLength > 0 || ProductNameTextBox.TextLength > 0) && QuantityTextBox.TextLength > 0;
        }

        private void CustomerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            CustomerIdTextBox.Enabled = CustomerNameTextBox.TextLength == 0;
            AddBtn.Enabled = CustomerNameTextBox.TextLength > 0 &&
                (ProductBarcodeTextBox.TextLength > 0 || ProductIdTextBox.TextLength > 0 || ProductNameTextBox.TextLength > 0) && QuantityTextBox.TextLength > 0;
        }

        private void QuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            AddBtn.Enabled =
                (ProductBarcodeTextBox.TextLength > 0 || ProductIdTextBox.TextLength > 0 || ProductNameTextBox.TextLength > 0) &&
                (CustomerNameTextBox.TextLength > 0 || CustomerIdTextBox.TextLength > 0) &&
                QuantityTextBox.TextLength > 0;
        }
        #endregion

    }
}
