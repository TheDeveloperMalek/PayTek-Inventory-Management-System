using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Roles : Form
    {
        #region essential data
        string usertype = "";
        public Roles()
        {
            InitializeComponent();
            Shared.ConnectionInitializer();
            this.rolesTableAdapter.Connection.ConnectionString = Shared.conn.ConnectionString;
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            this.rolesTableAdapter.Fill(this.rolesDataSet.Roles);
            ShowData();
        }
        #endregion

        #region Startup Functions

        //Update the data of customer's table
        public void ShowData()
        {
            Shared.ShowAllData(dataGridView1, "Roles", "Username", true, "Usertype", "developer");
        }
        //Shortcuts for window
        private void KeysShortcuts(object sender, KeyEventArgs e)
        {
            Shared.KeysShortcuts(sender, e, this);
        }
        void UsertypeCheck()
        {
            if (AdminRadio.Checked)
                usertype = "admin";
            else
                usertype = "user";
        }
        #endregion

        #region Validation functions
        private bool Chech_If_Text_Boxes_Were_Empty()
        {
            if (UsernameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                if (UsernameTextBox.Text == "")
                {
                    MessageBox.Show("Please enter username", "Inventory Management System");
                    return true;
                }
                if (PasswordTextBox.Text == "")
                {
                    MessageBox.Show("Please enter password", "Inventory Management System");
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region buttons

        private void resetBtn_Click(object sender, EventArgs e)
        {
            UsernameTextBox.Text =
            PasswordTextBox.Text = "";
            ShowData();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (!Chech_If_Text_Boxes_Were_Empty())
            {
                Shared.cmd.Connection = Shared.conn;
                UsertypeCheck();
                Shared.cmd.CommandText = $@"INSERT INTO Roles VALUES(@username , @password, @usertype , @date)";
                Shared.cmd.Parameters.AddWithValue("@username", UsernameTextBox.Text);
                Shared.cmd.Parameters.AddWithValue("@password", PasswordTextBox.Text);
                Shared.cmd.Parameters.AddWithValue("@usertype", usertype);
                Shared.cmd.Parameters.AddWithValue("@date", DateTime.Now);
                Shared.cmd.ExecuteNonQuery();
                Shared.cmd.Parameters.Clear();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "")
            {
                MessageBox.Show("Please enter username delete the user");
                return;
            }
            UsertypeCheck();
            Shared.cmd.Connection = Shared.conn;
            Shared.cmd.CommandText = $@"DELETE FROM Roles
                                       WHERE username = @username 
                                       AND usertype = @usertype";
            Shared.cmd.Parameters.AddWithValue("@username", UsernameTextBox.Text);
            Shared.cmd.Parameters.AddWithValue("@usertype", usertype);
            if (Shared.cmd.ExecuteNonQuery() > 0)
                MessageBox.Show("User is deleted successfully!");
            else
                MessageBox.Show("No change happened!");
            Shared.cmd.Parameters.Clear();
        }


        #endregion

    }
}
