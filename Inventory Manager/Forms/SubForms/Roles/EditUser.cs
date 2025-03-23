using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class EditUser : Form
    {

        #region Essential data
        readonly Customer callerForm;

        public EditUser(Customer r)
        {
            InitializeComponent();
            this.ViewPasswordBtn.CustomImages.Image = System.Drawing.Image.FromStream(Shared.StreamMakerFromAssemblyFile("Resources.Icons", "view", "png"));
            Shared.TextBoxAutoCompleteFromColumnGuna("Roles", "username", UsernameTextBox);
            callerForm = r;
        }
        #endregion

        #region Events

        #region Button Click
        private void EditUserBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            if (UsernameTextBox.Text == "")
            {
                Shared.ErrorOccuredMessageBox("Please enter username");
                return;
            }
            if (PasswordTextBox.Text == "")
            {
                Shared.ErrorOccuredMessageBox("Please enter password");
                return;
            }
            if (Shared.currentUserType != "developer")
            {
                Shared.IgnoredProcess("You can't change developer's password");
                return;
            }
            if (Shared.ArePasswordConditionsFulfilled(PasswordTextBox.Text))
                if (Shared.DoesUserExists(UsernameTextBox.Text))
                    try
                    {
                        using (var cmd = new SqlCommand("EditUserPassword", Shared.conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@username", UsernameTextBox.Text);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@pass", Shared.Encrypt(PasswordTextBox.Text));
                            if (cmd.ExecuteNonQuery() > 0)
                                Shared.ProcessIsDoneMessageBox("user's password", "edited");
                            else
                                Shared.IgnoredProcess("Nochange happened");
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
                else
                    Shared.ErrorOccuredMessageBox("Username does not exist");
        }

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.FadeOutEffect(this, 5);
        }
        #endregion
        private void AddNewUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            callerForm.ShowData();
        }
        private void ViewPasswordBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            if (PasswordTextBox.PasswordChar == '•')
            {
                PasswordTextBox.PasswordChar = '\0';
                ViewPasswordBtn.CustomImages.Image = System.Drawing.Image.FromStream(Shared.StreamMakerFromAssemblyFile("Resources.Icons", "hide", "png"));
            }
            else
            {
                PasswordTextBox.PasswordChar = '•';
                ViewPasswordBtn.CustomImages.Image = System.Drawing.Image.FromStream(Shared.StreamMakerFromAssemblyFile("Resources.Icons", "view", "png"));
            }
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            ChangePasswordBtn.Enabled = UsernameTextBox.TextLength > 0 && PasswordTextBox.TextLength > 0;
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            ChangePasswordBtn.Enabled = UsernameTextBox.TextLength > 0 && PasswordTextBox.TextLength > 0;
        }       
 #endregion
    }
}
