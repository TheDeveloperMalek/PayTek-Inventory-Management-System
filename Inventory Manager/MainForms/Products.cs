using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
namespace Inventory_Manager
{
    public partial class Products : Form
    {
        #region essential Data

        //holding data that will affect on the database
        private int id_value, barcode_value;
        private string name_value;
        public static string imageExtension = "jpg";

        public Products()
        {
            InitializeComponent();
            Shared.ConnectionInitializer();
            this.productTableAdapter.Connection.ConnectionString = Shared.conn.ConnectionString;
            this.note.Text = Shared.NoticeModifier("product");
            dataGridView1.Columns[3].Visible = Shared.isVisibleForDeveloper;
            ImageSetterByBarcode();
        }
        //database table dataview 
        private void Product_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'productDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.productDataSet.Product);
            this.productTableAdapter.Fill(this.productDataSet.Product);
            ShowData();
            Shared.TextBoxAutoCompleteFromColumn("Product", "ID", ProductIdTextBox);
            Shared.TextBoxAutoCompleteFromColumn("Product", "Barcode", ProductBarcodeTextBox);
            Shared.TextBoxAutoCompleteFromColumn("Product", "Name", ProductNameTextBox);
        }

        #endregion

        #region Startup functions
        public void ShowData()
        {
            Shared.ShowAllTableData(dataGridView1, "Product", "ID");
        }
        #endregion

        #region Get image functions
        private void ImageSetterByBarcode(string barcode = "none")
        {
            var path = $@"{Shared.documentsPath}\{Shared.programDirectoryName}\";
            Image noSource = null;

            #region default icon
            try
            {
                noSource = Image.FromFile($@"{path}noitem.png");
            }
            catch { }


            if (noSource != null)
                ProductImage.Image = noSource;

            else
            {
                try
                {
                    var a = new WebClient();
                    a.DownloadFile("https://cdn-icons-png.flaticon.com/512/9018/9018889.png", "noitem.png");
                    File.Copy("noitem.png", $"{path}noitem.png");
                    File.Delete("noitem.png");
                }
                catch (Exception a) { Shared.ErrorOccuredMessageBox(a.Message); }

                ProductImage.Image = null;
            }
            #endregion

            #region custom icon

            if (barcode != "none")
            {
                FileStream customSource = null;
                try
                {
                    customSource = new FileStream($@"{path}{barcode}.{imageExtension}", FileMode.Open);
                    var Source = Image.FromStream(customSource);
                    if (Source != null)
                        ProductImage.Image = Source;
                    else if (noSource != null)
                        ProductImage.Image = noSource;
                    else
                        ProductImage.Image = null;
                }

                catch { }
                finally
                {
                    if (customSource != null)
                    {
                        customSource.Close();
                        customSource.Dispose();

                    }
                }

            }
            #endregion

        }

        #endregion

        #region Validation functions
        //Check if the text boxes were empty
        private bool Chech_If_Text_Boxes_Were_Empty()
        {
            if (String.IsNullOrEmpty(ProductNameTextBox.Text))
            {
                if (String.IsNullOrEmpty(ProductNameTextBox.Text))
                {
                    Shared.ErrorOccuredMessageBox("Please enter name of the product");
                    return true;
                }
            }
            return false;
        }

