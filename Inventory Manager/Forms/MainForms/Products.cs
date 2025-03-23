using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Net;
namespace Inventory_Manager
{
    public partial class Products : Form
    {
        #region Essential Data

        //holding data that will affect on the database
        public static string imageExtension = "jpg";

        public Products()
        {
            InitializeComponent();
            Shared.ConnectionInitializer();
            this.productTableAdapter.Connection.ConnectionString = Shared.conn.ConnectionString;
            dataGridView1.Columns[3].Visible = Shared.isVisibleForDeveloper;
            ImageSetterByBarcode();
        }
        //database table dataview 
        private void Product_Load(object sender, EventArgs e)
        {
            this.productTableAdapter.Fill(this.productDataSet.Product);
            ShowData();
            Shared.TextBoxAutoCompleteFromColumn("Product", "ID", ProductIdTextBox);
            Shared.TextBoxAutoCompleteFromColumn("Product", "Barcode", ProductBarcodeTextBox);
            Shared.TextBoxAutoCompleteFromColumn("Product", "Name", ProductNameTextBox);
        }

        #endregion

        #region Startup Functions
        public void ShowData()
        {
            Shared.ShowAllTableData(dataGridView1, "Product", "ID");
        }

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
        #endregion

        #region Events
        #region Button Click

        #region Add Button
        private void AddProductBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var add = new AddNewProduct(this);
            add.Show();
        }
        #endregion

        #region Edit Button
        private void EditProductBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var edit = new EditProduct(this);
            edit.Show();
        }
        #endregion

        #region Delete Button
        //Delete a product
        private void DeleteProductBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var delete = new DeleteProduct(this);
            delete.Show();
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

        #region While Typing
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

        #region Cell Click
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ResetFields(groupBox1);
            var text = dataGridView1.CurrentCell.Value.ToString();
            var columnIndex = dataGridView1.CurrentCellAddress.X;
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
        #endregion
    }
}