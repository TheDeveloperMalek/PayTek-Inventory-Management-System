namespace Inventory_Manager
{
    partial class InventoryReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryReport));
            this.InventoryReportDataGridView = new System.Windows.Forms.DataGridView();
            this.productIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productBarcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoryReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryReportDataSet = new Inventory_Manager.DBTemplate.InventoryReportDataSet();
            this.FromDateLabel = new System.Windows.Forms.Label();
            this.ToDateLabel = new System.Windows.Forms.Label();
            this.ProductBarcodeTextBox = new System.Windows.Forms.TextBox();
            this.ProductBarcodeLabel = new System.Windows.Forms.Label();
            this.FinishingDateTimePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.BeginningDateTimePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExportTableAsExcelBtn = new Guna.UI2.WinForms.Guna2Button();
            this.ResetShowBtn = new Guna.UI2.WinForms.Guna2Button();
            this.ProductIdLabel = new System.Windows.Forms.Label();
            this.ProductNameLabel = new System.Windows.Forms.Label();
            this.ProductNameTextBox = new System.Windows.Forms.TextBox();
            this.ProductIdTextBox = new System.Windows.Forms.TextBox();
            this.inventoryReportTableAdapter = new Inventory_Manager.DBTemplate.InventoryReportDataSetTableAdapters.InventoryReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryReportDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InventoryReportDataGridView
            // 
            this.InventoryReportDataGridView.AutoGenerateColumns = false;
            this.InventoryReportDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.InventoryReportDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(84)))), ((int)(((byte)(117)))));
            this.InventoryReportDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InventoryReportDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.InventoryReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InventoryReportDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIDDataGridViewTextBoxColumn,
            this.productBarcodeDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn});
            this.InventoryReportDataGridView.DataSource = this.inventoryReportBindingSource;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InventoryReportDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.InventoryReportDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InventoryReportDataGridView.Location = new System.Drawing.Point(0, 118);
            this.InventoryReportDataGridView.Name = "InventoryReportDataGridView";
            this.InventoryReportDataGridView.RowTemplate.Height = 50;
            this.InventoryReportDataGridView.Size = new System.Drawing.Size(1196, 401);
            this.InventoryReportDataGridView.TabIndex = 29;
            this.InventoryReportDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // productIDDataGridViewTextBoxColumn
            // 
            this.productIDDataGridViewTextBoxColumn.DataPropertyName = "Product ID";
            this.productIDDataGridViewTextBoxColumn.HeaderText = "Product ID";
            this.productIDDataGridViewTextBoxColumn.Name = "productIDDataGridViewTextBoxColumn";
            this.productIDDataGridViewTextBoxColumn.Width = 134;
            // 
            // productBarcodeDataGridViewTextBoxColumn
            // 
            this.productBarcodeDataGridViewTextBoxColumn.DataPropertyName = "Product Barcode";
            this.productBarcodeDataGridViewTextBoxColumn.HeaderText = "Product Barcode";
            this.productBarcodeDataGridViewTextBoxColumn.Name = "productBarcodeDataGridViewTextBoxColumn";
            this.productBarcodeDataGridViewTextBoxColumn.Width = 183;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "Product Name";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "Product Name";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.Width = 160;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Width = 126;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Width = 85;
            // 
            // inventoryReportBindingSource
            // 
            this.inventoryReportBindingSource.DataMember = "InventoryReport";
            this.inventoryReportBindingSource.DataSource = this.inventoryReportDataSet;
            // 
            // inventoryReportDataSet
            // 
            this.inventoryReportDataSet.DataSetName = "InventoryReportDataSet";
            this.inventoryReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FromDateLabel
            // 
            this.FromDateLabel.AutoSize = true;
            this.FromDateLabel.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromDateLabel.Location = new System.Drawing.Point(660, 16);
            this.FromDateLabel.Name = "FromDateLabel";
            this.FromDateLabel.Size = new System.Drawing.Size(69, 29);
            this.FromDateLabel.TabIndex = 31;
            this.FromDateLabel.Text = "From:";
            // 
            // ToDateLabel
            // 
            this.ToDateLabel.AutoSize = true;
            this.ToDateLabel.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToDateLabel.Location = new System.Drawing.Point(685, 52);
            this.ToDateLabel.Name = "ToDateLabel";
            this.ToDateLabel.Size = new System.Drawing.Size(44, 29);
            this.ToDateLabel.TabIndex = 32;
            this.ToDateLabel.Text = "To:";
            // 
            // ProductBarcodeTextBox
            // 
            this.ProductBarcodeTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ProductBarcodeTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.ProductBarcodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductBarcodeTextBox.Location = new System.Drawing.Point(226, 41);
            this.ProductBarcodeTextBox.Name = "ProductBarcodeTextBox";
            this.ProductBarcodeTextBox.Size = new System.Drawing.Size(210, 31);
            this.ProductBarcodeTextBox.TabIndex = 37;
            this.ProductBarcodeTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_barcode_text_box_KeyUp);
            // 
            // ProductBarcodeLabel
            // 
            this.ProductBarcodeLabel.AutoSize = true;
            this.ProductBarcodeLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductBarcodeLabel.ForeColor = System.Drawing.Color.White;
            this.ProductBarcodeLabel.Location = new System.Drawing.Point(222, 14);
            this.ProductBarcodeLabel.Name = "ProductBarcodeLabel";
            this.ProductBarcodeLabel.Size = new System.Drawing.Size(214, 24);
            this.ProductBarcodeLabel.TabIndex = 38;
            this.ProductBarcodeLabel.Text = "Product\'s Barcode";
            // 
            // FinishingDateTimePicker
            // 
            this.FinishingDateTimePicker.BorderRadius = 10;
            this.FinishingDateTimePicker.Checked = true;
            this.FinishingDateTimePicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FinishingDateTimePicker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FinishingDateTimePicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FinishingDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.FinishingDateTimePicker.Location = new System.Drawing.Point(735, 52);
            this.FinishingDateTimePicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.FinishingDateTimePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.FinishingDateTimePicker.Name = "FinishingDateTimePicker";
            this.FinishingDateTimePicker.Size = new System.Drawing.Size(200, 36);
            this.FinishingDateTimePicker.TabIndex = 43;
            this.FinishingDateTimePicker.Value = new System.DateTime(2025, 1, 22, 0, 0, 0, 0);
            this.FinishingDateTimePicker.Click += new System.EventHandler(this.FinishingDateTimePicker_Click);
            // 
            // BeginningDateTimePicker
            // 
            this.BeginningDateTimePicker.BorderRadius = 10;
            this.BeginningDateTimePicker.Checked = true;
            this.BeginningDateTimePicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BeginningDateTimePicker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BeginningDateTimePicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BeginningDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.BeginningDateTimePicker.Location = new System.Drawing.Point(735, 12);
            this.BeginningDateTimePicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.BeginningDateTimePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.BeginningDateTimePicker.Name = "BeginningDateTimePicker";
            this.BeginningDateTimePicker.Size = new System.Drawing.Size(200, 36);
            this.BeginningDateTimePicker.TabIndex = 44;
            this.BeginningDateTimePicker.Value = new System.DateTime(2023, 9, 18, 0, 0, 0, 0);
            this.BeginningDateTimePicker.Click += new System.EventHandler(this.BeginningDateTimePicker_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(57)))), ((int)(((byte)(81)))));
            this.groupBox1.Controls.Add(this.BeginningDateTimePicker);
            this.groupBox1.Controls.Add(this.FinishingDateTimePicker);
            this.groupBox1.Controls.Add(this.ExportTableAsExcelBtn);
            this.groupBox1.Controls.Add(this.ResetShowBtn);
            this.groupBox1.Controls.Add(this.ProductBarcodeLabel);
            this.groupBox1.Controls.Add(this.ProductBarcodeTextBox);
            this.groupBox1.Controls.Add(this.ToDateLabel);
            this.groupBox1.Controls.Add(this.FromDateLabel);
            this.groupBox1.Controls.Add(this.ProductIdLabel);
            this.groupBox1.Controls.Add(this.ProductNameLabel);
            this.groupBox1.Controls.Add(this.ProductNameTextBox);
            this.groupBox1.Controls.Add(this.ProductIdTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1196, 118);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // ExportTableAsExcelBtn
            // 
            this.ExportTableAsExcelBtn.BorderRadius = 20;
            this.ExportTableAsExcelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExportTableAsExcelBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ExportTableAsExcelBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ExportTableAsExcelBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ExportTableAsExcelBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ExportTableAsExcelBtn.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.ExportTableAsExcelBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportTableAsExcelBtn.ForeColor = System.Drawing.Color.Black;
            this.ExportTableAsExcelBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExportTableAsExcelBtn.Image")));
            this.ExportTableAsExcelBtn.ImageSize = new System.Drawing.Size(40, 40);
            this.ExportTableAsExcelBtn.Location = new System.Drawing.Point(941, 63);
            this.ExportTableAsExcelBtn.Name = "ExportTableAsExcelBtn";
            this.ExportTableAsExcelBtn.Size = new System.Drawing.Size(233, 49);
            this.ExportTableAsExcelBtn.TabIndex = 42;
            this.ExportTableAsExcelBtn.Text = "Export as excel file";
            this.ExportTableAsExcelBtn.Click += new System.EventHandler(this.exportbtn_Click);
            // 
            // ResetShowBtn
            // 
            this.ResetShowBtn.BorderRadius = 20;
            this.ResetShowBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResetShowBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ResetShowBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ResetShowBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ResetShowBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ResetShowBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(38)))));
            this.ResetShowBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetShowBtn.ForeColor = System.Drawing.Color.Black;
            this.ResetShowBtn.Image = ((System.Drawing.Image)(resources.GetObject("ResetShowBtn.Image")));
            this.ResetShowBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ResetShowBtn.ImageSize = new System.Drawing.Size(40, 40);
            this.ResetShowBtn.Location = new System.Drawing.Point(938, 9);
            this.ResetShowBtn.Name = "ResetShowBtn";
            this.ResetShowBtn.Size = new System.Drawing.Size(233, 49);
            this.ResetShowBtn.TabIndex = 41;
            this.ResetShowBtn.Text = "Reset Filter";
            this.ResetShowBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // ProductIdLabel
            // 
            this.ProductIdLabel.AutoSize = true;
            this.ProductIdLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductIdLabel.ForeColor = System.Drawing.Color.White;
            this.ProductIdLabel.Location = new System.Drawing.Point(7, 14);
            this.ProductIdLabel.Name = "ProductIdLabel";
            this.ProductIdLabel.Size = new System.Drawing.Size(154, 24);
            this.ProductIdLabel.TabIndex = 21;
            this.ProductIdLabel.Text = "Product\'s Id";
            // 
            // ProductNameLabel
            // 
            this.ProductNameLabel.AutoSize = true;
            this.ProductNameLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductNameLabel.ForeColor = System.Drawing.Color.White;
            this.ProductNameLabel.Location = new System.Drawing.Point(438, 16);
            this.ProductNameLabel.Name = "ProductNameLabel";
            this.ProductNameLabel.Size = new System.Drawing.Size(178, 24);
            this.ProductNameLabel.TabIndex = 23;
            this.ProductNameLabel.Text = "Product\'s Name";
            // 
            // ProductNameTextBox
            // 
            this.ProductNameTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ProductNameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.ProductNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductNameTextBox.Location = new System.Drawing.Point(442, 41);
            this.ProductNameTextBox.Name = "ProductNameTextBox";
            this.ProductNameTextBox.Size = new System.Drawing.Size(210, 31);
            this.ProductNameTextBox.TabIndex = 22;
            this.ProductNameTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_name_text_box_KeyUp);
            // 
            // ProductIdTextBox
            // 
            this.ProductIdTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ProductIdTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.ProductIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductIdTextBox.Location = new System.Drawing.Point(10, 41);
            this.ProductIdTextBox.Name = "ProductIdTextBox";
            this.ProductIdTextBox.Size = new System.Drawing.Size(210, 31);
            this.ProductIdTextBox.TabIndex = 20;
            this.ProductIdTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_id_text_box_KeyUp);
            // 
            // inventoryReportTableAdapter
            // 
            this.inventoryReportTableAdapter.ClearBeforeFill = true;
            // 
            // InventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1196, 519);
            this.Controls.Add(this.InventoryReportDataGridView);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1196, 519);
            this.Name = "InventoryReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Report form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InventoryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InventoryReportDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView InventoryReportDataGridView;
        private System.Windows.Forms.Label FromDateLabel;
        private System.Windows.Forms.Label ToDateLabel;
        private System.Windows.Forms.TextBox ProductBarcodeTextBox;
        private System.Windows.Forms.Label ProductBarcodeLabel;
        private Guna.UI2.WinForms.Guna2DateTimePicker FinishingDateTimePicker;
        private Guna.UI2.WinForms.Guna2DateTimePicker BeginningDateTimePicker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ProductIdLabel;
        private System.Windows.Forms.Label ProductNameLabel;
        private System.Windows.Forms.TextBox ProductNameTextBox;
        private System.Windows.Forms.TextBox ProductIdTextBox;
        private Inventory_Manager.DBTemplate.InventoryReportDataSet inventoryReportDataSet;
        private System.Windows.Forms.BindingSource inventoryReportBindingSource;
        private Inventory_Manager.DBTemplate.InventoryReportDataSetTableAdapters.InventoryReportTableAdapter inventoryReportTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productBarcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private Guna.UI2.WinForms.Guna2Button ExportTableAsExcelBtn;
        private Guna.UI2.WinForms.Guna2Button ResetShowBtn;
    }
}