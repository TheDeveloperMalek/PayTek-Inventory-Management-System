using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Inventory_Manager
{

    public partial class Purchases : Form
    {
        #region essential_data
        //establish connection to the server
        readonly SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        //holding data that will affect on the database
        private int customer_id_value, product_id_value, purchase_id_value, product_barcode_value, product_quantity_value;
        private string product_name_value, customer_name_value;

        public Purchases()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
        }

        private void Purchases_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'purchaseDataSet.Purchase' table. You can move, or remove it, as needed.
            this.purchaseTableAdapter2.Fill(this.publicDataSet9.Purchase);
            conn.ConnectionString = ("Data Source=DESKTOP-CM5BM88;Initial Catalog=Public;Integrated Security=True;Encrypt=False;");
            if (conn.State != ConnectionState.Open)
            {
                ShowData();
                Open_Connection_If_Was_Closed();
            }
            #region For ORM(auto Complete)

            #region from product

            var t1 = new Thread(() =>
            {
                using (PublicEntities1 db = new PublicEntities1())
                {
                    var products = db.Product.ToList();

                    var AutoCompleteProductId = new AutoCompleteStringCollection();
                    var AutoCompleteProductBarcode = new AutoCompleteStringCollection();
                    var AutoCompleteProductName = new AutoCompleteStringCollection();

                    foreach (Product p in products)
                    {
                        AutoCompleteProductId.Add(p.id.ToString());
                        AutoCompleteProductBarcode.Add(p.barcode.ToString());
                        AutoCompleteProductName.Add(p.name);
                    }

                    if (product_id_text_box.IsHandleCreated)
                    {
                        if (product_id_text_box.InvokeRequired)
                        {
                            product_id_text_box.Invoke(new Action(() =>
                            {
                                product_id_text_box.AutoCompleteCustomSource = AutoCompleteProductId;
                            }));
                        }
                        else
                        {
                            product_id_text_box.AutoCompleteCustomSource = AutoCompleteProductId;
                        }
                    }

                    if (product_name_text_box.IsHandleCreated)
                    {
                        if (product_name_text_box.InvokeRequired)
                        {
                            product_name_text_box.Invoke(new Action(() =>
                            {
                                product_name_text_box.AutoCompleteCustomSource = AutoCompleteProductName;
                            }));
                        }
                        else
                        {
                            product_name_text_box.AutoCompleteCustomSource = AutoCompleteProductName;
                        }
                    }

                    if (product_barcode_text_box.IsHandleCreated)
                    {
                        if (product_barcode_text_box.InvokeRequired)
                        {
                            product_barcode_text_box.Invoke(new Action(() =>
                            {
                                product_barcode_text_box.AutoCompleteCustomSource = AutoCompleteProductBarcode;
                            }));
                        }
                        else
                        {
                            product_barcode_text_box.AutoCompleteCustomSource = AutoCompleteProductBarcode;
                        }
                    }
                }
            });

            t1.Start();
            #endregion

            #region from customer

            var t2 = new Thread(() =>
            {
                using (CustomerEntities dbc = new CustomerEntities())
                {
                    var customers = dbc.Customer.ToList();
                    var AutoCompleteCustomerId = new AutoCompleteStringCollection();
                    var AutoCompleteCustomerName = new AutoCompleteStringCollection();

                    foreach (var customer in customers)
                    {
                        AutoCompleteCustomerId.Add(customer.id.ToString());
                        AutoCompleteCustomerName.Add(customer.name);
                    }

                    Action setupAutoComplete = () =>
                    {
                        purchaseBindingSource2.DataSource = customers;
                        customer_id_text_box.AutoCompleteCustomSource = AutoCompleteCustomerId;
                        customer_name_text_box.AutoCompleteCustomSource = AutoCompleteCustomerName;
                    };

                    if (customer_id_text_box.InvokeRequired)
                    {
                        customer_id_text_box.Invoke(setupAutoComplete);
                    }
                    else
                    {
                        setupAutoComplete();
                    }
                }
            });

            t2.Start();
            #endregion

            #endregion
        }
        #endregion

        #region startup_functions
        //Update the data of Product's table
        public void ShowData()
        {
            Open_Connection_If_Was_Closed();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Purchase ORDER BY id";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        //Shortcuts for window
        private void KeysShortcuts(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F) //make full screen
            {
                if (this.FormBorderStyle == FormBorderStyle.None)
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Normal;
                    this.Location = new System.Drawing.Point(0, 0);
                    this.Size = Screen.PrimaryScreen.Bounds.Size;
                }
                return;
            }
            if (e.Control && e.KeyCode == Keys.E) //exit
            {
                this.Close();
                return;
            }
            if (e.Control && e.KeyCode == Keys.M) //minimize
            {
                this.WindowState = FormWindowState.Minimized;
                return;
            }

            if (e.Control && e.KeyCode == Keys.I) // show information about the devleoper
            {
                ShowToast("The Developer: Muhammad Malek Alset");
                return;
            }
        }

        //showing a message as a toast
        private void ShowToast(string message)
        {
            ToolTip toast = new ToolTip();
            int screenWidth = Screen.PrimaryScreen.Bounds.Width,
            screenHeight = Screen.PrimaryScreen.Bounds.Height,
            toastWidth = 300,
            toastHeight = 50,
            x = (screenWidth - toastWidth) / 2,
            y = screenHeight - toastHeight - 75;
            toast.Show(message, this, x, y, 1500);
        }


        private void Open_Connection_If_Was_Closed()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
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
                || (customer_id_text_box.Text == "" && String.IsNullOrEmpty(customer_name_text_box.Text)
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
                if (customer_id_text_box.Text == "" && String.IsNullOrEmpty(customer_name_text_box.Text))
                {
                    MessageBox.Show("Please Enter customer's id or name ", "Inventory Management System");
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
                && String.IsNullOrEmpty(customer_id_text_box.Text)
                && String.IsNullOrEmpty(customer_name_text_box.Text)
                && String.IsNullOrEmpty(purchase_id_text_box.Text)
                )
            {
                MessageBox.Show("Please fill one of those fields to perform this action\n(product id , product barcode , product name , customer id , customer name ,purchase id)");
                return false;
            }
            return true;
        }


        private bool Check_If_There_Is_Enough_Product_Quantity(int wanted_quantity)
        {
            if (product_id_text_box.Text != "")
            {
                cmd.CommandText = $"SELECT name from Product WHERE id = {product_id_value}";
                var name = Convert.ToString(cmd.ExecuteScalar());

                cmd.CommandText = $"SELECT quantity from Product WHERE id = {product_id_value}";
                var quantity = Convert.ToInt32(cmd.ExecuteScalar());
                if (quantity >= wanted_quantity)
                {
                    return true;
                }
                MessageBox.Show($"Unavailabe because the available quantity of product \"{name}\" is {quantity}");
                return false;
            }

            if (product_name_text_box.Text != "")
            {
                cmd.CommandText = $"SELECT quantity from Product WHERE name = \'{product_name_text_box.Text}\'";
                var quantity = Convert.ToInt32(cmd.ExecuteScalar());
                if (quantity >= wanted_quantity)
                {
                    return true;
                }
                MessageBox.Show($"Unavailabe because the available quantity of product \"{product_name_text_box.Text}\" is {quantity}");
                return false;
            }

            if (product_barcode_text_box.Text != "")
            {
                cmd.CommandText = $"SELECT name from Product WHERE barcode = {product_barcode_value}";
                var name = Convert.ToString(cmd.ExecuteScalar());

                cmd.CommandText = $"SELECT quantity from Product WHERE barcode = {product_barcode_value}";
                var quantity = Convert.ToInt32(cmd.ExecuteScalar());
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

            cmd.CommandText = $"SELECT product_name from Purchase WHERE id = {purchase_id_value}";
            var name = Convert.ToString(cmd.ExecuteScalar());

            cmd.CommandText = $@"SELECT quantity FROM Purchase WHERE id = {purchase_id_value}";
            var old_quantity_of_purchase = Convert.ToInt32(cmd.ExecuteScalar());

            cmd.CommandText = $@"SELECT p.quantity from Product p JOIN Purchase pu ON pu.product_id = p.id WHERE pu.id = {purchase_id_value}";
            var quantity = Convert.ToInt32(cmd.ExecuteScalar());
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
            Open_Connection_If_Was_Closed();
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

                if (customer_name_text_box.Text == "")
                    if (!int.TryParse(customer_id_text_box.Text, out customer_id_value) || customer_id_value < 0)
                    {
                        MessageBox.Show("Please enter a valid value for customer's id field");
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

        private bool Check_If_Customer_Already_Exists()
        {
            customer_name_value = customer_name_text_box.Text;
            string checkQuery = "SELECT COUNT(*) FROM Customer WHERE name = @name OR  id = @id";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
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
            product_name_value = product_name_text_box.Text;
            string checkQuery = @"SELECT COUNT(*)
                                  FROM Product
                                  WHERE name = @name OR  id = @id OR barcode = @barcode";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
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
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
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
                if (!Check_If_Customer_Already_Exists())
                {
                    if (!String.IsNullOrEmpty(customer_name_text_box.Text))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO customer (name) VALUES (@name_value)";
                        cmd.Parameters.AddWithValue("@name_value", customer_name_value);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a name or an existed customer's id to continue process");
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
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@product_quantity", product_quantity_value);
                            cmd.Parameters.AddWithValue("@date", DateTime.Today);

                            if (String.IsNullOrEmpty(customer_name_text_box.Text))
                            {
                                cmd.Parameters.AddWithValue("@customer_id", customer_id_value);

                                if (product_name_text_box.Text != "")
                                {
                                    product_name_value = product_name_text_box.Text;
                                    cmd.Parameters.AddWithValue("@product_name", product_name_value);
                                    cmd.CommandText = @"INSERT INTO Purchase (product_id , product_barcode, product_name, customer_id , customer_name , quantity, last_modified)
                                                    SELECT p.id , p.barcode , p.name , c.id , c.name , @product_quantity , @date  
                                                    FROM Customer c 
                                                    JOIN Product p 
                                                    ON (p.name = @product_name AND c.id = @customer_id )";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"UPDATE Product 
                                                        SET quantity = quantity - @product_quantity 
                                                        WHERE name = @product_name";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"IF EXISTS 
                                                         (SELECT quantity FROM InventoryReport WHERE name
                        = @product_name AND date = @date) 
                                                            UPDATE InventoryReport SET quantity =                                       quantity + @product_quantity 
                                                            WHERE name = @product_name AND date = @date; 
                                                            ELSE INSERT INTO InventoryReport 
                                                            (id, name,date, quantity) 
                                                            SELECT p.id , p.name, @date, @product_quantity  
                                                            FROM Product p 
                                                            WHERE p.name = @product_name;";
                                    cmd.ExecuteNonQuery();
                                }

                                else if (product_id_text_box.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@product_id", product_id_value);
                                    cmd.CommandText = @"INSERT INTO Purchase (product_id, product_barcode,  product_name, customer_id , customer_name , quantity, last_modified) 
                                                        SELECT p.id , p.barcode , p.name , c.id , c.name , @product_quantity , @date  
                                                        FROM Customer c
                                                        JOIN Product p
                                                        ON (p.id = @product_id AND c.id = @customer_id )";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"UPDATE Product SET quantity = quantity - @product_quantity 
                                                        WHERE id = @product_id";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"IF EXISTS (SELECT quantity FROM InventoryReport WHERE id = @product_id  AND date = @date) 
                                                        UPDATE InventoryReport SET quantity =                                       quantity + @product_quantity 
                                                        WHERE id = @product_id AND date = @date; 
                                                        ELSE INSERT INTO InventoryReport 
                                                        (id, name,date, quantity) 
                                                        SELECT p.id , p.name, @date, @product_quantity  
                                                        FROM Product p 
                                                        WHERE p.id = @product_id;";
                                    cmd.ExecuteNonQuery();
                                }

                                else if (product_barcode_text_box.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@product_barcode", product_barcode_value);
                                    cmd.CommandText = @"INSERT INTO Purchase (product_id, product_barcode, product_name, customer_id , customer_name , quantity, last_modified) 
                                                        SELECT p.id , p.barcode , p.name , c.id , c.name , @product_quantity , @date  
                                                        FROM Customer c
                                                        JOIN Product p
                                                        ON (p.barcode = @product_barcode AND c.id = @customer_id )";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"UPDATE Product SET quantity = quantity - @product_quantity 
                                                        WHERE barcode = @product_barcode";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"IF EXISTS (SELECT quantity FROM InventoryReport WHERE barcode = @product_barcode  AND date = @date) 
                                                        UPDATE InventoryReport SET quantity =                                       quantity + @product_quantity 
                                                        WHERE barcode = @product_barcode AND date = @date; 
                                                        ELSE INSERT INTO InventoryReport 
                                                        (id, name,date, quantity) 
                                                        SELECT p.id , p.name, @date, @product_quantity  
                                                        FROM Product p 
                                                        WHERE barcode = @product_barcode;";
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                customer_name_value = customer_name_text_box.Text;
                                cmd.Parameters.AddWithValue("@customer_name", customer_name_value);

                                if (product_name_text_box.Text != "")
                                {
                                    product_name_value = product_name_text_box.Text;
                                    cmd.Parameters.AddWithValue("@product_name", product_name_value);
                                    cmd.CommandText = @"INSERT INTO Purchase (product_id, product_barcode,  product_name, customer_id , customer_name , quantity, last_modified) SELECT p.id , p.barcode ,  p.name , c.id , c.name , @product_quantity , @date  
                                                        FROM Customer c 
                                                        JOIN Product p
                                                        ON (p.name = @product_name AND c.name = @customer_name )";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"UPDATE Product 
                                                        SET quantity = quantity - @product_quantity
                                                        WHERE name = @product_name";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"IF EXISTS  (SELECT quantity FROM InventoryReport WHERE name =  @product_name AND date = @date) 
                                                        UPDATE InventoryReport SET quantity =                                       quantity + @product_quantity 
                                                        WHERE name = @product_name AND date =                                       @date; 
                                                        ELSE INSERT INTO InventoryReport (id, barcode ,  name,date, quantity) 
                                                        SELECT p.id, p.barcode , p.name, @date,                                                @product_quantity  
                                                        FROM Product p 
                                                        WHERE p.name = @product_name;";
                                    cmd.ExecuteNonQuery();
                                }

                                else if (product_id_text_box.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@product_id", product_id_value);
                                    cmd.CommandText = @"INSERT INTO Purchase (product_id, product_barcode, product_name, customer_id , customer_name , quantity , last_modified) 
                                                        SELECT p.id , p.barcode , p.name , c.id , c.name , @product_quantity , @date  
                                                        FROM Customer c 
                                                        JOIN Product p
                                                        ON (p.id = @product_id AND c.name = @customer_name )";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"UPDATE Product SET quantity = quantity - @product_quantity 
                                                        WHERE id = @product_id";
                                    cmd.ExecuteNonQuery();
                                    cmd.CommandText = @"IF EXISTS (SELECT quantity FROM InventoryReport                                    WHERE id = @product_id AND date = @date) 
                                                        UPDATE InventoryReport SET quantity =                                       quantity + @product_quantity
                                                        WHERE id = @product_id AND date = @date; 
                                                        ELSE INSERT INTO InventoryReport (id, barcode ,  name,date, quantity) 
                                                        SELECT p.id , p.barcode , p.name, @date,                                                @product_quantity  
                                                        FROM Product p 
                                                        WHERE p.id = @product_id;";
                                    cmd.ExecuteNonQuery();
                                }

                                else if (product_barcode_text_box.Text != "")
                                {
                                    cmd.Parameters.AddWithValue("@product_barcode", product_barcode_value);
                                    cmd.CommandText = @"INSERT INTO Purchase (product_id, product_barcode,  product_name, customer_id , customer_name , quantity , last_modified) 
                                                        SELECT p.id , p.barcode , p.name , c.id , c.name , @product_quantity , @date  
                                                        FROM Customer c 
                                                        JOIN Product p
                                                        ON (p.barcode = @product_barcode AND c.name = @customer_name )";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"UPDATE Product SET quantity = quantity - @product_quantity 
                                                        WHERE barcode = @product_barcode";
                                    cmd.ExecuteNonQuery();
                                    cmd.CommandText = @"IF EXISTS (SELECT quantity FROM InventoryReport                                    WHERE barcode = @product_barcode AND date = @date) 
                                                        UPDATE InventoryReport SET quantity =                                       quantity + @product_quantity
                                                        WHERE barcode = @product_barcode AND date = @date; 
                                                        ELSE INSERT INTO InventoryReport (id, barcode , name,date, quantity) 
                                                        SELECT p.id , p.barcode , p.name, @date,                                                @product_quantity  
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
                        conn.Close();
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
                        if (Check_If_There_Is_Enough_Product_Quantity_Update(product_quantity_value))
                            try
                            {
                                using (SqlCommand cmd = conn.CreateCommand())
                                {
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Parameters.AddWithValue("@product_quantity", product_quantity_value);
                                    cmd.Parameters.AddWithValue("@id", purchase_id_value);

                                    cmd.CommandText = @"UPDATE Product
                                                        SET Product.quantity = Product.quantity - (
                                                            SELECT @product_quantity - pu.quantity
                                                            FROM Purchase pu
                                                            WHERE pu.id = @id
                                                        )
                                                        WHERE Product.id = (
                                                            SELECT pu.product_id
                                                            FROM Purchase pu
                                                            WHERE pu.id = @id
                                                        );";

                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = @"UPDATE InventoryReport
                                                    SET InventoryReport.quantity =                                              InventoryReport.quantity + (
                                                    SELECT @product_quantity - pu.quantity
                                                    FROM Purchase pu
                                                    WHERE pu.id = @id
                                                    )
                                                    WHERE InventoryReport.id = (
                                                    SELECT pu.product_id
                                                    FROM Purchase pu
                                                    WHERE pu.id = @id) AND date =  
                                                    (SELECT last_modified
                                                    FROM Purchase 
                                                    WHERE id = @id
                                                    )";

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
                                conn.Close();
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

        #region search_button
        //searching for a purchase
        private void searchBtn_Click(object sender, EventArgs e)
        {
            Open_Connection_If_Was_Closed();
            if (At_Least_Input_For_Search())
            {
                cmd = conn.CreateCommand();
                if (!(product_name_text_box.Text == ""))
                {

                    product_name_value = product_name_text_box.Text;
                    cmd.CommandText = "SELECT * FROM Purchase WHERE product_name LIKE @product_name";
                }

                else if (!(product_id_text_box.Text == ""))
                {
                    if (!int.TryParse(product_id_text_box.Text, out product_id_value) || product_id_value < 0)
                    {
                        MessageBox.Show("Please enter a valid value for product's id field");
                        return;
                    }
                    cmd.CommandText = "SELECT * FROM Purchase WHERE product_id = @product_id";
                }

                else if (!(product_barcode_text_box.Text == ""))
                {
                    if (!int.TryParse(product_barcode_text_box.Text, out product_barcode_value) || product_barcode_value < 0)
                    {
                        MessageBox.Show("Please enter a valid value for product's barcode field");
                        return;
                    }
                    cmd.CommandText = "SELECT * FROM Purchase WHERE product_barcode = @product_barcode";
                }

                else if (!(customer_name_text_box.Text == ""))
                {
                    customer_name_value = customer_name_text_box.Text;
                    cmd.CommandText = "SELECT * FROM Purchase WHERE customer_name LIKE @customer_name";
                }

                else if (!(customer_id_text_box.Text == ""))
                {
                    if (!int.TryParse(customer_id_text_box.Text, out customer_id_value) || customer_id_value < 0)
                    {
                        MessageBox.Show("Please enter a valid value for customer's id field");
                        return;
                    }
                    cmd.CommandText = "SELECT * FROM Purchase WHERE customer_id = @customer_id";
                }

                else
                {
                    if (!int.TryParse(purchase_id_text_box.Text, out purchase_id_value) || purchase_id_value < 0)
                    {
                        MessageBox.Show("Please enter a valid value for purchase's id field");
                        return;
                    }
                    cmd.CommandText = "SELECT * FROM Purchase WHERE id = @purchase_id";
                }

                cmd.Parameters.AddWithValue("@purchase_id", purchase_id_value);
                cmd.Parameters.AddWithValue("@product_barcode", product_barcode_value);
                cmd.Parameters.AddWithValue("@product_name", "%" + product_name_value + "%");
                cmd.Parameters.AddWithValue("@product_id", product_id_value);
                cmd.Parameters.AddWithValue("@customer_name", "%" + customer_name_value + "%");
                cmd.Parameters.AddWithValue("@customer_id", customer_id_value);
                try
                {
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        #endregion

        #region delete(returned)_button
        //delete the purchase (product was returned)
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Open_Connection_If_Was_Closed();
            DialogResult delete;
            delete = MessageBox.Show($"Are you sure that you want to delete the record with id '{purchase_id_text_box.Text}' ", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (delete == DialogResult.Yes)
            {
                if (User_Entered_Purchase_Id())
                    if (Check_If_Purchase_Already_Exists())
                    {
                        try
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@id", purchase_id_value);
                                cmd.CommandText = @"UPDATE Product
                                                    SET Product.quantity = Product.quantity + Purchase.quantity
                                                    FROM Product
                                                    JOIN Purchase ON Product.id = Purchase.product_id
                                                    WHERE Purchase.id = @id";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = @"UPDATE InventoryReport
                                                    SET InventoryReport.quantity = 
                                                    InventoryReport.quantity - Purchase.quantity
                                                    FROM InventoryReport
                                                    JOIN Purchase ON 
                                                   InventoryReport.id = Purchase.product_id
                                                    WHERE Purchase.id = @id 
                                                    AND date =  
                                                    (SELECT last_modified
                                                    FROM Purchase 
                                                    WHERE id = @id
                                                    )";
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
                            conn.Close();
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
            Open_Connection_If_Was_Closed();
            DialogResult delete;
            delete = MessageBox.Show($"Are you sure that you want to delete the record with id '{purchase_id_text_box.Text}' ", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (delete == DialogResult.Yes)
            {
                if (User_Entered_Purchase_Id())
                    if (Check_If_Purchase_Already_Exists())
                    {
                        try
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
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
                            conn.Close();
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

        #region autocomplete textbox Functions

        #region complete for product id
        private void product_id_text_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (PublicEntities1 db = new PublicEntities1())
                {
                    productBindingSource.DataSource = db.Product.Where(p => p.id.ToString().Contains(product_id_text_box.Text)).ToList();
                }
            }
        }
        #endregion

        #region complete for product name
        private void product_name_text_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (PublicEntities1 db = new PublicEntities1())
                {
                    productBindingSource.DataSource = db.Product.Where(p => p.name.Contains(product_name_text_box.Text)).ToList();
                }
            }
        }
        #endregion

        #region complete for customer id
        private void customer_id_text_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (CustomerEntities db = new CustomerEntities())
                {
                    customerBindingSource.DataSource = db.Customer.Where(p => p.id.ToString().Contains(customer_id_text_box.Text)).ToList();
                }
            }
        }
        #endregion

        #region complete for customer name
        private void customer_name_text_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (CustomerEntities db = new CustomerEntities())
                {
                    customerBindingSource.DataSource = db.Customer.Where(p => p.name.Contains(customer_id_text_box.Text)).ToList();
                }
            }
        }
        #endregion

        #endregion

        #region entities
        private void Purchase_Load(object sender, EventArgs e) { }
        private void note_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void product_id_text_box_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void customer_name_text_box_TextChanged(object sender, EventArgs e) { }
        private void purchase_id_text_box_TextChanged(object sender, EventArgs e) { }
        #endregion
    }
}