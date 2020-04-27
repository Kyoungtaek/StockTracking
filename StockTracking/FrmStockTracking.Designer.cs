namespace StockTracking
{
    partial class FrmStockTracking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnDeleted = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(12, 12);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(150, 150);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Location = new System.Drawing.Point(168, 12);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(150, 150);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.Text = "Product";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnSales
            // 
            this.btnSales.Location = new System.Drawing.Point(324, 12);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(150, 150);
            this.btnSales.TabIndex = 2;
            this.btnSales.Text = "Sales";
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnAddStock
            // 
            this.btnAddStock.Location = new System.Drawing.Point(12, 168);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(150, 150);
            this.btnAddStock.TabIndex = 3;
            this.btnAddStock.Text = "Add Stock";
            this.btnAddStock.UseVisualStyleBackColor = true;
            this.btnAddStock.Click += new System.EventHandler(this.btnAddStock_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.Location = new System.Drawing.Point(168, 168);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(150, 150);
            this.btnCategory.TabIndex = 4;
            this.btnCategory.Text = "Category";
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnDeleted
            // 
            this.btnDeleted.Location = new System.Drawing.Point(324, 168);
            this.btnDeleted.Name = "btnDeleted";
            this.btnDeleted.Size = new System.Drawing.Size(150, 150);
            this.btnDeleted.TabIndex = 5;
            this.btnDeleted.Text = "Deleted";
            this.btnDeleted.UseVisualStyleBackColor = true;
            this.btnDeleted.Click += new System.EventHandler(this.btnDeleted_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(168, 324);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 150);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmStockTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 483);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDeleted);
            this.Controls.Add(this.btnCategory);
            this.Controls.Add(this.btnAddStock);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnCustomer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmStockTracking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Tracking";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmStockTracking_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnDeleted;
        private System.Windows.Forms.Button btnExit;
    }
}