using Inventory_Manager.DBTemplate;
namespace Inventory_Manager
{
    partial class Customers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customers));
            this.CustomerDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerDataSet = new Inventory_Manager.DBTemplate.CustomerDataSet();
            this.CustomerIdLabel = new System.Windows.Forms.Label();
            this.CustomerNameLabel = new System.Windows.Forms.Label();
            this.AddNewCustomerBtn = new Guna.UI2.WinForms.Guna2Button();
            this.customer_name_text_box = new System.Windows.Forms.TextBox();
            this.ResetTableView = new Guna.UI2.WinForms.Guna2Button();
            this.customer_id_text_box = new System.Windows.Forms.TextBox();
            this.DeleteCustomerBtn = new Guna.UI2.WinForms.Guna2Button();
            this.EditCustomerBtn = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NoticeLabel = new System.Windows.Forms.Label();
            this.customerTableAdapter = new Inventory_Manager.DBTemplate.CustomerDataSetTableAdapters.CustomerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CustomerDataGridView
            // 
            this.CustomerDataGridView.AllowUserToAddRows = false;
            this.CustomerDataGridView.AllowUserToDeleteRows = false;
            this.CustomerDataGridView.AutoGenerateColumns = false;
            this.CustomerDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomerDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(84)))), ((int)(((byte)(117)))));
            this.CustomerDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CustomerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.CustomerDataGridView.DataSource = this.customerBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CustomerDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.CustomerDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerDataGridView.Location = new System.Drawing.Point(0, 140);
            this.CustomerDataGridView.Name = "CustomerDataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.CustomerDataGridView.RowTemplate.Height = 50;
            this.CustomerDataGridView.Size = new System.Drawing.Size(890, 328);
            this.CustomerDataGridView.TabIndex = 15;
            this.CustomerDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn3.HeaderText = "ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn4.HeaderText = "Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataMember = "Customer";
            this.customerBindingSource.DataSource = this.customerDataSet;
            // 
            // customerDataSet
            // 
            this.customerDataSet.DataSetName = "CustomerDataSet";
            this.customerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CustomerIdLabel
            // 
            this.CustomerIdLabel.AutoSize = true;
            this.CustomerIdLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerIdLabel.ForeColor = System.Drawing.Color.White;
            this.CustomerIdLabel.Location = new System.Drawing.Point(5, 17);
            this.CustomerIdLabel.Name = "CustomerIdLabel";
            this.CustomerIdLabel.Size = new System.Drawing.Size(166, 24);
            this.CustomerIdLabel.TabIndex = 1;
            this.CustomerIdLabel.Text = "Customer\'s Id";
            // 
            // CustomerNameLabel
            // 
            this.CustomerNameLabel.AutoSize = true;
            this.CustomerNameLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerNameLabel.ForeColor = System.Drawing.Color.White;
            this.CustomerNameLabel.Location = new System.Drawing.Point(221, 17);
            this.CustomerNameLabel.Name = "CustomerNameLabel";
            this.CustomerNameLabel.Size = new System.Drawing.Size(190, 24);
            this.CustomerNameLabel.TabIndex = 3;
            this.CustomerNameLabel.Text = "Customer\'s Name";
            // 
            // AddNewCustomerBtn
            // 
            this.AddNewCustomerBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AddNewCustomerBtn.AutoRoundedCorners = true;
            this.AddNewCustomerBtn.BorderRadius = 24;
            this.AddNewCustomerBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddNewCustomerBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AddNewCustomerBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AddNewCustomerBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddNewCustomerBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AddNewCustomerBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(222)))), ((int)(((byte)(129)))));
            this.AddNewCustomerBtn.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewCustomerBtn.ForeColor = System.Drawing.Color.Black;
            this.AddNewCustomerBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddNewCustomerBtn.Image")));
            this.AddNewCustomerBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.AddNewCustomerBtn.ImageSize = new System.Drawing.Size(40, 40);
            this.AddNewCustomerBtn.Location = new System.Drawing.Point(581, 19);
            this.AddNewCustomerBtn.Name = "AddNewCustomerBtn";
            this.AddNewCustomerBtn.Size = new System.Drawing.Size(145, 50);
            this.AddNewCustomerBtn.TabIndex = 30;
            this.AddNewCustomerBtn.Text = "Add";
            this.AddNewCustomerBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.AddNewCustomerBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // customer_name_text_box
            // 
            this.customer_name_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer_name_text_box.Location = new System.Drawing.Point(225, 44);
            this.customer_name_text_box.Name = "customer_name_text_box";
            this.customer_name_text_box.Size = new System.Drawing.Size(210, 31);
            this.customer_name_text_box.TabIndex = 1;
            this.customer_name_text_box.KeyUp += new System.Windows.Forms.KeyEventHandler(this.customer_name_text_box_KeyUp);
            // 
            // ResetTableView
            // 
            this.ResetTableView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ResetTableView.AutoRoundedCorners = true;
            this.ResetTableView.BorderRadius = 24;
            this.ResetTableView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResetTableView.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ResetTableView.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ResetTableView.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ResetTableView.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ResetTableView.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(38)))));
            this.ResetTableView.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetTableView.ForeColor = System.Drawing.Color.Black;
            this.ResetTableView.Image = ((System.Drawing.Image)(resources.GetObject("ResetTableView.Image")));
            this.ResetTableView.ImageSize = new System.Drawing.Size(40, 40);
            this.ResetTableView.Location = new System.Drawing.Point(581, 72);
            this.ResetTableView.Name = "ResetTableView";
            this.ResetTableView.Size = new System.Drawing.Size(145, 50);
            this.ResetTableView.TabIndex = 31;
            this.ResetTableView.Text = "Reset";
            this.ResetTableView.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // customer_id_text_box
            // 
            this.customer_id_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer_id_text_box.Location = new System.Drawing.Point(9, 44);
            this.customer_id_text_box.Name = "customer_id_text_box";
            this.customer_id_text_box.Size = new System.Drawing.Size(210, 31);
            this.customer_id_text_box.TabIndex = 0;
            this.customer_id_text_box.KeyUp += new System.Windows.Forms.KeyEventHandler(this.customer_id_text_box_KeyUp);
            // 
            // DeleteCustomerBtn
            // 
            this.DeleteCustomerBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DeleteCustomerBtn.AutoRoundedCorners = true;
            this.DeleteCustomerBtn.BorderRadius = 24;
            this.DeleteCustomerBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteCustomerBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.DeleteCustomerBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.DeleteCustomerBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.DeleteCustomerBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.DeleteCustomerBtn.FillColor = System.Drawing.Color.LightCoral;
            this.DeleteCustomerBtn.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteCustomerBtn.ForeColor = System.Drawing.Color.Black;
            this.DeleteCustomerBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeleteCustomerBtn.Image")));
            this.DeleteCustomerBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DeleteCustomerBtn.ImageSize = new System.Drawing.Size(40, 40);
            this.DeleteCustomerBtn.Location = new System.Drawing.Point(732, 72);
            this.DeleteCustomerBtn.Name = "DeleteCustomerBtn";
            this.DeleteCustomerBtn.Size = new System.Drawing.Size(145, 50);
            this.DeleteCustomerBtn.TabIndex = 32;
            this.DeleteCustomerBtn.Text = "Delete";
            this.DeleteCustomerBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DeleteCustomerBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // EditCustomerBtn
            // 
            this.EditCustomerBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EditCustomerBtn.AutoRoundedCorners = true;
            this.EditCustomerBtn.BorderRadius = 24;
            this.EditCustomerBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditCustomerBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.EditCustomerBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.EditCustomerBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.EditCustomerBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.EditCustomerBtn.FillColor = System.Drawing.Color.LightBlue;
            this.EditCustomerBtn.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCustomerBtn.ForeColor = System.Drawing.Color.Black;
            this.EditCustomerBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditCustomerBtn.Image")));
            this.EditCustomerBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.EditCustomerBtn.ImageSize = new System.Drawing.Size(40, 40);
            this.EditCustomerBtn.Location = new System.Drawing.Point(732, 19);
            this.EditCustomerBtn.Name = "EditCustomerBtn";
            this.EditCustomerBtn.Size = new System.Drawing.Size(145, 50);
            this.EditCustomerBtn.TabIndex = 33;
            this.EditCustomerBtn.Text = "Edit";
            this.EditCustomerBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.EditCustomerBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(57)))), ((int)(((byte)(81)))));
            this.groupBox1.Controls.Add(this.EditCustomerBtn);
            this.groupBox1.Controls.Add(this.DeleteCustomerBtn);
            this.groupBox1.Controls.Add(this.customer_id_text_box);
            this.groupBox1.Controls.Add(this.ResetTableView);
            this.groupBox1.Controls.Add(this.customer_name_text_box);
            this.groupBox1.Controls.Add(this.AddNewCustomerBtn);
            this.groupBox1.Controls.Add(this.CustomerNameLabel);
            this.groupBox1.Controls.Add(this.CustomerIdLabel);
            this.groupBox1.Controls.Add(this.NoticeLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(890, 140);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // NoticeLabel
            // 
            this.NoticeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoticeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.NoticeLabel.Location = new System.Drawing.Point(5, 75);
            this.NoticeLabel.Name = "NoticeLabel";
            this.NoticeLabel.Size = new System.Drawing.Size(569, 62);
            this.NoticeLabel.TabIndex = 17;
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 468);
            this.Controls.Add(this.CustomerDataGridView);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(899, 507);
            this.Name = "Customers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customers Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Customer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView CustomerDataGridView;
        private System.Windows.Forms.Label CustomerIdLabel;
        private System.Windows.Forms.Label CustomerNameLabel;
        private Guna.UI2.WinForms.Guna2Button AddNewCustomerBtn;
        private System.Windows.Forms.TextBox customer_name_text_box;
        private Guna.UI2.WinForms.Guna2Button ResetTableView;
        private System.Windows.Forms.TextBox customer_id_text_box;
        private Guna.UI2.WinForms.Guna2Button DeleteCustomerBtn;
        private Guna.UI2.WinForms.Guna2Button EditCustomerBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private CustomerDataSet customerDataSet;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private Inventory_Manager.DBTemplate.CustomerDataSetTableAdapters.CustomerTableAdapter customerTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label NoticeLabel;
    }
}