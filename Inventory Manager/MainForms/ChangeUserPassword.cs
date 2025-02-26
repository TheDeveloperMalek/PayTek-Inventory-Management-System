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
            Shared.FadeInEffect(this , 5);
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
            this.ViewPasswordBtn.CustomImages.Image = System.Drawing.Image.FromStream(Shared.FileGetterFromAssembly("Icons", "view", "png"));
        }

        private void ChangeUsersPassword_Load(object sender, EventArgs e)
        {
            CurrentUserPassword.Text = TextCustomizer(Shared.currentUserPassword);
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
            var passwordLength = NewPasswordTextBox.Text.Length;
            var minimumPasswordLength = 3;
            var maximumPasswordLength = 30;
            CurrentUserPassword.Text = TextCustomizer(Shared.currentUserPassword);


            if (passwordLength >= minimumPasswordLength && passwordLength <= maximumPasswordLength)
            {
                Shared.ConnectionInitializer();
                Shared.cmd.Connection = Shared.conn;
                Shared.cmd.CommandType = CommandType.Text;
                Shared.cmd.CommandText = @"UPDATE Roles
                                        SET Password = @password
                                        WHERE usertype = @usertype 
                                        AND username = @username";
                Shared.cmd.Parameters.AddWithValue("@password", Shared.Encrypt(NewPasswordTextBox.Text));
                Shared.cmd.Parameters.AddWithValue("@username", Shared.currentUserName);
                Shared.cmd.Parameters.AddWithValue("@usertype", Shared.currentUserType);

                Shared.cmd.ExecuteNonQuery();

                Shared.ProcessIsDoneMessageBox("password" , "changed");
                Shared.currentUserPassword = NewPasswordTextBox.Text;
                CurrentUserPassword.Text = TextCustomizer(Shared.currentUserPassword);
                Shared.cmd.Dispose();
                Shared.conn.Dispose();
            }

            else
                Shared.ErrorOccuredMessageBox($"Password length is {passwordLength} , it should be between {minimumPasswordLength} and {maximumPasswordLength}");

            Shared.cmd.Parameters.Clear();
        }

        #endregion

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.FadeOutEffect(this, 2);
        }

        private void ViewPasswordBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            if (NewPasswordTextBox.PasswordChar == '•')
            {
                NewPasswordTextBox.PasswordChar = '\0';
                ViewPasswordBtn.CustomImages.Image = System.Drawing.Image.FromStream(Shared.FileGetterFromAssembly("Icons", "hide", "png"));
            }
            else
            {
                NewPasswordTextBox.PasswordChar = '•';
                ViewPasswordBtn.CustomImages.Image = System.Drawing.Image.FromStream(Shared.FileGetterFromAssembly("Icons", "view", "png"));
            }
        }
    }
}
