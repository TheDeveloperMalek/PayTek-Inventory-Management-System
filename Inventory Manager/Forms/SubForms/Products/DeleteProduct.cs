using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace Inventory_Manager
{
    public partial class DeleteProduct : Form
    {

        #region Essential Data
        readonly Products callerForm;

        public DeleteProduct(Products r)
        {
            InitializeComponent();
            callerForm = r;
            Shared.TextBoxAutoCompleteFromColumnGuna("Product", "id", ProductIdTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Product", "barcode", ProductBarcodeTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Product", "name", ProductNameTextBox);
        }
        #endregion

        #region Startup Functions

        #region Validation Functions
        public bool IsDataFilledCorrectly()
        {
            bool AreAllTextBoxesEmpty = ProductIdTextBox.Text is ""
                && ProductNameTextBox.Text is ""
                && ProductBarcodeTextBox.Text is "";

            if (AreAllTextBoxesEmpty)
            {
                Shared.ErrorOccuredMessageBox("Please type id , barcode or name at least to delete a product");
                return false;
            }

            if (!int.TryParse(ProductIdTextBox.Text, out int id) && id < 0
                && ProductNameTextBox.Text is ""
                && ProductBarcodeTextBox.Text is "")
            {
                Shared.ErrorOccuredMessageBox("Please enter a valid value for the id field");
                return false;
            }
            if (!int.TryParse(ProductBarcodeTextBox.Text, out int barcode) && barcode < 0
                && ProductNameTextBox.Text is ""
                && ProductIdTextBox.Text is "")
            {
                Shared.ErrorOccuredMessageBox("Please enter a valid value for the barcode field");
                return false;
            }
            return true;
        }

        private bool CheckIfProductAlreadyExists()
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

        #region Data Manipulation Functions
        private void DeleteProductImage()
        {
            if (ProductIdTextBox.Text != "")
                File.Delete($@"{Shared.documentsPath}\{Shared.programDirectoryName}\{Shared.ProductBarcodeGetterGuna("ID", ProductIdTextBox)}.{Products.imageExtension}");


            else if (ProductBarcodeTextBox.Text != "")
                File.Delete($@"{Shared.documentsPath}\{Shared.programDirectoryName}\{ProductBarcodeTextBox.Text}.{Products.imageExtension}");

            else if (ProductNameTextBox.Text != "")

                File.Delete($@"{Shared.documentsPath}\{Shared.programDirectoryName}\{Shared.ProductBarcodeGetterGuna("Name", ProductIdTextBox)}.{Products.imageExtension}");
        }
        #endregion

        #endregion

        #region Events

        #region Button Click
        private void DeleteUserBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            if (IsDataFilledCorrectly())
                if (CheckIfProductAlreadyExists())
                {
                    DialogResult delete = MessageBox.Show("Are you sure ?", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (delete is DialogResult.Yes)
                        try
                        {
                            string storedProcedure = "";
                            using (SqlCommand cmd = new SqlCommand(storedProcedure, Shared.conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                if (ProductIdTextBox.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@id", int.Parse(ProductIdTextBox.Text));
                                    storedProcedure = "DeleteProductById";
                                }

                                else if (ProductBarcodeTextBox.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@barcode", int.Parse(ProductBarcodeTextBox.Text));
                                    storedProcedure = "DeleteProductByBarcode";
                                }


                                else if (ProductNameTextBox.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@name", ProductNameTextBox.Text);
                                    storedProcedure = "DeleteProductByName";
                                }

                                cmd.CommandText = storedProcedure;
                                cmd.ExecuteNonQuery();
                                DeleteProductImage();
                                Shared.ProcessIsDoneMessageBox("product", "deleted");
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
                    Shared.ErrorOccuredMessageBox("The product doesn't exists");
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
            ProductNameTextBox.Enabled = ProductBarcodeTextBox.Enabled = ProductIdTextBox.TextLength == 0;
            DeleteBtn.Enabled =
            ProductIdTextBox.TextLength > 0;
        }

        private void ProductBarcodeTextBox_TextChanged(object sender, EventArgs e)
        {
            ProductNameTextBox.Enabled = ProductIdTextBox.Enabled = ProductBarcodeTextBox.TextLength == 0;
            DeleteBtn.Enabled =
           ProductBarcodeTextBox.TextLength > 0;
        }

        private void ProductNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ProductBarcodeTextBox.Enabled = ProductIdTextBox.Enabled = ProductNameTextBox.TextLength == 0;
            DeleteBtn.Enabled =
           ProductNameTextBox.TextLength > 0;
        }

        #endregion

    }
}
