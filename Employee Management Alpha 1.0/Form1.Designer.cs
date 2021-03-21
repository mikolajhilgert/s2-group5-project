namespace Employee_Management_Alpha_1._0
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnCloseApp = new System.Windows.Forms.Button();
            this.panelStatisticsSubmenu = new System.Windows.Forms.Panel();
            this.btnViewStats = new System.Windows.Forms.Button();
            this.btnStats = new System.Windows.Forms.Button();
            this.panelDepSubmenu = new System.Windows.Forms.Panel();
            this.btnEditDep = new System.Windows.Forms.Button();
            this.btnAssignEmpToDep = new System.Windows.Forms.Button();
            this.btnAddDep = new System.Windows.Forms.Button();
            this.btnDepMan = new System.Windows.Forms.Button();
            this.panelStockSubmenu = new System.Windows.Forms.Panel();
            this.btnDepoInfo = new System.Windows.Forms.Button();
            this.btnDepoRequests = new System.Windows.Forms.Button();
            this.btnStockRequests = new System.Windows.Forms.Button();
            this.btnBuyStock = new System.Windows.Forms.Button();
            this.btnStockInfo = new System.Windows.Forms.Button();
            this.btnRemoveStock = new System.Windows.Forms.Button();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.btnStockMan = new System.Windows.Forms.Button();
            this.panelEmpSubmenu = new System.Windows.Forms.Panel();
            this.btnShitManager = new System.Windows.Forms.Button();
            this.btnEmpStatus = new System.Windows.Forms.Button();
            this.btnEmpInfo = new System.Windows.Forms.Button();
            this.btnRemoveEmp = new System.Windows.Forms.Button();
            this.btnAddEmp = new System.Windows.Forms.Button();
            this.btnEmpMan = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pbLogoText = new System.Windows.Forms.PictureBox();
            this.panelLiveFeed = new System.Windows.Forms.Panel();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.panelSideMenu.SuspendLayout();
            this.panelStatisticsSubmenu.SuspendLayout();
            this.panelDepSubmenu.SuspendLayout();
            this.panelStockSubmenu.SuspendLayout();
            this.panelEmpSubmenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoText)).BeginInit();
            this.panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panelSideMenu.Controls.Add(this.btnCloseApp);
            this.panelSideMenu.Controls.Add(this.panelStatisticsSubmenu);
            this.panelSideMenu.Controls.Add(this.btnStats);
            this.panelSideMenu.Controls.Add(this.panelDepSubmenu);
            this.panelSideMenu.Controls.Add(this.btnDepMan);
            this.panelSideMenu.Controls.Add(this.panelStockSubmenu);
            this.panelSideMenu.Controls.Add(this.btnStockMan);
            this.panelSideMenu.Controls.Add(this.panelEmpSubmenu);
            this.panelSideMenu.Controls.Add(this.btnEmpMan);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(188, 608);
            this.panelSideMenu.TabIndex = 0;
            // 
            // btnCloseApp
            // 
            this.btnCloseApp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCloseApp.FlatAppearance.BorderSize = 0;
            this.btnCloseApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCloseApp.ForeColor = System.Drawing.Color.Silver;
            this.btnCloseApp.Image = global::Employee_Management_Alpha_1._0.Properties.Resources.icons8_exit_48;
            this.btnCloseApp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseApp.Location = new System.Drawing.Point(0, 764);
            this.btnCloseApp.Margin = new System.Windows.Forms.Padding(2);
            this.btnCloseApp.Name = "btnCloseApp";
            this.btnCloseApp.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnCloseApp.Size = new System.Drawing.Size(171, 34);
            this.btnCloseApp.TabIndex = 2;
            this.btnCloseApp.Text = "Log out";
            this.btnCloseApp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseApp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCloseApp.UseVisualStyleBackColor = true;
            this.btnCloseApp.Click += new System.EventHandler(this.BtnCloseApp_Click);
            // 
            // panelStatisticsSubmenu
            // 
            this.panelStatisticsSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panelStatisticsSubmenu.Controls.Add(this.btnViewStats);
            this.panelStatisticsSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStatisticsSubmenu.Location = new System.Drawing.Point(0, 731);
            this.panelStatisticsSubmenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelStatisticsSubmenu.Name = "panelStatisticsSubmenu";
            this.panelStatisticsSubmenu.Size = new System.Drawing.Size(171, 33);
            this.panelStatisticsSubmenu.TabIndex = 8;
            this.panelStatisticsSubmenu.Visible = false;
            // 
            // btnViewStats
            // 
            this.btnViewStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewStats.FlatAppearance.BorderSize = 0;
            this.btnViewStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnViewStats.ForeColor = System.Drawing.Color.Silver;
            this.btnViewStats.Location = new System.Drawing.Point(0, 0);
            this.btnViewStats.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewStats.Name = "btnViewStats";
            this.btnViewStats.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnViewStats.Size = new System.Drawing.Size(171, 32);
            this.btnViewStats.TabIndex = 0;
            this.btnViewStats.Text = "View Statistics";
            this.btnViewStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewStats.UseVisualStyleBackColor = true;
            this.btnViewStats.Click += new System.EventHandler(this.BtnViewStats_Click);
            // 
            // btnStats
            // 
            this.btnStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStats.FlatAppearance.BorderSize = 0;
            this.btnStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStats.ForeColor = System.Drawing.Color.Silver;
            this.btnStats.Image = global::Employee_Management_Alpha_1._0.Properties.Resources.icons8_pie_chart_report_50;
            this.btnStats.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStats.Location = new System.Drawing.Point(0, 694);
            this.btnStats.Margin = new System.Windows.Forms.Padding(2);
            this.btnStats.Name = "btnStats";
            this.btnStats.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnStats.Size = new System.Drawing.Size(171, 37);
            this.btnStats.TabIndex = 7;
            this.btnStats.Text = "Statistics";
            this.btnStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStats.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.BtnStats_Click);
            // 
            // panelDepSubmenu
            // 
            this.panelDepSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panelDepSubmenu.Controls.Add(this.btnEditDep);
            this.panelDepSubmenu.Controls.Add(this.btnAssignEmpToDep);
            this.panelDepSubmenu.Controls.Add(this.btnAddDep);
            this.panelDepSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDepSubmenu.Location = new System.Drawing.Point(0, 596);
            this.panelDepSubmenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelDepSubmenu.Name = "panelDepSubmenu";
            this.panelDepSubmenu.Size = new System.Drawing.Size(171, 98);
            this.panelDepSubmenu.TabIndex = 6;
            this.panelDepSubmenu.Visible = false;
            // 
            // btnEditDep
            // 
            this.btnEditDep.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditDep.FlatAppearance.BorderSize = 0;
            this.btnEditDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEditDep.ForeColor = System.Drawing.Color.Silver;
            this.btnEditDep.Location = new System.Drawing.Point(0, 61);
            this.btnEditDep.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditDep.Name = "btnEditDep";
            this.btnEditDep.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnEditDep.Size = new System.Drawing.Size(171, 33);
            this.btnEditDep.TabIndex = 2;
            this.btnEditDep.Text = "Edit Department";
            this.btnEditDep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditDep.UseVisualStyleBackColor = true;
            this.btnEditDep.Click += new System.EventHandler(this.BtnEditDep_Click);
            // 
            // btnAssignEmpToDep
            // 
            this.btnAssignEmpToDep.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAssignEmpToDep.FlatAppearance.BorderSize = 0;
            this.btnAssignEmpToDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignEmpToDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAssignEmpToDep.ForeColor = System.Drawing.Color.Silver;
            this.btnAssignEmpToDep.Location = new System.Drawing.Point(0, 28);
            this.btnAssignEmpToDep.Margin = new System.Windows.Forms.Padding(2);
            this.btnAssignEmpToDep.Name = "btnAssignEmpToDep";
            this.btnAssignEmpToDep.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnAssignEmpToDep.Size = new System.Drawing.Size(171, 33);
            this.btnAssignEmpToDep.TabIndex = 1;
            this.btnAssignEmpToDep.Text = "Assign employees";
            this.btnAssignEmpToDep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssignEmpToDep.UseVisualStyleBackColor = true;
            this.btnAssignEmpToDep.Click += new System.EventHandler(this.BtnAssignEmpToDep_Click);
            // 
            // btnAddDep
            // 
            this.btnAddDep.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddDep.FlatAppearance.BorderSize = 0;
            this.btnAddDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddDep.ForeColor = System.Drawing.Color.Silver;
            this.btnAddDep.Location = new System.Drawing.Point(0, 0);
            this.btnAddDep.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddDep.Name = "btnAddDep";
            this.btnAddDep.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnAddDep.Size = new System.Drawing.Size(171, 28);
            this.btnAddDep.TabIndex = 0;
            this.btnAddDep.Text = "Add department";
            this.btnAddDep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddDep.UseVisualStyleBackColor = true;
            this.btnAddDep.Click += new System.EventHandler(this.BtnAddDep_Click);
            // 
            // btnDepMan
            // 
            this.btnDepMan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDepMan.FlatAppearance.BorderSize = 0;
            this.btnDepMan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepMan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDepMan.ForeColor = System.Drawing.Color.Silver;
            this.btnDepMan.Image = global::Employee_Management_Alpha_1._0.Properties.Resources.icons8_unit_50;
            this.btnDepMan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepMan.Location = new System.Drawing.Point(0, 559);
            this.btnDepMan.Margin = new System.Windows.Forms.Padding(2);
            this.btnDepMan.Name = "btnDepMan";
            this.btnDepMan.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnDepMan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDepMan.Size = new System.Drawing.Size(171, 37);
            this.btnDepMan.TabIndex = 5;
            this.btnDepMan.Text = "Departments";
            this.btnDepMan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepMan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDepMan.UseVisualStyleBackColor = true;
            this.btnDepMan.Click += new System.EventHandler(this.BtnDepMan_Click);
            // 
            // panelStockSubmenu
            // 
            this.panelStockSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panelStockSubmenu.Controls.Add(this.btnDepoInfo);
            this.panelStockSubmenu.Controls.Add(this.btnDepoRequests);
            this.panelStockSubmenu.Controls.Add(this.btnStockRequests);
            this.panelStockSubmenu.Controls.Add(this.btnBuyStock);
            this.panelStockSubmenu.Controls.Add(this.btnStockInfo);
            this.panelStockSubmenu.Controls.Add(this.btnRemoveStock);
            this.panelStockSubmenu.Controls.Add(this.btnAddStock);
            this.panelStockSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStockSubmenu.Location = new System.Drawing.Point(0, 321);
            this.panelStockSubmenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelStockSubmenu.Name = "panelStockSubmenu";
            this.panelStockSubmenu.Size = new System.Drawing.Size(171, 238);
            this.panelStockSubmenu.TabIndex = 4;
            this.panelStockSubmenu.Visible = false;
            // 
            // btnDepoInfo
            // 
            this.btnDepoInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDepoInfo.FlatAppearance.BorderSize = 0;
            this.btnDepoInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepoInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDepoInfo.ForeColor = System.Drawing.Color.Silver;
            this.btnDepoInfo.Location = new System.Drawing.Point(0, 199);
            this.btnDepoInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnDepoInfo.Name = "btnDepoInfo";
            this.btnDepoInfo.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnDepoInfo.Size = new System.Drawing.Size(171, 34);
            this.btnDepoInfo.TabIndex = 6;
            this.btnDepoInfo.Text = "Depo info";
            this.btnDepoInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepoInfo.UseVisualStyleBackColor = true;
            this.btnDepoInfo.Click += new System.EventHandler(this.BtnDepoInfo_Click);
            // 
            // btnDepoRequests
            // 
            this.btnDepoRequests.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDepoRequests.FlatAppearance.BorderSize = 0;
            this.btnDepoRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepoRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDepoRequests.ForeColor = System.Drawing.Color.Silver;
            this.btnDepoRequests.Location = new System.Drawing.Point(0, 165);
            this.btnDepoRequests.Margin = new System.Windows.Forms.Padding(2);
            this.btnDepoRequests.Name = "btnDepoRequests";
            this.btnDepoRequests.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnDepoRequests.Size = new System.Drawing.Size(171, 34);
            this.btnDepoRequests.TabIndex = 5;
            this.btnDepoRequests.Text = "Depo Requests";
            this.btnDepoRequests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepoRequests.UseVisualStyleBackColor = true;
            this.btnDepoRequests.Click += new System.EventHandler(this.BtnDepoRequests_Click_1);
            // 
            // btnStockRequests
            // 
            this.btnStockRequests.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockRequests.FlatAppearance.BorderSize = 0;
            this.btnStockRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStockRequests.ForeColor = System.Drawing.Color.Silver;
            this.btnStockRequests.Location = new System.Drawing.Point(0, 131);
            this.btnStockRequests.Margin = new System.Windows.Forms.Padding(2);
            this.btnStockRequests.Name = "btnStockRequests";
            this.btnStockRequests.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnStockRequests.Size = new System.Drawing.Size(171, 34);
            this.btnStockRequests.TabIndex = 4;
            this.btnStockRequests.Text = "Stock Requests";
            this.btnStockRequests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockRequests.UseVisualStyleBackColor = true;
            this.btnStockRequests.Click += new System.EventHandler(this.BtnStockRequests_Click);
            // 
            // btnBuyStock
            // 
            this.btnBuyStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBuyStock.FlatAppearance.BorderSize = 0;
            this.btnBuyStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuyStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBuyStock.ForeColor = System.Drawing.Color.Silver;
            this.btnBuyStock.Location = new System.Drawing.Point(0, 97);
            this.btnBuyStock.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuyStock.Name = "btnBuyStock";
            this.btnBuyStock.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnBuyStock.Size = new System.Drawing.Size(171, 34);
            this.btnBuyStock.TabIndex = 3;
            this.btnBuyStock.Text = "Buy stock";
            this.btnBuyStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuyStock.UseVisualStyleBackColor = true;
            this.btnBuyStock.Click += new System.EventHandler(this.BtnBuyStock_Click_1);
            // 
            // btnStockInfo
            // 
            this.btnStockInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockInfo.FlatAppearance.BorderSize = 0;
            this.btnStockInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStockInfo.ForeColor = System.Drawing.Color.Silver;
            this.btnStockInfo.Location = new System.Drawing.Point(0, 63);
            this.btnStockInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnStockInfo.Name = "btnStockInfo";
            this.btnStockInfo.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnStockInfo.Size = new System.Drawing.Size(171, 34);
            this.btnStockInfo.TabIndex = 2;
            this.btnStockInfo.Text = "Stock info";
            this.btnStockInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockInfo.UseVisualStyleBackColor = true;
            this.btnStockInfo.Click += new System.EventHandler(this.BtnStockInfo_Click_1);
            // 
            // btnRemoveStock
            // 
            this.btnRemoveStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRemoveStock.FlatAppearance.BorderSize = 0;
            this.btnRemoveStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRemoveStock.ForeColor = System.Drawing.Color.Silver;
            this.btnRemoveStock.Location = new System.Drawing.Point(0, 32);
            this.btnRemoveStock.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveStock.Name = "btnRemoveStock";
            this.btnRemoveStock.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnRemoveStock.Size = new System.Drawing.Size(171, 31);
            this.btnRemoveStock.TabIndex = 1;
            this.btnRemoveStock.Text = "Remove stock";
            this.btnRemoveStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveStock.UseVisualStyleBackColor = true;
            this.btnRemoveStock.Click += new System.EventHandler(this.BtnRemoveStock_Click_1);
            // 
            // btnAddStock
            // 
            this.btnAddStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddStock.FlatAppearance.BorderSize = 0;
            this.btnAddStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddStock.ForeColor = System.Drawing.Color.Silver;
            this.btnAddStock.Location = new System.Drawing.Point(0, 0);
            this.btnAddStock.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnAddStock.Size = new System.Drawing.Size(171, 32);
            this.btnAddStock.TabIndex = 0;
            this.btnAddStock.Text = "Add stock";
            this.btnAddStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddStock.UseVisualStyleBackColor = true;
            this.btnAddStock.Click += new System.EventHandler(this.BtnModStock_Click);
            // 
            // btnStockMan
            // 
            this.btnStockMan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockMan.FlatAppearance.BorderSize = 0;
            this.btnStockMan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockMan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStockMan.ForeColor = System.Drawing.Color.Silver;
            this.btnStockMan.Image = global::Employee_Management_Alpha_1._0.Properties.Resources.icons8_new_product_50;
            this.btnStockMan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockMan.Location = new System.Drawing.Point(0, 284);
            this.btnStockMan.Margin = new System.Windows.Forms.Padding(2);
            this.btnStockMan.Name = "btnStockMan";
            this.btnStockMan.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnStockMan.Size = new System.Drawing.Size(171, 37);
            this.btnStockMan.TabIndex = 3;
            this.btnStockMan.Text = "Stock";
            this.btnStockMan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockMan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStockMan.UseVisualStyleBackColor = true;
            this.btnStockMan.Click += new System.EventHandler(this.BtnStockMan_Click);
            // 
            // panelEmpSubmenu
            // 
            this.panelEmpSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panelEmpSubmenu.Controls.Add(this.btnShitManager);
            this.panelEmpSubmenu.Controls.Add(this.btnEmpStatus);
            this.panelEmpSubmenu.Controls.Add(this.btnEmpInfo);
            this.panelEmpSubmenu.Controls.Add(this.btnRemoveEmp);
            this.panelEmpSubmenu.Controls.Add(this.btnAddEmp);
            this.panelEmpSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEmpSubmenu.Location = new System.Drawing.Point(0, 118);
            this.panelEmpSubmenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelEmpSubmenu.Name = "panelEmpSubmenu";
            this.panelEmpSubmenu.Size = new System.Drawing.Size(171, 166);
            this.panelEmpSubmenu.TabIndex = 2;
            this.panelEmpSubmenu.Visible = false;
            // 
            // btnShitManager
            // 
            this.btnShitManager.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShitManager.FlatAppearance.BorderSize = 0;
            this.btnShitManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShitManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnShitManager.ForeColor = System.Drawing.Color.Silver;
            this.btnShitManager.Location = new System.Drawing.Point(0, 128);
            this.btnShitManager.Margin = new System.Windows.Forms.Padding(2);
            this.btnShitManager.Name = "btnShitManager";
            this.btnShitManager.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnShitManager.Size = new System.Drawing.Size(171, 32);
            this.btnShitManager.TabIndex = 5;
            this.btnShitManager.Text = "Shift manager";
            this.btnShitManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShitManager.UseVisualStyleBackColor = true;
            this.btnShitManager.Click += new System.EventHandler(this.btnShitManager_Click);
            // 
            // btnEmpStatus
            // 
            this.btnEmpStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmpStatus.FlatAppearance.BorderSize = 0;
            this.btnEmpStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEmpStatus.ForeColor = System.Drawing.Color.Silver;
            this.btnEmpStatus.Location = new System.Drawing.Point(0, 96);
            this.btnEmpStatus.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmpStatus.Name = "btnEmpStatus";
            this.btnEmpStatus.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnEmpStatus.Size = new System.Drawing.Size(171, 32);
            this.btnEmpStatus.TabIndex = 4;
            this.btnEmpStatus.Text = "Employee status";
            this.btnEmpStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpStatus.UseVisualStyleBackColor = true;
            this.btnEmpStatus.Click += new System.EventHandler(this.BtnEmpStatus_Click);
            // 
            // btnEmpInfo
            // 
            this.btnEmpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmpInfo.FlatAppearance.BorderSize = 0;
            this.btnEmpInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEmpInfo.ForeColor = System.Drawing.Color.Silver;
            this.btnEmpInfo.Location = new System.Drawing.Point(0, 64);
            this.btnEmpInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmpInfo.Name = "btnEmpInfo";
            this.btnEmpInfo.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnEmpInfo.Size = new System.Drawing.Size(171, 32);
            this.btnEmpInfo.TabIndex = 3;
            this.btnEmpInfo.Text = "Employee info";
            this.btnEmpInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpInfo.UseVisualStyleBackColor = true;
            this.btnEmpInfo.Click += new System.EventHandler(this.BtnEmpInfo_Click);
            // 
            // btnRemoveEmp
            // 
            this.btnRemoveEmp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRemoveEmp.FlatAppearance.BorderSize = 0;
            this.btnRemoveEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRemoveEmp.ForeColor = System.Drawing.Color.Silver;
            this.btnRemoveEmp.Location = new System.Drawing.Point(0, 32);
            this.btnRemoveEmp.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveEmp.Name = "btnRemoveEmp";
            this.btnRemoveEmp.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnRemoveEmp.Size = new System.Drawing.Size(171, 32);
            this.btnRemoveEmp.TabIndex = 2;
            this.btnRemoveEmp.Text = "Remove employee";
            this.btnRemoveEmp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveEmp.UseVisualStyleBackColor = true;
            this.btnRemoveEmp.Click += new System.EventHandler(this.BtnRemoveEmp_Click);
            // 
            // btnAddEmp
            // 
            this.btnAddEmp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddEmp.FlatAppearance.BorderSize = 0;
            this.btnAddEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddEmp.ForeColor = System.Drawing.Color.Silver;
            this.btnAddEmp.Location = new System.Drawing.Point(0, 0);
            this.btnAddEmp.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddEmp.Name = "btnAddEmp";
            this.btnAddEmp.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnAddEmp.Size = new System.Drawing.Size(171, 32);
            this.btnAddEmp.TabIndex = 1;
            this.btnAddEmp.Text = "Add employee";
            this.btnAddEmp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddEmp.UseVisualStyleBackColor = true;
            this.btnAddEmp.Click += new System.EventHandler(this.BtnModEmp_Click);
            // 
            // btnEmpMan
            // 
            this.btnEmpMan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmpMan.FlatAppearance.BorderSize = 0;
            this.btnEmpMan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpMan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEmpMan.ForeColor = System.Drawing.Color.Silver;
            this.btnEmpMan.Image = global::Employee_Management_Alpha_1._0.Properties.Resources.icons8_crowd_501;
            this.btnEmpMan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpMan.Location = new System.Drawing.Point(0, 81);
            this.btnEmpMan.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmpMan.Name = "btnEmpMan";
            this.btnEmpMan.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnEmpMan.Size = new System.Drawing.Size(171, 37);
            this.btnEmpMan.TabIndex = 1;
            this.btnEmpMan.Text = "Employees";
            this.btnEmpMan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpMan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmpMan.UseVisualStyleBackColor = true;
            this.btnEmpMan.Click += new System.EventHandler(this.BtnEmpMan_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pbLogoText);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(2);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(171, 81);
            this.panelLogo.TabIndex = 1;
            // 
            // pbLogoText
            // 
            this.pbLogoText.Image = global::Employee_Management_Alpha_1._0.Properties.Resources.Névtelen_1;
            this.pbLogoText.Location = new System.Drawing.Point(9, 9);
            this.pbLogoText.Margin = new System.Windows.Forms.Padding(2);
            this.pbLogoText.Name = "pbLogoText";
            this.pbLogoText.Size = new System.Drawing.Size(165, 67);
            this.pbLogoText.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogoText.TabIndex = 1;
            this.pbLogoText.TabStop = false;
            // 
            // panelLiveFeed
            // 
            this.panelLiveFeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panelLiveFeed.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLiveFeed.Location = new System.Drawing.Point(188, 498);
            this.panelLiveFeed.Margin = new System.Windows.Forms.Padding(2);
            this.panelLiveFeed.Name = "panelLiveFeed";
            this.panelLiveFeed.Size = new System.Drawing.Size(618, 110);
            this.panelLiveFeed.TabIndex = 1;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panelChildForm.Controls.Add(this.pbLogo);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(188, 0);
            this.panelChildForm.Margin = new System.Windows.Forms.Padding(2);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(618, 498);
            this.panelChildForm.TabIndex = 0;
            this.panelChildForm.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelChildForm_Paint);
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbLogo.Image = global::Employee_Management_Alpha_1._0.Properties.Resources.moneknotext1;
            this.pbLogo.Location = new System.Drawing.Point(219, 200);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(209, 164);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 608);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelLiveFeed);
            this.Controls.Add(this.panelSideMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(822, 547);
            this.Name = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.panelSideMenu.ResumeLayout(false);
            this.panelStatisticsSubmenu.ResumeLayout(false);
            this.panelDepSubmenu.ResumeLayout(false);
            this.panelStockSubmenu.ResumeLayout(false);
            this.panelEmpSubmenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoText)).EndInit();
            this.panelChildForm.ResumeLayout(false);
            this.panelChildForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelEmpSubmenu;
        private System.Windows.Forms.Button btnEmpInfo;
        private System.Windows.Forms.Button btnRemoveEmp;
        private System.Windows.Forms.Button btnAddEmp;
        private System.Windows.Forms.Button btnEmpMan;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Panel panelDepSubmenu;
        private System.Windows.Forms.Button btnAssignEmpToDep;
        private System.Windows.Forms.Button btnAddDep;
        private System.Windows.Forms.Button btnDepMan;
        private System.Windows.Forms.Panel panelStockSubmenu;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Button btnStockMan;
        private System.Windows.Forms.Panel panelStatisticsSubmenu;
        private System.Windows.Forms.Button btnViewStats;
        private System.Windows.Forms.Panel panelLiveFeed;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.PictureBox pbLogoText;
        private System.Windows.Forms.Button btnCloseApp;
        private System.Windows.Forms.Button btnEditDep;
        private System.Windows.Forms.Button btnRemoveStock;
        private System.Windows.Forms.Button btnEmpStatus;
        private System.Windows.Forms.Button btnShitManager;
        private System.Windows.Forms.Button btnStockInfo;
        private System.Windows.Forms.Button btnBuyStock;
        private System.Windows.Forms.Button btnStockRequests;
        private System.Windows.Forms.Button btnDepoInfo;
        private System.Windows.Forms.Button btnDepoRequests;
    }
}

