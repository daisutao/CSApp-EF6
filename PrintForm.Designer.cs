namespace CSApp
{
    partial class PrintForm
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
            this.lblPrinter = new System.Windows.Forms.Label();
            this.cbbPrinter = new System.Windows.Forms.ComboBox();
            this.pbLabelPreview = new System.Windows.Forms.PictureBox();
            this.lstLabels = new System.Windows.Forms.ListBox();
            this.btnUpdateVar = new System.Windows.Forms.Button();
            this.lblVarValue = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblPQty = new System.Windows.Forms.Label();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtConfigure = new System.Windows.Forms.TextBox();
            this.lblConfigure = new System.Windows.Forms.Label();
            this.txtRevision = new System.Windows.Forms.TextBox();
            this.lblRevision = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEngineer = new System.Windows.Forms.TextBox();
            this.lblEngineer = new System.Windows.Forms.Label();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.lblRows = new System.Windows.Forms.Label();
            this.txtVPos = new System.Windows.Forms.TextBox();
            this.lblVPos = new System.Windows.Forms.Label();
            this.txtHPos = new System.Windows.Forms.TextBox();
            this.lblHPos = new System.Windows.Forms.Label();
            this.txtPQty = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.txtDayFlag = new System.Windows.Forms.TextBox();
            this.lblDayFlag = new System.Windows.Forms.Label();
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
            this.grpVariables.Controls.Add(this.lblPrinter);
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
            // lblPrinter
            // 
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Location = new System.Drawing.Point(6, 225);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(77, 12);
            this.lblPrinter.TabIndex = 17;
            this.lblPrinter.Text = "使用打印机：";
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
            this.btnPrint.Location = new System.Drawing.Point(322, 150);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblPQty
            // 
            this.lblPQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPQty.Location = new System.Drawing.Point(276, 126);
            this.lblPQty.Name = "lblPQty";
            this.lblPQty.Size = new System.Drawing.Size(65, 15);
            this.lblPQty.TabIndex = 7;
            this.lblPQty.Text = "打印页数：";
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.txtDayFlag);
            this.grpSettings.Controls.Add(this.lblDayFlag);
            this.grpSettings.Controls.Add(this.btnQuery);
            this.grpSettings.Controls.Add(this.button1);
            this.grpSettings.Controls.Add(this.btnSave);
            this.grpSettings.Controls.Add(this.btnEdit);
            this.grpSettings.Controls.Add(this.txtConfigure);
            this.grpSettings.Controls.Add(this.lblConfigure);
            this.grpSettings.Controls.Add(this.txtRevision);
            this.grpSettings.Controls.Add(this.lblRevision);
            this.grpSettings.Controls.Add(this.label1);
            this.grpSettings.Controls.Add(this.txtEngineer);
            this.grpSettings.Controls.Add(this.lblEngineer);
            this.grpSettings.Controls.Add(this.txtRows);
            this.grpSettings.Controls.Add(this.lblRows);
            this.grpSettings.Controls.Add(this.txtVPos);
            this.grpSettings.Controls.Add(this.lblVPos);
            this.grpSettings.Controls.Add(this.txtHPos);
            this.grpSettings.Controls.Add(this.lblHPos);
            this.grpSettings.Controls.Add(this.btnPrint);
            this.grpSettings.Controls.Add(this.txtPQty);
            this.grpSettings.Controls.Add(this.lblPQty);
            this.grpSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpSettings.Location = new System.Drawing.Point(221, 268);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(402, 184);
            this.grpSettings.TabIndex = 17;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "打印设置";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(8, 150);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 31;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(136, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 22);
            this.button1.TabIndex = 30;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(136, 101);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 22);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEdit.Location = new System.Drawing.Point(78, 101);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(57, 22);
            this.btnEdit.TabIndex = 29;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtConfigure
            // 
            this.txtConfigure.Enabled = false;
            this.txtConfigure.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtConfigure.Location = new System.Drawing.Point(141, 74);
            this.txtConfigure.Name = "txtConfigure";
            this.txtConfigure.Size = new System.Drawing.Size(52, 21);
            this.txtConfigure.TabIndex = 26;
            // 
            // lblConfigure
            // 
            this.lblConfigure.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblConfigure.Location = new System.Drawing.Point(76, 77);
            this.lblConfigure.Name = "lblConfigure";
            this.lblConfigure.Size = new System.Drawing.Size(65, 15);
            this.lblConfigure.TabIndex = 25;
            this.lblConfigure.Text = "末尾码：";
            // 
            // txtRevision
            // 
            this.txtRevision.Enabled = false;
            this.txtRevision.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtRevision.Location = new System.Drawing.Point(141, 47);
            this.txtRevision.Name = "txtRevision";
            this.txtRevision.Size = new System.Drawing.Size(52, 21);
            this.txtRevision.TabIndex = 24;
            // 
            // lblRevision
            // 
            this.lblRevision.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRevision.Location = new System.Drawing.Point(76, 50);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(65, 15);
            this.lblRevision.TabIndex = 23;
            this.lblRevision.Text = "版本号：";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(76, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "机种码：";
            // 
            // txtEngineer
            // 
            this.txtEngineer.Enabled = false;
            this.txtEngineer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEngineer.Location = new System.Drawing.Point(141, 20);
            this.txtEngineer.Name = "txtEngineer";
            this.txtEngineer.Size = new System.Drawing.Size(52, 21);
            this.txtEngineer.TabIndex = 22;
            // 
            // lblEngineer
            // 
            this.lblEngineer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEngineer.Location = new System.Drawing.Point(76, 23);
            this.lblEngineer.Name = "lblEngineer";
            this.lblEngineer.Size = new System.Drawing.Size(65, 15);
            this.lblEngineer.TabIndex = 21;
            this.lblEngineer.Text = "机种码：";
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
            // lblRows
            // 
            this.lblRows.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRows.Location = new System.Drawing.Point(276, 99);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(65, 15);
            this.lblRows.TabIndex = 19;
            this.lblRows.Text = "每页行数：";
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
            // lblVPos
            // 
            this.lblVPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVPos.Location = new System.Drawing.Point(276, 50);
            this.lblVPos.Name = "lblVPos";
            this.lblVPos.Size = new System.Drawing.Size(65, 15);
            this.lblVPos.TabIndex = 17;
            this.lblVPos.Text = "垂直偏移：";
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
            // lblHPos
            // 
            this.lblHPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHPos.Location = new System.Drawing.Point(276, 23);
            this.lblHPos.Name = "lblHPos";
            this.lblHPos.Size = new System.Drawing.Size(65, 15);
            this.lblHPos.TabIndex = 15;
            this.lblHPos.Text = "水平偏移：";
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
            // txtDayFlag
            // 
            this.txtDayFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDayFlag.Location = new System.Drawing.Point(260, 151);
            this.txtDayFlag.MaxLength = 1;
            this.txtDayFlag.Name = "txtDayFlag";
            this.txtDayFlag.Size = new System.Drawing.Size(52, 21);
            this.txtDayFlag.TabIndex = 33;
            // 
            // lblDayFlag
            // 
            this.lblDayFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDayFlag.Location = new System.Drawing.Point(195, 154);
            this.lblDayFlag.Name = "lblDayFlag";
            this.lblDayFlag.Size = new System.Drawing.Size(65, 15);
            this.lblDayFlag.TabIndex = 32;
            this.lblDayFlag.Text = "Day Flag：";
            // 
            // PrintForm
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
            this.Name = "PrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MFLEX 打印程序";
            this.Load += new System.EventHandler(this.PrintForm_Load);
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
        private System.Windows.Forms.Label lblPQty;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.TextBox txtPQty;
        private System.Windows.Forms.Label lblHPos;
        private System.Windows.Forms.TextBox txtVPos;
        private System.Windows.Forms.Label lblVPos;
        private System.Windows.Forms.TextBox txtHPos;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.ListBox lstLabels;
        private System.Windows.Forms.PictureBox pbLabelPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnPrinterSettings;
        private System.Windows.Forms.Label lblPrinter;
        private System.Windows.Forms.ComboBox cbbPrinter;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.TextBox txtConfigure;
        private System.Windows.Forms.Label lblConfigure;
        private System.Windows.Forms.TextBox txtRevision;
        private System.Windows.Forms.Label lblRevision;
        private System.Windows.Forms.TextBox txtEngineer;
        private System.Windows.Forms.Label lblEngineer;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDayFlag;
        private System.Windows.Forms.Label lblDayFlag;
    }
}

