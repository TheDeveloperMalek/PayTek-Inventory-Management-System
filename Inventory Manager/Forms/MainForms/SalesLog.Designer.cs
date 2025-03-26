namespace Inventory_Manager
{
    partial class SalesLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesLog));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerStart = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dateTimePickerEnd = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.printBillBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button7 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button8 = new Guna.UI2.WinForms.Guna2Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ProductBarcodeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SaleIDTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ProductQuantityTextBox = new System.Windows.Forms.TextBox();
            this.CustomerIDTextBox = new System.Windows.Forms.TextBox();
            this.CustomerNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ProductIDTextBox = new System.Windows.Forms.TextBox();
            this.ProductNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datatable = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saleLogDataSet = new Inventory_Manager.DBTemplate.SaleLogDataSet();
            this.saleLogTableAdapter = new Inventory_Manager.DBTemplate.SaleLogDataSetTableAdapters.SaleLogTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datatable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleLogBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleLogDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(57)))), ((int)(((byte)(81)))));
            this.groupBox1.Controls.Add(this.dateTimePickerStart);
            this.groupBox1.Controls.Add(this.dateTimePickerEnd);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.printBillBtn);
            this.groupBox1.Controls.Add(this.guna2Button5);
            this.groupBox1.Controls.Add(this.guna2Button6);
            this.groupBox1.Controls.Add(this.guna2Button7);
            this.groupBox1.Controls.Add(this.guna2Button8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ProductBarcodeTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.SaleIDTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ProductQuantityTextBox);
            this.groupBox1.Controls.Add(this.CustomerIDTextBox);
            this.groupBox1.Controls.Add(this.CustomerNameTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ProductIDTextBox);
            this.groupBox1.Controls.Add(this.ProductNameTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.MinimumSize = new System.Drawing.Size(750, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1223, 194);
            this.groupBox1.TabIndex = 14;
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
            this.dateTimePickerStart.Location = new System.Drawing.Point(1011, 37);
            this.dateTimePickerStart.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerStart.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 36);
            this.dateTimePickerStart.TabIndex = 61;
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
            this.dateTimePickerEnd.Location = new System.Drawing.Point(1011, 95);
            this.dateTimePickerEnd.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerEnd.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 36);
            this.dateTimePickerEnd.TabIndex = 60;
            this.dateTimePickerEnd.Value = new System.DateTime(2025, 1, 22, 0, 0, 0, 0);
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePickerEnd_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(961, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 29);
            this.label8.TabIndex = 59;
            this.label8.Text = "To:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(936, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 29);
            this.label9.TabIndex = 58;
            this.label9.Text = "From:";
            // 
            // printBillBtn
            // 
            this.printBillBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.printBillBtn.AutoRoundedCorners = true;
            this.printBillBtn.BorderRadius = 24;
            this.printBillBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printBillBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.printBillBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.printBillBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.printBillBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.printBillBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(165)))), ((int)(((byte)(238)))));
            this.printBillBtn.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBillBtn.ForeColor = System.Drawing.Color.Black;
            this.printBillBtn.Image = ((System.Drawing.Image)(resources.GetObject("printBillBtn.Image")));
            this.printBillBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.printBillBtn.ImageSize = new System.Drawing.Size(40, 40);
            this.printBillBtn.Location = new System.Drawing.Point(779, 138);
            this.printBillBtn.Name = "printBillBtn";
            this.printBillBtn.Size = new System.Drawing.Size(145, 50);
            this.printBillBtn.TabIndex = 57;
            this.printBillBtn.Text = "Print";
            this.printBillBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.printBillBtn.Click += new System.EventHandler(this.pdfButton_Click);
            // 
            // guna2Button5
            // 
            this.guna2Button5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.guna2Button5.AutoRoundedCorners = true;
            this.guna2Button5.BorderRadius = 24;
            this.guna2Button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button5.FillColor = System.Drawing.Color.LightBlue;
            this.guna2Button5.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button5.ForeColor = System.Drawing.Color.Black;
            this.guna2Button5.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button5.Image")));
            this.guna2Button5.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button5.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2Button5.Location = new System.Drawing.Point(168, 138);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.Size = new System.Drawing.Size(145, 50);
            this.guna2Button5.TabIndex = 56;
            this.guna2Button5.Text = "Edit";
            this.guna2Button5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button5.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // guna2Button6
            // 
            this.guna2Button6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.guna2Button6.AutoRoundedCorners = true;
            this.guna2Button6.BorderRadius = 24;
            this.guna2Button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button6.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button6.FillColor = System.Drawing.Color.LightCoral;
            this.guna2Button6.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button6.ForeColor = System.Drawing.Color.Black;
            this.guna2Button6.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button6.Image")));
            this.guna2Button6.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button6.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2Button6.Location = new System.Drawing.Point(470, 138);
            this.guna2Button6.Name = "guna2Button6";
            this.guna2Button6.Size = new System.Drawing.Size(303, 50);
            this.guna2Button6.TabIndex = 55;
            this.guna2Button6.Text = "Delete (canceled)";
            this.guna2Button6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button6.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // guna2Button7
            // 
            this.guna2Button7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.guna2Button7.AutoRoundedCorners = true;
            this.guna2Button7.BorderRadius = 24;
            this.guna2Button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button7.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button7.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button7.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button7.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(38)))));
            this.guna2Button7.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button7.ForeColor = System.Drawing.Color.Black;
            this.guna2Button7.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button7.Image")));
            this.guna2Button7.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2Button7.Location = new System.Drawing.Point(319, 138);
            this.guna2Button7.Name = "guna2Button7";
            this.guna2Button7.Size = new System.Drawing.Size(145, 50);
            this.guna2Button7.TabIndex = 54;
            this.guna2Button7.Text = "Reset";
            this.guna2Button7.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // guna2Button8
            // 
            this.guna2Button8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.guna2Button8.AutoRoundedCorners = true;
            this.guna2Button8.BorderRadius = 24;
            this.guna2Button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button8.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button8.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button8.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button8.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(222)))), ((int)(((byte)(129)))));
            this.guna2Button8.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button8.ForeColor = System.Drawing.Color.Black;
            this.guna2Button8.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button8.Image")));
            this.guna2Button8.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button8.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2Button8.Location = new System.Drawing.Point(17, 138);
            this.guna2Button8.Name = "guna2Button8";
            this.guna2Button8.Size = new System.Drawing.Size(145, 50);
            this.guna2Button8.TabIndex = 53;
            this.guna2Button8.Text = "Add";
            this.guna2Button8.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button8.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(224, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(214, 24);
            this.label7.TabIndex = 40;
            this.label7.Text = "Product\'s Barcode";
            // 
            // ProductBarcodeTextBox
            // 
            this.ProductBarcodeTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ProductBarcodeTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.ProductBarcodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductBarcodeTextBox.Location = new System.Drawing.Point(228, 37);
            this.ProductBarcodeTextBox.Name = "ProductBarcodeTextBox";
            this.ProductBarcodeTextBox.Size = new System.Drawing.Size(210, 31);
            this.ProductBarcodeTextBox.TabIndex = 39;
            this.ProductBarcodeTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_barcode_text_box_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(655, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 24);
            this.label3.TabIndex = 23;
            this.label3.Text = "Sale\'s Id";
            // 
            // SaleIDTextBox
            // 
            this.SaleIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaleIDTextBox.Location = new System.Drawing.Point(659, 37);
            this.SaleIDTextBox.Name = "SaleIDTextBox";
            this.SaleIDTextBox.Size = new System.Drawing.Size(210, 31);
            this.SaleIDTextBox.TabIndex = 2;
            this.SaleIDTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Sale_id_text_box_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(224, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 21;
            this.label4.Text = "Quantity";
            // 
            // ProductQuantityTextBox
            // 
            this.ProductQuantityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductQuantityTextBox.Location = new System.Drawing.Point(228, 95);
            this.ProductQuantityTextBox.Name = "ProductQuantityTextBox";
            this.ProductQuantityTextBox.Size = new System.Drawing.Size(210, 31);
            this.ProductQuantityTextBox.TabIndex = 5;
            this.ProductQuantityTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_quantity_text_box_KeyUp);
            // 
            // CustomerIDTextBox
            // 
            this.CustomerIDTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CustomerIDTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CustomerIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerIDTextBox.Location = new System.Drawing.Point(443, 37);
            this.CustomerIDTextBox.Name = "CustomerIDTextBox";
            this.CustomerIDTextBox.Size = new System.Drawing.Size(210, 31);
            this.CustomerIDTextBox.TabIndex = 1;
            this.CustomerIDTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.customer_id_text_box_KeyUp);
            // 
            // CustomerNameTextBox
            // 
            this.CustomerNameTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CustomerNameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CustomerNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerNameTextBox.Location = new System.Drawing.Point(443, 95);
            this.CustomerNameTextBox.Name = "CustomerNameTextBox";
            this.CustomerNameTextBox.Size = new System.Drawing.Size(210, 31);
            this.CustomerNameTextBox.TabIndex = 4;
            this.CustomerNameTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.customer_name_text_box_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(439, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 24);
            this.label5.TabIndex = 19;
            this.label5.Text = "Customer\'s Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(439, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 24);
            this.label6.TabIndex = 17;
            this.label6.Text = "Customer\'s Id";
            // 
            // ProductIDTextBox
            // 
            this.ProductIDTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ProductIDTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.ProductIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductIDTextBox.Location = new System.Drawing.Point(12, 37);
            this.ProductIDTextBox.Name = "ProductIDTextBox";
            this.ProductIDTextBox.Size = new System.Drawing.Size(210, 31);
            this.ProductIDTextBox.TabIndex = 0;
            this.ProductIDTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_id_text_box_KeyUp);
            // 
            // ProductNameTextBox
            // 
            this.ProductNameTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ProductNameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.ProductNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductNameTextBox.Location = new System.Drawing.Point(12, 95);
            this.ProductNameTextBox.Name = "ProductNameTextBox";
            this.ProductNameTextBox.Size = new System.Drawing.Size(210, 31);
            this.ProductNameTextBox.TabIndex = 3;
            this.ProductNameTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_name_text_box_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product\'s Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product\'s Id";
            // 
            // datatable
            // 
            this.datatable.AllowUserToAddRows = false;
            this.datatable.AllowUserToDeleteRows = false;
            this.datatable.AutoGenerateColumns = false;
            this.datatable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.datatable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(57)))), ((int)(((byte)(81)))));
            this.datatable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datatable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datatable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datatable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.productNameColumn,
            this.quantityColumn,
            this.priceColumn,
            this.totalPriceColumn,
            this.dataGridViewTextBoxColumn9});
            this.datatable.DataSource = this.saleLogBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datatable.DefaultCellStyle = dataGridViewCellStyle2;
            this.datatable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datatable.Location = new System.Drawing.Point(0, 194);
            this.datatable.Name = "datatable";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datatable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.datatable.RowTemplate.Height = 50;
            this.datatable.Size = new System.Drawing.Size(1223, 298);
            this.datatable.TabIndex = 24;
            this.datatable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 64;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Customer ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Customer ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 148;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Customer Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Customer Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 174;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Product ID";
            this.dataGridViewTextBoxColumn4.HeaderText = "Product ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 134;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Product Barcode";
            this.dataGridViewTextBoxColumn5.HeaderText = "Product Barcode";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 183;
            // 
            // productNameColumn
            // 
            this.productNameColumn.DataPropertyName = "Product Name";
            this.productNameColumn.HeaderText = "Product Name";
            this.productNameColumn.Name = "productNameColumn";
            this.productNameColumn.Width = 160;
            // 
            // quantityColumn
            // 
            this.quantityColumn.DataPropertyName = "Quantity";
            this.quantityColumn.HeaderText = "Quantity";
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.Width = 126;
            // 
            // priceColumn
            // 
            this.priceColumn.DataPropertyName = "Price";
            this.priceColumn.HeaderText = "Unit Price";
            this.priceColumn.Name = "priceColumn";
            this.priceColumn.Width = 124;
            // 
            // totalPriceColumn
            // 
            this.totalPriceColumn.DataPropertyName = "Total Price";
            this.totalPriceColumn.HeaderText = "Total Price";
            this.totalPriceColumn.Name = "totalPriceColumn";
            this.totalPriceColumn.Width = 133;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn9.HeaderText = "Date";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 85;
            // 
            // saleLogBindingSource
            // 
            this.saleLogBindingSource.DataMember = "SaleLog";
            this.saleLogBindingSource.DataSource = this.saleLogDataSet;
            // 
            // saleLogDataSet
            // 
            this.saleLogDataSet.DataSetName = "SaleLogDataSet";
            this.saleLogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // saleLogTableAdapter
            // 
            this.saleLogTableAdapter.ClearBeforeFill = true;
            // 
            // SalesLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 492);
            this.Controls.Add(this.datatable);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1223, 492);
            this.Name = "SalesLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Sales_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datatable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleLogBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleLogDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ProductIDTextBox;
        private System.Windows.Forms.TextBox ProductNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CustomerIDTextBox;
        private System.Windows.Forms.TextBox CustomerNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ProductQuantityTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SaleIDTextBox;
        private System.Windows.Forms.DataGridView datatable;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ProductBarcodeTextBox;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2Button guna2Button6;
        private Guna.UI2.WinForms.Guna2Button guna2Button7;
        private Guna.UI2.WinForms.Guna2Button guna2Button8;
        private Guna.UI2.WinForms.Guna2Button printBillBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePickerStart;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Inventory_Manager.DBTemplate.SaleLogDataSet saleLogDataSet;
        private System.Windows.Forms.BindingSource saleLogBindingSource;
        private Inventory_Manager.DBTemplate.SaleLogDataSetTableAdapters.SaleLogTableAdapter saleLogTableAdapter;
    }
}