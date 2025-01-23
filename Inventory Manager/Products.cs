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
        #region essential_data

        //holding data that will affect on the database
        private int id_value, barcode_value;
        private string name_value;
        private double price_value;
        public static string imageExtension = "jpg";

        public Products()
        {
            InitializeComponent();
            Shared.ConnectionInitializer();
            this.productTableAdapter.Connection.ConnectionString = Shared.conn.ConnectionString;
            this.note.Text = Shared.NoticeModifier("product");
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
            dataGridView1.Columns[3].Visible = Shared.isVisibleForDeveloper;
            ImageSetterByBarcode();
        }
        //database table dataview 
        private void Product_Load(object sender, EventArgs e)
        {
            this.productTableAdapter.Fill(this.productDataSet.Product);
            ShowData();
        }

        #endregion

        #region startup_functions

        #region for shortcuts
        //Shortcuts for window
        private void KeysShortcuts(object sender, KeyEventArgs e)
        {
            Shared.KeysShortcuts(sender, e, this);
        }
        #endregion

        //Update the data of Product's table
        public void ShowData()
        {
            Shared.ShowAllData(dataGridView1, "Product", "ID");
        }
        public void ResetFields()
        {
            product_id_text_box.Text =
            product_barcode_text_box.Text =
            product_name_text_box.Text = "";
        }
        #endregion

        #region Get Image Functions
        private void ImageSetterByBarcode(string barcode = "none")
        {
            var path = $@"{Shared.DocumentsPath}\{Shared.DirectoryName}\";
            Image noSource = null;

            #region default icon
            try
            {
                noSource = Image.FromFile($@"{path}noitem.png");
            }
            catch { }


            if (noSource != null)
                productIcon.Image = noSource;

            else
            {
                try
                {
                    var a = new WebClient();
                    a.DownloadFile("https://cdn-icons-png.flaticon.com/512/9018/9018889.png", "noitem.png");
                    File.Copy("noitem.png", $"{path}noitem.png");
                    File.Delete("noitem.png");
                }
                catch (Exception a) { MessageBox.Show(a.Message); }

                productIcon.Image = null;
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
                        productIcon.Image = Source;
                    else if (noSource != null)
                        productIcon.Image = noSource;
                    else
                        productIcon.Image = null;
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

        #region validation_functions
        //Check if the text boxes were empty
        private bool Chech_If_Text_Boxes_Were_Empty()
        {
            if (String.IsNullOrEmpty(product_name_text_box.Text))
            {
                if (String.IsNullOrEmpty(product_name_text_box.Text))
                {
                    MessageBox.Show("Please Enter name of the product", "Inventory Management System");
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
                name_value = product_name_text_box.Text;
                if (!int.TryParse(product_barcode_text_box.Text, out barcode_value) || barcode_value < 0)
                {
                    MessageBox.Show("Please enter a valid value for the barcode field");
                    return false;
                }
                return true;
            }
            return false;
        }
        //At least requriements to update or delete records
        public bool At_Least_Input_Requriements()
        {
            if (product_id_text_box.Text == ""
                && product_name_text_box.Text == ""
                && product_barcode_text_box.Text == "")
            {
                MessageBox.Show("Please type a name , id , or barcode at least to perform this action", "Inventory Management System");
                return false;
            }
            if (!int.TryParse(product_id_text_box.Text, out id_value)
                && product_name_text_box.Text == ""
                && product_barcode_text_box.Text == "")
            {
                MessageBox.Show("Please enter a valid value for the id field");
                return false;
            }
            if (!int.TryParse(product_barcode_text_box.Text, out barcode_value)
                && product_name_text_box.Text == ""
                && product_id_text_box.Text == "")
            {
                MessageBox.Show("Please enter a valid value for the barcode field");
                return false;
            }
            name_value = product_name_text_box.Text;
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

        #region buttons

        #region save_button
        //save product
        private void button1_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            if (Validation_of_input())
                if (!Check_If_Product_Already_Exists())
                {
                    string name_value = product_name_text_box.Text;
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
                                        productIcon.Image = Image.FromFile(selectedFilePath);
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
                                        MessageBox.Show("You did not choose an image!");
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

                        MessageBox.Show("Data inserted successfully!");
                        Shared.cmd.Parameters.Clear();
                        ShowData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        Shared.cmd.Dispose();
                        Shared.conn.Close();
                    }
                }
                else if (Check_If_Product_Already_Exists())
                {
                    MessageBox.Show("The Product already exists , please update it using update button");
                }
        }
        #endregion

        #region update_button
        //update existing product's id or name
        private void button2_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();

            if (At_Least_Input_Requriements())
                if (Check_If_Product_Already_Exists())
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

                                    if (!string.IsNullOrEmpty(product_id_text_box.Text))
                                    {
                                        newFilePath = Path.Combine(folderPath, $"{Shared.ProductBarcodeGetter("ID", product_id_text_box)}.{imageExtension}");
                                    }
                                    else if (!string.IsNullOrEmpty(product_barcode_text_box.Text))
                                    {
                                        newFilePath = Path.Combine(folderPath, $"{barcode_value}.{imageExtension}");
                                    }
                                    else
                                    {
                                        newFilePath = Path.Combine(folderPath, $"{Shared.ProductBarcodeGetter("Name", product_name_text_box)}.{imageExtension}");

                                    }
                                    File.Copy(selectedFilePath, newFilePath, true);
                                    var changeOnForm = new FileStream(newFilePath, FileMode.Open);
                                    productIcon.Image = Image.FromStream(changeOnForm);
                                    changeOnForm.Close();
                                    changeOnForm.Dispose();
                                }
                                else
                                {
                                    MessageBox.Show("You did not choose an image!");
                                }

                            }
                        }

                        #endregion

                        #region Update name logic

                        if (withName.Checked)
                        {
                            if (product_id_text_box.Text != ""
                                || product_barcode_text_box.Text != "")
                            {
                                if (product_name_text_box.Text != "")
                                {
                                    if (product_id_text_box.Text != "")
                                    {
                                        if (!int.TryParse(product_id_text_box.Text, out id_value))
                                        {
                                            MessageBox.Show("Please enter a valid value for the id field");
                                            return;
                                        }
                                        updateCmd.CommandText = @"UPDATE Product 
                                                              SET name = @name 
                                                              WHERE id = @id";
                                        updateCmd.ExecuteNonQuery();

                                        updateCmd.CommandText = @"UPDATE ProductReport 
                                                              SET product_name = @name 
                                                              WHERE product_id = @id";
                                    }
                                    else
                                    {
                                        if (!int.TryParse(product_barcode_text_box.Text, out barcode_value))
                                        {
                                            MessageBox.Show("Please enter a valid value for the barcode field");
                                            return;
                                        }
                                        updateCmd.CommandText = @"UPDATE Product 
                                                              SET name = @name 
                                                              WHERE barcode = @barcode";
                                        updateCmd.ExecuteNonQuery();

                                        updateCmd.CommandText = @"UPDATE ProductReport 
                                                              SET product_name = @name 
                                                              WHERE product_barcode = @barcode";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Product name can not be empty");
                                    return;
                                }
                            }

                            else
                            {
                                MessageBox.Show("Type id or barcode to update the name");
                                return;
                            }

                            int.TryParse(updateCmd.ExecuteNonQuery().ToString(), out int rowsAffected);

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Product's name updated successfully.");
                            }
                            else
                            {
                                MessageBox.Show("No product was updated.");
                            }
                        }

                        #endregion

                        #region Update specification logic

                        if (withSpecification.Checked)
                        {
                            if (product_id_text_box.Text != ""
                                || product_barcode_text_box.Text != ""
                                || product_name_text_box.Text != "")
                            {
                                if (SpecificationRichBox.Text != "")
                                {
                                    if (product_id_text_box.Text != "")
                                    {
                                        if (!int.TryParse(product_id_text_box.Text, out id_value))
                                        {
                                            MessageBox.Show("Please enter a valid value for the id field");
                                            return;
                                        }
                                        updateCmd.CommandText = @"UPDATE Product 
                                                              SET specification = @specification_value 
                                                              WHERE id = @id";
                                    }
                                    else if (product_barcode_text_box.Text != "")
                                    {
                                        if (!int.TryParse(product_barcode_text_box.Text, out barcode_value))
                                        {
                                            MessageBox.Show("Please enter a valid value for the barcode field");
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
                                    MessageBox.Show("Product specification can not be empty");
                                    return;
                                }
                            }

                            else
                            {
                                MessageBox.Show("Type id , barcode or name to update the specification");
                                return;
                            }

                            int.TryParse(updateCmd.ExecuteNonQuery().ToString(), out int rowsAffected);

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Product's specification updated successfully.");
                            }
                            else
                            {
                                MessageBox.Show("No product was updated.");
                            }
                        }

                        #endregion

                    }
                }
                else
                {
                    MessageBox.Show("The Product doesn't exists");
                }

            ShowData();
            Shared.conn.Close();
            return;
        }
        #endregion

        #region delete_button
        //Delete a product
        private void button3_Click(object sender, EventArgs e)
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
                                if (product_id_text_box.Text != "")
                                {
                                    #region Delete icon logic
                                    try
                                    {
                                        File.Delete($@"{Shared.DocumentsPath}\{Shared.DirectoryName}\{Shared.ProductBarcodeGetter("ID", product_id_text_box)}.{imageExtension}");
                                    }
                                    catch (Exception m) { MessageBox.Show(m.Message); }
                                    #endregion


                                    cmd.CommandText = "DELETE FROM Product WHERE id = @id";
                                }

                                else if (product_barcode_text_box.Text != "")
                                {
                                    #region Delete icon logic
                                    try
                                    {
                                        var Command = $@"SELECT  barcode
                                             FROM Product
                                             WHERE
                                             barcode = @barcode";
                                        File.Delete($@"{Shared.DocumentsPath}\{Shared.DirectoryName}\{product_barcode_text_box.Text}.{imageExtension}");
                                    }
                                    catch (Exception m) { MessageBox.Show(m.Message); }
                                    #endregion

                                    cmd.CommandText = "DELETE FROM Product WHERE barcode = @barcode";
                                }

                                else if (product_name_text_box.Text != "")
                                {
                                    #region Delete icon logic
                                    try
                                    {
                                        var Command = $@"SELECT  barcode
                                             FROM Product
                                             WHERE
                                             name = @name";

                                        File.Delete($@"{Shared.DocumentsPath}\{Shared.DirectoryName}\{Shared.ProductBarcodeGetter("Name", product_name_text_box)}.{imageExtension}");
                                    }
                                    catch (Exception m) { MessageBox.Show(m.Message); }
                                    #endregion

                                    cmd.CommandText = "DELETE FROM Product WHERE name = @name";
                                }

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Record deleted successfully.");
                                }
                                else
                                {
                                    MessageBox.Show("No record found with the specified name or id.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
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
                        MessageBox.Show("The Product doesn't exists");
                    }
            }
            else
            {
                MessageBox.Show("Nothing has been changed", "Inventory Management System");
                ShowData();
            }
        }
        #endregion

        #region Reset_button
        //Reset filters and view
        private void printBtn_Click(object sender, EventArgs e)
        {
            ResetFields();
            ImageSetterByBarcode();
            ShowData();
        }
        #endregion

        #endregion

        #region Events For Searching

        #region While Typing
        private void product_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, product_name_text_box, "Product", "Name", "ID");
            ImageSetterByBarcode(Shared.ProductBarcodeGetter("Name", product_name_text_box));
        }

        private void product_barcode_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, product_barcode_text_box, "Product", "Barcode", "ID", false, "product barcode");
            ImageSetterByBarcode(Shared.ProductBarcodeGetter("Barcode", product_barcode_text_box));
        }

        private void product_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, product_id_text_box, "Product", "id", "ID", false, "product ID");
            ImageSetterByBarcode(Shared.ProductBarcodeGetter("ID", product_id_text_box));
        }

        #endregion


        #region Click on a cell
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            ResetFields();
            var text = dataGridView1.CurrentCell.Value.ToString();
            var columnIndex = dataGridView1.CurrentCellAddress.X;
            var rowIndex = dataGridView1.CurrentCellAddress.Y;
            var c = new KeyEventArgs(Keys.NoName);

            switch (columnIndex)
            {
                case 0:
                    product_id_text_box.Text = text;
                    product_id_text_box_KeyUp(sender, c);
                    break;
                case 1:
                    product_barcode_text_box.Text = text;
                    product_barcode_text_box_KeyUp(sender, c);
                    break;
                case 2:
                    product_name_text_box.Text = text;
                    product_name_text_box_KeyUp(sender, c);
                    break;
            }
            ShowData();
            dataGridView1.CurrentCell = dataGridView1[columnIndex, rowIndex];
        }
        #endregion

        #endregion

    }
}       