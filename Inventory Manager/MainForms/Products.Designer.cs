using Inventory_Manager.DBTemplate;
namespace Inventory_Manager
{
    partial class Products
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Products));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ProductIdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ProductNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EditCustomerBtn = new Guna.UI2.WinForms.Guna2Button();
            this.DeleteCustomerBtn = new Guna.UI2.WinForms.Guna2Button();
            this.ResetTableView = new Guna.UI2.WinForms.Guna2Button();
            this.AddNewProductBtn = new Guna.UI2.WinForms.Guna2Button();
            this.withSpecification = new System.Windows.Forms.CheckBox();
            this.SpecificationRichBox = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.withName = new System.Windows.Forms.CheckBox();
            this.withPhoto = new System.Windows.Forms.CheckBox();
            this.ProductImage = new System.Windows.Forms.PictureBox();
            this.note = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ProductBarcodeTextBox = new System.Windows.Forms.TextBox();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productDataSet = new Inventory_Manager.DBTemplate.ProductDataSet();
            this.productBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.productTableAdapter = new Inventory_Manager.DBTemplate.ProductDataSetTableAdapters.ProductTableAdapter();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductIdTextBox
            // 
            this.ProductIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductIdTextBox.Location = new System.Drawing.Point(11, 45);
            this.ProductIdTextBox.Name = "ProductIdTextBox";
            this.ProductIdTextBox.Size = new System.Drawing.Size(210, 31);
            this.ProductIdTextBox.TabIndex = 0;
            this.ProductIdTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_id_text_box_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product\'s Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product\'s Name";
            // 
            // ProductNameTextBox
            // 
            this.ProductNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductNameTextBox.Location = new System.Drawing.Point(11, 108);
            this.ProductNameTextBox.Name = "ProductNameTextBox";
            this.ProductNameTextBox.Size = new System.Drawing.Size(210, 31);
            this.ProductNameTextBox.TabIndex = 1;
            this.ProductNameTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_name_text_box_KeyUp);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(57)))), ((int)(((byte)(81)))));
            this.groupBox1.Controls.Add(this.EditCustomerBtn);
            this.groupBox1.Controls.Add(this.DeleteCustomerBtn);
            this.groupBox1.Controls.Add(this.ResetTableView);
            this.groupBox1.Controls.Add(this.AddNewProductBtn);
            this.groupBox1.Controls.Add(this.withSpecification);
            this.groupBox1.Controls.Add(this.SpecificationRichBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.withName);
            this.groupBox1.Controls.Add(this.withPhoto);
            this.groupBox1.Controls.Add(this.ProductImage);
            this.groupBox1.Controls.Add(this.note);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ProductBarcodeTextBox);
            this.groupBox1.Controls.Add(this.ProductIdTextBox);
            this.groupBox1.Controls.Add(this.ProductNameTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1268, 182);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
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
            this.EditCustomerBtn.Location = new System.Drawing.Point(847, 36);
            this.EditCustomerBtn.Name = "EditCustomerBtn";
            this.EditCustomerBtn.Size = new System.Drawing.Size(145, 50);
            this.EditCustomerBtn.TabIndex = 37;
            this.EditCustomerBtn.Text = "Edit";
            this.EditCustomerBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.EditCustomerBtn.Click += new System.EventHandler(this.EditProductBtn_Click);
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
            this.DeleteCustomerBtn.Location = new System.Drawing.Point(847, 89);
            this.DeleteCustomerBtn.Name = "DeleteCustomerBtn";
            this.DeleteCustomerBtn.Size = new System.Drawing.Size(145, 50);
            this.DeleteCustomerBtn.TabIndex = 36;
            this.DeleteCustomerBtn.Text = "Delete";
            this.DeleteCustomerBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DeleteCustomerBtn.Click += new System.EventHandler(this.DeleteProductBtn_Click);
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
            this.ResetTableView.Location = new System.Drawing.Point(696, 89);
            this.ResetTableView.Name = "ResetTableView";
            this.ResetTableView.Size = new System.Drawing.Size(145, 50);
            this.ResetTableView.TabIndex = 35;
            this.ResetTableView.Text = "Reset";
            this.ResetTableView.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // AddNewProductBtn
            // 
            this.AddNewProductBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AddNewProductBtn.AutoRoundedCorners = true;
            this.AddNewProductBtn.BorderRadius = 24;
            this.AddNewProductBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddNewProductBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AddNewProductBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AddNewProductBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddNewProductBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AddNewProductBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(222)))), ((int)(((byte)(129)))));
            this.AddNewProductBtn.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewProductBtn.ForeColor = System.Drawing.Color.Black;
            this.AddNewProductBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddNewProductBtn.Image")));
            this.AddNewProductBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.AddNewProductBtn.ImageSize = new System.Drawing.Size(40, 40);
            this.AddNewProductBtn.Location = new System.Drawing.Point(696, 36);
            this.AddNewProductBtn.Name = "AddNewProductBtn";
            this.AddNewProductBtn.Size = new System.Drawing.Size(145, 50);
            this.AddNewProductBtn.TabIndex = 34;
            this.AddNewProductBtn.Text = "Add";
            this.AddNewProductBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.AddNewProductBtn.Click += new System.EventHandler(this.AddProductBtn_Click);
            // 
            // withSpecification
            // 
            this.withSpecification.AutoSize = true;
            this.withSpecification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.withSpecification.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.withSpecification.Location = new System.Drawing.Point(227, 117);
            this.withSpecification.Name = "withSpecification";
            this.withSpecification.Size = new System.Drawing.Size(140, 22);
            this.withSpecification.TabIndex = 33;
            this.withSpecification.Text = "Edit Specification";
            this.withSpecification.UseVisualStyleBackColor = true;
            // 
            // SpecificationRichBox
            // 
            this.SpecificationRichBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpecificationRichBox.Location = new System.Drawing.Point(464, 45);
            this.SpecificationRichBox.Name = "SpecificationRichBox";
            this.SpecificationRichBox.Size = new System.Drawing.Size(220, 94);
            this.SpecificationRichBox.TabIndex = 32;
            this.SpecificationRichBox.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(460, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 24);
            this.label7.TabIndex = 31;
            this.label7.Text = "Specification";
            // 
            // withName
            // 
            this.withName.AutoSize = true;
            this.withName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.withName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.withName.Location = new System.Drawing.Point(227, 100);
            this.withName.Name = "withName";
            this.withName.Size = new System.Drawing.Size(93, 22);
            this.withName.TabIndex = 23;
            this.withName.Text = "Edit name";
            this.withName.UseVisualStyleBackColor = true;
            // 
            // withPhoto
            // 
            this.withPhoto.AutoSize = true;
            this.withPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.withPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.withPhoto.Location = new System.Drawing.Point(227, 84);
            this.withPhoto.Name = "withPhoto";
            this.withPhoto.Size = new System.Drawing.Size(131, 22);
            this.withPhoto.TabIndex = 22;
            this.withPhoto.Text = "Add / Edit photo";
            this.withPhoto.UseVisualStyleBackColor = true;
            // 
            // ProductImage
            // 
            this.ProductImage.Location = new System.Drawing.Point(998, 18);
            this.ProductImage.Name = "ProductImage";
            this.ProductImage.Size = new System.Drawing.Size(157, 157);
            this.ProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProductImage.TabIndex = 16;
            this.ProductImage.TabStop = false;
            // 
            // note
            // 
            this.note.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.note.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.note.Location = new System.Drawing.Point(8, 142);
            this.note.Name = "note";
            this.note.Size = new System.Drawing.Size(676, 37);
            this.note.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(223, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "Product\'s Barcode";
            // 
            // ProductBarcodeTextBox
            // 
            this.ProductBarcodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductBarcodeTextBox.Location = new System.Drawing.Point(227, 45);
            this.ProductBarcodeTextBox.Name = "ProductBarcodeTextBox";
            this.ProductBarcodeTextBox.Size = new System.Drawing.Size(210, 31);
            this.ProductBarcodeTextBox.TabIndex = 2;
            this.ProductBarcodeTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_barcode_text_box_KeyUp);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            // 
            // productDataSet
            // 
            this.productDataSet.DataSetName = "ProductDataSet";
            this.productDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productBindingSource1
            // 
            this.productBindingSource1.DataMember = "Product";
            this.productBindingSource1.DataSource = this.productDataSet;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn20.HeaderText = "Date";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.Width = 85;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Specification";
            this.dataGridViewTextBoxColumn19.HeaderText = "Specification";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Width = 169;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn18.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Width = 126;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn17.HeaderText = "Name";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Width = 93;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Barcode";
            this.dataGridViewTextBoxColumn16.HeaderText = "Barcode";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 118;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn15.HeaderText = "ID";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 64;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(84)))), ((int)(((byte)(117)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20});
            this.dataGridView1.DataSource = this.productBindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 182);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.Size = new System.Drawing.Size(1268, 295);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1268, 477);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1268, 477);
            this.Name = "Products";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Product_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ProductIdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ProductNameTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ProductBarcodeTextBox;
        private System.Windows.Forms.Label note;
        private System.Windows.Forms.PictureBox ProductImage;
        private System.Windows.Forms.CheckBox withName;
        private System.Windows.Forms.CheckBox withPhoto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox SpecificationRichBox;
        private System.Windows.Forms.CheckBox withSpecification;
        private System.Windows.Forms.BindingSource productBindingSource;
        private ProductDataSet productDataSet;
        private System.Windows.Forms.BindingSource productBindingSource1;
        private Inventory_Manager.DBTemplate.ProductDataSetTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2Button EditCustomerBtn;
        private Guna.UI2.WinForms.Guna2Button DeleteCustomerBtn;
        private Guna.UI2.WinForms.Guna2Button ResetTableView;
        private Guna.UI2.WinForms.Guna2Button AddNewProductBtn;
    }
}