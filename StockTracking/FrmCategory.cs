using StockTracking.BLL;
using StockTracking.DAL.DTO;
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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        CategoryBLL bll = new CategoryBLL();
        private void FrmCategory_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Category name is emtpy");
            }
            else
            {
                var category = new CategoryDetailDTO();
                category.CategoryName = txtCategoryName.Text.Trim();

                if (bll.Insert(category))
                {
                    MessageBox.Show("Category is added");
                    txtCategoryName.Clear();
                }
            }
        }
    }
}
