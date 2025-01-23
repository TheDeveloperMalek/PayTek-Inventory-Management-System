using System;
using System.Data;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class ChangeUserPassword : Form
    {

        #region essential data

        public ChangeUserPassword()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
        }

        private void ChangeUsersPassword_Load(object sender, EventArgs e)
        {
            crrUserPass.Text = TextCustomizer(Shared.Password);
        }

        #endregion

        #region startup functions

        private void KeysShortcuts(object sender, KeyEventArgs e)
        {
            Shared.KeysShortcuts(sender, e, this , false);
            if (e.KeyCode == Keys.Enter) //change password
            {
                LogintBtn_Click(sender, e);
                return;
            }
        }


        string TextCustomizer(string input)
        {
            var output = "";
            if (input.Length >  20)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (i % 30 == 0)
                        output += "\n";
                    output += input[i];
                }
                return output;
            }
            else
                return input;
        }

        #endregion

        #region buttons

        private void LogintBtn_Click(object sender, EventArgs e)
        {
            var passwordLength = password_text_box.Text.Length;
            var minimumPasswordLength = 3;
            var maximumPasswordLength = 30;
            crrUserPass.Text = TextCustomizer(Shared.Password);


            if (passwordLength >= minimumPasswordLength && passwordLength <= maximumPasswordLength)
            {
                Shared.ConnectionInitializer();
                Shared.cmd.Connection = Shared.conn;
                Shared.cmd.CommandType = CommandType.Text;
                Shared.cmd.CommandText = @"UPDATE Roles
                                        SET Password = @password
                                        WHERE usertype = @usertype 
                                        AND username = @username";
                Shared.cmd.Parameters.AddWithValue("@password", Shared.Encrypt(password_text_box.Text));
                Shared.cmd.Parameters.AddWithValue("@username", Shared.UserName);
                Shared.cmd.Parameters.AddWithValue("@usertype", Shared.Usertype);

                Shared.cmd.ExecuteNonQuery();

                MessageBox.Show("Updated successfully");
                Shared.Password = password_text_box.Text;
                crrUserPass.Text = TextCustomizer(Shared.Password);
                Shared.cmd.Dispose();
                Shared.conn.Dispose();
            }

            else
            {
                MessageBox.Show($"Password length is {passwordLength} , it should be between {minimumPasswordLength} and {maximumPasswordLength}");
            }

            Shared.cmd.Parameters.Clear();
        }

        #endregion

    }
}
