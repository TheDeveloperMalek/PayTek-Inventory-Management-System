using Inventory_Manager.PublicDataSet5TableAdapters;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Customers : Form
    {
        #region essential_data
        //establish connection to the server
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        //holding data that will affect on the database
        private int id_value;
        private string name_value;

        public Customers()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
        }
        private void Product_Load(object sender, EventArgs e)
        {
            var customerTableAdapter = new CustomerTableAdapter();
            string connectionString = ConfigurationManager.ConnectionStrings["Inventory_Manager.Properties.Settings.PublicConnectionString"].ConnectionString;
            string machineName = Environment.MachineName;
            connectionString = connectionString.Replace("{MachineName}", machineName);
            customerTableAdapter.Connection.ConnectionString = connectionString;
            customerTableAdapter.Fill(this.publicDataSet5.Customer);
            conn.ConnectionString = connectionString;
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
        //Update the data of customer's table
        public void ShowData()
        {
            Open_Connection_If_Was_Closed();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM customer ORDER BY id";
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
        #endregion

        #region Functions_For_Events
        void SearchCommand(string command, SqlCommand objCmd)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = command;
            cmd.Parameters.AddWithValue("@id", id_value + "%");
            cmd.Parameters.AddWithValue("@name", "%" + name_value + "%");
            cmd.ExecuteNonQuery();
            ShowDataSearching(objCmd);
            cmd.Parameters.Clear();
            cmd.Dispose();
        }

        void ShowDataSearching(SqlCommand objCmd)
        {
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
            if (customer_id_text_box.Text == "" || String.IsNullOrEmpty(customer_name_text_box.Text))
            {
                if (customer_id_text_box.Text == "")
                {
                    MessageBox.Show("Please Enter Id ", "Inventory Management System");
                    return true;
                }
                if (String.IsNullOrEmpty(customer_name_text_box.Text))
                {
                    MessageBox.Show("Please Enter name of the customer", "Inventory Management System");
                    return true;
                }
            }
            return false;
        }

        //Check the validity of user input
        public bool Validation_of_input()
        {
            Open_Connection_If_Was_Closed();
            if (!Chech_If_Text_Boxes_Were_Empty())
            {
                name_value = customer_name_text_box.Text;
                if (!int.TryParse(customer_id_text_box.Text, out id_value) || id_value < 0)
                {
                    MessageBox.Show("Please enter a valid value for the id field");
                    return false;
                }
                return true;
            }
            return false;
        }
        //At least requriements to update or delete records
        public bool At_Least_Input_Requriements()
        {
            if (customer_id_text_box.Text == "" && customer_name_text_box.Text == "")
            {
                MessageBox.Show("Please type a name or an id at least to perform this action", "Inventory Management System");
                return false;
            }
            if (!int.TryParse(customer_id_text_box.Text, out id_value) && customer_name_text_box.Text == "")
            {
                MessageBox.Show("Please enter a valid value for the id field");
                return false;
            }
            name_value = customer_name_text_box.Text;
            return true;
        }
        //At least requriements to update or delete records
        public bool At_Least_Input_Name()
        {
            if (customer_name_text_box.Text == "")
            {
                MessageBox.Show("Please type a name at least to add new customer", "Inventory Management System");
                return false;
            }
            name_value = customer_name_text_box.Text;
            return true;
        }

        //Chech if the current customer exists or not
        private bool Check_If_Customer_Already_Exists()
        {
            string checkQuery = "SELECT COUNT(*) FROM Customer WHERE name = @name OR  id = @id";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@id", id_value);
                checkCmd.Parameters.AddWithValue("@name", name_value);

                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);

                if (productCount > 0)
                {
                    return true;
                }
                return false;
            }
        }

        private bool Check_If_CustomerId_Already_Exists()
        {
            string checkQuery = "SELECT COUNT(*) FROM Customer WHERE id = @id";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@id", id_value);

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
        private void saveBtn_Click(object sender, EventArgs e)
        {
            Open_Connection_If_Was_Closed();
            if (At_Least_Input_Name())
                if (!Check_If_Customer_Already_Exists())
                {
                    string name_value = customer_name_text_box.Text;
                    try
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "INSERT INTO customer (name) VALUES (@name_value)";

                            // Add parameters
                            cmd.Parameters.AddWithValue("@name_value", name_value);

                            cmd.ExecuteNonQuery(); // Execute the command
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
                        conn.Close(); // Ensure the connection is closed
                    }
                    ShowData();
                    return;
                }
                else if (Check_If_Customer_Already_Exists())
                {
                    MessageBox.Show("The customer already exists , please update it using update button");
                }
        }
        #endregion

        #region update_button
        private void updateBtn_Click(object sender, EventArgs e)
        {
            Open_Connection_If_Was_Closed();
            {
                if (int.TryParse(customer_id_text_box.Text, out id_value))
                {
                    if (Check_If_CustomerId_Already_Exists())
                    {
                        using (SqlCommand updateCmd = conn.CreateCommand())
                        {
                            name_value = customer_name_text_box.Text;
                            updateCmd.CommandType = CommandType.Text;
                            updateCmd.Parameters.AddWithValue("@id", id_value);
                            updateCmd.Parameters.AddWithValue("@name", name_value);
                            if (!(customer_name_text_box.Text == ""))
                            {
                                updateCmd.CommandText = "UPDATE customer SET name = @name WHERE id = @id";
                                updateCmd.ExecuteNonQuery();
                            }
                            else
                            {
                                MessageBox.Show("Type atleast something to update the data");
                                return;
                            }

                            int.TryParse(updateCmd.ExecuteNonQuery().ToString(), out int rowsAffected);

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("customer updated successfully.");
                            }
                            else
                            {
                                MessageBox.Show("No customer was updated.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("The customer doesn't exists");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid value for the id field");
                    return;
                }
            }
            ShowData();
            conn.Close();
            return;
        }
        #endregion

        #region delete_button
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Open_Connection_If_Was_Closed();
            DialogResult delete;
            delete = MessageBox.Show($"Are you sure ? ", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (delete == DialogResult.Yes)
            {
                if (At_Least_Input_Requriements())
                    if (Check_If_Customer_Already_Exists())
                    {
                        try
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.Text;
                                if (!(customer_id_text_box.Text == ""))
                                {
                                    cmd.CommandText = "DELETE FROM Customer WHERE id = @id";
                                    cmd.Parameters.AddWithValue("@id", id_value);
                                }

                                else if (!(customer_name_text_box.Text == ""))
                                {
                                    cmd.CommandText = "DELETE FROM Customer WHERE name = @name";
                                    cmd.Parameters.AddWithValue("@name", name_value);
                                }

                                int rowsAffected = cmd.ExecuteNonQuery(); // Execute the command

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Customer deleted successfully.");
                                }
                                else
                                {
                                    MessageBox.Show("No customer found with the specified name or id.");
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
                        MessageBox.Show("The customer doesn't exists");
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
        private void searchBtn_Click(object sender, EventArgs e)
        {
            customer_id_text_box.Text =
            customer_name_text_box.Text = "";
            ShowData();
        }
        #endregion

        #endregion

        #region Events_For_Searching
        private void product_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            var command = $@"SELECT  *
                                 FROM Customer
                                 WHERE
                                 name LIKE @name
                                 ORDER BY id";
            name_value = customer_name_text_box.Text;

            SearchCommand(command, cmd);
        }

        private void customer_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            if (int.TryParse("0" + customer_id_text_box.Text, out id_value) && id_value >= 0)
            {
                var command = $@"SELECT  *
                                      FROM Customer
                                      WHERE
                                      id LIKE @id
                                      ORDER BY id";
                SearchCommand(command, cmd);
            }
            else
            {
                MessageBox.Show("Enter a valid value for id");
                customer_id_text_box.Text = "0";
                return;
            }
        }

        #endregion

        #region entities
        private void label1_Click(object sender, EventArgs e) { }
        private void product_name_text_box_TextChanged(object sender, EventArgs e) { }
        private void customer_id_text_box_TextChanged(object sender, EventArgs e) { }
        private void note_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        #endregion
    }
}
