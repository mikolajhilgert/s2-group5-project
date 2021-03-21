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
    public partial class DepartmentAssignment : Form
    {
        public DepartmentAssignment()
        {
            InitializeComponent();
            PopulateComboBox();
        }

        private void PopulateComboBox()
        {
            foreach (var d in DepartmentManagement.GetAllActiveDepartments())
            {
                cmbDepartments.Items.Add(d);
            }
        }
        private Department GetComboBoxDepartment()
        {
            if (!(cmbDepartments.SelectedIndex.Equals(null)))
            {
                string inputFromComboBox = cmbDepartments.SelectedItem.ToString();
                Match match = Regex.Match(inputFromComboBox, @"([^\s]+)");
                foreach (var d in DepartmentManagement.GetAllDepartments())
                {
                    if (d.Id == Convert.ToInt32(match.Value))
                        return d;
                }
            }
            else
                MessageBox.Show("Invalid department selected");
            return null;
        }

        private void UpdateListboxes(Department d)
        {
            lbAssigned.Items.Clear();
            lbAvailable.Items.Clear();
            if (DepartmentManagement.GetAllDepartments() is null)
            {
                MessageBox.Show("The database is empty!");
                lbAssigned.Items.Add("The database is empty!");
                lbAvailable.Items.Add("The database is empty!");
            }
            else
            {

                foreach (var employee in DepartmentManagement.GetAllAssignableEmployeesForDepartment(d))
                {
                    lbAvailable.Items.Add(employee.GetEmployeeInfo());
                }
                foreach (var employee in DepartmentManagement.GetAllAssignedEmployeesForDepartment(d))
                {
                    lbAssigned.Items.Add(employee.GetEmployeeInfo());
                }
            }
        }

        private void cmbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListboxes(GetComboBoxDepartment());
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            Employee_Management employee_Management = new Employee_Management();
            Employee employee = new Employee();
            if (lbAvailable.SelectedIndex >= 0 && lbAvailable.SelectedItem != null)
            {
                string inputFromListBox = lbAvailable.SelectedItem.ToString();
                Match match = Regex.Match(inputFromListBox, @"([^\s]+)");
                employee = employee_Management.GetEmployeebyID(Convert.ToInt32(match.Value));
                DepartmentManagement.AssignEmployee(employee, GetComboBoxDepartment());
                UpdateListboxes(GetComboBoxDepartment());
            }
            else
                MessageBox.Show("Invalid employee selected");
        }

        private void btnUnassign_Click(object sender, EventArgs e)
        {
            Employee_Management employee_Management = new Employee_Management();

            Employee employee = new Employee();
            if (lbAssigned.SelectedIndex >= 0 && lbAssigned.SelectedItem != null)
            {
                string inputFromListBox = lbAssigned.SelectedItem.ToString();
                Match match = Regex.Match(inputFromListBox, @"([^\s]+)");
                employee = employee_Management.GetEmployeebyID(Convert.ToInt32(match.Value));
                DepartmentManagement.UnassignEmployee(employee);
                UpdateListboxes(GetComboBoxDepartment());
            }
            else
                MessageBox.Show("Invalid employee selected");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
