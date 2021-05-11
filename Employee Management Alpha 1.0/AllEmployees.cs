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
        EmployeeManagement employeeManagement;
        const string pattern = @"([^\s]+)"; //pattern to get the first string before a space
        const string patternBSN = @"^[0-9]{9}$"; //pattern to check bsn
        Regex rg = new Regex(pattern);
        public AllEmployees()
        {
            InitializeComponent();
            UpdateList();
        }

        private void UpdateList()
        {
            lbViewEmployees.Items.Clear();
            employeeManagement = new EmployeeManagement();
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
            Match BSNmatch = Regex.Match(tbBSN.Text, patternBSN);
            if ((!String.IsNullOrEmpty(tbFirstName.Text)) && (!String.IsNullOrEmpty(tbLastName.Text)) && (!String.IsNullOrEmpty(tbBSN.Text)) && (!String.IsNullOrEmpty(tbPosition.Text)) && (!String.IsNullOrEmpty(cbWorkingH.Text)) && (!String.IsNullOrEmpty(tbPhone.Text)) && (!String.IsNullOrEmpty(tbAddress.Text)) && (!String.IsNullOrEmpty(tbEmail.Text)) && (!String.IsNullOrEmpty(tbEmergencyN.Text)) && (!String.IsNullOrEmpty(tbContactR.Text)) && (!String.IsNullOrEmpty(tbEmergencyNr.Text)) && (!String.IsNullOrEmpty(tbCertifications.Text)) && (!String.IsNullOrEmpty(tbLanguage.Text)) && (!String.IsNullOrEmpty(dateTimeStart.Text)) && (!String.IsNullOrEmpty(dateTimeEnd.Text)))
                if ((DateTime.Parse(dateTimeStart.Text) < DateTime.Parse(dateTimeEnd.Text)) && BSNmatch.Success && int.TryParse(tbSalary.Text, out int value))
                {
                    employeeManagement.EditEmployee(Convert.ToInt32(tbID.Text), tbFirstName.Text, tbLastName.Text, dtfiller, tbBSN.Text, tbPosition.Text, Convert.ToInt32(cbWorkingH.Text), tbPhone.Text, tbAddress.Text, tbEmail.Text, tbPassword.Text, tbEmergencyN.Text, tbContactR.Text, tbEmergencyNr.Text, tbCertifications.Text, tbLanguage.Text,dateTimeStart.Value, dateTimeEnd.Value, Convert.ToInt32(tbSalary.Text));
                }
                else
                {
                    MessageBox.Show("Some details are invalid. (Check BSN syntax, make sure a start date is before an end date!)");
                }  
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
            employee = employeeManagement.GetEmployeeByID(Convert.ToInt32(tbID.Text));
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
            tbPassword.Text = employee.password;
            dateTimeStart.Text = employee.startDate.ToString();
            dateTimeEnd.Text = employee.endDate.ToString();
            cbWorkingH.Text = employee.workinghours.ToString();
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

        private void btnPassVisible_Click(object sender, EventArgs e)
        {
            if (tbPassword.PasswordChar == '*')
                tbPassword.PasswordChar = '\0';
            else
                tbPassword.PasswordChar = '*';
        }
    }
}
