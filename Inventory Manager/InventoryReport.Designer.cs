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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.product_id_text_box = new System.Windows.Forms.TextBox();
            this.product_name_text_box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.searchBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.product_barcode_text_box = new System.Windows.Forms.TextBox();
            this.exportbtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoryReportBindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            this.testDataSet = new Inventory_Manager.InventoryReportDataSet();
            this.inventoryReportBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryReportDataSet = new Inventory_Manager.InventoryReportDataSet();
            this.inventoryReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryReportBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryReportBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryReportBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryReportTableAdapter1 = new Inventory_Manager.TestDataSetTableAdapters.InventoryReportTableAdapter();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportBindingSource5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // product_id_text_box
            // 
            this.product_id_text_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.product_id_text_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.product_id_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_id_text_box.Location = new System.Drawing.Point(10, 41);
            this.product_id_text_box.Name = "product_id_text_box";
            this.product_id_text_box.Size = new System.Drawing.Size(210, 31);
            this.product_id_text_box.TabIndex = 20;
            this.product_id_text_box.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_id_text_box_KeyUp);
            // 
            // product_name_text_box
            // 
            this.product_name_text_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.product_name_text_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.product_name_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_name_text_box.Location = new System.Drawing.Point(442, 41);
            this.product_name_text_box.Name = "product_name_text_box";
            this.product_name_text_box.Size = new System.Drawing.Size(210, 31);
            this.product_name_text_box.TabIndex = 22;
            this.product_name_text_box.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_name_text_box_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(438, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "Product\'s Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 21;
            this.label1.Text = "Product\'s Id";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(55)))), ((int)(((byte)(81)))));
            this.groupBox1.Controls.Add(this.dateTimePickerStart);
            this.groupBox1.Controls.Add(this.searchBtn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.product_barcode_text_box);
            this.groupBox1.Controls.Add(this.exportbtn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePickerEnd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.product_name_text_box);
            this.groupBox1.Controls.Add(this.product_id_text_box);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1257, 95);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStart.Location = new System.Drawing.Point(735, 17);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(197, 29);
            this.dateTimePickerStart.TabIndex = 40;
            this.dateTimePickerStart.Value = new System.DateTime(2023, 9, 18, 0, 0, 0, 0);
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.searchBtn.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.ForeColor = System.Drawing.Color.Black;
            this.searchBtn.Location = new System.Drawing.Point(938, 10);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(208, 39);
            this.searchBtn.TabIndex = 39;
            this.searchBtn.Text = "Reset Filter";
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(222, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 24);
            this.label5.TabIndex = 38;
            this.label5.Text = "Product\'s Barcode";
            // 
            // product_barcode_text_box
            // 
            this.product_barcode_text_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.product_barcode_text_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.product_barcode_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_barcode_text_box.Location = new System.Drawing.Point(226, 41);
            this.product_barcode_text_box.Name = "product_barcode_text_box";
            this.product_barcode_text_box.Size = new System.Drawing.Size(210, 31);
            this.product_barcode_text_box.TabIndex = 37;
            this.product_barcode_text_box.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_barcode_text_box_KeyUp);
            // 
            // exportbtn
            // 
            this.exportbtn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.exportbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exportbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportbtn.ForeColor = System.Drawing.Color.Black;
            this.exportbtn.Location = new System.Drawing.Point(938, 50);
            this.exportbtn.Name = "exportbtn";
            this.exportbtn.Size = new System.Drawing.Size(208, 39);
            this.exportbtn.TabIndex = 35;
            this.exportbtn.Text = "Export as excel file";
            this.exportbtn.UseVisualStyleBackColor = false;
            this.exportbtn.Click += new System.EventHandler(this.exportbtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(685, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 29);
            this.label4.TabIndex = 32;
            this.label4.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(660, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 29);
            this.label3.TabIndex = 31;
            this.label3.Text = "From:";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEnd.Location = new System.Drawing.Point(735, 52);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(197, 29);
            this.dateTimePickerEnd.TabIndex = 28;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(87)))), ((int)(((byte)(110)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.barcode,
            this.nameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.inventoryReportBindingSource5;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.Size = new System.Drawing.Size(1257, 385);
            this.dataGridView1.TabIndex = 29;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // barcode
            // 
            this.barcode.DataPropertyName = "barcode";
            this.barcode.HeaderText = "barcode";
            this.barcode.Name = "barcode";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // inventoryReportBindingSource5
            // 
            this.inventoryReportBindingSource5.DataMember = "InventoryReport";
            this.inventoryReportBindingSource5.DataSource = this.testDataSet;
            // 
            // testDataSet
            // 
            this.testDataSet.DataSetName = "TestDataSet";
            this.testDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inventoryReportBindingSource2
            // 
            this.inventoryReportBindingSource2.DataMember = "InventoryReport";
            this.inventoryReportBindingSource2.DataSource = this.inventoryReportDataSet;
            // 
            // inventoryReportDataSet
            // 
            this.inventoryReportDataSet.DataSetName = "InventoryReportDataSet";
            this.inventoryReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inventoryReportBindingSource
            // 
            this.inventoryReportBindingSource.DataMember = "InventoryReport";
            // 
            // inventoryReportBindingSource1
            // 
            this.inventoryReportBindingSource1.DataMember = "InventoryReport";
            // 
            // inventoryReportBindingSource3
            // 
            this.inventoryReportBindingSource3.DataMember = "InventoryReport";
            this.inventoryReportBindingSource3.DataSource = this.inventoryReportDataSet;
            // 
            // inventoryReportBindingSource4
            // 
            this.inventoryReportBindingSource4.DataMember = "InventoryReport";
            this.inventoryReportBindingSource4.DataSource = this.inventoryReportDataSet;
            // 
            // inventoryReportTableAdapter1
            // 
            this.inventoryReportTableAdapter1.ClearBeforeFill = true;
            // 
            // productBindingSource
            // InventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1257, 480);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(1171, 519);
            this.Name = "InventoryReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Report form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InventoryReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportBindingSource5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox product_id_text_box;
        private System.Windows.Forms.TextBox product_name_text_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource inventoryReportBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource inventoryReportBindingSource1;
        private System.Windows.Forms.Button exportbtn;
        private InventoryReportDataSet inventoryReportDataSet;
        private System.Windows.Forms.BindingSource inventoryReportBindingSource2;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox product_barcode_text_box;
        private System.Windows.Forms.BindingSource inventoryReportBindingSource3;
        private System.Windows.Forms.BindingSource inventoryReportBindingSource4;
        private InventoryReportDataSet testDataSet;
        private System.Windows.Forms.BindingSource inventoryReportBindingSource5;
        private TestDataSetTableAdapters.InventoryReportTableAdapter inventoryReportTableAdapter1;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
    }
}