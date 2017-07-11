﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CSApp.Properties;

namespace CSApp
{
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
        }

        private void QueryForm_Load(object sender, EventArgs e)
        {
            //dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (cbbCategory.Text.Equals(string.Empty))
            {
                MessageBox.Show(Resources.SELECT_PRODUCT, Resources.INFOR);
                return;
            }
            if (txtDayFlag.Text.Equals(string.Empty))
            {
                MessageBox.Show(Resources.INPUT_DAY_FLAG, Resources.INFOR);
                return;
            }
            string dateFlag = Common.GetWeekFlag(dtpPrintDate.Value) + txtDayFlag.Text.ToUpper();
            List<Barcode> barcodes = Business.GetBarcodeList(cbbCategory.Text, dateFlag);
            if (barcodes == null)
            {
                MessageBox.Show(Resources.QUERY_NULL, Resources.ERROR);
                return;
            }
            
            dataGridView1.DataSource = barcodes;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["PrintedId"].Visible = false;
            dataGridView1.Columns["Printed"].Visible = false;
            dataGridView1.Refresh();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("未查询或者查询结果为空！", Resources.INFOR);
                return;
            }
            Common.GridToExcel(cbbCategory.Text, dataGridView1);
        }
    }
}