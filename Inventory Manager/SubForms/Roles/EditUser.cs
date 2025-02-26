using System;
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
            callerForm = r;
            Shared.TextBoxAutoCompleteFromColumnGuna("Roles", "username", UsernameTextBox);
        }
        #endregion

        #region Events

        private void EditUserBtn_Click(object sender, EventArgs e)
        {
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
            if(Shared.currentUserType != "developer")
            {
                Shared.IgnoredProcess("You can't change developer's password");
                return;
            }
            if (Shared.IsUserExists(UsernameTextBox.Text))
            {
                Shared.cmd.Connection = Shared.conn;
                Shared.cmd.CommandText = $@"UPDATE Roles
                                            SET password = @pass ,
                                            ""Last Modified"" = @date
                                            WHERE username = @username";
                Shared.cmd.Parameters.AddWithValue("@username", UsernameTextBox.Text);
                Shared.cmd.Parameters.AddWithValue("@date", DateTime.Now);
                Shared.cmd.Parameters.AddWithValue("@pass", Shared.Encrypt(PasswordTextBox.Text));
                if (Shared.cmd.ExecuteNonQuery() > 0)
                {
                    Shared.ProcessIsDoneMessageBox("user's password", "edited");
                }
                else
                {
                    Shared.IgnoredProcess("Nochange happened");
                }
            }
            else
                Shared.ErrorOccuredMessageBox("Username is not exists");
            Shared.cmd.Parameters.Clear();
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
