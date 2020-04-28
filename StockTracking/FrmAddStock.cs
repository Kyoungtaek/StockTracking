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
    public partial class FrmAddStock : Form
    {
        private ProductBLL bll = new ProductBLL();
        private ProductDTO dto = new ProductDTO();
        private bool comboFull = false;
        private ProductDetailDTO detail = new ProductDetailDTO();

        public FrmAddStock()
        {
            InitializeComponent();
        }

        private void txtProductStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddStock_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Products;
            dataGridView1.Columns[0].HeaderText = "Product Name";
            dataGridView1.Columns[1].HeaderText = "Category Name";
            dataGridView1.Columns[2].HeaderText = "Stock Amount";
            dataGridView1.Columns[3].HeaderText = "Price";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;

            cbCategory.DataSource = dto.Categories;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "ID";
            cbCategory.SelectedIndex = -1;

            if (dto.Categories.Count > 0)
            {
                comboFull = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please select a product from table");
            }
            else if (string.IsNullOrWhiteSpace(txtProductStock.Text))
            {
                MessageBox.Show("Please give a stock amount");
            }
            else
            {
                int sumStock = detail.StockAmount;
                sumStock += Convert.ToInt32(txtProductStock.Text);
                detail.StockAmount = sumStock;

                if (bll.Update(detail))
                {
                    MessageBox.Show("Stock was added");
                    bll = new ProductBLL();
                    dto = bll.Select();
                    dataGridView1.DataSource = dto.Products;
                    txtProductStock.Clear();
                }
            }
        }
        
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                List<ProductDetailDTO> list = dto.Products;
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cbCategory.SelectedValue)).ToList();
                dataGridView1.DataSource = list;

                if (list.Count == 0)
                {
                    txtPrice.Clear();
                    txtProductName.Clear();
                    txtProductStock.Clear();
                }
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProductName.Text = detail.ProductName;
            detail.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            txtPrice.Text = detail.Price.ToString();
            detail.StockAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            detail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
        }
    }
}
