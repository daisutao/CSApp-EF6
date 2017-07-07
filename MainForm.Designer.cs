namespace CSApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

       
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLabelFolder = new System.Windows.Forms.Label();
            this.lstVariables = new System.Windows.Forms.ListBox();
            this.grpVariables = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnPrinterSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbPrinter = new System.Windows.Forms.ComboBox();
            this.pbLabelPreview = new System.Windows.Forms.PictureBox();
            this.lstLabels = new System.Windows.Forms.ListBox();
            this.btnUpdateVar = new System.Windows.Forms.Button();
            this.lblVarValue = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVPos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHPos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPQty = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.grpVariables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLabelPreview)).BeginInit();
            this.grpSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLabelFolder
            // 
            this.lblLabelFolder.AutoSize = true;
            this.lblLabelFolder.Location = new System.Drawing.Point(219, 230);
            this.lblLabelFolder.Name = "lblLabelFolder";
            this.lblLabelFolder.Size = new System.Drawing.Size(65, 12);
            this.lblLabelFolder.TabIndex = 2;
            this.lblLabelFolder.Text = "模板路径：";
            // 
            // lstVariables
            // 
            this.lstVariables.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lstVariables.ItemHeight = 12;
            this.lstVariables.Location = new System.Drawing.Point(6, 66);
            this.lstVariables.Name = "lstVariables";
            this.lstVariables.Size = new System.Drawing.Size(187, 124);
            this.lstVariables.TabIndex = 9;
            this.lstVariables.SelectedIndexChanged += new System.EventHandler(this.lstVariables_SelectedIndexChanged);
            // 
            // grpVariables
            // 
            this.grpVariables.Controls.Add(this.button2);
            this.grpVariables.Controls.Add(this.btnPrinterSettings);
            this.grpVariables.Controls.Add(this.label1);
            this.grpVariables.Controls.Add(this.cbbPrinter);
            this.grpVariables.Controls.Add(this.pbLabelPreview);
            this.grpVariables.Controls.Add(this.lstLabels);
            this.grpVariables.Controls.Add(this.lstVariables);
            this.grpVariables.Controls.Add(this.btnUpdateVar);
            this.grpVariables.Controls.Add(this.lblVarValue);
            this.grpVariables.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpVariables.Location = new System.Drawing.Point(221, 12);
            this.grpVariables.Name = "grpVariables";
            this.grpVariables.Size = new System.Drawing.Size(402, 250);
            this.grpVariables.TabIndex = 16;
            this.grpVariables.TabStop = false;
            this.grpVariables.Text = "模板信息";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(341, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 22);
            this.button2.TabIndex = 18;
            this.button2.Text = "设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnPrinterSettings_Click);
            // 
            // btnPrinterSettings
            // 
            this.btnPrinterSettings.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPrinterSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrinterSettings.Location = new System.Drawing.Point(343, 221);
            this.btnPrinterSettings.Name = "btnPrinterSettings";
            this.btnPrinterSettings.Size = new System.Drawing.Size(55, 22);
            this.btnPrinterSettings.TabIndex = 19;
            this.btnPrinterSettings.Text = "设置";
            this.btnPrinterSettings.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "使用打印机：";
            // 
            // cbbPrinter
            // 
            this.cbbPrinter.FormattingEnabled = true;
            this.cbbPrinter.Location = new System.Drawing.Point(89, 223);
            this.cbbPrinter.Name = "cbbPrinter";
            this.cbbPrinter.Size = new System.Drawing.Size(246, 20);
            this.cbbPrinter.Sorted = true;
            this.cbbPrinter.TabIndex = 16;
            this.cbbPrinter.SelectedIndexChanged += new System.EventHandler(this.cbbPrinter_SelectedIndexChanged);
            // 
            // pbLabelPreview
            // 
            this.pbLabelPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLabelPreview.Location = new System.Drawing.Point(199, 20);
            this.pbLabelPreview.Name = "pbLabelPreview";
            this.pbLabelPreview.Size = new System.Drawing.Size(197, 197);
            this.pbLabelPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLabelPreview.TabIndex = 15;
            this.pbLabelPreview.TabStop = false;
            // 
            // lstLabels
            // 
            this.lstLabels.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lstLabels.ItemHeight = 12;
            this.lstLabels.Location = new System.Drawing.Point(6, 20);
            this.lstLabels.Name = "lstLabels";
            this.lstLabels.Size = new System.Drawing.Size(187, 40);
            this.lstLabels.Sorted = true;
            this.lstLabels.TabIndex = 14;
            this.lstLabels.SelectedIndexChanged += new System.EventHandler(this.lstLabels_SelectedIndexChanged);
            // 
            // btnUpdateVar
            // 
            this.btnUpdateVar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnUpdateVar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdateVar.Location = new System.Drawing.Point(137, 195);
            this.btnUpdateVar.Name = "btnUpdateVar";
            this.btnUpdateVar.Size = new System.Drawing.Size(56, 22);
            this.btnUpdateVar.TabIndex = 13;
            this.btnUpdateVar.Text = "更新";
            this.btnUpdateVar.UseVisualStyleBackColor = true;
            this.btnUpdateVar.Click += new System.EventHandler(this.btnUpdateVar_Click);
            // 
            // lblVarValue
            // 
            this.lblVarValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVarValue.Location = new System.Drawing.Point(6, 196);
            this.lblVarValue.Name = "lblVarValue";
            this.lblVarValue.Size = new System.Drawing.Size(125, 21);
            this.lblVarValue.TabIndex = 12;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrint.Location = new System.Drawing.Point(302, 150);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(94, 22);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "打印测试";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(276, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "打印页数：";
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.txtRows);
            this.grpSettings.Controls.Add(this.label5);
            this.grpSettings.Controls.Add(this.txtVPos);
            this.grpSettings.Controls.Add(this.label4);
            this.grpSettings.Controls.Add(this.txtHPos);
            this.grpSettings.Controls.Add(this.label3);
            this.grpSettings.Controls.Add(this.btnPrint);
            this.grpSettings.Controls.Add(this.txtPQty);
            this.grpSettings.Controls.Add(this.label2);
            this.grpSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpSettings.Location = new System.Drawing.Point(221, 268);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(402, 178);
            this.grpSettings.TabIndex = 17;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "打印设置";
            // 
            // txtRows
            // 
            this.txtRows.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtRows.Location = new System.Drawing.Point(341, 96);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(52, 21);
            this.txtRows.TabIndex = 20;
            this.txtRows.TextChanged += new System.EventHandler(this.txtRows_TextChanged);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(276, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "每页行数：";
            // 
            // txtVPos
            // 
            this.txtVPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtVPos.Location = new System.Drawing.Point(341, 47);
            this.txtVPos.Name = "txtVPos";
            this.txtVPos.Size = new System.Drawing.Size(52, 21);
            this.txtVPos.TabIndex = 18;
            this.txtVPos.TextChanged += new System.EventHandler(this.txtVPos_TextChanged);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(276, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "垂直偏移：";
            // 
            // txtHPos
            // 
            this.txtHPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtHPos.Location = new System.Drawing.Point(341, 20);
            this.txtHPos.Name = "txtHPos";
            this.txtHPos.Size = new System.Drawing.Size(52, 21);
            this.txtHPos.TabIndex = 16;
            this.txtHPos.TextChanged += new System.EventHandler(this.txtHPos_TextChanged);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(276, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "水平偏移：";
            // 
            // txtPQty
            // 
            this.txtPQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPQty.Location = new System.Drawing.Point(341, 123);
            this.txtPQty.Name = "txtPQty";
            this.txtPQty.Size = new System.Drawing.Size(52, 21);
            this.txtPQty.TabIndex = 8;
            this.txtPQty.Text = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 440);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条码列表";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 20);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(188, 414);
            this.treeView1.TabIndex = 19;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // frmSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 464);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.grpVariables);
            this.Controls.Add(this.lblLabelFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(500, 372);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeSoft 打印测试程序";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpVariables.ResumeLayout(false);
            this.grpVariables.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLabelPreview)).EndInit();
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblLabelFolder;
        private System.Windows.Forms.ListBox lstVariables;
        private System.Windows.Forms.GroupBox grpVariables;
        private System.Windows.Forms.TextBox lblVarValue;
        private System.Windows.Forms.Button btnUpdateVar;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.TextBox txtPQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVPos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHPos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstLabels;
        private System.Windows.Forms.PictureBox pbLabelPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnPrinterSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbPrinter;
        private System.Windows.Forms.TextBox txtRows;
    }
}

