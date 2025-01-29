using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Homepage : Form
    {
        bool sidebarExpanded;
        bool MaxmizeAble = false;
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
            if(e.Control && e.KeyCode == Keys.F)
                if(MaxmizeAble){
                testPanel.Controls[0].Width = testPanel.Width;
                testPanel.Controls[0].Height = testPanel.Height;
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

        private void FormViewer(Form obj)
        {
            MaxmizeAble = true;
            testPanel.Visible = true;
            pictureBox3.Visible = false;
            testPanel.Controls.Clear();
            obj.FormBorderStyle = FormBorderStyle.None;
            testPanel.Controls.Add(obj);
            obj.Show();
        }

        #endregion

        #region buttons

        private void menu_Click(object sender, EventArgs e)
        {
            sideBarTimer.Start();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var c = new ChangeUserPassword();
            c.Show();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            testPanel.Controls.Clear();
            testPanel.Visible = false;
            pictureBox3.Visible = true;
            MaxmizeAble = false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Products s = new Products { TopLevel = false, TopMost = true };
            FormViewer(s);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            var s = new Suppliers() { TopLevel = false, TopMost = true };
            FormViewer(s); ;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Shared.ShowToast($"Welcome {Shared.UserName}", this);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Customers C = new Customers() { TopLevel = false, TopMost = true };
            FormViewer(C);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sales p = new Sales() { TopLevel = false, TopMost = true };
            FormViewer(p);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ProductsReport p = new ProductsReport() { TopLevel = false, TopMost = true };
            FormViewer(p);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            InventoryReport ir = new InventoryReport { TopLevel = false, TopMost = true };
            FormViewer(ir);
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
            var p = new Purchases() { TopLevel = false, TopMost = true };
            FormViewer(p); ;
        }

        private void roles_Click(object sender, EventArgs e)
        {
            var r = new Roles();
            r.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var C = new InventoryReport() { TopLevel = false, TopMost = true };
            FormViewer(C);
        }


        #region shortcut guidance button
        private void shortcutBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Ctrl + f => Toggle full screen
Ctrl + m => Minimize the form
Ctrl + e => Close the form
Ctrl + b => Create a backup of the database
Ctrl + r => Restore data from a database's backup
Alt + s => Switch to login form
Ctrl + p => To save the table as an excel file (just for reports)
                            ", "Shortcuts Table");
        }

        #endregion

        #endregion

        private void sideBarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpanded = false;
                    if(MaxmizeAble)
                    {
                        var d = testPanel.Controls[0];
                        testPanel.Controls.Clear();
                        testPanel.Controls.Add(d);
                        testPanel.Controls[0].Width = testPanel.Width;
                        testPanel.Controls[0].Height = testPanel.Height;
                    }
                    sideBarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpanded = true;
                    sideBarTimer.Stop();
                }
            }
        }

    }
}
