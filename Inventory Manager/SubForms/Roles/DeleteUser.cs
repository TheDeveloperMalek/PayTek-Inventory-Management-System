using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class DeleteUser : Form
    {

        #region Essential data
        readonly Customer callerForm;

        public DeleteUser(Customer r)
        {
            InitializeComponent();
            callerForm = r;
            Shared.TextBoxAutoCompleteFromColumnGuna("Roles", "username", UsernameTextBox);
        }
        #endregion

        #region Events

        private void DeleteUserBtn_Click(object sender, EventArgs e)
        {
            if(UsernameTextBox.Text == "")
            {
                Shared.ErrorOccuredMessageBox("Please enter the username");
                return;
            }
            if ((UsernameTextBox.Text == "admin" || UsernameTextBox.Text == "developer" || UsernameTextBox.Text == "user") && Shared.currentUserType != "developer" )
            {
                Shared.IgnoredProcess("You can't delete default accounts");
                return;
            }
            if (Shared.IsUserExists(UsernameTextBox.Text))
            {
                Shared.cmd.Connection = Shared.conn;
                Shared.cmd.CommandText = $@"DELETE FROM Roles
                                       WHERE username = @username";
                Shared.cmd.Parameters.AddWithValue("@username", UsernameTextBox.Text);
                if (Shared.cmd.ExecuteNonQuery() > 0)
                {
                    Shared.ProcessIsDoneMessageBox("user", "deleted");
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
