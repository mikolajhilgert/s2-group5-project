using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_Alpha_1._0
{
    public partial class Form1 : Form
    {
        
        public static string loggedUser;
        
        public Form1()
        {
            InitializeComponent();
            
            loggedUser = LoginForm.userType;
            
            userAccess();

        }
        
        public void userAccess()
        {
            if (loggedUser == "Admin")
            {
                btnBuyStock.Visible = false;
                btnDepoRequests.Visible = false;

                panelStockSubmenu.Height = 115;
            }
            if(loggedUser == "Management")
            {
                btnDepMan.Visible = false;
                btnEmpMan.Visible = false;
                btnBuyStock.Visible = false;

                panelStockSubmenu.Height = 115;
            }
            if(loggedUser == "Stock worker")
            {
                btnDepMan.Visible = false;
                btnEmpMan.Visible = false;
                btnAddEditRemStock.Visible = false;
                btnBuyStock.Visible = false;
                btnStats.Visible = false;

                panelStockSubmenu.Height = 105;
            }
            if (loggedUser == "Cashier")
            {
                btnDepMan.Visible = false;
                btnEmpMan.Visible = false;
                btnAddEditRemStock.Visible = false;
                btnDepoRequests.Visible = false;
                btnStats.Visible = false;

                panelStockSubmenu.Height = 105;
            }

        }
     

        public void hideSubmenus() //method for hiding submenus
        {
            panelStatisticsSubmenu.Visible = false;
            panelDepSubmenu.Visible = false;
            panelEmpSubmenu.Visible = false;
            panelStockSubmenu.Visible = false;
        }

        public void showSubmenus(Panel subMenu) //method for controlling the dropdown menu visibility
        {
            if (subMenu.Visible == false) //opens selected dropdown submenu and closes all other submenus
            {
                hideSubmenus();
                subMenu.Visible = true;
            }
            else //closes active submenu by clicking again
                subMenu.Visible = false;
        }

        private void BtnEmpMan_Click(object sender, EventArgs e) 
        {

            
                showSubmenus(panelEmpSubmenu);
        }
        #region EmpSub 
        private void BtnModEmp_Click(object sender, EventArgs e) //when programming submenu buttons, always leave hideSubmenus() method as last line of code
        {
            openChildForm(new AddEmployee()); //create new form object
            hideSubmenus();
        }

        private void BtnEmpInfo_Click(object sender, EventArgs e)
        {
            openChildForm(new AllEmployees()); //create new form object
            hideSubmenus();
        }

        private void BtnRemoveEmp_Click(object sender, EventArgs e)
        {
            openChildForm(new RemoveEmployee());
            hideSubmenus();
        }
        private void BtnEmpStatus_Click(object sender, EventArgs e)
        {
            openChildForm(new EmployeeChangeStatus());
            hideSubmenus();
        }

        private void BtnDep_Click(object sender, EventArgs e)
        {
            hideSubmenus();
        }
        #endregion
        private void BtnStockMan_Click(object sender, EventArgs e)
        {
            showSubmenus(panelStockSubmenu);
        }
        #region StockSub
        private void BtnModStock_Click(object sender, EventArgs e)
        {
            openChildForm(new CRUDProduct()); //create new form object
            hideSubmenus();
        }
        private void BtnRemoveStock_Click_1(object sender, EventArgs e)
        {

        }

        private void BtnStockInfo_Click_1(object sender, EventArgs e)
        {
            openChildForm(new ViewStore()); //create new form object
            hideSubmenus();
        }
        private void BtnBuyStock_Click_1(object sender, EventArgs e)
        {
            openChildForm(new CashierMachine()); //create new form object
            hideSubmenus();
        }

        private void BtnStockRequests_Click(object sender, EventArgs e)
        {
            openChildForm(new StockRequestsForm());
            hideSubmenus();
        }
        private void BtnDepoRequests_Click_1(object sender, EventArgs e)
        {
            openChildForm(new ViewDepo()); //create new form object
            hideSubmenus();
        }

        private void BtnDepoInfo_Click(object sender, EventArgs e)
        {

        }
        #endregion
        private void BtnDepMan_Click(object sender, EventArgs e)
        {
            showSubmenus(panelDepSubmenu);
        }
        #region DepSub
        private void BtnAddDep_Click(object sender, EventArgs e)
        {
            openChildForm(new AddDepartment());
            hideSubmenus();
        }
        private void BtnAssignEmpToDep_Click(object sender, EventArgs e)
        {
            openChildForm(new DepartmentAssignment());
            hideSubmenus();
        }
        private void BtnEditDep_Click(object sender, EventArgs e)
        {
            openChildForm(new UpdateDepartment());
            hideSubmenus();
        }
        #endregion
        private void BtnStats_Click(object sender, EventArgs e)
        {
            showSubmenus(panelStatisticsSubmenu);
        }
        #region StatSub
        private void BtnViewStats_Click(object sender, EventArgs e)
        {
            openChildForm(new ViewStatistics());
            hideSubmenus();
        }
        #endregion

        private Form activeForm = null;
        private void openChildForm(Form childForm) //method that creates a new Form object when switching between pages 
        {
            if (activeForm != null)
                
                activeForm.Close(); //close active child form
                Size = new Size(813, 613);
                activeForm = childForm; //store active form object
                childForm.TopLevel = false; //child form will behave like a control
                childForm.FormBorderStyle = FormBorderStyle.None; //turn off borders
                childForm.Dock = DockStyle.Fill; //set dock to fill to fill out entire panel
                panelChildForm.Controls.Add(childForm); //add child form to panel
                panelChildForm.Tag = childForm; //assign tag to Form object
                childForm.BringToFront(); //bring to front to cover logo on home page
                childForm.Show(); //
            
        }

        private void BtnCloseApp_Click(object sender, EventArgs e) //close application
        {
            this.Hide();
            LoginForm main = new LoginForm();
            main.Closed += (s, args) => this.Close();
            main.Show();
        }

        private void PanelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }



        

        

        private void btnShitManager_Click(object sender, EventArgs e)
        {
            openChildForm(new ViewShedule()); //create new form object
            Size = new Size(1540, 710); //change window size
            hideSubmenus();
        }
        private void btnShiftDayViewer_Click(object sender, EventArgs e)
        {
            openChildForm(new ShiftAttendance()); //create new form object
            hideSubmenus();
        }
        private void BtnBuyStock_Click(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
        }

        

        private void BtnDepoRequests_Click(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {

        }

        

        private void Form1_Activated(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
