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
    public partial class FrmStockTracking : Form
    {
        public FrmStockTracking()
        {
            InitializeComponent();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            var frm = new FrmSalesLIst();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            var frm = new FrmProductList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            var frm = new FrmCustomerList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            var frm = new FrmAddStock();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            var frm = new FrmCategoryList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnDeleted_Click(object sender, EventArgs e)
        {
            var frm = new FrmDeleted();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmStockTracking_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
