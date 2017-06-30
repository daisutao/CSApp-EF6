using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CSApp.Properties;
using Tkx.Lppa;

namespace CSApp
{
    public partial class frmSample : Form
    {
        private Tkx.Lppa.Application NetApp = null;
        private Tkx.Lppa.Document ActiveDoc = null;

        public frmSample()
        {
            InitializeComponent();
        }

        private void frmSample_Load(object sender, EventArgs e)
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

            NetApp = new Tkx.Lppa.Application();
            //NetApp = Tkx.Lppa.Application.SelectApplication();
            UpdatePrinterList();

            // 加载制品信息
            TreeNode node = new TreeNode {Text = Resources.APPLE_LBL};
            treeView1.Nodes.Add(node);
            foreach (var product in Business.context.Product.OrderBy(c => c.Category))
            {
                TreeNode node1 = new TreeNode();
                node1.Text = product.Category;
                node1.Tag = product;
                node.Nodes.Add(node1); //node下的子节点
            }
            if (node.Nodes.Count > 0)
                treeView1.SelectedNode = node.Nodes[0];
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (ActiveDoc != null)
            {
                ActiveDoc.Close(false);
                ActiveDoc.Dispose();
            }

            if(NetApp != null)
                NetApp.Quit();

            if (Business.context != null)
                Business.context.Dispose();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        private void UpdatePrinterList()
        {
            cbbPrinter.Items.Clear();

            string[] printers = NetApp.PrinterSystem.PrintersNames(KindOfPrinters.AllPrinters);
            foreach (string printer in printers)
            {
                cbbPrinter.Items.Add(printer);
            }
        }

        private void UpdateSelectedPrinter()
        {
            if (ActiveDoc != null)
            {
                cbbPrinter.SelectedIndex = cbbPrinter.Items.IndexOf(ActiveDoc.Printer.Name);
            }
        }

        private void UpdateLabelPreview()
        {
            if(ActiveDoc != null)
            {
                pbLabelPreview.Image = ActiveDoc != null ? ActiveDoc.GetPreview(true, true, 400) : null;
            }
        }

        private void UpdateVarList()
        {
            lstVariables.Items.Clear();

            if (ActiveDoc != null)
            {
                foreach (Variable aVariable in ActiveDoc.Variables)
                {
                    lstVariables.Items.Add(aVariable.Name);
                }
            }

            if (lstVariables.Items.Count > 0)
                lstVariables.SelectedIndex = 0;
        }

        private void lstLabels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveDoc != null)
            {
                ActiveDoc.Close(false);
                ActiveDoc.Dispose();
                ActiveDoc = null;
            }

            ActiveDoc = NetApp.Documents.Open(AppDomain.CurrentDomain.BaseDirectory + lstLabels.Text, false);
            UpdateLabelPreview();
            UpdateVarList();
            UpdateSelectedPrinter();
        }

        private void lstVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveDoc != null)
            {
                Variable aVariable = ActiveDoc.Variables[lstVariables.Text];
                lblVarValue.Text = aVariable.Value;
            }            
        }

        private void btnUpdateVar_Click(object sender, EventArgs e)
        {
            if (ActiveDoc != null)
            {
                Variable aVariable = ActiveDoc.Variables[lstVariables.Text];
                aVariable.Value = lblVarValue.Text;
            } 

            UpdateLabelPreview();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (ActiveDoc == null) return;
            var product = (Product)treeView1.SelectedNode.Tag;
            string dateFlag = (System.DateTime.Now.Year % 10).ToString()
                              + Common.GetWeekOfYear(System.DateTime.Now).ToString("00")
                              + (Convert.ToInt32(System.DateTime.Now.DayOfWeek) + 1).ToString();
            var printed = Business.GetPrinted(product.ID, dateFlag);

            int pqty = int.Parse(txtPQty.Text);
            int page = int.Parse(txtRows.Text) * ActiveDoc.Format.ColumnCount;
            while (pqty > 0)
            {
                if (!Business.SetPrinted(printed, (int)Math.Pow(34, 4) - 1, page))
                {
                    MessageBox.Show(string.Format(Resources.MAX_LIMIT, printed.TotalNum), Resources.ERROR);
                    return;
                }
                ActiveDoc.HorzPrintOffset = int.Parse(txtHPos.Text);
                ActiveDoc.VertPrintOffset = int.Parse(txtVPos.Text);
                ActiveDoc.FullClippingMode = true;
                    
                for (int i = printed.TotalNum - page; i < printed.TotalNum; ++i)
                {
                    string barcode = product.PlantCode + dateFlag
                                     + Common.ConvertDecimalToBase34(i) + product.Engineer + product.Revision;
                    barcode += Common.ConvertBase10ToBase34(Common.GetCheckSum(barcode)) + product.Configure;

                    ActiveDoc.Variables["var0"].Value = barcode;
                    ActiveDoc.Variables["var1"].Value = barcode.Substring(0, 11);
                    ActiveDoc.Variables["var2"].Value = barcode.Substring(11);
                    UpdateLabelPreview();
                    Thread.Sleep(500);

                    Business.context.Barcode.Add(new Barcode
                    {
                        PrintedID = printed.ID,
                        Contents = barcode,
                        QCSymbol = "B",
                    });
                    ActiveDoc.PrintLabel(1);
                }
                Business.context.SaveChanges();
                ActiveDoc.FormFeed();
                //ActiveDoc.PrintDocument(int.Parse(txtPQty.Text));
                --pqty; 
            }
        }

        private void btnPrinterSettings_Click(object sender, EventArgs e)
        {
            try
            {
                NetApp.Dialogs[DialogType.PrinterSetup].Show((int)Handle);
            }
            catch (COMException)
            {
            }
        }

        private void cbbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveDoc != null)
            {
                ActiveDoc.Printer.SwitchTo(cbbPrinter.Text);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Level == 1)
            {
                lstLabels.Items.Clear();

                var product = (Product)treeView1.SelectedNode.Tag;

                string label = AppDomain.CurrentDomain.BaseDirectory + product.LabelFile;
                if (!File.Exists(label))
                    MessageBox.Show(string.Format(Resources.NO_TEMPLATE, product.LabelFile), Resources.ERROR);
                else
                    lstLabels.Items.Add(product.LabelFile);
                
                if (lstLabels.Items.Count > 0)
                    lstLabels.SelectedIndex = 0;
                else
                    pbLabelPreview.Image = null;

                txtHPos.Text = product.HorzOffset.ToString();
                txtVPos.Text = product.VertOffset.ToString();
                txtRows.Text = product.PageLinage.ToString();
            }
        }

        private void txtHPos_TextChanged(object sender, EventArgs e)
        {
            int value;
            var product = (Product)treeView1.SelectedNode.Tag;
            if (int.TryParse(txtHPos.Text, out value) && value != product.HorzOffset)
            {
                product.HorzOffset = value;
                Business.context.SaveChanges();
            }
        }

        private void txtVPos_TextChanged(object sender, EventArgs e)
        {
            int value;
            var product = (Product)treeView1.SelectedNode.Tag;
            if (int.TryParse(txtVPos.Text, out value) && value != product.VertOffset)
            {
                product.VertOffset = value;
                Business.context.SaveChanges();
            }
        }

        private void txtRows_TextChanged(object sender, EventArgs e)
        {
            int value;
            var product = (Product)treeView1.SelectedNode.Tag;
            if (int.TryParse(txtRows.Text, out value) && value != product.PageLinage)
            {
                product.PageLinage = value;
                Business.context.SaveChanges();
            }
        }
    }
}