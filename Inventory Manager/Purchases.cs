using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventory_Manager
{

    public partial class Purchases : Form
    {
        #region essential_data

        //holding data that will affect on the database
        private int supplier_id_value, product_id_value, purchase_id_value, product_barcode_value, product_quantity_value;
        private string product_name_value, supplier_name_value;
        readonly string status = "Purchase";

        public Purchases()
        {
            InitializeComponent();
            Shared.ConnectionInitializer();
            this.purchaseTableAdapter.Connection.ConnectionString = Shared.conn.ConnectionString;
            this.label8.Visible = 
            this.cost_text_box.Visible =
            this.dataGridView1.Columns[7].Visible = Shared.isJustVisibleForNonUserType;
            this.note.Text = Shared.NoticeModifier("purchase");
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
        }

        private void Purchases_Load(object sender, EventArgs e)
        {
            this.purchaseTableAdapter.Fill(this.purchaseDataSet.Purchase);
            ShowData();
            Shared.AutoCompleteForTextBox("Product" , "ID" , product_id_text_box);
            Shared.AutoCompleteForTextBox("Product" , "Barcode" , product_barcode_text_box);
            Shared.AutoCompleteForTextBox("Product" , "Name" , product_name_text_box);
            Shared.AutoCompleteForTextBox("Supplier" , "ID" , supplier_id_text_box);
            Shared.AutoCompleteForTextBox("Supplier" , "Name" , supplier_name_text_box);
            Shared.AutoCompleteForTextBox("Purchase" ,"ID"  , purchase_id_text_box);
        }
        #endregion

        #region Startup Functions
        public void ShowData()
        {
            Shared.ShowAllData(dataGridView1, "Purchase", "ID");
        }

        //Shortcuts for window
        private void KeysShortcuts(object sender, KeyEventArgs e)
        {
            Shared.KeysShortcuts(sender, e, this);
        }
        #endregion

        #region validation_functions
        //Check if the text boxes were empty
        private bool At_Least_Input()
        {
            if (
                (product_id_text_box.Text == ""
                && String.IsNullOrEmpty(product_name_text_box.Text)
                && product_barcode_text_box.Text == "")
                ||
                product_quantity_text_box.Text == ""
                || (supplier_id_text_box.Text == "" && String.IsNullOrEmpty(supplier_name_text_box.Text)
                || purchase_id_text_box.Text == "")
                )
            {
                if (product_id_text_box.Text == ""
                    && String.IsNullOrEmpty(product_name_text_box.Text)
                    && product_barcode_text_box.Text == "")
                {
                    MessageBox.Show("Please Enter product's id , barcode , or name", "Inventory Management System");
                    return false;
                }
                if (supplier_id_text_box.Text == "" && String.IsNullOrEmpty(supplier_name_text_box.Text))
                {
                    MessageBox.Show("Please Enter supplier's id or name ", "Inventory Management System");
                    return false;
                }
                if (product_quantity_text_box.Text == "")
                {
                    MessageBox.Show("Please Enter quantity", "Inventory Management System");
                    return false;
                }
            }
            return true;
        }

        //Check for requried textboxes for searching
        private bool At_Least_Input_For_Search()
        {
            if (
                    String.IsNullOrEmpty(product_id_text_box.Text)
                && String.IsNullOrEmpty(product_barcode_text_box.Text)
                && String.IsNullOrEmpty(product_name_text_box.Text)
                && String.IsNullOrEmpty(supplier_id_text_box.Text)
                && String.IsNullOrEmpty(supplier_name_text_box.Text)
                && String.IsNullOrEmpty(purchase_id_text_box.Text)
                )
            {
                MessageBox.Show("Please fill one of those fields to perform this action\n(product id , product barcode , product name , supplier id , supplier name ,purchase id)");
                return false;
            }
            return true;
        }


        private bool Check_If_There_Is_Enough_Product_Quantity(int wanted_quantity)
        {
            if (product_id_text_box.Text != "")
            {
                Shared.cmd.CommandText = $"SELECT name from Product WHERE id = {product_id_value}";
                var name = Convert.ToString(Shared.cmd.ExecuteScalar());

                Shared.cmd.CommandText = $"SELECT quantity from Product WHERE id = {product_id_value}";
                var quantity = Convert.ToInt32(Shared.cmd.ExecuteScalar());
                if (quantity >= wanted_quantity)
                {
                    return true;
                }
                MessageBox.Show($"Unavailabe because the available quantity of product \"{name}\" is {quantity}");
                return false;
            }

            if (product_name_text_box.Text != "")
            {
                Shared.cmd.CommandText = $"SELECT quantity from Product WHERE name = \'{product_name_text_box.Text}\'";
                var quantity = Convert.ToInt32(Shared.cmd.ExecuteScalar());
                if (quantity >= wanted_quantity)
                {
                    return true;
                }
                MessageBox.Show($"Unavailabe because the available quantity of product \"{product_name_text_box.Text}\" is {quantity}");
                return false;
            }

            if (product_barcode_text_box.Text != "")
            {
                Shared.cmd.CommandText = $"SELECT name from Product WHERE barcode = {product_barcode_value}";
                var name = Convert.ToString(Shared.cmd.ExecuteScalar());

                Shared.cmd.CommandText = $"SELECT quantity from Product WHERE barcode = {product_barcode_value}";
                var quantity = Convert.ToInt32(Shared.cmd.ExecuteScalar());
                if (quantity >= wanted_quantity)
                {
                    return true;
                }
                MessageBox.Show($"Unavailabe because the available quantity of product \"{name}\" is {quantity}");
                return false;
            }
            return true;
        }


        private bool Check_If_There_Is_Enough_Product_Quantity_Update(int wanted_quantity)
        {

            Shared.cmd.CommandText = $"SELECT product_name from Purchase WHERE id = {purchase_id_value}";
            var name = Convert.ToString(Shared.cmd.ExecuteScalar());

            Shared.cmd.CommandText = $@"SELECT quantity FROM Purchase WHERE id = {purchase_id_value}";
            var old_quantity_of_purchase = Convert.ToInt32(Shared.cmd.ExecuteScalar());

            Shared.cmd.CommandText = $@"SELECT p.quantity from Product p JOIN Purchase pu ON pu.product_id = p.id WHERE pu.id = {purchase_id_value}";
            var quantity = Convert.ToInt32(Shared.cmd.ExecuteScalar());
            if (quantity >= wanted_quantity - old_quantity_of_purchase)
            {
                return true;
            }
            MessageBox.Show($"Unavailabe because the available quantity of product \"{name}\" is {quantity}");
            return false;
        }


        private bool User_Entered_Purchase_Id()
        {
            if (String.IsNullOrEmpty(purchase_id_text_box.Text))
            {
                MessageBox.Show("Please enter the purchase id to perform this action");
                return false;
            }
            else if (!int.TryParse(purchase_id_text_box.Text, out purchase_id_value) || purchase_id_value < 0)
            {
                MessageBox.Show("Please enter a valid value for product's id field");
                return false;
            }
            else
                return true;
        }


        private bool User_Entered_Quantity()
        {
            if (String.IsNullOrEmpty(product_quantity_text_box.Text))
            {
                MessageBox.Show("Please enter the quantity to perform this action");
                return false;
            }
            else if (!int.TryParse(product_quantity_text_box.Text, out product_quantity_value) || product_quantity_value < 0)
            {
                MessageBox.Show("Please enter a valid value for product's quantity field");
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
                if (product_name_text_box.Text == "")
                {
                    if (product_barcode_text_box.Text == "")
                        if (!int.TryParse(product_id_text_box.Text, out product_id_value) || product_id_value < 0)
                        {
                            MessageBox.Show("Please enter a valid value for product's id field");
                            return false;
                        }
                    if (product_id_text_box.Text == "")
                        if (!int.TryParse(product_barcode_text_box.Text, out product_barcode_value) || product_barcode_value < 0)
                        {
                            MessageBox.Show("Please enter a valid value for product's barcode field");
                            return false;
                        }
                }

                if (supplier_name_text_box.Text == "")
                    if (!int.TryParse(supplier_id_text_box.Text, out supplier_id_value) || supplier_id_value < 0)
                    {
                        MessageBox.Show("Please enter a valid value for supplier's id field");
                        return false;
                    }

                if (!int.TryParse(product_quantity_text_box.Text, out product_quantity_value) || product_quantity_value <= 0)
                {
                    MessageBox.Show("Please enter a valid value for the quantity field");
                    return false;
                }
            }
            else return false;
            return true;
        }

        private bool Check_If_Supplier_Already_Exists()
        {
            supplier_name_value = supplier_name_text_box.Text;
            string checkQuery = "SELECT COUNT(*) FROM Supplier WHERE name = @name OR  id = @id";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, Shared.conn))
            {
                checkCmd.Parameters.AddWithValue("@id", supplier_id_value);
                checkCmd.Parameters.AddWithValue("@name", supplier_name_value);

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
            product_name_value = product_name_text_box.Text;
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

        private bool Check_If_Purchase_Already_Exists()
        {
            string checkQuery = "SELECT COUNT(*) FROM Purchase WHERE  id = @id";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, Shared.conn))
            {
                checkCmd.Parameters.AddWithValue("@id", purchase_id_value);

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
        //saving new purchase
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (Validation_of_input())
            {
                if (!Check_If_Supplier_Already_Exists())
                {
                    if (!String.IsNullOrEmpty(supplier_name_text_box.Text))
                    {
                        Shared.cmd.CommandType = CommandType.Text;
                        Shared.cmd.CommandText = "INSERT INTO Supplier (name) VALUES (@name_value)";
                        Shared.cmd.Parameters.AddWithValue("@name_value", supplier_name_value);
                        Shared.cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a name or an existed supplier's id to continue process");
                        return;
                    }
                }
            }
            else
                return;

            if (Check_If_Product_Already_Exists())
            {
                try
                {
                    using (SqlCommand cmd = Shared.conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@product_quantity", product_quantity_value);
                        cmd.Parameters.AddWithValue("@price", cost_text_box.Text);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@date", DateTime.Today);

                        if (String.IsNullOrEmpty(supplier_name_text_box.Text))
                        {
                            cmd.Parameters.AddWithValue("@supplier_id", supplier_id_value);

                            if (product_name_text_box.Text != "")
                            {
                                product_name_value = product_name_text_box.Text;
                                cmd.Parameters.AddWithValue("@product_name", product_name_value);
                                cmd.CommandText = @"INSERT INTO Purchase (""Product ID"" , ""Product Barcode"", ""Product Name"", ""Supplier ID"" , ""Supplier Name"", ""Quantity"" , ""Price"", ""Date"")
                                                    SELECT p.id , p.barcode , p.name , c.id , c.name , @product_quantity , @price , @date  
                                                    FROM supplier c 
                                                    JOIN Product p 
                                                    ON (p.name = @product_name AND c.id = @supplier_id )";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = @"UPDATE Product 
                                                        SET quantity = quantity + @product_quantity ,
                                                        Date = @date
                                                        WHERE name = @product_name";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = @"IF EXISTS 
                                                         (SELECT quantity FROM ProductReport WHERE ""Product Name""
                        = @product_name AND date = @date AND status = @status) 
                                                            UPDATE ProductReport SET quantity =                                       quantity + @product_quantity 
                                                            WHERE ""Product Name"" = @product_name AND date = @date AND status = @status; 
                                                            ELSE INSERT INTO ProductReport 
                                                            (""Product ID"", ""Product Name"" , ""Product Barcode"",date, quantity , status) 
                                                            SELECT p.id , p.name , p.barcode, @date, @product_quantity   , @status
                                                            FROM Product p 
                                                            WHERE p.name = @product_name;";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = $@"INSERT INTO InventoryReport 
                                                            (""Product ID"", ""Product Name"" , ""Product Barcode"",date, quantity) 
                                                            SELECT p.id , p.name , p.barcode, @date, @product_quantity
                                                            FROM Product p 
                                                            WHERE p.name = @product_name;";
                                cmd.ExecuteNonQuery();
                            }

                            else if (product_id_text_box.Text != "")
                            {
                                cmd.Parameters.AddWithValue("@product_id", product_id_value);
                                cmd.CommandText = @"INSERT INTO Purchase (""Product ID"" , ""Product Barcode"", ""Product Name"", ""Supplier ID"" , ""Supplier Name"", ""Quantity"", ""Price"" , ""Date"") 
                                                        SELECT p.id , p.barcode , p.name , c.id , c.name , @product_quantity , @price , @date
                                                        FROM supplier c
                                                        JOIN Product p
                                                        ON (p.id = @product_id AND c.id = @supplier_id )";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = @"UPDATE Product SET quantity = quantity + @product_quantity ,
                                                        Date = @date
                                                        WHERE id = @product_id";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = @"IF EXISTS (SELECT quantity FROM ProductReport WHERE ""Product ID"" = @product_id  AND date = @date AND status = @status) 
                                                        UPDATE ProductReport SET quantity =                                       quantity + @product_quantity 
                                                        WHERE ""Product ID"" = @product_id AND date = @date AND status = @status; 
                                                        ELSE INSERT INTO ProductReport 
                                                        (""Product ID"", ""Product Name"" , ""Product Barcode"" ,date, quantity , status) 
                                                        SELECT p.id , p.name, p.barcode ,  @date, @product_quantity   , @status 
                                                        FROM Product p 
                                                        WHERE p.id = @product_id;";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = $@"INSERT INTO InventoryReport 
                                                            (""Product ID"", ""Product Name"" , ""Product Barcode"",date, quantity) 
                                                            SELECT p.id , p.name , p.barcode, @date, @product_quantity
                                                            FROM Product p 
                                                            WHERE p.id = @product_id;";
                                cmd.ExecuteNonQuery();
                            }

                            else if (product_barcode_text_box.Text != "")
                            {
                                cmd.Parameters.AddWithValue("@product_barcode", product_barcode_value);
                                cmd.CommandText = @"INSERT INTO Purchase (""Product ID"" , ""Product Barcode"", ""Product Name"", ""Supplier ID"" , ""Supplier Name"", ""Quantity"", ""Price"" , ""Date"") 
                                                        SELECT p.id , p.barcode , p.name , c.id , c.name , @product_quantity , @price , @date  
                                                        FROM supplier c
                                                        JOIN Product p
                                                        ON (p.barcode = @product_barcode AND c.id = @supplier_id )";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = @"UPDATE Product SET quantity = quantity + @product_quantity ,
                                                        Date = @date
                                                        WHERE barcode = @product_barcode";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = @"IF EXISTS (SELECT quantity FROM ProductReport WHERE ""Product Barcode"" = @product_barcode  AND date = @date AND status = @status) 
                                                        UPDATE ProductReport SET quantity =                                       quantity + @product_quantity 
                                                        WHERE ""Product Barcode"" = @product_barcode AND date = @date AND status = @status; 
                                                        ELSE INSERT INTO ProductReport 
                                                        (""Product ID"", ""Product Name"", ""Product Barcode"" ,date, quantity , status) 
                                                        SELECT p.id , p.name , p.barcode , @date, @product_quantity   , @status
                                                        FROM Product p 
                                                        WHERE p.barcode = @product_barcode;";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = $@"INSERT INTO InventoryReport 
                                                            (""Product ID"", ""Product Name"" , ""Product Barcode"",date, quantity) 
                                                            SELECT p.id , p.name , p.barcode, @date, @product_quantity
                                                            FROM Product p 
                                                            WHERE p.barcode = @product_barcode;";
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            supplier_name_value = supplier_name_text_box.Text;
                            cmd.Parameters.AddWithValue("@supplier_name", supplier_name_value);

                            if (product_name_text_box.Text != "")
                            {
                                product_name_value = product_name_text_box.Text;
                                cmd.Parameters.AddWithValue("@product_name", product_name_value);
                                cmd.CommandText = @"INSERT INTO Purchase (""Product ID"" , ""Product Barcode"", ""Product Name"", ""Supplier ID"" , ""Supplier Name"", ""Quantity"", ""Price"" , ""Date"") SELECT p.id , p.barcode ,  p.name , c.id , c.name , @product_quantity , @price , @date  
                                                        FROM supplier c 
                                                        JOIN Product p
                                                        ON (p.name = @product_name AND c.name = @supplier_name )";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = @"UPDATE Product 
                                                        SET quantity = quantity + @product_quantity,
                                                        Date = @date
                                                        WHERE name = @product_name";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = $@"IF EXISTS 
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
                                                            SELECT p.id , p.name , p.barcode, @date, @product_quantity
                                                            FROM Product p 
                                                            WHERE p.name = @product_name;";
                                cmd.ExecuteNonQuery();
                            }

                            else if (product_id_text_box.Text != "")
                            {
                                cmd.Parameters.AddWithValue("@product_id", product_id_value);
                                cmd.CommandText = @"INSERT INTO Purchase (""Product ID"" , ""Product Barcode"", ""Product Name"", ""Supplier ID"" , ""Supplier Name"", Quantity, ""Price"" , ""Date"") 
                                                        SELECT p.id , p.barcode , p.name , c.id , c.name , @product_quantity , @price , @date  
                                                        FROM supplier c 
                                                        JOIN Product p
                                                        ON (p.id = @product_id AND c.name = @supplier_name )";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = @"UPDATE Product SET quantity = quantity + @product_quantity ,
                                                        Date = @date
                                                        WHERE id = @product_id";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = @"IF EXISTS (SELECT quantity FROM ProductReport WHERE ""Product ID"" = @product_id  AND date = @date AND status = @status) 
                                                        UPDATE ProductReport SET quantity =                                       quantity + @product_quantity 
                                                        WHERE ""Product ID"" = @product_id AND date = @date AND status = @status; 
                                                        ELSE INSERT INTO ProductReport 
                                                        (""Product ID"" , ""Product Barcode"" , ""Product Name"",date, quantity , status) 
                                                        SELECT p.id , p.barcode , p.name, @date, @product_quantity , @status  
                                                        FROM Product p 
                                                        WHERE p.id = @product_id";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = $@"INSERT INTO InventoryReport 
                                                            (""Product ID"", ""Product Name"" , ""Product Barcode"",date, quantity) 
                                                            SELECT p.id , p.name , p.barcode, @date, @product_quantity
                                                            FROM Product p 
                                                            WHERE p.id = @product_id";
                                cmd.ExecuteNonQuery();
                            }

                            else if (product_barcode_text_box.Text != "")
                            {
                                cmd.Parameters.AddWithValue("@product_barcode", product_barcode_value);
                                cmd.CommandText = @"INSERT INTO Purchase (""Product ID"" , ""Product Barcode"", ""Product Name"", ""Supplier ID"" , ""Supplier Name"", ""Quantity"", ""Price"" ,""Date"") 
                                                        SELECT p.id , p.barcode , p.name , c.id , c.name , @product_quantity , @price , @date  
                                                        FROM supplier c 
                                                        JOIN Product p
                                                        ON (p.barcode = @product_barcode AND c.name = @supplier_name )";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = @"UPDATE Product SET quantity = quantity + @product_quantity ,
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
                                                            SELECT p.id , p.name , p.barcode, @date, @product_quantity
                                                            FROM Product p 
                                                            WHERE p.barcode = @product_barcode;";
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Data inserted successfully!");
                    ShowData();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    Shared.conn.Close();
                }
            }
            else
                MessageBox.Show("The Product is not exists");
        }
        #endregion

        #region update_button
        //update a purchase
        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (User_Entered_Purchase_Id())
                if (User_Entered_Quantity())
                    if (Check_If_Purchase_Already_Exists())
                    {
                        try
                        {
                            using (SqlCommand cmd = Shared.conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@product_quantity", product_quantity_value);
                                cmd.Parameters.AddWithValue("@status", status);
                                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                                cmd.Parameters.AddWithValue("@id", purchase_id_value);

                                cmd.CommandText = $@"UPDATE ProductReport
                                                         SET quantity = quantity + @product_quantity - 
                                                         (SELECT quantity
                                                         FROM Purchase
                                                         WHERE id = @id)
                                                         WHERE date = 
                                                         (SELECT date 
                                                         FROM Purchase 
                                                         WHERE id = @id)
                                                         AND ""Product ID"" = 
                                                         (SELECT ""Product ID""
                                                         FROM Purchase 
                                                         WHERE id = @id)
                                                         AND status = @status";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = $@"INSERT INTO InventoryReport
                                                        SELECT ""Product ID"", ""Product Barcode"", ""Product Name"", @product_quantity - quantity , @date
                                                        FROM Purchase
                                                        WHERE Purchase.id = @id;";
                                cmd.ExecuteNonQuery();


                                cmd.CommandText = @"UPDATE Product
                                                        SET Product.quantity = Product.quantity + (
                                                            SELECT @product_quantity - pu.quantity
                                                            FROM Purchase pu
                                                            WHERE pu.id = @id
                                                        )
                                                        WHERE Product.id = (
                                                            SELECT pu.""Product ID""
                                                            FROM Purchase pu
                                                            WHERE pu.id = @id
                                                        );";

                                cmd.ExecuteNonQuery();

                                cmd.CommandText = @"UPDATE Purchase
                                                        SET quantity = @product_quantity
                                                        WHERE id = @id";

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Record updated successfully.");
                                }
                                else
                                {
                                    MessageBox.Show("No record found with the specified id.");
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
                        MessageBox.Show("The Purchase doesn't exists");
                    }
        }
        #endregion

        #region Reset_button
        //searching for a purchase
        private void searchBtn_Click(object sender, EventArgs e)
        {
            purchase_id_text_box.Text =
            product_id_text_box.Text =
            product_barcode_text_box.Text =
            product_name_text_box.Text =
            product_quantity_text_box.Text =
            supplier_id_text_box.Text =
            supplier_name_text_box.Text = "";
            ShowData();
        }
        #endregion

        #region delete(returned)_button
        //delete the purchase (product was returned)
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            DialogResult delete;
            delete = MessageBox.Show($"Are you sure that you want to delete the record with id '{purchase_id_text_box.Text}' ", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (delete == DialogResult.Yes)
            {
                if (User_Entered_Purchase_Id())
                    if (Check_If_Purchase_Already_Exists())
                    {
                        try
                        {
                            using (SqlCommand cmd = Shared.conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@id", purchase_id_value);
                                cmd.Parameters.AddWithValue("@status", status);
                                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                                cmd.CommandText = @"UPDATE Product
                                                    SET Product.quantity = Product.quantity - Purchase.quantity , 
                                                    Product.date = @date    
                                                    FROM Product
                                                    JOIN Purchase ON Product.id = Purchase.""Product ID""
                                                    WHERE Purchase.id = @id";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = $@"UPDATE ProductReport 
                                                    SET quantity = quantity - 
                                                    (SELECT quantity
                                                     FROM Purchase                                                   
                                                     WHERE id = @id)
                                                     WHERE ""Product ID"" = (
                                                     SELECT ""Product ID""
                                                     FROM Purchase 
                                                     WHERE ID = @id)
                                                     AND date = 
                                                     (SELECT date 
                                                     FROM Purchase 
                                                     WHERE id = @id)
                                                     AND status = @status";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = $@"INSERT INTO InventoryReport
                                                        SELECT ""Product ID"", ""Product Barcode"", ""Product Name"", -quantity , @date
                                                        FROM Purchase
                                                        WHERE Purchase.id = @id;";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = "DELETE FROM Purchase WHERE id = @id";

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Record deleted successfully.");
                                }
                                else
                                {
                                    MessageBox.Show("No record found with the specified id.");
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
                        MessageBox.Show("The Purchase doesn't exists");
                    }
            }
            else
            {
                MessageBox.Show("Nothing has been changed", "Inventory Management System");
                ShowData();
            }
        }
        #endregion

        #region delete(from log)_button
        //delete a purchase only from the log
        private void button1_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            DialogResult delete;
            delete = MessageBox.Show($"Are you sure that you want to delete the record with id '{purchase_id_text_box.Text}' ", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (delete == DialogResult.Yes)
            {
                if (User_Entered_Purchase_Id())
                    if (Check_If_Purchase_Already_Exists())
                    {
                        try
                        {
                            using (SqlCommand cmd = Shared.conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "DELETE FROM Purchase WHERE id = @id";
                                cmd.Parameters.AddWithValue("@id", purchase_id_value);


                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Record deleted successfully.");
                                }
                                else
                                {
                                    MessageBox.Show("No record found with the specified id.");
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
                        MessageBox.Show("The Purchase doesn't exists");
                    }
            }
            else
            {
                MessageBox.Show("Nothing has been changed", "Inventory Management System");
                ShowData();
            }
        }
        #endregion

        #endregion

        #region Events For Searching

        private void purchase_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, purchase_id_text_box, "Purchase", "ID", "ID", false, "purchase id");
        }

        private void product_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, product_name_text_box, "Purchase", "Product Name", "ID");
        }

        private void product_barcode_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, product_barcode_text_box, "Purchase", "Product Barcode", "ID", false, "product barcode");
        }

        private void product_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, product_id_text_box, "Purchase", "Product ID", "ID", false, "product id");
        }

        private void product_quantity_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, product_quantity_text_box, "Purchase", "Quantity", "ID", false, "quantity");
        }

        private void supplier_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, supplier_name_text_box, "Purchase", "Supplier Name", "ID");
        }

        private void supplier_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, supplier_id_text_box, "Purchase", "Supplier ID", "ID", false, "supplier id");
        }


        #endregion

    }
}