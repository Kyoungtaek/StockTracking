using StockTracking.BLL;
using StockTracking.DAL.DTO;
using StockTracking.Infrastructures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockTracking
{
    public partial class FrmProduct : Form
    {
        public ProductDTO dto = new ProductDTO();
        private ProductBLL bll = new ProductBLL();

        public FrmProduct()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            cbCategory.DataSource = dto.Categories;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "ID";
            cbCategory.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Product name is empty");
            }
            else if(cbCategory.SelectedIndex==-1)
            {
                MessageBox.Show("Please select category");
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Price is emtpy");
            }
            else
            {
                var product = new ProductDetailDTO();
                product.Price = Convert.ToInt32(txtPrice.Text.Trim());
                product.ProductName = txtProductName.Text.Trim();
                product.CategoryID = Convert.ToInt32(cbCategory.SelectedValue);

                if (bll.Insert(product))
                {
                    MessageBox.Show("Product was added");
                    cbCategory.SelectedIndex = -1;
                    txtPrice.Clear();
                    txtProductName.Clear();
                }
            }
        }
    }
}
