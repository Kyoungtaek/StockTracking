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
        private CategoryBLL bll = new CategoryBLL();
        public CategoryDetailDTO detail = new CategoryDetailDTO();
        public bool isUpdate = false;

        public FrmCategory()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void FrmCategory_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                txtCategoryName.Text = detail.CategoryName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Category name is emtpy");
            }
            else
            {
                if (!isUpdate)
                {
                    var category = new CategoryDetailDTO();
                    category.CategoryName = txtCategoryName.Text.Trim();

                    if (bll.Insert(category))
                    {
                        MessageBox.Show("Category is added");
                        txtCategoryName.Clear();
                    }
                }
                else if (isUpdate)
                {
                    detail.CategoryName = txtCategoryName.Text;
                    if (bll.Update(detail))
                    {
                        MessageBox.Show("Updated");
                        this.Close();
                    }
                }
            }
        }
    }
}