        //Check the validity of user input
        public bool Validation_of_input()
        {
            Shared.ConnectionInitializer();
            if (!Chech_If_Text_Boxes_Were_Empty())
            {
                name_value = ProductNameTextBox.Text;
                if (!int.TryParse(ProductBarcodeTextBox.Text, out barcode_value) || barcode_value < 0)
                {
                    Shared.ErrorOccuredMessageBox("Please enter a valid value for the barcode field");
                    return false;
                }
                return true;
            }
            return false;
        }
        //At least requriements to update or delete records
        public bool At_Least_Input_Requriements()
        {
            if (ProductIdTextBox.Text == ""
                && ProductNameTextBox.Text == ""
                && ProductBarcodeTextBox.Text == "")
            {
                Shared.ErrorOccuredMessageBox("Please type a name , id , or barcode at least to perform this action");
                return false;
            }
            if (!int.TryParse(ProductIdTextBox.Text, out id_value)
                && ProductNameTextBox.Text == ""
                && ProductBarcodeTextBox.Text == "")
            {
                Shared.ErrorOccuredMessageBox("Please enter a valid value for the id field");
                return false;
            }
            if (!int.TryParse(ProductBarcodeTextBox.Text, out barcode_value)
                && ProductNameTextBox.Text == ""
                && ProductIdTextBox.Text == "")
            {
                Shared.ErrorOccuredMessageBox("Please enter a valid value for the barcode field");
                return false;
            }
            name_value = ProductNameTextBox.Text;
            return true;
        }

