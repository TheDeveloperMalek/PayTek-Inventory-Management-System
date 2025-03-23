using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;
namespace Inventory_Manager
{
    public partial class EditProduct : Form
    {

        #region Essential data
        readonly Products callerForm;

        public EditProduct(Products r)
        {
            InitializeComponent();
            callerForm = r;
            Shared.TextBoxAutoCompleteFromColumnGuna("Product", "id", ProductIdTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Product", "barcode", ProductBarcodeTextBox);
            Shared.TextBoxAutoCompleteFromColumnGuna("Product", "name", ProductNameTextBox);
        }
        #endregion

        #region Validation Functions
        int id, barcode;

        public bool IsDataFilledCorrectly()
        {
            if (ProductIdTextBox.Text is ""
                && ProductNameTextBox.Text is ""
                && ProductBarcodeTextBox.Text is "")
            {
                Shared.ErrorOccuredMessageBox("Please type id , barcode or name at least to perform this action");
                return false;
            }
            if (!int.TryParse(ProductIdTextBox.Text, out id) && id < 0
                && ProductNameTextBox.Text is ""
                && ProductBarcodeTextBox.Text is "")
            {
                Shared.ErrorOccuredMessageBox("Please enter a valid value for the id field");
                return false;
            }
            if (!int.TryParse(ProductBarcodeTextBox.Text, out barcode) && barcode < 0
                && ProductNameTextBox.Text is ""
                && ProductIdTextBox.Text is "")
            {
                Shared.ErrorOccuredMessageBox("Please enter a valid value for the barcode field");
                return false;
            }
            return true;
        }

        private bool DoesProductAlreadyExist()
        {
            using (SqlCommand checkCmd = new SqlCommand("GetExistedProductsNumberByIdBarcodeName", Shared.conn))
            {
                checkCmd.CommandType = CommandType.StoredProcedure;
                checkCmd.Parameters.AddWithValue("@id", id);
                checkCmd.Parameters.AddWithValue("@barcode", barcode);
                checkCmd.Parameters.AddWithValue("@name", ProductNameTextBox.Text);

                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);
                return productCount > 0;
            }
        }

        #endregion

