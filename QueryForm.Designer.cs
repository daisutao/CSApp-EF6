namespace CSApp
{
    partial class QueryForm
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
            this.grpQuery = new System.Windows.Forms.GroupBox();
            this.txtDayFlag = new System.Windows.Forms.TextBox();
            this.lblDayFlag = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.cbbCategory = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPrintDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpQuery
            // 
            this.grpQuery.Controls.Add(this.txtDayFlag);
            this.grpQuery.Controls.Add(this.lblDayFlag);
            this.grpQuery.Controls.Add(this.btnExcel);
            this.grpQuery.Controls.Add(this.cbbCategory);
            this.grpQuery.Controls.Add(this.btnQuery);
            this.grpQuery.Controls.Add(this.label2);
            this.grpQuery.Controls.Add(this.dtpPrintDate);
            this.grpQuery.Controls.Add(this.label1);
            this.grpQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpQuery.Location = new System.Drawing.Point(0, 0);
            this.grpQuery.Name = "grpQuery";
            this.grpQuery.Size = new System.Drawing.Size(784, 50);
            this.grpQuery.TabIndex = 0;
            this.grpQuery.TabStop = false;
            this.grpQuery.Text = "查询条件";
            // 
            // txtDayFlag
            // 
            this.txtDayFlag.Enabled = false;
            this.txtDayFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDayFlag.Location = new System.Drawing.Point(479, 22);
            this.txtDayFlag.MaxLength = 1;
            this.txtDayFlag.Name = "txtDayFlag";
            this.txtDayFlag.Size = new System.Drawing.Size(52, 21);
            this.txtDayFlag.TabIndex = 35;
            this.txtDayFlag.Text = "2";
            // 
            // lblDayFlag
            // 
            this.lblDayFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDayFlag.Location = new System.Drawing.Point(408, 25);
            this.lblDayFlag.Name = "lblDayFlag";
            this.lblDayFlag.Size = new System.Drawing.Size(65, 15);
            this.lblDayFlag.TabIndex = 34;
            this.lblDayFlag.Text = "Day Flag：";
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(675, 20);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 7;
            this.btnExcel.Text = "导出数据";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // cbbCategory
            // 
            this.cbbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCategory.FormattingEnabled = true;
            this.cbbCategory.Location = new System.Drawing.Point(87, 21);
            this.cbbCategory.Name = "cbbCategory";
            this.cbbCategory.Size = new System.Drawing.Size(121, 20);
            this.cbbCategory.TabIndex = 6;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(578, 20);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "打印品目：";
            // 
            // dtpPrintDate
            // 
            this.dtpPrintDate.CustomFormat = "yyyy/MM/dd";
            this.dtpPrintDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPrintDate.Location = new System.Drawing.Point(295, 21);
            this.dtpPrintDate.Name = "dtpPrintDate";
            this.dtpPrintDate.Size = new System.Drawing.Size(92, 21);
            this.dtpPrintDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "打印日期：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(784, 511);
            this.dataGridView1.TabIndex = 1;
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.grpQuery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "QueryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "打印查询";
            this.Load += new System.EventHandler(this.QueryForm_Load);
            this.grpQuery.ResumeLayout(false);
            this.grpQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpPrintDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.ComboBox cbbCategory;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox txtDayFlag;
        private System.Windows.Forms.Label lblDayFlag;
    }
}