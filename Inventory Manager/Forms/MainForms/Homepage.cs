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
        object callerOfExpand;
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

        private void Auth_FormClosed(object sender, EventArgs e)
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

        private void FormsButtonClickProcedure(object SenderButton , Form form)
        {
            Shared.PlayClickSound();
            ChangeButtonsBackgroundColor(SenderButton);
            ShowFormByPanel(form); 
            callerOfExpand = SenderButton;
            sideBarTimer.Start();
        }

        #endregion

        #region Events

        #region Button Click

        private void Menu_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            callerOfExpand = sender;
            sideBarTimer.Start();
        }
        private void HomepageBtn_Click(object sender, EventArgs e)
        {
            var f = new Homepage() { TopLevel = false, TopMost = true };
            FormsButtonClickProcedure(sender, f);
            MaxmizeAble =
            ViewFormPanel.Visible = false;
            AsideCubesPicture.Visible = true;
        }
        private void ProductsBtn_Click(object sender, EventArgs e)
        {
            var f = new Products() { TopLevel = false, TopMost = true };
            FormsButtonClickProcedure(sender , f);
        }
        private void SuppliersBtn_Click(object sender, EventArgs e)
        {
            var f = new Suppliers() { TopLevel = false, TopMost = true };
            FormsButtonClickProcedure(sender, f);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Shared.ShowToast($"Welcome {Shared.currentUserName}", this);
        }

        private void CustomersBtn_Click(object sender, EventArgs e)
        {
            var f = new Customers() { TopLevel = false, TopMost = true };
            FormsButtonClickProcedure(sender, f);
        }

        private void SalesBtn_Click(object sender, EventArgs e)
        {
            var f = new Sales() { TopLevel = false, TopMost = true };
            FormsButtonClickProcedure(sender, f);
        }

        private void ProductsReportBtn_Click(object sender, EventArgs e)
        {
            var f = new ProductsReport() { TopLevel = false, TopMost = true };
            FormsButtonClickProcedure(sender, f);
        }

        private void InventoryReportBtn_Click(object sender, EventArgs e)
        {
            var f = new InventoryReport() { TopLevel = false, TopMost = true };
            FormsButtonClickProcedure(sender, f);
        }

        private void ChangeUserPasswordBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            var c = new ChangeUserPassword();
            c.Show();
            callerOfExpand = sender;
            sideBarTimer.Start();
        }

        private void PurchasesBtn_Click(object sender, EventArgs e)
        {
            var f = new Purchases() { TopLevel = false, TopMost = true };
            FormsButtonClickProcedure(sender, f);
        }
        private void RolesBtn_Click(object sender, EventArgs e)
        {
            var f = new Customer() { TopLevel = false, TopMost = true };
            FormsButtonClickProcedure(sender, f);
        }

        private void TerminalBtn_Click(object sender, EventArgs e)
        {
            var f = new Terminal() { TopLevel = false, TopMost = true };
            FormsButtonClickProcedure(sender, f);
        }
        private void OffersBtn_Click(object sender, EventArgs e)
        {
            var f = new SalesLog() { TopLevel = false, TopMost = true };
            FormsButtonClickProcedure(sender, f);
        }
        private void PrefButton_Click(object sender, EventArgs e)
        {
            var f = new Preferences() { TopLevel = false, TopMost = true };
            FormsButtonClickProcedure(sender, f);
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
                if(callerOfExpand == ShowBtnsNamesBtn)
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
