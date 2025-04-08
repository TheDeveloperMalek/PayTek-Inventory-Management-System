using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class ChangeUserPassword : Form
    {

        #region Essential Data

        public ChangeUserPassword()
        {
            InitializeComponent();
            Shared.FadeInEffect(this, 5);
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
            this.ViewPasswordBtn.CustomImages.Image = System.Drawing.Image.FromStream(Shared.StreamMakerFromAssemblyFile("Resources.Icons", "view", "png"));
        }

        private void ChangeUsersPassword_Load(object sender, EventArgs e)
        {
            CurrentUserPassword.Text = TextFormatter(Shared.currentUserPassword);
        }

        #endregion

        #region startup functions

        private void KeysShortcuts(object sender, KeyEventArgs e)
        {
            Shared.KeysShortcuts(sender, e, this, false);
            if (e.KeyCode == Keys.Enter)
            {
                LogintBtn_Click(sender, e);
                return;
            }
        }


        string TextFormatter(string input)
        {
            var output = "";
            if (input.Length > 20)
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

        #region Events

        #region Buttons Click

        private void LogintBtn_Click(object sender, EventArgs e)
        {
            CurrentUserPassword.Text = TextFormatter(Shared.currentUserPassword);

            if (Shared.ArePasswordConditionsFulfilled(NewPasswordTextBox.Text))
            {
                try
                {
                    Shared.ConnectionInitializer();
                    using (var cmd = new SqlCommand("EditCurrentUserPassword", Shared.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@password", Shared.Encrypt(NewPasswordTextBox.Text));
                        cmd.Parameters.AddWithValue("@username", Shared.currentUserName);
                        cmd.Parameters.AddWithValue("@usertype", Shared.currentUserType);
                        cmd.ExecuteNonQuery();
                        Shared.ProcessIsDoneMessageBox("password", "changed");
                        Shared.currentUserPassword = NewPasswordTextBox.Text;
                        CurrentUserPassword.Text = TextFormatter(Shared.currentUserPassword);
                    }
                }
                catch (Exception exc)
                {
                    Shared.ErrorOccuredMessageBox(exc.Message);
                }
                finally
                {
                    Shared.conn.Close();
                }
            }
        }

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
                ViewPasswordBtn.CustomImages.Image = System.Drawing.Image.FromStream(Shared.StreamMakerFromAssemblyFile("Resources.Icons", "hide", "png"));
            }
            else
            {
                NewPasswordTextBox.PasswordChar = '•';
                ViewPasswordBtn.CustomImages.Image = System.Drawing.Image.FromStream(Shared.StreamMakerFromAssemblyFile("Resources.Icons", "view", "png"));
            }
        }
        #endregion
        private void NewPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            ChangeUserPasswordBtn.Enabled = NewPasswordTextBox.TextLength > 0;
        }
        #endregion

    }
}