        #region Data Manipulation Functions
        private void ImportProductImage()
        {
            string newFilePath;
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = $"Image File(*.{Products.imageExtension})|*.{Products.imageExtension}";
                ofd.Title = "Import image for the product";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = ofd.FileName;
                    if (!Directory.Exists(Shared.folderPath))
                        Directory.CreateDirectory(Shared.folderPath);

                    if (!string.IsNullOrEmpty(ProductIdTextBox.Text))
                        newFilePath = Path.Combine(Shared.folderPath, $"{Shared.ProductBarcodeGetterGuna("ID", ProductIdTextBox)}.{Products.imageExtension}");
                    else if (!string.IsNullOrEmpty(ProductBarcodeTextBox.Text))
                        newFilePath = Path.Combine(Shared.folderPath, $"{barcode}.{Products.imageExtension}");
                    else
                        newFilePath = Path.Combine(Shared.folderPath, $"{Shared.ProductBarcodeGetterGuna("Name", ProductNameTextBox)}.{Products.imageExtension}");

                    File.Copy(selectedFilePath, newFilePath, true);
                }
                else
                    Shared.ErrorOccuredMessageBox("You did not choose an image!");
            }


        }

        private void UpdateName(SqlCommand updateCmd)
        {
            updateCmd.Parameters.AddWithValue("@name", ProductNameTextBox.Text);
            if (ProductIdTextBox.Text != "" || ProductBarcodeTextBox.Text != "")
            {
                if (ProductNameTextBox.Text != "")
                {
                    if (ProductIdTextBox.Text != "")
                    {
                        if (!int.TryParse(ProductIdTextBox.Text, out id))
                        {
                            Shared.ErrorOccuredMessageBox("Please enter a valid value for the id field");
                            return;
                        }
                        updateCmd.Parameters.AddWithValue("@id", id);
                        updateCmd.CommandText = "EditProductNameById";
                    }
                    else
                    {
                        if (!int.TryParse(ProductBarcodeTextBox.Text, out barcode))
                        {
                            Shared.ErrorOccuredMessageBox("Please enter a valid value for the barcode field");
                            return;
                        }
                        updateCmd.Parameters.AddWithValue("@barcode", barcode);
                        updateCmd.CommandText = "EditProductNameByBarcode";
                    }
                }
                else
                {
                    Shared.ErrorOccuredMessageBox("Product name can not be empty");
                    return;
                }
            }

            else
            {
                Shared.ErrorOccuredMessageBox("Type id or barcode to edit the name");
                return;
            }

            updateCmd.ExecuteNonQuery();
            updateCmd.Parameters.Clear();
            Shared.ProcessIsDoneMessageBox("product's name", "edited");

        }

        private void UpdateSpecification(SqlCommand updateCmd)
        {
            updateCmd.Parameters.AddWithValue("@specification", SpecificationRichBox.Text);
            if (ProductIdTextBox.Text != ""
                    || ProductBarcodeTextBox.Text != ""
                    || ProductNameTextBox.Text != "")
            {
                if (SpecificationRichBox.Text != "")
                {
                    if (ProductIdTextBox.Text != "")
                    {
                        if (!int.TryParse(ProductIdTextBox.Text, out id))
                        {
                            Shared.ErrorOccuredMessageBox("Please enter a valid value for the id field");
                            return;
                        }
                        updateCmd.Parameters.AddWithValue("@id", id);
                        updateCmd.CommandText = "EditSpecificationById";
                    }
                    else if (ProductBarcodeTextBox.Text != "")
                    {
                        if (!int.TryParse(ProductBarcodeTextBox.Text, out barcode))
                        {
                            Shared.ErrorOccuredMessageBox("Please enter a valid value for the barcode field");
                            return;
                        }
                        updateCmd.Parameters.AddWithValue("@barcode", barcode);
                        updateCmd.CommandText = "EditSpecificationByBarcode";
                    }
                    else
                    {
                        updateCmd.Parameters.AddWithValue("@name", ProductNameTextBox.Text);
                        updateCmd.CommandText = "EditSpecificationByName";
                    }
                }
                else
                {
                    Shared.ErrorOccuredMessageBox("Product's specification can not be empty");
                    return;
                }
            }

            else
            {
                Shared.ErrorOccuredMessageBox("Type id , barcode or name to edit the specification");
                return;
            }

            updateCmd.ExecuteNonQuery();
            updateCmd.Parameters.Clear();
            Shared.ProcessIsDoneMessageBox("product's specification", "edited");

        }
        #endregion

        #region Events

        #region Click Button
        private void EditUserBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            if (IsDataFilledCorrectly())
                if (DoesProductAlreadyExist())
                {
                    try
                    {
                        string storedProcedure = "";
                        using (var editCmd = new SqlCommand(storedProcedure, Shared.conn))
                        {
                            editCmd.CommandType = CommandType.StoredProcedure;

                            if (withPhoto.Checked)
                                ImportProductImage();

                            if (withName.Checked)
                                UpdateName(editCmd);

                            if (withSpecification.Checked)
                                UpdateSpecification(editCmd);

                        }
                    }
                    catch (Exception exc)
                    {
                        Shared.ErrorOccuredMessageBox(exc.Message);
                    }
                    finally
                    {
                        Shared.conn.Close();
                    }
                }
                else
                    Shared.ErrorOccuredMessageBox("The Product doesn't exists");

        }

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.FadeOutEffect(this, 5);
        }

        #endregion

        private void UpdateWithSpecificationRadio_CheckedChanged(object sender, EventArgs e)
        {
            SpecificationRichBox.Enabled = !SpecificationRichBox.Enabled;
            EditBtn.Enabled = (withSpecification.Checked && SpecificationRichBox.TextLength > 0) ||
                 (withName.Checked && ProductNameTextBox.TextLength > 0) || withPhoto.Checked;
            Shared.PlayClickSound();
        }

        private void UpdateWithNameRadio_CheckedChanged(object sender, EventArgs e)
        {
            ProductNameTextBox.Enabled = !ProductNameTextBox.Enabled;
            EditBtn.Enabled = (withSpecification.Checked && SpecificationRichBox.TextLength > 0) ||
                 (withName.Checked && ProductNameTextBox.TextLength > 0) || withPhoto.Checked;
            Shared.PlayClickSound();
        }

        private void UpdateWithPhotoRadio_CheckedChanged(object sender, EventArgs e)
        {
            EditBtn.Enabled = (withSpecification.Checked && SpecificationRichBox.TextLength > 0) ||
                 (withName.Checked && ProductNameTextBox.TextLength > 0) || withPhoto.Checked;
            Shared.PlayClickSound();
        }

        private void ProductIdTextBox_TextChanged(object sender, EventArgs e)
        {
            EditBtn.Enabled = ProductIdTextBox.TextLength > 0 && ( (withSpecification.Checked && SpecificationRichBox.TextLength > 0)
                || (withName.Checked && ProductNameTextBox.TextLength > 0)
                || withPhoto.Checked);
            ProductBarcodeTextBox.Enabled = ProductIdTextBox.TextLength == 0;
            withPhoto.Enabled = withName.Enabled = withSpecification.Enabled = ProductIdTextBox.TextLength > 0;
        }

        private void ProductBarcodeTextBox_TextChanged(object sender, EventArgs e)
        {
            EditBtn.Enabled = ProductBarcodeTextBox.TextLength > 0 && ((withSpecification.Checked && SpecificationRichBox.TextLength > 0)
                 || (withName.Checked && ProductNameTextBox.TextLength > 0)
                 || withPhoto.Checked);
            ProductIdTextBox.Enabled = ProductBarcodeTextBox.TextLength == 0;
            withPhoto.Enabled = withName.Enabled = withSpecification.Enabled = ProductBarcodeTextBox.TextLength > 0;
        }

        private void ProductNameTextBox_TextChanged(object sender, EventArgs e)
        {
            EditBtn.Enabled = (withSpecification.Checked && SpecificationRichBox.TextLength > 0) ||
                 (withName.Checked && ProductNameTextBox.TextLength > 0) || withPhoto.Checked;
        }

        private void SpecificationRichBox_TextChanged(object sender, EventArgs e)
        {
            EditBtn.Enabled = (withSpecification.Checked && SpecificationRichBox.TextLength > 0) ||
                 (withName.Checked && ProductNameTextBox.TextLength > 0) || withPhoto.Checked;
        }

        private void AddNewUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            callerForm.ShowData();
        }
        #endregion

    }
}
