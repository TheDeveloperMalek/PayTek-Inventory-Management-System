﻿using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class ProductsReport : Form
    {
        #region Essential Data
        public ProductsReport()
        {
            InitializeComponent();
            Shared.ConnectionInitializer();
            this.productReportTableAdapter.Connection.ConnectionString = Shared.conn.ConnectionString;
            dateTimePickerEnd.Value = DateTime.Now;
            dateTimePickerStart.Value = DateTime.Now.AddMonths(-5);

            #region DatePicker Set
            dateTimePickerStart.MaxDate = DateTime.Now.AddDays(-1);
            dateTimePickerEnd.MaxDate = DateTime.Now;
            #endregion

            #region For Shortcuts
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
            #endregion
        }

        private void ProductsReport_Load(object sender, EventArgs e)
        {
            this.productReportTableAdapter.Fill(this.productReportDataSet.ProductReport);
            ShowData();
            Shared.TextBoxAutoCompleteFromColumn("Product", "ID", product_id_text_box);
            Shared.TextBoxAutoCompleteFromColumn("Product", "Barcode", product_barcode_text_box);
            Shared.TextBoxAutoCompleteFromColumn("Product", "Name", product_name_text_box);
        }

        #endregion

        #region Startup Functions
        public void ShowData()
        {
            Shared.ShowAllProductReportTableDataWithDate(dataGridView2, "Product ID", dateTimePickerStart, dateTimePickerEnd);

        }
        
        private void KeysShortcuts(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P) //print
            {
                exportbtn_Click(sender, e);
                return;
            }
        }

        #endregion

        #region Events
        #region Button Click

        #region Export Button
        private void exportbtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.SaveDataGridViewASExcelFile("Products Report" , dataGridView2 , dateTimePickerStart , dateTimePickerEnd);
        }
        #endregion

        #region Reset Button
        private void searchBtn_Click_1(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ResetFields(groupBox1);
            ShowData();
        }
        #endregion

        #endregion

        #region Searching
        private void product_name_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandWitDateAssembler(dataGridView2 , product_name_text_box , "ProductReport" , "Product Name" , "Product ID" , dateTimePickerStart , dateTimePickerEnd);
        }

        private void product_barcode_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandWitDateAssembler(dataGridView2, product_barcode_text_box, "ProductReport", "Product Barcode", "Product ID" , dateTimePickerStart, dateTimePickerEnd  , false , "product barcode");
        }
        private void product_id_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            Shared.SearchCommandWitDateAssembler(dataGridView2, product_id_text_box, "ProductReport", "Product ID", "Product ID", dateTimePickerStart, dateTimePickerEnd , false , "product id");
        }
        private void dateTimePickerEnd_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ShowAllProductReportTableDataWithDate(dataGridView2, "Product ID", dateTimePickerStart, dateTimePickerEnd);
        }

        private void dateTimePickerStart_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ShowAllProductReportTableDataWithDate(dataGridView2, "Product ID", dateTimePickerStart, dateTimePickerEnd);
        }
        #endregion

        #region Cell Click
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Shared.PlayClickSound();
            Shared.ResetFields(groupBox1);
            var text = dataGridView2.CurrentCell.Value.ToString();
            var columnIndex = dataGridView2.CurrentCellAddress.X;
            var c = new KeyEventArgs(Keys.NoName);

            switch (columnIndex)
            {
                case 0:
                    product_id_text_box.Text = text;
                    product_id_text_box_KeyUp(sender, c);
                    break;
                case 1:
                    product_barcode_text_box.Text = text;
                    product_barcode_text_box_KeyUp(sender, c);
                    break;
                case 2:
                    product_name_text_box.Text = text;
                    product_name_text_box_KeyUp(sender, c);
                    break;
            }
        }
        #endregion

        #endregion

    }
}