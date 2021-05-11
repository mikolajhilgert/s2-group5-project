
namespace Employee_Management_Alpha_1._0
{
    partial class ViewDepo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgDepo = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Request = new System.Windows.Forms.DataGridViewButtonColumn();
            this.nRestockAmount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDepo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRestockAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDepo
            // 
            this.dgDepo.AllowUserToAddRows = false;
            this.dgDepo.AllowUserToDeleteRows = false;
            this.dgDepo.AllowUserToResizeColumns = false;
            this.dgDepo.AllowUserToResizeRows = false;
            this.dgDepo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDepo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ProductName,
            this.Price,
            this.Stock,
            this.Category,
            this.Request});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDepo.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgDepo.Location = new System.Drawing.Point(6, 82);
            this.dgDepo.MultiSelect = false;
            this.dgDepo.Name = "dgDepo";
            this.dgDepo.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDepo.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgDepo.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Transparent;
            this.dgDepo.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgDepo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgDepo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgDepo.Size = new System.Drawing.Size(604, 303);
            this.dgDepo.TabIndex = 70;
            this.dgDepo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStore_CellContentClick);
            this.dgDepo.SelectionChanged += new System.EventHandler(this.dgStore_SelectionChanged);
            // 
            // ID
            // 
            this.ID.HeaderText = "ProductID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price Per Item";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Depo Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // Request
            // 
            this.Request.HeaderText = "Request Stock";
            this.Request.Name = "Request";
            this.Request.ReadOnly = true;
            this.Request.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Request.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Request.Text = "Make Request";
            // 
            // nRestockAmount
            // 
            this.nRestockAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nRestockAmount.Location = new System.Drawing.Point(542, 48);
            this.nRestockAmount.Name = "nRestockAmount";
            this.nRestockAmount.Size = new System.Drawing.Size(68, 26);
            this.nRestockAmount.TabIndex = 69;
            this.nRestockAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 73;
            this.label2.Text = "Depo Overview:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(406, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 18);
            this.label1.TabIndex = 71;
            this.label1.Text = "Request quantity:";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Employee_Management_Alpha_1._0.Properties.Resources.icons8_back_24;
            this.btnClose.Location = new System.Drawing.Point(11, 11);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 27);
            this.btnClose.TabIndex = 72;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ViewDepo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(616, 396);
            this.Controls.Add(this.dgDepo);
            this.Controls.Add(this.nRestockAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Name = "ViewDepo";
            this.Text = "ViewDepo";
            ((System.ComponentModel.ISupportInitialize)(this.dgDepo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRestockAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDepo;
        private System.Windows.Forms.NumericUpDown nRestockAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewButtonColumn Request;
    }
}