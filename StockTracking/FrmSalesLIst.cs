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
    public partial class FrmSalesLIst : Form
    {
        private SalesBLL bll = new SalesBLL();
        private SalesDTO dto = new SalesDTO();
        public FrmSalesLIst()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void txtSalesAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new FrmSales();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;

            dto = bll.Select();
            dataGridView1.DataSource = dto.Sales;
            CleanFilter();
        }

        private void FrmSalesLIst_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Sales;
            dataGridView1.Columns[0].HeaderText = "Customer";
            dataGridView1.Columns[1].HeaderText = "Product";
            dataGridView1.Columns[2].HeaderText = "Category";

            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;

            cbCategory.DataSource = dto.Categories;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "ID";
            cbCategory.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<SalesDetailDTO> list = dto.Sales;
            if (!string.IsNullOrEmpty(txtProductName.Text))
            {
                list = list.Where(x => x.ProductName.Contains(txtProductName.Text)).ToList();
            }
            if (!string.IsNullOrEmpty(txtCustomerName.Text))
            {
                list = list.Where(x => x.CustomerName.Contains(txtCustomerName.Text)).ToList();
            }
            if (cbCategory.SelectedIndex!=-1)
            {
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cbCategory.SelectedValue)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(txtProductPrice.Text))
            {
                if (rbPriceEqual.Checked)
                {
                    list = list.Where(x => x.Price == Convert.ToInt32(txtProductPrice.Text)).ToList();
                }
                else if (rbPriceMore.Checked)
                {
                    list = list.Where(x => x.Price > Convert.ToInt32(txtProductPrice.Text)).ToList();
                }
                else if (rbPriceLess.Checked)
                {
                    list = list.Where(x => x.Price < Convert.ToInt32(txtProductPrice.Text)).ToList();
                }
            }
            if (!string.IsNullOrWhiteSpace(txtSalesAmount.Text))
            {
                if (rbSaleEqual.Checked)
                {
                    list = list.Where(x => x.SalesAmount == Convert.ToInt32(txtSalesAmount.Text)).ToList();
                }
                else if (rbSaleMore.Checked)
                {
                    list = list.Where(x => x.SalesAmount > Convert.ToInt32(txtSalesAmount.Text)).ToList();
                }
                else if (rbSaleLess.Checked)
                {
                    list = list.Where(x => x.SalesAmount < Convert.ToInt32(txtSalesAmount.Text)).ToList();
                }
            }
            if (chDate.Checked)
            {
                list = list.Where(x => x.SalesDate >= dtpStartDate.Value && x.SalesDate <= dtpEndDate.Value).ToList();
            }

            dataGridView1.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanFilter();
        }

        private void CleanFilter()
        {
            txtProductPrice.Clear();
            txtCustomerName.Clear();
            txtProductName.Clear();
            txtSalesAmount.Clear();
            rbPriceEqual.Checked = false;
            rbPriceMore.Checked = false;
            rbPriceLess.Checked = false;
            rbSaleEqual.Checked = false;
            rbSaleLess.Checked = false;
            rbSaleMore.Checked = false;
            dtpEndDate.Value = DateTime.Today;
            dtpStartDate.Value = DateTime.Today;
            chDate.Checked = false;
            cbCategory.SelectedIndex = -1;

            dataGridView1.DataSource = dto.Sales;
        }
    }
}
