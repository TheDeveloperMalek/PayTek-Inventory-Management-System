using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventory_Manager
{

    public partial class Sales : Form
    {
        #region essential_data

        //holding data that will affect on the database
        private int customer_id_value, product_id_value, sale_id_value, product_barcode_value, product_quantity_value;
        private string product_name_value, customer_name_value;
        readonly string status = "Sale";

        public Sales()
        {
            InitializeComponent();
            Shared.ConnectionInitializer();
            this.saleTableAdapter.Connection.ConnectionString = Shared.conn.ConnectionString;
            this.label8.Visible =
            this.unitprice_text_box.Visible =
            this.dataGridView1.Columns[7].Visible = Shared.isJustVisibleForNonUserType;
            this.note.Text = Shared.NoticeModifier("sale");
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            this.saleTableAdapter.Fill(this.saleDataSet.Sale);
            ShowData();
            Shared.TextBoxAutoCompleteFromColumn("Product", "ID", ProductIDTextBox);
            Shared.TextBoxAutoCompleteFromColumn("Product", "Barcode", ProductBarcodeTextBox);
            Shared.TextBoxAutoCompleteFromColumn("Product", "Name", ProductNameTextBox);
            Shared.TextBoxAutoCompleteFromColumn("Customer", "ID", CustomerIDTextBox);
            Shared.TextBoxAutoCompleteFromColumn("Customer", "Name", CustomerNameTextBox);
            Shared.TextBoxAutoCompleteFromColumn("Sale", "ID", SaleIDTextBox);
        }
        #endregion

        #region Startup Functions
        //Update the data of Product's table
        public void ShowData()
        {
            Shared.ShowAllTableData(dataGridView1, "Sale", "ID");
        }

        #endregion

        #region validation_functions
        //Check if the text boxes were empty
        private bool At_Least_Input()
        {
            if (
                (ProductIDTextBox.Text == ""
                && String.IsNullOrEmpty(ProductNameTextBox.Text)
                && ProductBarcodeTextBox.Text == "")
                ||
                ProductQuantityTextBox.Text == ""
                || (CustomerIDTextBox.Text == "" && String.IsNullOrEmpty(CustomerNameTextBox.Text)
                || SaleIDTextBox.Text == "")
                )
            {
                if (ProductIDTextBox.Text == ""
                    && String.IsNullOrEmpty(ProductNameTextBox.Text)
                    && ProductBarcodeTextBox.Text == "")
                {
                    Shared.ErrorOccuredMessageBox("Please Enter product's id , barcode , or name");
                    return false;
                }
                if (CustomerIDTextBox.Text == "" && String.IsNullOrEmpty(CustomerNameTextBox.Text))
                {
                    Shared.ErrorOccuredMessageBox("Please Enter customer's id or name ");
                    return false;
                }
                if (ProductQuantityTextBox.Text == "")
                {
                    Shared.ErrorOccuredMessageBox("Please Enter quantity");
                    return false;
                }
            }
            return true;
        }

        //Check for requried textboxes for searching
        private bool At_Least_Input_For_Search()
        {
            if (
                    String.IsNullOrEmpty(ProductIDTextBox.Text)
                && String.IsNullOrEmpty(ProductBarcodeTextBox.Text)
                && String.IsNullOrEmpty(ProductNameTextBox.Text)
                && String.IsNullOrEmpty(CustomerIDTextBox.Text)
                && String.IsNullOrEmpty(CustomerNameTextBox.Text)
                && String.IsNullOrEmpty(SaleIDTextBox.Text)
                )
            {
                Shared.ErrorOccuredMessageBox("Please fill one of those fields to perform this action\n(product id , product barcode , product name , customer id , customer name ,Sale id)");
                return false;
            }
            return true;
        }


        private bool Check_If_There_Is_Enough_Product_Quantity(int wanted_quantity)
        {
            if (ProductIDTextBox.Text != "")
            {
                Shared.cmd.CommandText = $"SELECT name from Product WHERE id = {product_id_value}";
                var name = Convert.ToString(Shared.cmd.ExecuteScalar());

                Shared.cmd.CommandText = $"SELECT quantity from Product WHERE id = {product_id_value}";
                var quantity = Convert.ToInt32(Shared.cmd.ExecuteScalar());
                if (quantity >= wanted_quantity)
                {
                    return true;
                }
                Shared.ErrorOccuredMessageBox($"Unavailabe because the available quantity of product \"{name}\" is {quantity}");
                return false;
            }

            if (ProductNameTextBox.Text != "")
            {
                Shared.cmd.CommandText = $"SELECT quantity from Product WHERE name = N\'{ProductNameTextBox.Text}\'";
                var quantity = Convert.ToInt32(Shared.cmd.ExecuteScalar());
                if (quantity >= wanted_quantity)
                {
                    return true;
                }
                Shared.ErrorOccuredMessageBox($"Unavailabe because the available quantity of product \"{ProductNameTextBox.Text}\" is {quantity}");
                return false;
            }

            if (ProductBarcodeTextBox.Text != "")
            {
                Shared.cmd.CommandText = $"SELECT name from Product WHERE barcode = {product_barcode_value}";
                var name = Convert.ToString(Shared.cmd.ExecuteScalar());

                Shared.cmd.CommandText = $"SELECT quantity from Product WHERE barcode = {product_barcode_value}";
                var quantity = Convert.ToInt32(Shared.cmd.ExecuteScalar());
                if (quantity >= wanted_quantity)
                {
                    return true;
                }
                Shared.ErrorOccuredMessageBox($"Unavailabe because the available quantity of product \"{name}\" is {quantity}");
                return false;
            }
            return true;
        }


        private bool Check_If_There_Is_Enough_Product_Quantity_Update(int wanted_quantity)
        {

            Shared.cmd.CommandText = $@"SELECT ""Product Name"" from Sale WHERE id = {sale_id_value}";
            var name = Convert.ToString(Shared.cmd.ExecuteScalar());

            Shared.cmd.CommandText = $@"SELECT quantity FROM Sale WHERE id = {sale_id_value}";
            var old_quantity_of_Sale = Convert.ToInt32(Shared.cmd.ExecuteScalar());

            Shared.cmd.CommandText = $@"SELECT p.quantity from Product p JOIN Sale pu ON pu.""Product ID"" = p.id WHERE pu.id = {sale_id_value}";
            var quantity = Convert.ToInt32(Shared.cmd.ExecuteScalar());
            if (quantity >= wanted_quantity - old_quantity_of_Sale)
            {
                return true;
            }
            Shared.ErrorOccuredMessageBox($"Unavailabe because the available quantity of product \"{name}\" is {quantity}");
            return false;
        }


        private bool User_Entered_Sale_Id()
        {
            if (String.IsNullOrEmpty(SaleIDTextBox.Text))
            {
                Shared.ErrorOccuredMessageBox("Please enter the Sale id to perform this action");
                return false;
            }
            else if (!int.TryParse(SaleIDTextBox.Text, out sale_id_value) || sale_id_value < 0)
            {
                Shared.ErrorOccuredMessageBox("Please enter a valid value for product's id field");
                return false;
            }
            else
                return true;
        }


        private bool User_Entered_Quantity()
        {
            if (String.IsNullOrEmpty(ProductQuantityTextBox.Text))
            {
                Shared.ErrorOccuredMessageBox("Please enter the quantity to perform this action");
                return false;
            }
            else if (!int.TryParse(ProductQuantityTextBox.Text, out product_quantity_value) || product_quantity_value < 0)
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
                        if (!int.TryParse(ProductIDTextBox.Text, out product_id_value) || product_id_value < 0)
                        {
                            Shared.ErrorOccuredMessageBox("Please enter a valid value for product's id field");
                            return false;
                        }
                    if (ProductIDTextBox.Text == "")
                        if (!int.TryParse(ProductBarcodeTextBox.Text, out product_barcode_value) || product_barcode_value < 0)
                        {
                            Shared.ErrorOccuredMessageBox("Please enter a valid value for product's barcode field");
                            return false;
                        }
                }

                if (CustomerNameTextBox.Text == "")
                    if (!int.TryParse(CustomerIDTextBox.Text, out customer_id_value) || customer_id_value < 0)
                    {
                        Shared.ErrorOccuredMessageBox("Please enter a valid value for customer's id field");
                        return false;
                    }

                if (!int.TryParse(ProductQuantityTextBox.Text, out product_quantity_value) || product_quantity_value <= 0)
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
            customer_name_value = CustomerNameTextBox.Text;
            string checkQuery = "SELECT COUNT(*) FROM Customer WHERE name = @name OR  id = @id";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, Shared.conn))
            {
                checkCmd.Parameters.AddWithValue("@id", customer_id_value);
                checkCmd.Parameters.AddWithValue("@name", customer_name_value);

                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);

                if (productCount > 0)
                {
                    return true;
                }
                return false;
            }
        }

        private bool Check_If_Product_Already_Exists()
        {
            product_name_value = ProductNameTextBox.Text;
            string checkQuery = @"SELECT COUNT(*)
                                  FROM Product
                                  WHERE name = @name OR  id = @id OR barcode = @barcode";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, Shared.conn))
            {
                checkCmd.Parameters.AddWithValue("@id", product_id_value);
                checkCmd.Parameters.AddWithValue("@barcode", product_barcode_value);
                checkCmd.Parameters.AddWithValue("@name", product_name_value);

                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);

                if (productCount > 0)
                {
                    return true;
                }
                return false;
            }
        }

        private bool Check_If_Sale_Already_Exists()
        {
            string checkQuery = "SELECT COUNT(*) FROM Sale WHERE  id = @id";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, Shared.conn))
            {
                checkCmd.Parameters.AddWithValue("@id", sale_id_value);

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
        //saving new Sale
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (Validation_of_input())
            {
                if (!Check_If_Customer_Already_Exists())
                {
                    if (!String.IsNullOrEmpty(CustomerNameTextBox.Text))
                    {
                        Shared.cmd.CommandType = CommandType.Text;
                        Shared.cmd.CommandText = "INSERT INTO customer (name) VALUES (@name_value)";
                        Shared.cmd.Parameters.AddWithValue("@name_value", customer_name_value);
                        Shared.cmd.ExecuteNonQuery();
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
                if (Check_If_There_Is_Enough_Product_Quantity(product_quantity_value))
                    try
                    {
                        using (SqlCommand cmd = Shared.conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@product_quantity", product_quantity_value);
                            cmd.Parameters.AddWithValue("@price", unitprice_text_box.Text);
                            cmd.Parameters.AddWithValue("@status", status);
                            cmd.Parameters.AddWithValue("@date", DateTime.Today);

                            if (String.IsNullOrEmpty(CustomerNameTextBox.Text))
                            {
                                cmd.Parameters.AddWithValue("@customer_id", customer_id_value);

                                if (ProductNameTextBox.Text != "")
                                {
                                    product_name_value = ProductNameTextBox.Text;
                                    cmd.Parameters.AddWithValue("@product_name", product_name_value);
                                    cmd.CommandText = @"INSERT INTO Sale (""Product ID"", ""Product Barcode"", ""Product Name"", ""Customer ID"" , ""Customer Name"" , ""Quantity"" , ""Price"", ""Date"")
                                                    SELECT p.id , p.barcode , p.name , c.id , c.name , @product_quantity , @price , @date  
                                                    FROM Customer c 
                                                    JOIN Product p 
                                                    ON (p.name = @product_name AND c.id = @customer_id )";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"UPDATE Product 
                                                        SET quantity = quantity - @product_quantity,
                                                        Date = @date
                                                        WHERE name = @product_name";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"IF EXISTS 
                                                         (SELECT quantity FROM ProductReport WHERE ""Product Name""
                        = @product_name AND date = @date AND status = @status) 
                                                            UPDATE ProductReport SET quantity =                                       quantity + @product_quantity 
                                                            WHERE ""Product Name"" = @product_name AND date = @date; 
                                                            ELSE INSERT INTO ProductReport 
                                                            (""Product ID"", ""Product Name"" , ""Product Barcode"",date, quantity , status) 
                                                            SELECT p.id , p.name , p.barcode, @date, @product_quantity   , @status
                                                            FROM Product p 
                                                            WHERE p.name = @product_name;";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = $@"INSERT INTO InventoryReport 
                                                            (""Product ID"", ""Product Name"" , ""Product Barcode"",date, quantity) 
                                                            SELECT p.id , p.name , p.barcode, @date, -@product_quantity
                                                            FROM Product p 
                                                            WHERE p.name = @product_name;";
                                    cmd.ExecuteNonQuery();
                                }

                                else if (ProductIDTextBox.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@product_id", product_id_value);
                                    cmd.CommandText = @"INSERT INTO Sale (""Product ID"", ""Product Barcode"", ""Product Name"", ""Customer ID"" , ""Customer Name"" , ""Quantity"" , ""Price"", ""Date"") 
                                                        SELECT p.id , p.barcode , p.name , c.id , c.name , @product_quantity , @price , @date  
                                                        FROM Customer c
                                                        JOIN Product p
                                                        ON (p.id = @product_id AND c.id = @customer_id )";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"UPDATE Product SET quantity = quantity - @product_quantity ,
                                                        Date = @date
                                                        WHERE id = @product_id";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"IF EXISTS (SELECT quantity FROM ProductReport WHERE ""Product ID"" = @product_id  AND date = @date AND status = @status) 
                                                        UPDATE ProductReport SET quantity =                                       quantity + @product_quantity 
                                                        WHERE ""Product ID"" = @product_id AND date = @date; 
                                                        ELSE INSERT INTO ProductReport 
                                                        (""Product ID"", ""Product Name"", ""Product Barcode"" ,date, quantity , status) 
                                                        SELECT p.id , p.name , p.barcode , @date, @product_quantity   , @status
                                                        FROM Product p 
                                                        WHERE p.id = @product_id;";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = $@"INSERT INTO InventoryReport 
                                                            (""Product ID"", ""Product Name"" , ""Product Barcode"",date, quantity) 
                                                            SELECT p.id , p.name , p.barcode, @date, -@product_quantity
                                                            FROM Product p 
                                                            WHERE p.id = @product_id;";
                                    cmd.ExecuteNonQuery();
                                }

                                else if (ProductBarcodeTextBox.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@product_barcode", product_barcode_value);
                                    cmd.CommandText = @"INSERT INTO Sale (""Product ID"", ""Product Barcode"", ""Product Name"", ""Customer ID"" , ""Customer Name"" , ""Quantity"" , ""Price"", ""Date"") 
                                                        SELECT p.id , p.barcode , p.name , c.id , c.name , @product_quantity , @price , @date  
                                                        FROM Customer c
                                                        JOIN Product p
                                                        ON (p.barcode = @product_barcode AND c.id = @customer_id )";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"UPDATE Product SET quantity = quantity - @product_quantity ,
                                                        Date = @date
                                                        WHERE barcode = @product_barcode";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"IF EXISTS (SELECT quantity FROM ProductReport WHERE ""Product Barcode"" = @product_barcode  AND date = @date AND status = @status) 
                                                        UPDATE ProductReport SET quantity =                                       quantity + @product_quantity 
                                                        WHERE ""Product Barcode"" = @product_barcode AND date = @date; 
                                                        ELSE INSERT INTO ProductReport 
                                                        (""Product ID"", ""Product Name"", ""Product Barcode"" ,date, quantity , status) 
                                                        SELECT p.id , p.name , p.barcode , @date, @product_quantity   , @status
                                                        FROM Product p 
                                                        WHERE p.barcode = @product_barcode;";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = $@"INSERT INTO InventoryReport 
                                                            (""Product ID"", ""Product Name"" , ""Product Barcode"",date, quantity) 
                                                            SELECT p.id , p.name , p.barcode, @date, -@product_quantity
                                                            FROM Product p 
                                                            WHERE p.barcode = @product_barcode;";
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                customer_name_value = CustomerNameTextBox.Text;
                                cmd.Parameters.AddWithValue("@customer_name", customer_name_value);

                                if (ProductNameTextBox.Text != "")
                                {
                                    product_name_value = ProductNameTextBox.Text;
                                    cmd.Parameters.AddWithValue("@product_name", product_name_value);
                                    cmd.CommandText = @"INSERT INTO Sale (""Product ID"", ""Product Barcode"", ""Product Name"", ""Customer ID"" , ""Customer Name"" , ""Quantity"", ""Price"" , ""Date"") SELECT p.id , p.barcode ,  p.name , c.id , c.name , @product_quantity , @price , @date  
                                                        FROM Customer c 
                                                        JOIN Product p
                                                        ON (p.name = @product_name AND c.name = @customer_name )";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"UPDATE Product 
                                                        SET quantity = quantity - @product_quantity,
                                                        Date = @date
                                                        WHERE name = @product_name";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"IF EXISTS 
                                                         (SELECT quantity FROM ProductReport WHERE ""Product Name""
                        = @product_name AND date = @date AND status = @status) 
                                                            UPDATE ProductReport SET quantity =                                       quantity + @product_quantity 
                                                            WHERE ""Product Name"" = @product_name AND date = @date AND status = @status; 
                                                            ELSE INSERT INTO ProductReport 
                                                            (""Product ID"", ""Product Name"" , ""Product Barcode"" ,date, quantity , status) 
                                                            SELECT p.id , p.name , p.barcode , @date, @product_quantity   , @status
                                                            FROM Product p 
                                                            WHERE p.name = @product_name;";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = $@"INSERT INTO InventoryReport 
                                                            (""Product ID"", ""Product Name"" , ""Product Barcode"",date, quantity) 
                                                            SELECT p.id , p.name , p.barcode, @date, -@product_quantity
                                                            FROM Product p 
                                                            WHERE p.name = @product_name;";
                                    cmd.ExecuteNonQuery();
                                }

                                else if (ProductIDTextBox.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@product_id", product_id_value);
                                    cmd.CommandText = @"INSERT INTO Sale (""Product ID"", ""Product Barcode"", ""Product Name"", ""Customer ID"" , ""Customer Name"" , ""Quantity"" , ""Price"", ""Date"") 
                                                        SELECT p.id , p.barcode , p.name , c.id , c.name , @product_quantity , @price , @date  
                                                        FROM Customer c 
                                                        JOIN Product p
                                                        ON (p.id = @product_id AND c.name = @customer_name )";
                                    cmd.ExecuteNonQuery();


                                    cmd.CommandText = @"UPDATE Product SET quantity = quantity - @product_quantity ,
                                                        Date = @date
                                                        WHERE id = @product_id";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"IF EXISTS (SELECT quantity FROM ProductReport WHERE ""Product ID"" = @product_id  AND date = @date AND status = @status) 
                                                        UPDATE ProductReport SET quantity =                                       quantity + @product_quantity 
                                                        WHERE ""Product ID"" = @product_id AND date = @date AND status = @status; 
                                                        ELSE INSERT INTO ProductReport 
                                                        (""Product ID"", ""Product Name"" , ""Product Barcode"",date, quantity , status) 
                                                        SELECT p.id , p.name, p.barcode ,  @date, @product_quantity , @status  
                                                        FROM Product p 
                                                        WHERE p.id = @product_id";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = $@"INSERT INTO InventoryReport 
                                                            (""Product ID"", ""Product Name"" , ""Product Barcode"",date, quantity) 
                                                            SELECT p.id , p.name , p.barcode, @date, -@product_quantity
                                                            FROM Product p 
                                                            WHERE p.id = @product_id;";
                                    cmd.ExecuteNonQuery();

                                }

                                else if (ProductBarcodeTextBox.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@product_barcode", product_barcode_value);
                                    cmd.CommandText = @"INSERT INTO Sale (""Product ID"", ""Product Barcode"", ""Product Name"", ""Customer ID"" , ""Customer Name"" , ""Quantity"" , ""Price"", ""Date"") 
                                                        SELECT p.id , p.barcode , p.name , c.id , c.name , @product_quantity , @price , @date  
                                                        FROM Customer c 
                                                        JOIN Product p
                                                        ON (p.barcode = @product_barcode AND c.name = @customer_name )";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"UPDATE Product SET quantity = quantity - @product_quantity ,
                                                        Date = @date
                                                        WHERE barcode = @product_barcode";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"IF EXISTS (SELECT quantity FROM ProductReport WHERE ""Product Barcode"" = @product_barcode  AND date = @date AND status = @status) 
                                                        UPDATE ProductReport SET quantity =                                       quantity + @product_quantity 
                                                        WHERE ""Product Barcode"" = @product_barcode AND date = @date AND status = @status; 
                                                        ELSE INSERT INTO ProductReport 
                                                        (""Product ID"", ""Product Name"" , ""Product Barcode "",date, quantity , status) 
                                                        SELECT p.id , p.name , p.barcode, @date, @product_quantity   , @status
                                                        FROM Product p 
                                                        WHERE p.barcode = @product_barcode;";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = $@"INSERT INTO InventoryReport 
                                                            (""Product ID"", ""Product Name"" , ""Product Barcode"",date, quantity) 
                                                            SELECT p.id , p.name , p.barcode, @date, -@product_quantity
                                                            FROM Product p 
                                                            WHERE p.barcode = @product_barcode;";
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        Shared.ProcessIsDoneMessageBox("sale" , "added");
                        ShowData();
                        return;
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

        #region update_button
        //update a Sale
        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (User_Entered_Sale_Id())
                if (User_Entered_Quantity())
                    if (Check_If_Sale_Already_Exists())
                    {
                        if (Check_If_There_Is_Enough_Product_Quantity_Update(product_quantity_value))
                            try
                            {
                                using (SqlCommand cmd = Shared.conn.CreateCommand())
                                {
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Parameters.AddWithValue("@product_quantity", product_quantity_value);
                                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@status", status);
                                    cmd.Parameters.AddWithValue("@id", sale_id_value);

                                    cmd.CommandText = $@"UPDATE ProductReport
                                                         SET quantity = quantity + @product_quantity - 
                                                         (SELECT quantity
                                                         FROM Sale
                                                         WHERE id = @id)
                                                         WHERE date = 
                                                         (SELECT date 
                                                         FROM Sale 
                                                         WHERE id = @id)
                                                         AND ""Product ID"" = 
                                                         (SELECT ""Product ID""
                                                         FROM Sale 
                                                         WHERE id = @id)
                                                         AND status = @status";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"INSERT INTO InventoryReport
                                                        SELECT ""Product ID"", ""Product Barcode"", ""Product Name"",  quantity - @product_quantity , @date
                                                        FROM Sale
                                                        WHERE Sale.id = @id;";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"UPDATE Product
                                                        SET Product.quantity = Product.quantity - (
                                                            SELECT @product_quantity - pu.quantity
                                                            FROM Sale pu
                                                            WHERE pu.id = @id
                                                        )
                                                        WHERE Product.id = (
                                                            SELECT pu.""Product ID""
                                                            FROM Sale pu
                                                            WHERE pu.id = @id
                                                        );";

                                    cmd.ExecuteNonQuery();



                                    cmd.CommandText = @"UPDATE Sale
                                                        SET quantity = @product_quantity,
                                                        Date = @date
                                                        WHERE id = @id";

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        Shared.ProcessIsDoneMessageBox("sale" , "edited");
                                    }
                                    else
                                    {
                                        Shared.ErrorOccuredMessageBox("No record found with the specified id.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Shared.ErrorOccuredMessageBox("Error: " + ex.Message);
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
                        Shared.ErrorOccuredMessageBox("The Sale doesn't exists");
                    }
        }
        #endregion

        #region Reset_button
        //searching for a Sale
        private void searchBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ResetFields(groupBox1);
            ShowData();
        }
        #endregion

        #region delete(returned)_button
        //delete the Sale (product was returned)
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            DialogResult delete;
            delete = MessageBox.Show($"Are you sure that you want to delete the record with id '{SaleIDTextBox.Text}' ", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (delete == DialogResult.Yes)
            {
                if (User_Entered_Sale_Id())
                    if (Check_If_Sale_Already_Exists())
                    {
                        try
                        {
                            using (SqlCommand cmd = Shared.conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@id", sale_id_value);
                                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                                cmd.Parameters.AddWithValue("@status", status);
                                cmd.CommandText = @"UPDATE Product
                                                    SET Product.quantity = Product.quantity + Sale.quantity
                                                    FROM Product
                                                    JOIN Sale ON Product.id = Sale.""Product ID""
                                                    WHERE Sale.id = @id";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = @"UPDATE ProductReport 
                                                    SET quantity = quantity - 
                                                    (SELECT quantity
                                                     FROM Sale                                                   
                                                     WHERE id = @id)
                                                     WHERE ""Product ID"" = (
                                                     SELECT ""Product ID""
                                                     FROM sale 
                                                     WHERE ID = @id)
                                                     AND status = @status";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = $@"INSERT INTO InventoryReport
                                                        SELECT ""Product ID"", ""Product Barcode"", ""Product Name"", quantity , @date
                                                        FROM Sale
                                                        WHERE Sale.id = @id;";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = "DELETE FROM Sale WHERE id = @id";

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    Shared.ProcessIsDoneMessageBox("sale" , "returned");
                                }
                                else
                                {
                                    Shared.ErrorOccuredMessageBox("No record found with the specified id.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Shared.ErrorOccuredMessageBox("Error: " + ex.Message);
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
                        Shared.ErrorOccuredMessageBox("The Sale doesn't exists");
                    }
            }
            else
            {
                Shared.IgnoredProcess("Nothing has been changed");
                ShowData();
            }
        }
        #endregion

        #region delete(from log)_button
        //delete a Sale only from the log
        private void button1_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            DialogResult delete;
            delete = MessageBox.Show($"Are you sure that you want to delete the record with id '{SaleIDTextBox.Text}' ", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (delete == DialogResult.Yes)
            {
                if (User_Entered_Sale_Id())
                    if (Check_If_Sale_Already_Exists())
                    {
                        try
                        {
                            using (SqlCommand cmd = Shared.conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "DELETE FROM Sale WHERE id = @id";
                                cmd.Parameters.AddWithValue("@id", sale_id_value);


                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    Shared.ProcessIsDoneMessageBox("sale" , "deleted");
                                }
                                else
                                {
                                    Shared.ErrorOccuredMessageBox("No record found with the specified id.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Shared.ErrorOccuredMessageBox("Error: " + ex.Message);
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
                        Shared.ErrorOccuredMessageBox("The Sale doesn't exists");
                    }
            }
            else
            {
                Shared.IgnoredProcess("Nothing has been changed");
                ShowData();
            }
        }
        #endregion

        #endregion

        #region Events For Searching

        private void Sale_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, SaleIDTextBox, "Sale", "ID", "ID", false, "sale id");
        }

        private void product_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, ProductNameTextBox, "Sale", "Product Name", "ID");
        }

        private void product_barcode_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, ProductBarcodeTextBox, "Sale", "Product Barcode", "ID", false, "product barcode");
        }

        private void product_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, ProductIDTextBox, "Sale", "Product ID", "ID", false, "product id");
        }

        private void product_quantity_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, ProductQuantityTextBox, "Sale", "Quantity", "ID", false, "quantity");
        }

        private void customer_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, CustomerNameTextBox, "Sale", "Customer Name", "ID");
        }

        private void customer_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, CustomerIDTextBox, "Sale", "Customer ID", "ID", false, "customer id");
        }

        #endregion

        #region Click on a cell
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SaleIDTextBox.Text =
            ProductIDTextBox.Text =
            ProductBarcodeTextBox.Text =
            ProductNameTextBox.Text =
            CustomerIDTextBox.Text =
            CustomerNameTextBox.Text =
            ProductQuantityTextBox.Text = "";
            var text = dataGridView1.CurrentCell.Value.ToString();
            var columnIndex = dataGridView1.CurrentCellAddress.X;
            var rowIndex = dataGridView1.CurrentCellAddress.Y;
            var c = new KeyEventArgs(Keys.NoName);

            switch (columnIndex)
            {
                case 0:
                    SaleIDTextBox.Text = text;
                    Sale_id_text_box_KeyUp(sender, c);
                    break;
                case 1:
                    CustomerIDTextBox.Text = text;
                    customer_id_text_box_KeyUp(sender, c);
                    break;
                case 2:
                    CustomerNameTextBox.Text = text;
                    customer_name_text_box_KeyUp(sender, c);
                    break;
                case 3:
                    ProductIDTextBox.Text = text;
                    product_id_text_box_KeyUp(sender, c);
                    break;
                case 4:
                    ProductBarcodeTextBox.Text = text;
                    product_barcode_text_box_KeyUp(sender, c);
                    break;
                case 5:
                    ProductNameTextBox.Text = text;
                    product_name_text_box_KeyUp(sender, c);
                    break;
                case 6:
                    ProductQuantityTextBox.Text = text;
                    product_quantity_text_box_KeyUp(sender, c);
                    break;
            }
        }

        #endregion

    }
}