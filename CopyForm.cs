using System;
using System.Windows.Forms;
using CSApp.Properties;

namespace CSApp
{
    public partial class CopyForm : Form
    {
        private readonly bool _addFlag;
        private readonly Product _product;

        public CopyForm(Product product, bool addFlag)
        {
            _product = product;
            _addFlag = addFlag;

            InitializeComponent();
            if (!addFlag)
                txtCategory.Text = product.Category;
            txtPlantCode.Text = product.PlantCode;
            txtEngineer.Text = product.Engineer;
            txtRevision.Text = product.Revision;
            txtConfigure.Text = product.Configure;
            txtLabelFile.Text = product.LabelFile;
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            if (txtCategory.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show(Resources.INPUT_CATEGORY, Resources.MSG_INFOR);
                return;
            }

            Product product;
            if (_addFlag)
            {
                product = new Product
                {
                    Category = txtCategory.Text,
                    PlantCode = txtPlantCode.Text,
                    Engineer = txtEngineer.Text,
                    Revision = txtRevision.Text,
                    Configure = txtConfigure.Text,
                    LabelFile = txtLabelFile.Text,
                    PageLinage = 2
                };
            }
            else
            {
                product = _product;
                product.Category = txtCategory.Text;
                product.PlantCode = txtPlantCode.Text;
                product.Engineer = txtEngineer.Text;
                product.Revision = txtRevision.Text;
                product.Configure = txtConfigure.Text;
                product.LabelFile = txtLabelFile.Text;
            }
            Business.SaveProduct(product);
            Close();
        }
    }
}