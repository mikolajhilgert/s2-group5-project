using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Employee_Management_Alpha_1._0
{
    public partial class AllEmployees : Form
    {
        Employee_Management employeeManagement;
        const string pattern = @"([^\s]+)"; //pattern to get the first string before a space
        Regex rg = new Regex(pattern);
        public AllEmployees()
        {
            InitializeComponent();
            UpdateList();
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
                    if(!(employeeManagement.GetAllEmployees()[i].first_name=="Admin"))
                        lbViewEmployees.Items.Add(employeeManagement.GetAllEmployees()[i].GetEmployeeInfo());

                }
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime dtfiller = DateTime.Now;
            if ((!String.IsNullOrEmpty(tbFirstName.Text)) && (!String.IsNullOrEmpty(tbLastName.Text)) && (!String.IsNullOrEmpty(tbBSN.Text)) && (!String.IsNullOrEmpty(tbPosition.Text)) && (!String.IsNullOrEmpty(tbWorkingH.Text)) && (!String.IsNullOrEmpty(tbPhone.Text)) && (!String.IsNullOrEmpty(tbAddress.Text)) && (!String.IsNullOrEmpty(tbEmail.Text)) && (!String.IsNullOrEmpty(tbEmergencyN.Text)) && (!String.IsNullOrEmpty(tbContactR.Text)) && (!String.IsNullOrEmpty(tbEmergencyNr.Text)) && (!String.IsNullOrEmpty(tbCertifications.Text)) && (!String.IsNullOrEmpty(tbLanguage.Text)) && (!String.IsNullOrEmpty(tbContractType.Text)) && (!String.IsNullOrEmpty(tbDuration.Text)))
                employeeManagement.ChangeEmployeeTest(Convert.ToInt32(tbID.Text), tbFirstName.Text, tbLastName.Text, dtfiller, tbBSN.Text, tbPosition.Text, Convert.ToInt32(tbWorkingH.Text), tbPhone.Text, tbAddress.Text, tbEmail.Text, tbEmergencyN.Text, tbContactR.Text, tbEmergencyNr.Text, tbCertifications.Text, tbLanguage.Text, tbContractType.Text, tbDuration.Text, Convert.ToInt32(tbSalary.Text));
            else
            {
                MessageBox.Show("Please make sure all information fields have been filled in.");
            }
            UpdateList();
        }

        private void lbViewEmployees_Click(object sender, EventArgs e)
        {

        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {
            Employee employee;
            employee = new Employee();
            employee = employeeManagement.ReturnEmployeeByID(Convert.ToInt32(tbID.Text));
            tbFirstName.Text = employee.Firstname;
            tbLastName.Text = employee.Lastname;
            tbAddress.Text = employee.address;
            tbBSN.Text = employee.bsn;
            tbCertifications.Text = employee.certifications;
            tbContactR.Text = employee.emergencyR;
            tbEmergencyN.Text = employee.emergencyC;
            tbEmergencyNr.Text = employee.emergencyNr;
            tbLanguage.Text = employee.languages;
            tbPosition.Text = employee.postion;
            tbEmail.Text = employee.email;
            tbContractType.Text = employee.contract;
            tbDuration.Text = employee.duration;
            tbWorkingH.Text = employee.workinghours.ToString();
            tbPhone.Text = employee.phoneNr;
            tbSalary.Text = employee.salary.ToString();
        }

        private void AllEmployees_Load(object sender, EventArgs e)
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
