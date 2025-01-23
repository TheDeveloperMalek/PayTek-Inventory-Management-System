using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Homepage : Form
    {
        #region essential_data
        public Homepage()
        {
            InitializeComponent();
            Shared.HideComponentsByUserType();
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
            this.terminal.Visible = Shared.isVisibleForDeveloper;
            this.roles.Visible = Shared.isVisibleForDeveloper;
        }
        #endregion

        #region Startup Functions
        private void KeysShortcuts(object sender, KeyEventArgs e)
        {
            Shared.KeysShortcuts(sender, e, this);
            if (e.Alt && e.KeyCode == Keys.S) //switch to login form again
            {
                this.Hide();
                var a = new Authorization();
                a.FormClosed += Auth_FormClosed;
                a.Show();
            }
            if (e.Control && e.KeyCode == Keys.B)
                MessageBox.Show(Shared.CreateDBBackup("Public"), "PayTek Inventory Management System");
            if (e.Control && e.KeyCode == Keys.R)
                MessageBox.Show(Shared.RestoreDBFromBakFile("Public"), "PayTek Inventory Management System");
        }

        private void Auth_FormClosed(object sender, EventArgs e) //event when the auth is closed
        {
            this.Close();
        }

        #endregion

        #region buttons
        private void button2_Click(object sender, EventArgs e)
        {
            Customers p = new Customers();
            p.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Products s = new Products();
            s.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            var s = new Suppliers();
            s.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Customers C = new Customers();
            C.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sales p = new Sales();
            p.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ProductsReport p = new ProductsReport();
            p.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            InventoryReport ir = new InventoryReport();
            ir.Show();
        }

        private void changeUserPassword_Click(object sender, EventArgs e)
        {
            var c = new ChangeUserPassword();
            c.Show();
        }

        private void terminal_Click(object sender, EventArgs e)
        {
            var cmd = new Terminal();
            cmd.Show();
            return;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            var p = new Purchases();
            p.Show();
        }

        private void roles_Click(object sender, EventArgs e)
        {
            var r = new Roles();
            r.Show();
        }

        #region shortcut guidance button
        private void shortcutBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Ctrl + f => Toggle full screen
Ctrl + m => Minimize the form
Ctrl + e => Close the form
Ctrl + b => Create a backup of the database
Ctrl + r => Restore data from a database's backup
Alt + s => Switch to login form (just for homepage)
Ctrl + p => To save the table as an excel file (just for reports)
                            ", "Shortcuts Table");
        }

        #endregion

        #endregion
    }
}
