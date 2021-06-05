
namespace Employee_Management_Alpha_1._0
{
    partial class ViewStatistics
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
            this.empList = new System.Windows.Forms.ListBox();
            this.labelTotalShift = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTotalHours = new System.Windows.Forms.Label();
            this.labelActiveE = new System.Windows.Forms.Label();
            this.labelTotalDaysWorked = new System.Windows.Forms.Label();
            this.labelTotalPayment = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabsStatistics = new System.Windows.Forms.TabControl();
            this.tabEmployees = new System.Windows.Forms.TabPage();
            this.tabDepartments = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.lblActiveDeps = new System.Windows.Forms.Label();
            this.lbDepartments = new System.Windows.Forms.ListBox();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.lblEmployeeCount = new System.Windows.Forms.Label();
            this.lblDepartmentProfit = new System.Windows.Forms.Label();
            this.lblProductCount = new System.Windows.Forms.Label();
            this.lblDepartmentHead = new System.Windows.Forms.Label();
            this.lbProducts = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblActiveProducts = new System.Windows.Forms.Label();
            this.lblAmountSold = new System.Windows.Forms.Label();
            this.lblProductProfit = new System.Windows.Forms.Label();
            this.tabsStatistics.SuspendLayout();
            this.tabEmployees.SuspendLayout();
            this.tabDepartments.SuspendLayout();
            this.tabProducts.SuspendLayout();
            this.SuspendLayout();
            // 
            // empList
            // 
            this.empList.FormattingEnabled = true;
            this.empList.Location = new System.Drawing.Point(6, 39);
            this.empList.Name = "empList";
            this.empList.Size = new System.Drawing.Size(187, 277);
            this.empList.TabIndex = 0;
            this.empList.SelectedIndexChanged += new System.EventHandler(this.empList_SelectedIndexChanged);
            // 
            // labelTotalShift
            // 
            this.labelTotalShift.AutoSize = true;
            this.labelTotalShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalShift.ForeColor = System.Drawing.Color.White;
            this.labelTotalShift.Location = new System.Drawing.Point(199, 39);
            this.labelTotalShift.Name = "labelTotalShift";
            this.labelTotalShift.Size = new System.Drawing.Size(355, 18);
            this.labelTotalShift.TabIndex = 1;
            this.labelTotalShift.Text = "This employee has been scheduled a total of 0 shifts.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select an employee below to view their statistics:";
            // 
            // labelTotalHours
            // 
            this.labelTotalHours.AutoSize = true;
            this.labelTotalHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalHours.ForeColor = System.Drawing.Color.White;
            this.labelTotalHours.Location = new System.Drawing.Point(199, 83);
            this.labelTotalHours.Name = "labelTotalHours";
            this.labelTotalHours.Size = new System.Drawing.Size(384, 18);
            this.labelTotalHours.TabIndex = 1;
            this.labelTotalHours.Text = "This employee has had 0 shifts (0 hours), including today.";
            // 
            // labelActiveE
            // 
            this.labelActiveE.AutoSize = true;
            this.labelActiveE.ForeColor = System.Drawing.Color.Red;
            this.labelActiveE.Location = new System.Drawing.Point(3, 6);
            this.labelActiveE.Name = "labelActiveE";
            this.labelActiveE.Size = new System.Drawing.Size(165, 13);
            this.labelActiveE.TabIndex = 3;
            this.labelActiveE.Text = "There are {null} active employees";
            // 
            // labelTotalDaysWorked
            // 
            this.labelTotalDaysWorked.AutoSize = true;
            this.labelTotalDaysWorked.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalDaysWorked.ForeColor = System.Drawing.Color.White;
            this.labelTotalDaysWorked.Location = new System.Drawing.Point(199, 127);
            this.labelTotalDaysWorked.Name = "labelTotalDaysWorked";
            this.labelTotalDaysWorked.Size = new System.Drawing.Size(346, 18);
            this.labelTotalDaysWorked.TabIndex = 4;
            this.labelTotalDaysWorked.Text = "This employee has been at the company for 0 days.";
            // 
            // labelTotalPayment
            // 
            this.labelTotalPayment.AutoSize = true;
            this.labelTotalPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPayment.ForeColor = System.Drawing.Color.White;
            this.labelTotalPayment.Location = new System.Drawing.Point(199, 171);
            this.labelTotalPayment.Name = "labelTotalPayment";
            this.labelTotalPayment.Size = new System.Drawing.Size(238, 18);
            this.labelTotalPayment.TabIndex = 5;
            this.labelTotalPayment.Text = "Total payment to employee: 0 Euro";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Employee_Management_Alpha_1._0.Properties.Resources.icons8_back_24;
            this.btnClose.Location = new System.Drawing.Point(11, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 27);
            this.btnClose.TabIndex = 68;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabsStatistics
            // 
            this.tabsStatistics.Controls.Add(this.tabEmployees);
            this.tabsStatistics.Controls.Add(this.tabDepartments);
            this.tabsStatistics.Controls.Add(this.tabProducts);
            this.tabsStatistics.Location = new System.Drawing.Point(11, 36);
            this.tabsStatistics.Name = "tabsStatistics";
            this.tabsStatistics.SelectedIndex = 0;
            this.tabsStatistics.Size = new System.Drawing.Size(603, 348);
            this.tabsStatistics.TabIndex = 69;
            // 
            // tabEmployees
            // 
            this.tabEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tabEmployees.Controls.Add(this.empList);
            this.tabEmployees.Controls.Add(this.labelTotalShift);
            this.tabEmployees.Controls.Add(this.label1);
            this.tabEmployees.Controls.Add(this.labelTotalDaysWorked);
            this.tabEmployees.Controls.Add(this.labelTotalPayment);
            this.tabEmployees.Controls.Add(this.labelActiveE);
            this.tabEmployees.Controls.Add(this.labelTotalHours);
            this.tabEmployees.Location = new System.Drawing.Point(4, 22);
            this.tabEmployees.Name = "tabEmployees";
            this.tabEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmployees.Size = new System.Drawing.Size(595, 322);
            this.tabEmployees.TabIndex = 0;
            this.tabEmployees.Text = "Employees";
            // 
            // tabDepartments
            // 
            this.tabDepartments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tabDepartments.Controls.Add(this.lblDepartmentHead);
            this.tabDepartments.Controls.Add(this.lblProductCount);
            this.tabDepartments.Controls.Add(this.lblDepartmentProfit);
            this.tabDepartments.Controls.Add(this.lblEmployeeCount);
            this.tabDepartments.Controls.Add(this.label2);
            this.tabDepartments.Controls.Add(this.lblActiveDeps);
            this.tabDepartments.Controls.Add(this.lbDepartments);
            this.tabDepartments.Location = new System.Drawing.Point(4, 22);
            this.tabDepartments.Name = "tabDepartments";
            this.tabDepartments.Padding = new System.Windows.Forms.Padding(3);
            this.tabDepartments.Size = new System.Drawing.Size(595, 322);
            this.tabDepartments.TabIndex = 1;
            this.tabDepartments.Text = "Departments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Select a department below to view their statistics:";
            // 
            // lblActiveDeps
            // 
            this.lblActiveDeps.AutoSize = true;
            this.lblActiveDeps.ForeColor = System.Drawing.Color.Red;
            this.lblActiveDeps.Location = new System.Drawing.Point(3, 6);
            this.lblActiveDeps.Name = "lblActiveDeps";
            this.lblActiveDeps.Size = new System.Drawing.Size(173, 13);
            this.lblActiveDeps.TabIndex = 71;
            this.lblActiveDeps.Text = "There are {null} active departments";
            // 
            // lbDepartments
            // 
            this.lbDepartments.FormattingEnabled = true;
            this.lbDepartments.Location = new System.Drawing.Point(6, 39);
            this.lbDepartments.Name = "lbDepartments";
            this.lbDepartments.Size = new System.Drawing.Size(187, 277);
            this.lbDepartments.TabIndex = 69;
            this.lbDepartments.SelectedIndexChanged += new System.EventHandler(this.lbDepartments_SelectedIndexChanged);
            // 
            // tabProducts
            // 
            this.tabProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tabProducts.Controls.Add(this.lblProductProfit);
            this.tabProducts.Controls.Add(this.lblAmountSold);
            this.tabProducts.Controls.Add(this.label3);
            this.tabProducts.Controls.Add(this.lblActiveProducts);
            this.tabProducts.Controls.Add(this.lbProducts);
            this.tabProducts.Location = new System.Drawing.Point(4, 22);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(595, 322);
            this.tabProducts.TabIndex = 2;
            this.tabProducts.Text = "Products";
            // 
            // lblEmployeeCount
            // 
            this.lblEmployeeCount.AutoSize = true;
            this.lblEmployeeCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeCount.ForeColor = System.Drawing.Color.White;
            this.lblEmployeeCount.Location = new System.Drawing.Point(199, 83);
            this.lblEmployeeCount.Name = "lblEmployeeCount";
            this.lblEmployeeCount.Size = new System.Drawing.Size(266, 18);
            this.lblEmployeeCount.TabIndex = 72;
            this.lblEmployeeCount.Text = "This department contains 0 employees.";
            // 
            // lblDepartmentProfit
            // 
            this.lblDepartmentProfit.AutoSize = true;
            this.lblDepartmentProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartmentProfit.ForeColor = System.Drawing.Color.White;
            this.lblDepartmentProfit.Location = new System.Drawing.Point(199, 171);
            this.lblDepartmentProfit.Name = "lblDepartmentProfit";
            this.lblDepartmentProfit.Size = new System.Drawing.Size(291, 18);
            this.lblDepartmentProfit.TabIndex = 73;
            this.lblDepartmentProfit.Text = "This department has made 0€ in total profit.";
            // 
            // lblProductCount
            // 
            this.lblProductCount.AutoSize = true;
            this.lblProductCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCount.ForeColor = System.Drawing.Color.White;
            this.lblProductCount.Location = new System.Drawing.Point(199, 127);
            this.lblProductCount.Name = "lblProductCount";
            this.lblProductCount.Size = new System.Drawing.Size(252, 18);
            this.lblProductCount.TabIndex = 74;
            this.lblProductCount.Text = "This department contains 0 products.";
            // 
            // lblDepartmentHead
            // 
            this.lblDepartmentHead.AutoSize = true;
            this.lblDepartmentHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartmentHead.ForeColor = System.Drawing.Color.White;
            this.lblDepartmentHead.Location = new System.Drawing.Point(199, 39);
            this.lblDepartmentHead.Name = "lblDepartmentHead";
            this.lblDepartmentHead.Size = new System.Drawing.Size(206, 18);
            this.lblDepartmentHead.TabIndex = 75;
            this.lblDepartmentHead.Text = "This department\'s head is null.";
            // 
            // lbProducts
            // 
            this.lbProducts.FormattingEnabled = true;
            this.lbProducts.Location = new System.Drawing.Point(6, 39);
            this.lbProducts.Name = "lbProducts";
            this.lbProducts.Size = new System.Drawing.Size(187, 277);
            this.lbProducts.TabIndex = 70;
            this.lbProducts.SelectedIndexChanged += new System.EventHandler(this.lbProducts_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(2, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "Select a product below to view their statistics:";
            // 
            // lblActiveProducts
            // 
            this.lblActiveProducts.AutoSize = true;
            this.lblActiveProducts.ForeColor = System.Drawing.Color.Red;
            this.lblActiveProducts.Location = new System.Drawing.Point(3, 6);
            this.lblActiveProducts.Name = "lblActiveProducts";
            this.lblActiveProducts.Size = new System.Drawing.Size(161, 13);
            this.lblActiveProducts.TabIndex = 73;
            this.lblActiveProducts.Text = "There are {null} products for sale";
            // 
            // lblAmountSold
            // 
            this.lblAmountSold.AutoSize = true;
            this.lblAmountSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountSold.ForeColor = System.Drawing.Color.White;
            this.lblAmountSold.Location = new System.Drawing.Point(199, 39);
            this.lblAmountSold.Name = "lblAmountSold";
            this.lblAmountSold.Size = new System.Drawing.Size(242, 18);
            this.lblAmountSold.TabIndex = 76;
            this.lblAmountSold.Text = "This product has been sold 0 times.";
            // 
            // lblProductProfit
            // 
            this.lblProductProfit.AutoSize = true;
            this.lblProductProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductProfit.ForeColor = System.Drawing.Color.White;
            this.lblProductProfit.Location = new System.Drawing.Point(199, 83);
            this.lblProductProfit.Name = "lblProductProfit";
            this.lblProductProfit.Size = new System.Drawing.Size(281, 18);
            this.lblProductProfit.TabIndex = 77;
            this.lblProductProfit.Text = "This product has made a total profit of 0€.";
            // 
            // ViewStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(649, 396);
            this.Controls.Add(this.tabsStatistics);
            this.Controls.Add(this.btnClose);
            this.Name = "ViewStatistics";
            this.Text = "Scheduling";
            this.tabsStatistics.ResumeLayout(false);
            this.tabEmployees.ResumeLayout(false);
            this.tabEmployees.PerformLayout();
            this.tabDepartments.ResumeLayout(false);
            this.tabDepartments.PerformLayout();
            this.tabProducts.ResumeLayout(false);
            this.tabProducts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox empList;
        private System.Windows.Forms.Label labelTotalShift;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTotalHours;
        private System.Windows.Forms.Label labelActiveE;
        private System.Windows.Forms.Label labelTotalDaysWorked;
        private System.Windows.Forms.Label labelTotalPayment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabsStatistics;
        private System.Windows.Forms.TabPage tabEmployees;
        private System.Windows.Forms.TabPage tabDepartments;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblActiveDeps;
        private System.Windows.Forms.ListBox lbDepartments;
        private System.Windows.Forms.Label lblDepartmentHead;
        private System.Windows.Forms.Label lblProductCount;
        private System.Windows.Forms.Label lblDepartmentProfit;
        private System.Windows.Forms.Label lblEmployeeCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblActiveProducts;
        private System.Windows.Forms.ListBox lbProducts;
        private System.Windows.Forms.Label lblProductProfit;
        private System.Windows.Forms.Label lblAmountSold;
    }
}