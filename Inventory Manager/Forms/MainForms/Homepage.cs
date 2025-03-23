using Inventory_Manager.Forms.MainForms;
using Inventory_Manager.MainForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Homepage : Form
    {
        #region Essential Data
        bool sidebarExpanded;
        bool MaxmizeAble = false;

        public Homepage()
        {
            InitializeComponent();
            Shared.FadeInEffect(this, 5);
            Shared.HideComponentsByUserType();
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
            TerminalLabel.Visible = 
            TerminalBtn.Visible = Shared.isVisibleForDeveloper;
            RolesLabel.Visible =
            RolesBtn.Visible = Shared.isJustVisibleForNonUserType;
        }
        #endregion

        #region Startup Functions
        private void KeysShortcuts(object sender, KeyEventArgs e)
        {
            Shared.KeysShortcuts(sender, e, this);

            if (e.Alt && e.KeyCode == Keys.S)
            {
                this.Hide();
                var a = new Authorization();
                a.FormClosed += Auth_FormClosed;
                a.Show();
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.F)
            {
                if (MaxmizeAble)
                {
                    var d = ViewFormPanel.Controls[0];
                    ViewFormPanel.Controls.Clear();
                    ViewFormPanel.Controls.Add(d);
                    ViewFormPanel.Controls[0].Width = ViewFormPanel.Width;
                    ViewFormPanel.Controls[0].Height = ViewFormPanel.Height;
                }
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.B)
            {
                Shared.ProcessIsDoneMessageBox(Shared.CreateDBBackup("Public").Replace("\nSaved backup", "database's backup") , "saved");
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.R)
            {
                Shared.ProcessIsDoneMessageBox(Shared.RestoreDBFromBakFile("Public").Replace("\nDatabase restored successfully!", "database"), "restored");
                e.SuppressKeyPress = true;
            }
        }

        private void Auth_FormClosed(object sender, EventArgs e) //event when the auth is closed
        {
            this.Close();
        }

        private void ShowFormByPanel(Form obj)
        {
            MaxmizeAble =
            ViewFormPanel.Visible = true;
            AsideCubesPicture.Visible = false;
            ViewFormPanel.Controls.Clear();
            obj.FormBorderStyle = FormBorderStyle.None;
            ViewFormPanel.Controls.Add(obj);
            obj.Show();
        }

        private void ChangeButtonsBackgroundColor(object ob)
        {
            Button a = ob as Button;
            foreach (Control d in sidebar.Controls)
            {
                if (d is Panel)
                {
                    foreach (Control c in d.Controls)
                    {
                        if (c is Button)
                        {
                            c.BackColor = Color.Transparent;
                            c.ForeColor = BtnsPanel.BackColor;
                        }

                    }

                }
            }
            a.BackColor = Color.White;
            a.ForeColor = Color.White;
        }

        #endregion

        #region Events

        #region Button Click

        private void Menu_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            sideBarTimer.Start();
        }
        private void HomepageBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            ChangeButtonsBackgroundColor(sender);
            ViewFormPanel.Controls.Clear();
            MaxmizeAble =
            ViewFormPanel.Visible = false;
            AsideCubesPicture.Visible = true;
        }
        private void ProductsBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            ChangeButtonsBackgroundColor(sender);
            Products s = new Products { TopLevel = false, TopMost = true };
            ShowFormByPanel(s);
        }
        private void SuppliersBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            ChangeButtonsBackgroundColor(sender);
            var s = new Suppliers() { TopLevel = false, TopMost = true };
            ShowFormByPanel(s); ;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Shared.ShowToast($"Welcome {Shared.currentUserName}", this);
        }

        private void CustomersBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            ChangeButtonsBackgroundColor(sender);
            Customers C = new Customers() { TopLevel = false, TopMost = true };
            ShowFormByPanel(C);
        }

        private void SalesBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            ChangeButtonsBackgroundColor(sender);
            Sales p = new Sales() { TopLevel = false, TopMost = true };
            ShowFormByPanel(p);
        }

        private void ProductsReportBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            ChangeButtonsBackgroundColor(sender);
            ProductsReport p = new ProductsReport() { TopLevel = false, TopMost = true };
            ShowFormByPanel(p);
        }

        private void InventoryReportBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            ChangeButtonsBackgroundColor(sender);
            InventoryReport ir = new InventoryReport { TopLevel = false, TopMost = true };
            ShowFormByPanel(ir);
        }

        private void ChangeUserPasswordBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var c = new ChangeUserPassword();
            c.Show();
        }

        private void PurchasesBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            ChangeButtonsBackgroundColor(sender);
            var p = new Purchases() { TopLevel = false, TopMost = true };
            ShowFormByPanel(p);
        }
        private void RolesBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            ChangeButtonsBackgroundColor(sender);
            var r = new Customer { TopLevel = false, TopMost = true };
            ShowFormByPanel(r);
        }

        private void TerminalBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            ChangeButtonsBackgroundColor(sender);
            var t = new Terminal { TopLevel = false, TopMost = true };
            ShowFormByPanel(t);
        }
        private void OffersBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            ChangeButtonsBackgroundColor(sender);
            var s = new SalesLog { TopLevel = false, TopMost = true };
            ShowFormByPanel(s);
        }
        private void PrefButton_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            ChangeButtonsBackgroundColor(sender);
            var C = new Preferences() { TopLevel = false, TopMost = true };
            ShowFormByPanel(C);
        }


        #region shortcut guidance button
        private void ShortCutGuidanceBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayNotificationSound();
            var d = new ShortcutsTable();
            d.Show();
        }


        #endregion

        #endregion

        #region Label Click
        private void ProductsLabel_Click(object sender, EventArgs e)
        {
            ProductsBtn_Click(ProductsBtn, e);
        }

        private void MenuLabel_Click(object sender, EventArgs e)
        {
            Menu_Click(sender, e);
        }

        private void PurchasesLabel_Click(object sender, EventArgs e)
        {
            PurchasesBtn_Click(PurchasesBtn, e);
        }

        private void SalesLabel_Click(object sender, EventArgs e)
        {
            SalesBtn_Click(SalesBtn, e);
        }

        private void OffersLabel_Click(object sender, EventArgs e)
        {
            OffersBtn_Click(SaleLogBtn, e);
        }

        private void SuppliersLabel_Click(object sender, EventArgs e)
        {
            SuppliersBtn_Click(SuppliersBtn, e);
        }

        private void CustomerLabel_Click(object sender, EventArgs e)
        {
            CustomersBtn_Click(CustomersBtn, e);
        }

        private void ProductsReportLabel_Click(object sender, EventArgs e)
        {
            ProductsReportBtn_Click(ProductReportBtn, e);
        }

        private void InventoryReportLabel_Click(object sender, EventArgs e)
        {
            InventoryReportBtn_Click(InventoryReportBtn, e);
        }

        private void HomepageLabel_Click(object sender, EventArgs e)
        {
            HomepageBtn_Click(HomepageBtn, e);
        }

        private void RolesLabel_Click(object sender, EventArgs e)
        {
            RolesBtn_Click(RolesBtn, e);
        }

        private void TerminalLabel_Click(object sender, EventArgs e)
        {
            TerminalBtn_Click(TerminalBtn, e);
        }

        private void PrefLabel_Click(object sender, EventArgs e)
        {
            PrefButton_Click(PrefButton, e);
        }
        #endregion

        private void sideBarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpanded = false;
                    if (MaxmizeAble)
                    {
                        var d = ViewFormPanel.Controls[0];
                        ViewFormPanel.Controls.Clear();
                        ViewFormPanel.Controls.Add(d);
                        ViewFormPanel.Controls[0].Width = ViewFormPanel.Width;
                        ViewFormPanel.Controls[0].Height = ViewFormPanel.Height;
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

        #endregion
        
    }
}
