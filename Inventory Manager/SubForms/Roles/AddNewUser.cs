using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class AddNewUser : Form
    {

        #region Essential data
        string usertype = "";
        readonly Customer callerForm;

        public AddNewUser(Customer r)
        {
            InitializeComponent();
            callerForm = r;
        }
        #endregion

        #region Startup functions
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
                    Shared.ErrorOccuredMessageBox("Please enter username");
                    return true;
                }
                if (PasswordTextBox.Text == "")
                {
                    Shared.ErrorOccuredMessageBox("Please enter password");
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Events

        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            if (!Chech_If_Text_Boxes_Were_Empty())
            {
                if (!Shared.IsUserExists(UsernameTextBox.Text))
                {
                    UsertypeCheck();
                    Shared.cmd.Connection = Shared.conn;
                    Shared.cmd.CommandText = $@"INSERT INTO Roles VALUES(@username , @password, @usertype , @date)";
                    Shared.cmd.Parameters.AddWithValue("@username", UsernameTextBox.Text);
                    Shared.cmd.Parameters.AddWithValue("@password", Shared.Encrypt(PasswordTextBox.Text));
                    Shared.cmd.Parameters.AddWithValue("@usertype", usertype);
                    Shared.cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    if (Shared.cmd.ExecuteNonQuery() > 0)
                        Shared.ProcessIsDoneMessageBox("user", "added");
                    Shared.cmd.Parameters.Clear();
                }
                else
                    Shared.IgnoredProcess("Username is already exist , please pick another username");
            }
        }

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.FadeOutEffect(this, 5);
        }

        private void UserRadio_CheckedChanged(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
        }

        private void AdminRadio_CheckedChanged(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
        }

        private void AddNewUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            callerForm.ShowData();
        }
        #endregion

    }
}