        //Chech if the current product exists or not
        private bool Check_If_Product_Already_Exists()
        {
            string checkQuery = "SELECT COUNT(*) FROM Product WHERE name = @name OR  id = @id or barcode = @barcode ";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, Shared.conn))
            {
                checkCmd.Parameters.AddWithValue("@id", id_value);
                checkCmd.Parameters.AddWithValue("@barcode", barcode_value);
                checkCmd.Parameters.AddWithValue("@name", name_value);

                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);

                if (productCount > 0)
                {
                    return true;
                }
                return false;
            }
        }
        #endregion

        #region Buttons

        #region Add button
        private void AddProductBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            if (Validation_of_input())
                if (!Check_If_Product_Already_Exists())
                {
                    string name_value = ProductNameTextBox.Text;
                    try
                    {
                        #region Export image logic
                        if (withPhoto.Checked)
                        {
                            using (var ofd = new OpenFileDialog())
                            {
                                ofd.Filter = $"Image File(*.{imageExtension})|*.{imageExtension}";
                                ofd.Title = "Import image for the product";
                                ofd.ShowDialog();
                                using (var svf = new SaveFileDialog())
                                {
                                    if (ofd.FileName != "")
                                    {
                                        string selectedFilePath = ofd.FileName;
                                        ProductImage.Image = Image.FromFile(selectedFilePath);
                                        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PayTek Inventory Management System");
                                        if (!Directory.Exists(folderPath))
                                        {
                                            Directory.CreateDirectory(folderPath);
                                        }
                                        string newFilePath = Path.Combine(folderPath, $"{barcode_value}.{imageExtension}");
                                        File.Copy(selectedFilePath, newFilePath, true);
                                    }
                                    else
                                    {
                                        Shared.ErrorOccuredMessageBox("You did not choose an image!");
                                    }
                                }
                            }
                        }
                        #endregion

                        using (SqlCommand cmd = Shared.conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@id_value", id_value);
                            cmd.Parameters.AddWithValue("@barcode_value", barcode_value);
                            cmd.Parameters.AddWithValue("@name_value", name_value);
                            cmd.Parameters.AddWithValue("@status_value", "Added new product");
                            cmd.Parameters.AddWithValue("@specification_value", SpecificationRichBox.Text);
                            cmd.Parameters.AddWithValue("@date_value", DateTime.Now);

                            cmd.CommandText = $@"INSERT INTO Product (barcode , name, quantity , specification , date) 
                                                VALUES (
                                                        @barcode_value ,
                                                        @name_value,
                                                        0 , 
                                                        @specification_value ,
                                                        @date_value
                                                        )
                                                ";
                            cmd.ExecuteNonQuery();

                        }
                        Shared.ProcessIsDoneMessageBox("product" , "added");
                        Shared.cmd.Parameters.Clear();
                        ShowData();
                    }
                    catch (Exception ex)
                    {
                        Shared.ErrorOccuredMessageBox(ex.Message);
                    }
                    finally
                    {
                        Shared.cmd.Dispose();
                        Shared.conn.Close();
                    }
                }
                else if (Check_If_Product_Already_Exists())
                {
                    Shared.IgnoredProcess("The Product already exists , please update it using update button");
                }
        }
        #endregion

        #region Edit Button
        private void EditProductBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();

            if (At_Least_Input_Requriements())
                if (Check_If_Product_Already_Exists())
                {
                    try
                    {
                        using (SqlCommand updateCmd = Shared.conn.CreateCommand())
                        {
                            updateCmd.CommandType = CommandType.Text;
                            updateCmd.Parameters.AddWithValue("@id", id_value);
                            updateCmd.Parameters.AddWithValue("@barcode", barcode_value);
                            updateCmd.Parameters.AddWithValue("@name", name_value);
                            updateCmd.Parameters.AddWithValue("@date", DateTime.Now);
                            updateCmd.Parameters.AddWithValue("@specification_value", SpecificationRichBox.Text);


                            #region Import image logic

                            if (withPhoto.Checked)
                            {
                                string newFilePath = "";
                                using (var ofd = new OpenFileDialog())
                                {
                                    ofd.Filter = $"Image File(*.{imageExtension})|*.{imageExtension}";
                                    ofd.Title = "Import image for the product";

                                    if (ofd.ShowDialog() == DialogResult.OK)
                                    {
                                        string selectedFilePath = ofd.FileName;



                                        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PayTek Inventory Management System\\");
                                        if (!Directory.Exists(folderPath))
                                        {
                                            Directory.CreateDirectory(folderPath);
                                        }

                                        if (!string.IsNullOrEmpty(ProductIdTextBox.Text))
                                        {
                                            newFilePath = Path.Combine(folderPath, $"{Shared.ProductBarcodeGetter("ID", ProductIdTextBox)}.{imageExtension}");
                                        }
                                        else if (!string.IsNullOrEmpty(ProductBarcodeTextBox.Text))
                                        {
                                            newFilePath = Path.Combine(folderPath, $"{barcode_value}.{imageExtension}");
                                        }
                                        else
                                        {
                                            newFilePath = Path.Combine(folderPath, $"{Shared.ProductBarcodeGetter("Name", ProductNameTextBox)}.{imageExtension}");

                                        }
                                        File.Copy(selectedFilePath, newFilePath, true);
                                        var changeOnForm = new FileStream(newFilePath, FileMode.Open);
                                        ProductImage.Image = Image.FromStream(changeOnForm);
                                        changeOnForm.Close();
                                        changeOnForm.Dispose();
                                    }
                                    else
                                    {
                                        Shared.ErrorOccuredMessageBox("You did not choose an image!");
                                    }

                                }
                            }

                            #endregion

                            #region Update name logic

                            if (withName.Checked)
                            {
                                if (ProductIdTextBox.Text != ""
                                    || ProductBarcodeTextBox.Text != "")
                                {
                                    if (ProductNameTextBox.Text != "")
                                    {
                                        if (ProductIdTextBox.Text != "")
                                        {
                                            if (!int.TryParse(ProductIdTextBox.Text, out id_value))
                                            {
                                                Shared.ErrorOccuredMessageBox("Please enter a valid value for the id field");
                                                return;
                                            }
                                            updateCmd.CommandText = @"UPDATE Product 
                                                              SET name = @name 
                                                              WHERE id = @id";
                                            updateCmd.ExecuteNonQuery();

                                            updateCmd.CommandText = @"UPDATE ProductReport 
                                                              SET ""Product Name"" = @name 
                                                              WHERE ""Product ID""= @id";
                                            updateCmd.ExecuteNonQuery();

                                            updateCmd.CommandText = @"UPDATE InventoryReport 
                                                              SET ""Product Name"" = @name 
                                                              WHERE ""Product ID""= @id";
                                        }
                                        else
                                        {
                                            if (!int.TryParse(ProductBarcodeTextBox.Text, out barcode_value))
                                            {
                                                Shared.ErrorOccuredMessageBox("Please enter a valid value for the barcode field");
                                                return;
                                            }
                                            updateCmd.CommandText = @"UPDATE Product 
                                                              SET name = @name 
                                                              WHERE barcode = @barcode";
                                            updateCmd.ExecuteNonQuery();

                                            updateCmd.CommandText = @"UPDATE ProductReport 
                                                              SET ""Product Name"" = @name 
                                                              WHERE ""Product Barcode"" = @barcode";
                                            updateCmd.ExecuteNonQuery();

                                            updateCmd.CommandText = @"UPDATE InventoryReport 
                                                              SET ""Product Name"" = @name 
                                                              WHERE ""Product Barcode"" = @barcode";
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
                                    Shared.ErrorOccuredMessageBox("Type id or barcode to update the name");
                                    return;
                                }

                                int.TryParse(updateCmd.ExecuteNonQuery().ToString(), out int rowsAffected);

                                if (rowsAffected > 0)
                                {
                                    Shared.ProcessIsDoneMessageBox("product's name" , "edited");
                                }
                                else
                                {
                                    Shared.IgnoredProcess("No product was edited");
                                }
                            }

                            #endregion

                            #region Update specification logic

                            if (withSpecification.Checked)
                            {
                                if (ProductIdTextBox.Text != ""
                                    || ProductBarcodeTextBox.Text != ""
                                    || ProductNameTextBox.Text != "")
                                {
                                    if (SpecificationRichBox.Text != "")
                                    {
                                        if (ProductIdTextBox.Text != "")
                                        {
                                            if (!int.TryParse(ProductIdTextBox.Text, out id_value))
                                            {
                                                Shared.ErrorOccuredMessageBox("Please enter a valid value for the id field");
                                                return;
                                            }
                                            updateCmd.CommandText = @"UPDATE Product 
                                                              SET specification = @specification_value 
                                                              WHERE id = @id";
                                        }
                                        else if (ProductBarcodeTextBox.Text != "")
                                        {
                                            if (!int.TryParse(ProductBarcodeTextBox.Text, out barcode_value))
                                            {
                                                Shared.ErrorOccuredMessageBox("Please enter a valid value for the barcode field");
                                                return;
                                            }
                                            updateCmd.CommandText = @"UPDATE Product 
                                                              SET specification = @specification_value  
                                                              WHERE barcode = @barcode";
                                        }
                                        else
                                        {
                                            updateCmd.CommandText = @"UPDATE Product 
                                                              SET specification = @specification_value  
                                                              WHERE name = @name";
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
                                    Shared.ErrorOccuredMessageBox("Type id , barcode or name to update the specification");
                                    return;
                                }

                                int.TryParse(updateCmd.ExecuteNonQuery().ToString(), out int rowsAffected);

                                if (rowsAffected > 0)
                                {
                                    Shared.ProcessIsDoneMessageBox("product's specification" , "edited");
                                }
                                else
                                {
                                    Shared.ErrorOccuredMessageBox("No product was edited");
                                }
                            }

                            #endregion

                        }
                    }
                    catch (Exception exc)
                    {
                        Shared.ErrorOccuredMessageBox(exc.Message);
                    }
                }
                else
                {
                    Shared.ErrorOccuredMessageBox("The Product doesn't exists");
                }

            ShowData();
            Shared.conn.Close();
            return;
        }
        #endregion

        #region Delete Button
        //Delete a product
        private void DeleteProductBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            DialogResult delete;
            delete = MessageBox.Show("Are you sure ?", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (delete == DialogResult.Yes)
            {
                if (At_Least_Input_Requriements())
                    if (Check_If_Product_Already_Exists())
                    {
                        try
                        {
                            using (SqlCommand cmd = Shared.conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@id", id_value);
                                cmd.Parameters.AddWithValue("@barcode", barcode_value);
                                cmd.Parameters.AddWithValue("@name", name_value);
                                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                                cmd.Parameters.AddWithValue("@status", "Deleted a product");
                                ImageSetterByBarcode();
                                if (ProductIdTextBox.Text != "")
                                {
                                    #region Delete icon logic
                                    try
                                    {
                                        File.Delete($@"{Shared.documentsPath}\{Shared.programDirectoryName}\{Shared.ProductBarcodeGetter("ID", ProductIdTextBox)}.{imageExtension}");
                                    }
                                    catch (Exception m) { Shared.ErrorOccuredMessageBox(m.Message); }
                                    #endregion


                                    cmd.CommandText = "DELETE FROM Product WHERE id = @id";
                                }

                                else if (ProductBarcodeTextBox.Text != "")
                                {
                                    #region Delete icon logic
                                    try
                                    {
                                        var Command = $@"SELECT  barcode
                                             FROM Product
                                             WHERE
                                             barcode = @barcode";
                                        File.Delete($@"{Shared.documentsPath}\{Shared.programDirectoryName}\{ProductBarcodeTextBox.Text}.{imageExtension}");
                                    }
                                    catch (Exception m) { Shared.ErrorOccuredMessageBox(m.Message); }
                                    #endregion

                                    cmd.CommandText = "DELETE FROM Product WHERE barcode = @barcode";
                                }

                                else if (ProductNameTextBox.Text != "")
                                {
                                    #region Delete icon logic
                                    try
                                    {
                                        var Command = $@"SELECT  barcode
                                             FROM Product
                                             WHERE
                                             name = @name";

                                        File.Delete($@"{Shared.documentsPath}\{Shared.programDirectoryName}\{Shared.ProductBarcodeGetter("Name", ProductNameTextBox)}.{imageExtension}");
                                    }
                                    catch (Exception m) { Shared.ErrorOccuredMessageBox(m.Message); }
                                    #endregion

                                    cmd.CommandText = "DELETE FROM Product WHERE name = @name";
                                }

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    Shared.ProcessIsDoneMessageBox("product" , "deleted");
                                }
                                else
                                {
                                    Shared.ErrorOccuredMessageBox("No record found with the specified name or id.");
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
                        ShowData();
                        return;
                    }
                    else
                    {
                        Shared.ErrorOccuredMessageBox("The product doesn't exists");
                    }
            }
            else
            {
                Shared.IgnoredProcess("Nothing has been changed");
                ShowData();
            }
        }
        #endregion

        #region Reset Button
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ResetFields(groupBox1);
            ImageSetterByBarcode();
            ShowData();
        }
        #endregion

        #endregion

        #region Events for searching

        #region While typing
        private void product_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, ProductNameTextBox, "Product", "Name", "ID");
            ImageSetterByBarcode(Shared.ProductBarcodeGetter("Name", ProductNameTextBox));
        }

        private void product_barcode_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, ProductBarcodeTextBox, "Product", "Barcode", "ID", false, "product barcode");
            ImageSetterByBarcode(Shared.ProductBarcodeGetter("Barcode", ProductBarcodeTextBox));
        }

        private void product_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, ProductIdTextBox, "Product", "id", "ID", false, "product ID");
            ImageSetterByBarcode(Shared.ProductBarcodeGetter("ID", ProductIdTextBox));
        }

        #endregion

        #region Click on a cell
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Shared.ResetFields(groupBox1);
            var text = dataGridView1.CurrentCell.Value.ToString();
            var columnIndex = dataGridView1.CurrentCellAddress.X;
            var rowIndex = dataGridView1.CurrentCellAddress.Y;
            var c = new KeyEventArgs(Keys.NoName);

            switch (columnIndex)
            {
                case 0:
                    ProductIdTextBox.Text = text;
                    product_id_text_box_KeyUp(sender, c);
                    break;
                case 1:
                    ProductBarcodeTextBox.Text = text;
                    product_barcode_text_box_KeyUp(sender, c);
                    break;
                case 2:
                    ProductNameTextBox.Text = text;
                    product_name_text_box_KeyUp(sender, c);
                    break;
            }
        }
        #endregion

        #endregion

    }
}