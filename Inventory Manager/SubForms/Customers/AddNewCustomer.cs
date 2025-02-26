using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class AddNewCustomer : Form
    {

        #region Essential data
        readonly Customers callerForm;

        public AddNewCustomer(Customers c)
        {
            InitializeComponent();
            callerForm = c;
        }
        #endregion

        #region Validation functions
        private bool Check_If_Customer_Name_Already_Exists()
        {
            string checkQuery = "SELECT COUNT(*) FROM Customer WHERE name = @name";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, Shared.conn))
            {
                checkCmd.Parameters.AddWithValue("@name", CustomerNameTextBox.Text);

                int.TryParse(checkCmd.ExecuteScalar().ToString(), out int productCount);

                if (productCount > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool At_Least_Input_Name()
        {
            if (CustomerNameTextBox.Text == "")
            {
                Shared.ErrorOccuredMessageBox("Please type a name ");
                return false;
            }
            return true;
        }
        #endregion

        #region Events
        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            if (At_Least_Input_Name())
                if (!Check_If_Customer_Name_Already_Exists())
                {
                    try
                    {
                        using (SqlCommand cmd = Shared.conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "INSERT INTO customer (name) VALUES (@name_value)";
                            cmd.Parameters.AddWithValue("@name_value", CustomerNameTextBox.Text);

                            cmd.ExecuteNonQuery();
                        }

                        Shared.ProcessIsDoneMessageBox("customer", "added");
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
                else if (Check_If_Customer_Name_Already_Exists())
                {
                    Shared.IgnoredProcess("The customer already exists , please edit it using edit button");
                }

        }

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.FadeOutEffect(this, 5);
        }

        private void AddNewUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            callerForm.ShowData();
        }

        #endregion
    }
}
