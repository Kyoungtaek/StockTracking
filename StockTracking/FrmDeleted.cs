﻿using System;
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
    public partial class FrmDeleted : Form
    {
        public FrmDeleted()
        {
            InitializeComponent();
        }

        private void FrmDeleted_Load(object sender, EventArgs e)
        {
            cbDeletedData.Items.Add("Category");
            cbDeletedData.Items.Add("Product");
            cbDeletedData.Items.Add("Customer");
            cbDeletedData.Items.Add("Sales");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
