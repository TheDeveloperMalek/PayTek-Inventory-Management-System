namespace Inventory_Manager
{
    partial class ProductsReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerStart = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dateTimePickerEnd = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.exportbtn = new Guna.UI2.WinForms.Guna2Button();
            this.searchBtn = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.product_barcode_text_box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.product_name_text_box = new System.Windows.Forms.TextBox();
            this.product_id_text_box = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.productIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productBarcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productReportDataSet = new Inventory_Manager.ProductReportDataSet();
            this.productReportTableAdapter = new Inventory_Manager.ProductReportDataSetTableAdapters.ProductReportTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productReportDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(38)))), ((int)(((byte)(53)))));
            this.groupBox1.Controls.Add(this.dateTimePickerStart);
            this.groupBox1.Controls.Add(this.dateTimePickerEnd);
            this.groupBox1.Controls.Add(this.exportbtn);
            this.groupBox1.Controls.Add(this.searchBtn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.product_barcode_text_box);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.product_name_text_box);
            this.groupBox1.Controls.Add(this.product_id_text_box);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.MinimumSize = new System.Drawing.Size(1112, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1155, 102);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.BorderRadius = 10;
            this.dateTimePickerStart.Checked = true;
            this.dateTimePickerStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePickerStart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dateTimePickerStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dateTimePickerStart.Location = new System.Drawing.Point(732, 13);
            this.dateTimePickerStart.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerStart.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 36);
            this.dateTimePickerStart.TabIndex = 48;
            this.dateTimePickerStart.Value = new System.DateTime(2023, 9, 18, 0, 0, 0, 0);
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.BorderRadius = 10;
            this.dateTimePickerEnd.Checked = true;
            this.dateTimePickerEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePickerEnd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(732, 54);
            this.dateTimePickerEnd.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerEnd.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 36);
            this.dateTimePickerEnd.TabIndex = 47;
            this.dateTimePickerEnd.Value = new System.DateTime(2025, 1, 22, 0, 0, 0, 0);
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePickerEnd_ValueChanged);
            // 
            // exportbtn
            // 
            this.exportbtn.BorderRadius = 20;
            this.exportbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exportbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exportbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exportbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exportbtn.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.exportbtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportbtn.ForeColor = System.Drawing.Color.Black;
            this.exportbtn.Location = new System.Drawing.Point(938, 51);
            this.exportbtn.Name = "exportbtn";
            this.exportbtn.Size = new System.Drawing.Size(211, 39);
            this.exportbtn.TabIndex = 46;
            this.exportbtn.Text = "Export as excel file";
            this.exportbtn.Click += new System.EventHandler(this.exportbtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.BorderRadius = 20;
            this.searchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.searchBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.searchBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.searchBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.searchBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.searchBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.ForeColor = System.Drawing.Color.Black;
            this.searchBtn.Location = new System.Drawing.Point(938, 10);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(211, 39);
            this.searchBtn.TabIndex = 45;
            this.searchBtn.Text = "Reset Filter";
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(222, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 24);
            this.label5.TabIndex = 36;
            this.label5.Text = "Product\'s Barcode";
            // 
            // product_barcode_text_box
            // 
            this.product_barcode_text_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.product_barcode_text_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.product_barcode_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_barcode_text_box.Location = new System.Drawing.Point(226, 46);
            this.product_barcode_text_box.Name = "product_barcode_text_box";
            this.product_barcode_text_box.Size = new System.Drawing.Size(210, 31);
            this.product_barcode_text_box.TabIndex = 35;
            this.product_barcode_text_box.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_barcode_text_box_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(688, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 29);
            this.label4.TabIndex = 32;
            this.label4.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(663, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 29);
            this.label3.TabIndex = 31;
            this.label3.Text = "From:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 21;
            this.label1.Text = "Product\'s Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(438, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "Product\'s Name";
            // 
            // product_name_text_box
            // 
            this.product_name_text_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.product_name_text_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.product_name_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_name_text_box.Location = new System.Drawing.Point(442, 46);
            this.product_name_text_box.Name = "product_name_text_box";
            this.product_name_text_box.Size = new System.Drawing.Size(210, 31);
            this.product_name_text_box.TabIndex = 22;
            this.product_name_text_box.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_name_text_box_KeyUp);
            // 
            // product_id_text_box
            // 
            this.product_id_text_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.product_id_text_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.product_id_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_id_text_box.Location = new System.Drawing.Point(10, 46);
            this.product_id_text_box.Name = "product_id_text_box";
            this.product_id_text_box.Size = new System.Drawing.Size(210, 31);
            this.product_id_text_box.TabIndex = 20;
            this.product_id_text_box.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_id_text_box_KeyUp);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIDDataGridViewTextBoxColumn,
            this.productBarcodeDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.productReportBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 102);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 50;
            this.dataGridView2.Size = new System.Drawing.Size(1155, 339);
            this.dataGridView2.TabIndex = 31;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // productIDDataGridViewTextBoxColumn
            // 
            this.productIDDataGridViewTextBoxColumn.DataPropertyName = "Product ID";
            this.productIDDataGridViewTextBoxColumn.HeaderText = "Product ID";
            this.productIDDataGridViewTextBoxColumn.Name = "productIDDataGridViewTextBoxColumn";
            // 
            // productBarcodeDataGridViewTextBoxColumn
            // 
            this.productBarcodeDataGridViewTextBoxColumn.DataPropertyName = "Product Barcode";
            this.productBarcodeDataGridViewTextBoxColumn.HeaderText = "Product Barcode";
            this.productBarcodeDataGridViewTextBoxColumn.Name = "productBarcodeDataGridViewTextBoxColumn";
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "Product Name";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "Product Name";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // productReportBindingSource
            // 
            this.productReportBindingSource.DataMember = "ProductReport";
            this.productReportBindingSource.DataSource = this.productReportDataSet;
            // 
            // productReportDataSet
            // 
            this.productReportDataSet.DataSetName = "ProductReportDataSet";
            this.productReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productReportTableAdapter
            // 
            this.productReportTableAdapter.ClearBeforeFill = true;
            // 
            // ProductsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 441);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(1171, 480);
            this.Name = "ProductsReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products Report form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ProductsReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productReportDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox product_name_text_box;
        private System.Windows.Forms.TextBox product_id_text_box;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox product_barcode_text_box;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePickerStart;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePickerEnd;
        private Guna.UI2.WinForms.Guna2Button exportbtn;
        private Guna.UI2.WinForms.Guna2Button searchBtn;
        private ProductReportDataSet productReportDataSet;
        private System.Windows.Forms.BindingSource productReportBindingSource;
        private ProductReportDataSetTableAdapters.ProductReportTableAdapter productReportTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productBarcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
    }
}