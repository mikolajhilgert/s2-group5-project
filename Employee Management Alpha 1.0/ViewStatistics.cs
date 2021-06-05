using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_Alpha_1._0
{
    public partial class ViewStatistics : Form
    {
        private Statistics statistics;
        private ProductManager productManager;
        private List<Employee> emps = new List<Employee>();
        private const string pattern = @"([^\s]+)"; //pattern to get the first string before a space
        public ViewStatistics()
        {
            InitializeComponent();
            this.statistics = new Statistics();
            this.productManager = new ProductManager();
            PopulateLables();

            RefreshEmps();
            UpdateDepartmentListbox();
            UpdateProductListbox();
        }

        private void PopulateLables()
        {
            labelActiveE.Text = "There are " + statistics.GetActiveEmployees().ToString() + " active employees";
            lblActiveDeps.Text = "There are " + DepartmentManagement.GetAllActiveDepartments().Count + " active departments";
            lblActiveProducts.Text = "There are " + productManager.RefreshProducts().Count + " different products for sale";
        }
        private void empList_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelTotalShift.Text = labelTotalHours.Text = labelTotalDaysWorked.Text = labelTotalPayment.Text = string.Empty;

            if (empList.SelectedItem != null)
            {
                Match match = Regex.Match(empList.SelectedItem.ToString(), pattern);
                if (match.Success)
                {
                    //all shifts assigned to single employee
                    int numbers = statistics.GetEmpShiftStats(Convert.ToInt32(match.Value));
                    labelTotalShift.Text = $"This employee has been scheduled a total of {numbers} shifts.";

                    //total hours worked
                    int hours = statistics.GetEmpTotalTime(Convert.ToInt32(match.Value));
                    labelTotalHours.Text = $"This employee has had {hours / 8} shifts ({hours} hours), including today.";

                    int workedDays = statistics.GetEmpWorkingDuration(Convert.ToInt32(match.Value));
                    labelTotalDaysWorked.Text = $"This employee has been at the company for {workedDays} days.";

                    int salary = statistics.GetEmpSalary(Convert.ToInt32(match.Value));
                    int monthsWorked = workedDays / 30;
                    labelTotalPayment.Text = $"Total payment to employee: {salary * monthsWorked} Euro.";

                }
            }
            else
            {
                MessageBox.Show("Select an employee in the listbox to view their statistics!");
            }

        }

        private void RefreshEmps()
        {
            emps = statistics.GetAllEmployees();
            if (statistics.GetAllEmployees() is null)
            {

                empList.Items.Add("The database is empty!");
            }
            else
            {
                for (int i = 0; i < emps.Count(); i++)
                {
                    empList.Items.Add(emps[i].GetEmployeeInfo());
                }
            }
        }

        #region departments
        private void UpdateDepartmentListbox()
        {
            lbDepartments.Items.Clear();
            if (DepartmentManagement.GetAllDepartments() is null)
            {
                MessageBox.Show("The database is empty!");
                lbDepartments.Items.Add("The database is empty!");
            }
            else
            {
                foreach (var d in DepartmentManagement.GetAllDepartments())
                {
                    lbDepartments.Items.Add(d);
                }
            }
        }

        private void UpdateDepartmentLabels(Department d)
        {
            lblDepartmentHead.Text = $"This department's head is {d.HeadOfDepartment}.";
            lblEmployeeCount.Text = $"This department contains {DepartmentManagement.GetAllAssignedEmployeesForDepartment(d).Count} employees.";
            lblProductCount.Text = $"This department contains {DepartmentManagement.GetProductsForDepartment(d).Count} products.";
            lblDepartmentProfit.Text = $"This department has made {DepartmentManagement.GetProfitForDepartment(d)}€ in total profit.";
        }

        private void lbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            Department department = new Department();
            if (lbDepartments.SelectedIndex >= 0 && lbDepartments.SelectedItem != null)
            {
                string inputFromListBox = lbDepartments.SelectedItem.ToString();
                Match match = Regex.Match(inputFromListBox, pattern);

                int id = Convert.ToInt32(match.Value);
                department = DepartmentManagement.GetDepartmentByID(id);
                UpdateDepartmentLabels(department);
            }
            else
                MessageBox.Show("Invalid department selected");
        }
        #endregion

        #region products
        private void UpdateProductListbox()
        {
            lbProducts.Items.Clear();
            if (productManager.RefreshProducts() is null)
            {
                MessageBox.Show("The database is empty!");
                lbProducts.Items.Add("The database is empty!");
            }
            else
            {
                foreach (Product p in productManager.RefreshProducts())
                {
                    lbProducts.Items.Add(p);
                }
            }
        }
        private void UpdateProductLabels(Product product)
        {
            int sales = productManager.GetAmountOfSales(product);
            lblAmountSold.Text = $"This product has been sold {sales} times.";
            decimal profit = sales * product.PricePerUnit;
            lblProductProfit.Text = $"This product has made a total profit of {profit}€.";
        }

        private void lbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product product = new Product();
            if (lbProducts.SelectedIndex >= 0 && lbProducts.SelectedItem != null)
            {
                string inputFromListBox = lbProducts.SelectedItem.ToString();
                Match match = Regex.Match(inputFromListBox, pattern);

                int id = Convert.ToInt32(match.Value);
                product = productManager.GetProductByID(id);
                UpdateProductLabels(product);
            }
            else
                MessageBox.Show("Invalid product selected");

        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
