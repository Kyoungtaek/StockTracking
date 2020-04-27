using StockTracking.BLL;
using StockTracking.DAL.DTO;
using System;
using System.Windows.Forms;

namespace StockTracking
{
    public partial class FrmCustomer : Form
    {
        private CustomerBLL bll = new CustomerBLL();
        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Customer name is empty");
            }
            else
            {
                var customer = new CustomerDetailDTO();
                customer.CsutomerName = txtCustomerName.Text.Trim();

                if (bll.Insert(customer))
                {
                    MessageBox.Show("Customer was added");
                    txtCustomerName.Clear();
                }
            }
        }
    }
}
