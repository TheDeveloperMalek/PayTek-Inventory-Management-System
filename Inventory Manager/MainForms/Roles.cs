using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Customer : Form
    {
        #region essential data
        public Customer()
        {
            InitializeComponent();
            Shared.FadeInEffect(this, 5);
            Shared.ConnectionInitializer();
            this.rolesTableAdapter.Connection.ConnectionString = Shared.conn.ConnectionString;
            
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            this.rolesTableAdapter.Fill(this.rolesDataSet.Roles);
            ShowData();
        }
        #endregion

        #region Startup Functions

        private void ShowDecryptedPasswords()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var columnName = "passwordDataGridViewTextBoxColumn";
                row.Cells[columnName].Value = Shared.Decrypt(row.Cells[columnName].Value.ToString());
            }
        }

        //Update the data of customer's table
        public void ShowData()
        {
            
                Shared.ShowAllTableData(dataGridView1, "Roles", "Username", true, "Usertype", "developer");
                ShowDecryptedPasswords();
        }
        #endregion

        #region buttons

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

        #region Events
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UsernameTextBox.Text =
            PasswordTextBox.Text = "";
            var text = dataGridView1.CurrentCell.Value.ToString();
            var columnIndex = dataGridView1.CurrentCellAddress.X;

            switch (columnIndex)
            {
                case 0:
                    UsernameTextBox.Text = text;
                    break;
                case 1:
                    PasswordTextBox.Text = text;
                    break;
            }
        }

        private void PasswordTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, PasswordTextBox, "Roles", "password", "username", excludeRow: true, excludedBy: "UserType", excludedValue: "Developer");
        }

        private void UsernameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandAssembler(dataGridView1, UsernameTextBox, "Roles", "username", "username", excludeRow: true, excludedBy: "UserType", excludedValue: "Developer");
        }

        #endregion

    }
}
