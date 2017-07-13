using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CSApp.Properties;
using Tkx.Lppa;

namespace CSApp
{
    public partial class PrintForm : Form
    {
        private Tkx.Lppa.Application _csApp;
        private Document _csDoc;

        public PrintForm()
        {
            InitializeComponent();
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            //context = new DataModelContext();
            // 通过代码初始化数据库 -- 方法1
            //System.Data.Entity.Database.SetInitializer(new DataModelInitializer());
            // 通过代码初始化数据库 -- 方法2
            /*IDatabaseInitializer<DataModelContext> dbInitializer = null;
            // 如果数据库已经存在
            if (context.Database.Exists())
                dbInitializer = new DropCreateDatabaseIfModelChanges<DataModelContext>();
            else // 创建数据库
                dbInitializer = new CreateDatabaseIfNotExists<DataModelContext>();
            
            dbInitializer.InitializeDatabase(context);*/

            _csApp = new Tkx.Lppa.Application();
            //_csApp = Tkx.Lppa.Application.SelectApplication();
            UpdatePrinterList();

            Text += string.Format(Resources.DEVICE_NAME, ConfigurationManager.AppSettings["device"]);

            // 加载制品信息
            UpdateTreeView();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (_csDoc != null)
            {
                _csDoc.Close(false);
                _csDoc.Dispose();
            }

            if(_csApp != null)
                _csApp.Quit();

            if (Business.Context != null)
                Business.Context.Dispose();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        private void UpdatePrinterList()
        {
            cbbPrinter.Items.Clear();

            string[] printers = _csApp.PrinterSystem.PrintersNames(KindOfPrinters.AllPrinters);
            foreach (string printer in printers)
            {
                cbbPrinter.Items.Add(printer);
            }
        }

        private void UpdateSelectedPrinter()
        {
            if (_csDoc != null)
            {
                cbbPrinter.SelectedIndex = cbbPrinter.Items.IndexOf(_csDoc.Printer.Name);
            }
        }

        private void UpdateTreeView()
        {
            treeView1.Nodes.Clear();
            TreeNode node = new TreeNode { Text = Resources.APPLE_LBL };
            treeView1.Nodes.Add(node);
            foreach (var product in Business.Context.Product.OrderBy(c => c.Category))
            {
                node.Nodes.Add(new TreeNode
                {
                    Text = product.Category,
                    Tag = product
                }); //node下的子节点
            }
            if (node.Nodes.Count > 0)
                treeView1.SelectedNode = node.Nodes[0];
        }

        private void UpdateLabelPreview()
        {
            if(_csDoc != null)
            {
                pbLabelPreview.Image = _csDoc != null ? _csDoc.GetPreview(true, true, 400) : null;
            }
        }

        private void UpdateVarList()
        {
            lstVariables.Items.Clear();

            if (_csDoc != null)
            {
                foreach (Variable aVariable in _csDoc.Variables)
                {
                    lstVariables.Items.Add(aVariable.Name);
                }
            }

            if (lstVariables.Items.Count > 0)
                lstVariables.SelectedIndex = 0;
        }

        private void lstLabels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_csDoc != null)
            {
                _csDoc.Close(false);
                _csDoc.Dispose();
                _csDoc = null;
            }

            _csDoc = _csApp.Documents.Open(AppDomain.CurrentDomain.BaseDirectory + lstLabels.Text, false);
            UpdateLabelPreview();
            UpdateVarList();
            UpdateSelectedPrinter();
        }

