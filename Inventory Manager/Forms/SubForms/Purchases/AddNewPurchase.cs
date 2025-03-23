using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class AddNewPurchase : Form
    {

        #region Essential data
        readonly Purchases callerForm;

        public AddNewPurchase(Purchases c)
        {
            InitializeComponent();
            CostTextBox.Visible = Shared.isJustVisibleForNonUserType;
            Shared.TextBoxAutoCompleteFromColumnGuna("Product", "ID", ProductIdTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Product", "Barcode", ProductBarcodeTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Product", "Name", ProductNameTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Supplier", "ID", SupplierIdTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Supplier", "Name", SupplierNameTextBox);
            callerForm = c;
        }
        #endregion

        #region Validation functions
        private bool DoesProductAlreadyExist()
        {
            using (SqlCommand checkCmd = new SqlCommand("GetExistedProductsNumberByIdBarcodeName", Shared.conn))
            {
                checkCmd.CommandType = CommandType.StoredProcedure;
                checkCmd.Parameters.AddWithValue("@id", ProductIdTextBox.Text);
                checkCmd.Parameters.AddWithValue("@barcode", ProductBarcodeTextBox.Text);
                checkCmd.Parameters.AddWithValue("@name", ProductNameTextBox.Text);
                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);
                return productCount > 0;
            }
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

        private bool AtLeastInput()
        {
            if (
                (ProductIdTextBox.Text == ""
                && String.IsNullOrEmpty(ProductNameTextBox.Text)
                && ProductBarcodeTextBox.Text == "")
                ||
                QuantityTextBox.Text == ""
                || (SupplierIdTextBox.Text == "" && String.IsNullOrEmpty(SupplierNameTextBox.Text)
                ))
            {
                if (ProductIdTextBox.Text == ""
                    && String.IsNullOrEmpty(ProductNameTextBox.Text)
                    && ProductBarcodeTextBox.Text == "")
                {
                    Shared.ErrorOccuredMessageBox("Please Enter product's id , barcode , or name");
                    return false;
                }
                if (SupplierIdTextBox.Text == "" && String.IsNullOrEmpty(SupplierNameTextBox.Text))
                {
                    Shared.ErrorOccuredMessageBox("Please Enter supplier's id or name ");
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
        public bool IsDataEnteredCorrectly()
        {
            Shared.ConnectionInitializer();
            if (AtLeastInput())
            {
                if (ProductNameTextBox.Text == "")
                {
                    if (ProductBarcodeTextBox.Text == "")
                        if (!int.TryParse(ProductIdTextBox.Text, out int a) || a < 0)
                        {
                            Shared.ErrorOccuredMessageBox("Please enter a valid value for product's id field");
                            return false;
                        }
                    if (ProductIdTextBox.Text == "")
                        if (!int.TryParse(ProductBarcodeTextBox.Text, out int axt) || axt < 0)
                        {
                            Shared.ErrorOccuredMessageBox("Please enter a valid value for product's barcode field");
                            return false;
                        }
                }

                if (SupplierNameTextBox.Text == "")
                    if (!int.TryParse(SupplierIdTextBox.Text, out int s) || s < 0)
                    {
                        Shared.ErrorOccuredMessageBox("Please enter a valid value for supplier's id field");
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
        #endregion

        #region Events

        #region Button Click
        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            if (IsDataEnteredCorrectly())
            {
                if (!DoesSupplierAlreadyExist())
                {
                    if (!String.IsNullOrEmpty(SupplierNameTextBox.Text))
                    {
                        using (SqlCommand cmd = new SqlCommand("AddNewSupplier", Shared.conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@name", SupplierNameTextBox.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        Shared.ErrorOccuredMessageBox("Please enter a name or an existed supplier's id to continue process");
                        return;
                    }
                }
            }
            else
                return;

            if (DoesProductAlreadyExist())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("", Shared.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@product_quantity", QuantityTextBox.Text);
                        cmd.Parameters.AddWithValue("@price", CostTextBox.Text);
                        cmd.Parameters.AddWithValue("@status", Purchases.status);
                        cmd.Parameters.AddWithValue("@date", DateTime.Today);

                        if (String.IsNullOrEmpty(SupplierNameTextBox.Text))
                        {
                            cmd.Parameters.AddWithValue("@supplier_id", SupplierIdTextBox.Text);

                            if (ProductNameTextBox.Text != "")
                            {
                                cmd.Parameters.AddWithValue("@product_name", ProductNameTextBox.Text);
                                cmd.CommandText = "AddNewPurchaseBySupplierIdAndProductName";
                            }

                            else if (ProductIdTextBox.Text != "")
                            {
                                cmd.Parameters.AddWithValue("@product_id", ProductIdTextBox.Text);
                                cmd.CommandText = "AddNewPurchaseBySupplierIdAndProductId";
                            }

                            else if (ProductBarcodeTextBox.Text != "")
                            {
                                cmd.Parameters.AddWithValue("@product_barcode", ProductBarcodeTextBox.Text);
                                cmd.CommandText = "AddNewPurchaseBySupplierIdAndProductBarcode";
                            }
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@supplier_name", SupplierNameTextBox.Text);

                            if (ProductNameTextBox.Text != "")
                            {
                                cmd.Parameters.AddWithValue("@product_name", ProductNameTextBox.Text);
                                cmd.CommandText = "AddNewPurchaseBySupplierNameAndProductName";
                            }

                            else if (ProductIdTextBox.Text != "")
                            {
                                cmd.Parameters.AddWithValue("@product_id", ProductIdTextBox.Text);
                                cmd.CommandText = "AddNewPurchaseBySupplierNameAndProductId";
                            }

                            else if (ProductBarcodeTextBox.Text != "")
                            {
                                cmd.Parameters.AddWithValue("@product_barcode", ProductBarcodeTextBox.Text);
                                cmd.CommandText = "AddNewPurchaseBySupplierNameAndProductBarcode";
                            }
                        }
                        cmd.ExecuteNonQuery();
                        Shared.ProcessIsDoneMessageBox("purchase", "added");
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


        private void ProductIdTextBox_TextChanged(object sender, EventArgs e)
        {
            ProductBarcodeTextBox.Enabled = ProductNameTextBox.Enabled = ProductIdTextBox.TextLength > 0;
            AddBtn.Enabled = ProductIdTextBox.TextLength > 0 && (SupplierIdTextBox.TextLength > 0 || SupplierNameTextBox.TextLength > 0) && QuantityTextBox.TextLength > 0;
        }

        private void ProductBarcodeTextBox_TextChanged(object sender, EventArgs e)
        {
            ProductIdTextBox.Enabled = ProductNameTextBox.Enabled = ProductBarcodeTextBox.TextLength > 0;
            AddBtn.Enabled = ProductBarcodeTextBox.TextLength > 0 && (SupplierIdTextBox.TextLength > 0 || SupplierNameTextBox.TextLength > 0) && QuantityTextBox.TextLength > 0;
        }

        private void ProductNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ProductBarcodeTextBox.Enabled = ProductIdTextBox.Enabled = ProductNameTextBox.TextLength > 0;
            AddBtn.Enabled = ProductNameTextBox.TextLength > 0 && (SupplierIdTextBox.TextLength > 0 || SupplierNameTextBox.TextLength > 0) && QuantityTextBox.TextLength > 0;
        }

        private void SupplierIdTextBox_TextChanged(object sender, EventArgs e)
        {
            SupplierNameTextBox.Enabled = SupplierIdTextBox.TextLength > 0;
            AddBtn.Enabled = SupplierIdTextBox.TextLength > 0 && (ProductIdTextBox.TextLength > 0 || ProductBarcodeTextBox.TextLength > 0 || ProductNameTextBox.TextLength > 0) && QuantityTextBox.TextLength > 0;
        }

        private void SupplierNameTextBox_TextChanged(object sender, EventArgs e)
        {
            SupplierIdTextBox.Enabled = SupplierNameTextBox.TextLength > 0;
            AddBtn.Enabled = SupplierNameTextBox.TextLength > 0 && (ProductIdTextBox.TextLength > 0 || ProductBarcodeTextBox.TextLength > 0 || ProductNameTextBox.TextLength > 0) && QuantityTextBox.TextLength > 0;
        }

        private void QuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            AddBtn.Enabled = (ProductIdTextBox.TextLength > 0 || ProductBarcodeTextBox.TextLength > 0 || ProductNameTextBox.TextLength > 0) && (SupplierIdTextBox.TextLength > 0 || SupplierNameTextBox.TextLength > 0) && QuantityTextBox.TextLength > 0;
        }
        #endregion
    }
}
