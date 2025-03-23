using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace Inventory_Manager
{
    public partial class AddNewProduct : Form
    {

        #region Essential Data
        readonly Products callerForm;
        int barcode;
        public AddNewProduct(Products c)
        {
            InitializeComponent();
            Shared.TextBoxAutoCompleteFromColumnGuna("Product", "Barcode", ProductBarcodeTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Product", "Name", ProductNameTextBox);
            callerForm = c;
        }
        #endregion

        #region Startup Functions

        #region Validation Functions
        private bool IsDataFilledCorrectly()
        {
            if (ProductBarcodeTextBox.Text is "")
                Shared.ErrorOccuredMessageBox("Please enter barcode of the product");

            else if (!int.TryParse(ProductBarcodeTextBox.Text, out barcode) || barcode < 0)
                Shared.ErrorOccuredMessageBox("Please enter a valid value for the barcode field");

            if (ProductNameTextBox.Text is "")
                Shared.ErrorOccuredMessageBox("Please enter name of the product");

            return barcode > 0 &&
                   ProductNameTextBox.Text != "";
        }

        private bool DoesProductAlreadyExist()
        {
            using (var checkCmd = new SqlCommand("GetExistedProductsNumberByBarcodeOrName", Shared.conn))
            {
                checkCmd.CommandType = CommandType.StoredProcedure;
                checkCmd.Parameters.AddWithValue("@barcode",barcode);
                checkCmd.Parameters.AddWithValue("@name", ProductNameTextBox.Text);
                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);
                return productCount > 0;
            }
        }
        #endregion

        #region Data Manipulation Functions
        private void ImportProductImage()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = $"Image File(*.{Products.imageExtension})|*.{Products.imageExtension}";
                ofd.Title = "Import image of the product";
                ofd.ShowDialog();
                using (var svf = new SaveFileDialog())
                {
                    if (ofd.FileName != "")
                    {
                        string selectedFilePath = ofd.FileName;
                        ProductImage.Image = System.Drawing.Image.FromFile(selectedFilePath);
                        if (!Directory.Exists(Shared.folderPath))
                            Directory.CreateDirectory(Shared.folderPath);
                        string newFilePath = Path.Combine(Shared.folderPath, $"{ProductBarcodeTextBox.Text}.{Products.imageExtension}");
                        File.Copy(selectedFilePath, newFilePath, true);
                    }
                    else
                        Shared.ErrorOccuredMessageBox("You did not choose an image!");
                }
            }

        }
        #endregion

        #endregion

        #region Events

        #region Button Click
        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            if (IsDataFilledCorrectly())
                if (!DoesProductAlreadyExist())
                    try
                    {
                        if (withPhoto.Checked)
                            ImportProductImage();

                        using (var cmd = new SqlCommand("AddNewProduct", Shared.conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@barcode", barcode);
                            cmd.Parameters.AddWithValue("@name", ProductNameTextBox.Text);
                            cmd.Parameters.AddWithValue("@specification", SpecificationRichBox.Text);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }
                        Shared.ProcessIsDoneMessageBox("product", "added");
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
                    Shared.IgnoredProcess("The Product already exists , please update it using update button");
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

        private void AddWithPhotoRadio_CheckedChanged(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
        }

        private void ProductBarcodeTextBox_TextChanged(object sender, EventArgs e)
        {
            AddBtn.Enabled = ProductNameTextBox.TextLength > 0 && ProductBarcodeTextBox.TextLength > 0;
        }

        private void ProductNameTextBox_TextChanged(object sender, EventArgs e)
        {
            AddBtn.Enabled = ProductNameTextBox.TextLength > 0 && ProductBarcodeTextBox.TextLength > 0;
        }
        #endregion

    }
}