        private void lstVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_csDoc != null)
            {
                Variable aVariable = _csDoc.Variables[lstVariables.Text];
                lblVarValue.Text = aVariable.Value;
            }            
        }

        private void btnUpdateVar_Click(object sender, EventArgs e)
        {
            if (_csDoc != null)
            {
                Variable aVariable = _csDoc.Variables[lstVariables.Text];
                aVariable.Value = lblVarValue.Text;
            } 

            UpdateLabelPreview();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_csDoc == null) return;
            if (txtDayFlag.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show(Resources.INPUT_DAY_FLAG, Resources.INFOR);
                return;
            }

            var product = (Product) treeView1.SelectedNode.Tag;
            string dateFlag = Common.GetWeekFlag(System.DateTime.Now) + txtDayFlag.Text.ToUpper();
            var printed = Business.GetPrinted(product.Id, dateFlag);

            int pqty = int.Parse(txtPQty.Text);
            int page = int.Parse(txtRows.Text) * _csDoc.Format.ColumnCount;
            while (pqty > 0)
            {
                if (!Business.SetPrinted(printed, (int)Math.Pow(34, 4) - 1, page))
                {
                    MessageBox.Show(string.Format(Resources.MAX_LIMIT, printed.TotalNum), Resources.ERROR);
                    return;
                }
                _csDoc.HorzPrintOffset = int.Parse(txtHPos.Text);
                _csDoc.VertPrintOffset = int.Parse(txtVPos.Text);
                _csDoc.FullClippingMode = true;
                    
                for (int i = printed.TotalNum - page; i < printed.TotalNum; ++i)
                {
                    string barcode = product.PlantCode + dateFlag
                                     + Common.ConvertDecimalToBase34(i) + product.Engineer + product.Revision;
                    barcode += Common.ConvertBase10ToBase34(Common.GetCheckSum(barcode)) + product.Configure;

                    _csDoc.Variables["var0"].Value = barcode;
                    _csDoc.Variables["var1"].Value = barcode.Substring(0, 11);
                    _csDoc.Variables["var2"].Value = barcode.Substring(11);
                    UpdateLabelPreview();

                    Business.Context.Barcode.Add(new Barcode
                    {
                        PrintedId = printed.Id,
                        Contents = barcode,
                        //QcSymbol = "B",
                        DeviceNo = ConfigurationManager.AppSettings["device"],
                    });
                    _csDoc.PrintLabel(1);
                }
                Business.Context.SaveChanges();
                _csDoc.FormFeed();
                --pqty;
            }
        }

        private void btnPrinterSettings_Click(object sender, EventArgs e)
        {
            try
            {
                _csApp.Dialogs[DialogType.PrinterSetup].Show((int)Handle);
            }
            catch (COMException)
            {
            }
        }

        private void cbbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_csDoc != null)
            {
                _csDoc.Printer.SwitchTo(cbbPrinter.Text);
                //_csDoc.Printer.HeadTemperature = 20; //SetParameter(PrinterSettings.HeadTemperature, new int?(20));
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Level == 1)
            {
                lstLabels.Items.Clear();

                var product = (Product) treeView1.SelectedNode.Tag;

                string label = AppDomain.CurrentDomain.BaseDirectory + product.LabelFile;
                if (!File.Exists(label))
                    MessageBox.Show(string.Format(Resources.NO_TEMPLATE, product.LabelFile), Resources.ERROR);
                else
                    lstLabels.Items.Add(product.LabelFile);
                
                if (lstLabels.Items.Count > 0)
                    lstLabels.SelectedIndex = 0;
                else
                    pbLabelPreview.Image = null;

                txtEngineer.Text = product.Engineer;
                txtRevision.Text = product.Revision;
                txtConfigure.Text = product.Configure;
                txtHPos.Text = product.HorzOffset.ToString();
                txtVPos.Text = product.VertOffset.ToString();
                txtRows.Text = product.PageLinage.ToString();
            }
        }

        private void txtHPos_TextChanged(object sender, EventArgs e)
        {
            int value;
            var product = (Product) treeView1.SelectedNode.Tag;
            if (int.TryParse(txtHPos.Text, out value) && value != product.HorzOffset)
            {
                product.HorzOffset = value;
                Business.Context.SaveChanges();
            }
        }

        private void txtVPos_TextChanged(object sender, EventArgs e)
        {
            int value;
            var product = (Product) treeView1.SelectedNode.Tag;
            if (int.TryParse(txtVPos.Text, out value) && value != product.VertOffset)
            {
                product.VertOffset = value;
                Business.Context.SaveChanges();
            }
        }

        private void txtRows_TextChanged(object sender, EventArgs e)
        {
            int value;
            var product = (Product) treeView1.SelectedNode.Tag;
            if (int.TryParse(txtRows.Text, out value) && value != product.PageLinage)
            {
                product.PageLinage = value;
                Business.Context.SaveChanges();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtEngineer.Enabled = true;
            txtRevision.Enabled = true;
            txtConfigure.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var product = (Product) treeView1.SelectedNode.Tag;
            product.Engineer = txtEngineer.Text.Trim();
            product.Revision = txtRevision.Text.Trim();
            product.Configure = txtConfigure.Text.Trim();
            Business.Context.SaveChanges();
            txtEngineer.Enabled = false;
            txtRevision.Enabled = false;
            txtConfigure.Enabled = false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryForm form = new QueryForm();
            foreach (TreeNode node in treeView1.TopNode.Nodes)
            {
                Product product = (Product) node.Tag;
                form.cbbCategory.Items.Add(product.Category);
            }
            form.ShowDialog();
            form.Close();
        }

        private void tsmCopy_Click(object sender, EventArgs e)
        {
            CopyForm form = new CopyForm((Product)treeView1.SelectedNode.Tag, true);
            form.ShowDialog();
            form.Close();

            UpdateTreeView();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            CopyForm form = new CopyForm((Product)treeView1.SelectedNode.Tag, false);
            form.ShowDialog();
            form.Close();

            UpdateTreeView();
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) //判断你点的是不是右键
            {
                Point point = new Point(e.X, e.Y);
                TreeNode node = treeView1.GetNodeAt(point);
                if (node != null && node.Level == 1) //判断你点的是不是一个节点
                {
                    node.ContextMenuStrip = contextMenuStrip1;
                    treeView1.SelectedNode = node;//选中这个节点
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}