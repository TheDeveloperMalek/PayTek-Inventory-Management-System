using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Customer : Form
    {
        #region Essential Data
        public Customer()
        {
            InitializeComponent();
            Shared.FadeInEffect(this, 5);
            Shared.ConnectionInitializer();
            this.rolesTableAdapter1.Connection.ConnectionString = Shared.conn.ConnectionString;
            
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            this.rolesTableAdapter1.Fill(this.rolesDataSet1.Roles);
            ShowData();
        }
        #endregion

        #region Startup Functions

        private void ShowDecryptedPasswords()
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var columnName = "Password";
                row.Cells[columnName].Value = Shared.Decrypt(row.Cells[columnName].Value.ToString());
            }
        }

        public void ShowData()
        {
            
                Shared.ShowAllTableData(dataGridView1, "Roles", "Username", true, "Usertype", "developer");
                ShowDecryptedPasswords();
        }
        #endregion

        #region Events
        #region Button Click

        private void resetBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ResetFields(groupBox1);
            ShowData();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var add = new AddNewUser(this);
            add.Show();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var delete = new DeleteUser(this);
            delete.Show();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var edit = new EditUser(this);
            edit.Show();
        }

        #endregion
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ResetFields(groupBox1);
            var text = dataGridView1.CurrentCell.Value.ToString();
            var columnIndex = dataGridView1.CurrentCellAddress.X;

            switch (columnIndex)
            {
                case 0:
                    UsernameTextBox.Text = text;
                    Shared.SearchCommandAssembler(dataGridView1, UsernameTextBox, "Roles", "username", "username", excludeRow: true, excludedBy: "UserType", excludedValue: "Developer");
                    ShowDecryptedPasswords();
                    break;
                case 1:
                    PasswordTextBox.Text = text;
                    var encryptedTextBox = new TextBox();
                    encryptedTextBox.Text = Shared.Encrypt(PasswordTextBox.Text);
                    Shared.SearchCommandAssembler(dataGridView1, encryptedTextBox, "Roles", "password", "username", excludeRow: true, excludedBy: "UserType", excludedValue: "Developer");
                    ShowDecryptedPasswords();
                    break;
            }
        }

        private void PasswordTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            var encryptedTextBox = new TextBox
            {
                Text = Shared.Encrypt(PasswordTextBox.Text)
            };
            Shared.SearchCommandAssembler(dataGridView1, encryptedTextBox, "Roles", "password", "username", excludeRow: true, excludedBy: "UserType", excludedValue: "Developer");
                    ShowDecryptedPasswords();
        }

        private void UsernameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, UsernameTextBox, "Roles", "username", "username", excludeRow: true, excludedBy: "UserType", excludedValue: "Developer");
                    ShowDecryptedPasswords();
        }

        #endregion

    }
}
