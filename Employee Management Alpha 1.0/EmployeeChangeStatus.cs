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
    public partial class EmployeeChangeStatus : Form
    {
        Employee_Management employeeManagement;
        const string pattern = @"([^\s]+)"; //pattern to get the first string before a space
        Regex rg = new Regex(pattern);
        public EmployeeChangeStatus()
        {
            InitializeComponent();
            UpdateList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateList()
        {
            lbViewEmployees.Items.Clear();
            employeeManagement = new Employee_Management();
            if (employeeManagement.GetAllEmployees() is null)
            {
                MessageBox.Show("The database is empty!");
                lbViewEmployees.Items.Add("The database is empty!");
            }
            else
            {
                for (int i = 0; i < employeeManagement.GetAllEmployees().Count(); i++)
                {
                    if (!(employeeManagement.GetAllEmployees()[i].first_name == "Admin"))
                        lbViewEmployees.Items.Add(employeeManagement.GetAllEmployees()[i].GetEmployeeInfo());

                }
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EmployeeStatus myStatus;
            Enum.TryParse(cbxSelectStatus.SelectedItem.ToString(), out myStatus);
            employeeManagement.ChangeEmployeeStatus(tbID.Text, myStatus);
            UpdateList();
        }

        private void lbViewEmployees_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeChangeStatus_Load(object sender, EventArgs e)
        {

        }

        private void lbViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbViewEmployees.SelectedItem != null)
            {
                string ID = lbViewEmployees.SelectedItem.ToString();
                Match match = Regex.Match(ID, pattern);
                if (match.Success)
                {
                    tbID.Text = match.Value;

                }
            }
        }
    }
}