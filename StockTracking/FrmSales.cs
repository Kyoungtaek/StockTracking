﻿using StockTracking.BLL;
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
    public partial class FrmSales : Form
    {
        public SalesDTO dto = new SalesDTO();
        private bool comboFull = false;
        private SalesDetailDTO detail = new SalesDetailDTO();
        private SalesBLL bll = new SalesBLL();

        public FrmSales()
        {
            InitializeComponent();
        }

        private void txtProductSalesAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSales_Load(object sender, EventArgs e)
        {
            cbCategory.DataSource = dto.Categories;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "ID";
            cbCategory.SelectedIndex = -1;

            gridProduct.DataSource = dto.Products;
            gridProduct.Columns[0].HeaderText = "Product Name";
            gridProduct.Columns[1].HeaderText = "Category Name";
            gridProduct.Columns[2].HeaderText = "Stock Amount";
            gridProduct.Columns[3].HeaderText = "Price";
            gridProduct.Columns[4].Visible = false;
            gridProduct.Columns[5].Visible = false;

            gridCustomer.DataSource = dto.Customers;
            gridCustomer.Columns[0].Visible = false;
            gridCustomer.Columns[1].HeaderText = "Customer Name";

            if (dto.Categories.Count > 0)
            {
                comboFull = true;
            }
        }


        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                List<ProductDetailDTO> list = dto.Products;
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cbCategory.SelectedValue)).ToList();
                gridProduct.DataSource = list;

                if (list.Count == 0)
                {
                    txtPrice.Clear();
                    txtProductName.Clear();
                    txtProductStock.Clear();
                }
            }
        }

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            List<CustomerDetailDTO> list = dto.Customers;
            list = list.Where(x => x.CsutomerName.Contains(txtCustomer.Text)).ToList();
            gridCustomer.DataSource = list;

            if (list.Count == 0)
            {
                txtCustomerName.Clear();
            }
        }

        private void gridProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ProductName = gridProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.Price = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[3].Value);
            detail.StockAmount = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[2].Value);
            detail.ProductID = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[4].Value);
            detail.CategoryID = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[5].Value);

            txtProductName.Text = detail.ProductName;
            txtPrice.Text = detail.Price.ToString();
            txtProductStock.Text = detail.StockAmount.ToString();
        }

        private void gridCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.CustomerName = gridCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            detail.CustomerID = Convert.ToInt32(gridCustomer.Rows[e.RowIndex].Cells[0].Value);
            txtCustomerName.Text = detail.CustomerName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (detail.ProductID == 0)
            {
                MessageBox.Show("Please select a product from product table");
            }
            else if (detail.CustomerID == 0)
            {
                MessageBox.Show("Please select a customer");
            }
            else if (detail.StockAmount < Convert.ToInt32(txtProductSalesAmount.Text))
            {
                MessageBox.Show("You have not enough product for sale");
            }
            else
            {
                detail.SalesAmount = Convert.ToInt32(txtProductSalesAmount.Text);
                detail.SalesDate = DateTime.Today;

                if (bll.Insert(detail))
                {
                    MessageBox.Show("Sales was Added");
                    bll = new SalesBLL();
                    dto = bll.Select();
                    gridProduct.DataSource = dto.Products;
                    gridCustomer.DataSource = dto.Customers;
                    comboFull = false;
                    cbCategory.DataSource = dto.Categories;
                    if (dto.Products.Count > 0)
                    {
                        comboFull = true;
                    }
                    txtProductSalesAmount.Clear();
                }
            }
        }
    }
}
