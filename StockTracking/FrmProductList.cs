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
    public partial class FrmProductList : Form
    {
        private ProductBLL bll = new ProductBLL();
        private ProductDTO dto = new ProductDTO();
        public FrmProductList()
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

        private void txtProductStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new FrmProduct();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;

            dto = bll.Select();
            dataGridView1.DataSource = dto.Products;

            CleanFilters();
        }

        private void FrmProductList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();

            cbCategory.DataSource = dto.Categories;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "ID";
            cbCategory.SelectedIndex = -1;

            dataGridView1.DataSource = dto.Products;
            dataGridView1.Columns[0].HeaderText = "Product Name";
            dataGridView1.Columns[1].HeaderText = "Category Name";
            dataGridView1.Columns[2].HeaderText = "Stock Amount";
            dataGridView1.Columns[3].HeaderText = "Price";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ProductDetailDTO> list = dto.Products;

            if (!string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                list = list.Where(x => x.ProductName.ToLower().Contains(txtProductName.Text)).ToList();
            }
            if (cbCategory.SelectedIndex != -1)
            {
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cbCategory.SelectedValue)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                if (rbPriceEqual.Checked)
                {
                    list = list.Where(x => x.Price == Convert.ToInt32(txtPrice.Text)).ToList();
                }
                else if (rbPriceMore.Checked)
                {
                    list = list.Where(x => x.Price > Convert.ToInt32(txtPrice.Text)).ToList();
                }
                else if (rbPriceLess.Checked)
                {
                    list = list.Where(x => x.Price < Convert.ToInt32(txtPrice.Text)).ToList();
                }
            }
            if (!string.IsNullOrWhiteSpace(txtProductStock.Text))
            {
                if (rbStockEqual.Checked)
                {
                    list = list.Where(x => x.StockAmount == Convert.ToInt32(txtProductStock.Text)).ToList();
                }
                else if (rbStockMore.Checked)
                {
                    list = list.Where(x => x.StockAmount > Convert.ToInt32(txtProductStock.Text)).ToList();
                }
                else if (rbStockLess.Checked)
                {
                    list = list.Where(x => x.StockAmount < Convert.ToInt32(txtProductStock.Text)).ToList();
                }
            }

            dataGridView1.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            txtProductStock.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            cbCategory.SelectedIndex = -1;
            rbPriceEqual.Checked = false;
            rbPriceLess.Checked = false;
            rbPriceMore.Checked = false;
            rbStockEqual.Checked = false;
            rbStockLess.Checked = false;
            rbStockMore.Checked = false;

            dataGridView1.DataSource = dto.Products;
        }
    }
}
