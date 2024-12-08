﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Inventory_Manager
{
    public partial class UserProductsWindow : Form
    {
        #region essential_data
        //establish connection to the server
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        //holding data that will affect on the database
        private int id_value, quantity_value, barcode_value;
        private string name_value;
        private double price_value;

        public UserProductsWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
        }

        //database table dataview 
        private void Test_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'productDataSet1.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.productDataSet1.Product);
            conn.ConnectionString = ("Data Source=DESKTOP-CM5BM88;Initial Catalog=Public;Integrated Security=True;Encrypt=False;");
            if (conn.State != ConnectionState.Open)
            {
                ShowData();
                Open_Connection_If_Was_Closed();
            }
        }

        #endregion

        #region startup_functions
        private void Open_Connection_If_Was_Closed()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
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

        //Update the data of Product's table
        public void ShowData()
        {
            Open_Connection_If_Was_Closed();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Product ORDER BY id";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        #endregion

        #region validation_functions
        //Check if the text boxes were empty
        private bool Chech_If_Text_Boxes_Were_Empty()
        {
            if (String.IsNullOrEmpty(product_name_text_box.Text))
            //|| product_id_text_box.Text == ""
            //|| product_quantity_text_box.Text == ""
            //|| product_price_text_box.Text == "")
            {
                //if (product_id_text_box.Text == "")
                //{
                //    MessageBox.Show("Please Enter Id ", "Inventory Management System");
                //    return true;
                //}
                if (String.IsNullOrEmpty(product_name_text_box.Text))
                {
                    MessageBox.Show("Please Enter name of the product", "Inventory Management System");
                    return true;
                }
                //if (product_quantity_text_box.Text == "")
                //{
                //    MessageBox.Show("Please Enter Quantity ", "Inventory Management System");
                //    return true;
                //}
                //if (product_price_text_box.Text == "")
                //{
                //    MessageBox.Show("Please Enter Price ", "Inventory Management System");
                //    return true;
                //}
            }
            return false;
        }

        //Check the validity of user input
        public bool Validation_of_input()
        {
            Open_Connection_If_Was_Closed();
            if (!Chech_If_Text_Boxes_Were_Empty())
            {
                name_value = product_name_text_box.Text;
                //if (!int.TryParse(product_id_text_box.Text, out id_value) || id_value < 0)
                //{
                //    MessageBox.Show("Please enter a valid value for the id field");
                //    return false;
                //}if (product_quantity_text_box.Text != "")
                if (!int.TryParse(product_barcode_text_box.Text, out barcode_value) || barcode_value < 0)
                {
                    MessageBox.Show("Please enter a valid value for the barcode field");
                    return false;
                }
                if (product_quantity_text_box.Text != "")
                    if (!int.TryParse(product_quantity_text_box.Text, out quantity_value) || quantity_value < 0)
                    {
                        MessageBox.Show("Please enter a valid value for the quantity field");
                        return false;
                    }
                if (product_price_text_box.Text != "")
                    if (!double.TryParse(product_price_text_box.Text, out price_value) || price_value < 0)
                    {
                        MessageBox.Show("Please enter a valid value for the product price field");
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
                MessageBox.Show("Please type a name or an id at least to perform this action", "Inventory Management System");
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
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
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
            Open_Connection_If_Was_Closed();
            if (Validation_of_input())
                if (!Check_If_Product_Already_Exists())
                {
                    string name_value = product_name_text_box.Text;
                    try
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@id_value", id_value);
                            cmd.Parameters.AddWithValue("@barcode_value", barcode_value);
                            cmd.Parameters.AddWithValue("@name_value", name_value);
                            cmd.Parameters.AddWithValue("@quantity_value", quantity_value);
                            cmd.Parameters.AddWithValue("@price_value", price_value);
                            cmd.Parameters.AddWithValue("@status_value", "Added new product");
                            cmd.Parameters.AddWithValue("@date_value", DateTime.Now);

                            cmd.CommandText = @"INSERT INTO Product (barcode , name, quantity, price) 
                                                VALUES (
                                                        @barcode_value ,
                                                        @name_value,
                                                        @quantity_value,
                                                        @price_value
                                                        )
                                                ";
                            cmd.ExecuteNonQuery();


                            cmd.CommandText = $@"INSERT INTO ProductReport 
                                                 VALUES (
                                                         (SELECT id FROM Product WHERE name = @name_value),
                                                         @barcode_value , 
                                                         @name_value, 
                                                         @status_value , 
                                                         @quantity_value, 
                                                         @date_value
                                                        )
                                                 ";
                            cmd.ExecuteNonQuery();

                        }

                        MessageBox.Show("Data inserted successfully!");
                        cmd.Parameters.Clear();
                        ShowData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
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
            Open_Connection_If_Was_Closed();
            {
                if (At_Least_Input_Requriements())
                    if (Check_If_Product_Already_Exists())
                    {
                        using (SqlCommand updateCmd = conn.CreateCommand())
                        {
                            updateCmd.CommandType = CommandType.Text;
                            updateCmd.Parameters.AddWithValue("@id", id_value);
                            updateCmd.Parameters.AddWithValue("@barcode", barcode_value);
                            updateCmd.Parameters.AddWithValue("@name", name_value);
                            updateCmd.Parameters.AddWithValue("@date", DateTime.Now);
                            updateCmd.Parameters.AddWithValue("@status", "Updated product's quantity");

                            if (product_quantity_text_box.Text != ""
                                || product_name_text_box.Text != ""
                                    || product_barcode_text_box.Text != ""
                                    || product_price_text_box.Text != "")
                            {
                                if (!(product_quantity_text_box.Text == "")
                                    )
                                {

                                    if (!int.TryParse(product_quantity_text_box.Text, out quantity_value))
                                    {
                                        MessageBox.Show("Please enter a valid value for the id field");
                                        return;
                                    }
                                    if (product_name_text_box.Text != "")
                                    {
                                        updateCmd.CommandText = @"INSERT INTO ProductReport 
                                                                  VALUES (
                                                                          (SELECT id from Product where name = @name) ,
                                                                          (SELECT barcode from Product where name = @name) ,
                                                                            @name ,
                                                                            @status ,
                                                                            @quantity ,
                                                                            @date
                                                                         )
                                                                ";
                                        updateCmd.Parameters.AddWithValue("@quantity", quantity_value);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                    if (product_id_text_box.Text != "")
                                    {
                                        updateCmd.CommandText = @"INSERT INTO ProductReport
                                                                 VALUES (
                                                                            @id , 
                                                                            (SELECT barcode from Product where id = @id) ,
                                                                            (SELECT name from Product where id = @id) ,
                                                                            @status,
                                                                            @quantity ,
                                                                            @date
                                                                        )
                                                                 ";
                                        updateCmd.Parameters.AddWithValue("@quantity", quantity_value);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                    if (product_barcode_text_box.Text != "")
                                    {
                                        updateCmd.CommandText = @"INSERT INTO ProductReport
                                                                  VALUES (
                                                                            (SELECT id from Product where barcode = @barcode) , 
                                                                            @barcode ,
                                                                            (SELECT name from Product where barcode = @barcode) ,
                                                                            @status,
                                                                            @quantity ,
                                                                            @date
                                                                          )
                                                                 ";
                                        updateCmd.Parameters.AddWithValue("@quantity", quantity_value);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                    updateCmd.CommandText = "UPDATE Product SET quantity = @quantity WHERE name = @name OR id = @id or barcode = @barcode";
                                    updateCmd.ExecuteNonQuery();
                                }
                                if (!(product_price_text_box.Text == ""))
                                {

                                    if (!double.TryParse(product_price_text_box.Text, out price_value))
                                    {
                                        MessageBox.Show("Please enter a valid value for the id field");
                                        return;
                                    }
                                    updateCmd.CommandText = "UPDATE Product SET price = @price   WHERE name = @name OR id = @id OR barcode = @barcode";
                                    updateCmd.Parameters.AddWithValue("@price", price_value);
                                    updateCmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Type atleast something to update the data");
                                return;
                            }

                            int.TryParse(updateCmd.ExecuteNonQuery().ToString(), out int rowsAffected);

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Product updated successfully.");
                            }
                            else
                            {
                                MessageBox.Show("No product was updated.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Product doesn't exists");
                    }
            }
            ShowData();
            conn.Close();
            return;
        }
        #endregion

        #region delete_button
        //Delete a product
        private void button3_Click(object sender, EventArgs e)
        {
            Open_Connection_If_Was_Closed();
            DialogResult delete;
            delete = MessageBox.Show($"Are you sure that you want to delete the record with product name '{product_name_text_box.Text}' and id '{product_id_text_box.Text}' ", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (delete == DialogResult.Yes)
            {
                if (At_Least_Input_Requriements())
                    if (Check_If_Product_Already_Exists())
                    {
                        try
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                                cmd.Parameters.AddWithValue("@status", "Deleted a product");
                                if (product_id_text_box.Text != "")
                                {

                                    cmd.CommandText = @"INSERT INTO ProductReport 
                                                        VALUES ( 
                                                                @id , 
                                                                (SELECT barcode from Product where id = @id) , 
                                                                (SELECT name from Product where id = @id) , 
                                                                @status, 
                                                                (SELECT quantity from Product where id = @id) , 
                                                                @date
                                                                )
                                                       ";
                                    cmd.Parameters.AddWithValue("@id", id_value);
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = "DELETE FROM Product WHERE id = @id";
                                }

                                else if (product_barcode_text_box.Text != "")
                                {
                                    cmd.CommandText = @"INSERT INTO ProductReport
                                                        VALUES (
                                                                (SELECT id FROM Product WHERE barcode = @barcode) ,
                                                                @barcode ,
                                                                (SELECT name FROM Product WHERE barcode = @barcode) ,
                                                                @status ,
                                                                (SELECT quantity FROM Product WHERE barcode = @barcode) ,
                                                                @date
                                                               )
                                                        ";
                                    cmd.Parameters.AddWithValue("@barcode", barcode_value);
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = "DELETE FROM Product WHERE barcode = @barcode";
                                }

                                else if (product_name_text_box.Text != "")
                                {
                                    cmd.CommandText = @"INSERT INTO ProductReport 
                                                        VALUES (
                                                                (SELECT id from Product where name = @name) ,
                                                                (SELECT barcode from Product where name = @name) ,
                                                                @name , 
                                                                @status , 
                                                                (SELECT quantity from Product where name = @name) , 
                                                                @date
                                                                )
                                                       ";
                                    cmd.Parameters.AddWithValue("@name", name_value);
                                    cmd.ExecuteNonQuery();

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
                            conn.Close();
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

        #region search_button
        //Search by name or id button
        private void printBtn_Click(object sender, EventArgs e)
        {
            Open_Connection_If_Was_Closed();
            if (At_Least_Input_Requriements())
            {
                cmd = conn.CreateCommand();
                if (!(product_name_text_box.Text == ""))
                    cmd.CommandText = "SELECT * FROM Product WHERE name LIKE @name";
                else if (product_id_text_box.Text != "")
                    cmd.CommandText = "SELECT * FROM Product WHERE id = @id";
                else
                    cmd.CommandText = "SELECT * FROM Product WHERE barcode = @barcode";

                cmd.Parameters.AddWithValue("@id", id_value);
                cmd.Parameters.AddWithValue("@barcode", barcode_value);
                cmd.Parameters.AddWithValue("@name", "%" + name_value + "%");

                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
        #endregion

        #endregion

        #region entities
        private void label1_Click(object sender, EventArgs e) { }
        private void product_name_text_box_TextChanged(object sender, EventArgs e) { }
        private void product_quantity_text_box_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void publicDataSetBindingSource_CurrentChanged(object sender, EventArgs e) { }
        private void productBindingSource_CurrentChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void product_price_text_box_TextChanged(object sender, EventArgs e) { }
        private void productBindingSource1_CurrentChanged(object sender, EventArgs e) { }
        private void productBindingSource2_CurrentChanged(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        #endregion
    }
}