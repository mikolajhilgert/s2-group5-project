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
using System.Text.RegularExpressions;

namespace Employee_Management_Alpha_1._0
{
    public partial class AddEmployee : Form
    {
        Employee_Management employeeManagement;
        const string pattern = @"^[0-9]{9}$"; //pattern to check bsn
        Regex rg = new Regex(pattern);
        public AddEmployee()
        {
            InitializeComponent();
            employeeManagement = new Employee_Management();
            UpdateList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateList()
        {
            lbEmployees.Items.Clear();
            employeeManagement = new Employee_Management();
            if (employeeManagement.GetAllEmployees() is null)
            {
                MessageBox.Show("The database is empty!");
                lbEmployees.Items.Add("The database is empty!");
            }
            else
            {
                for (int i = 0; i < employeeManagement.GetAllEmployees().Count(); i++)
                {
                    if (!(employeeManagement.GetAllEmployees()[i].first_name == "Admin"))
                        lbEmployees.Items.Add(employeeManagement.GetAllEmployees()[i].GetEmployeeInfo());

                }
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
           
            lbEmployees.Items.Clear();
            Match BSNmatch= Regex.Match(tbBSN.Text, pattern);
            //DateTime time = Convert.ToDateTime(dtpEmployee.Value); //Date time picker
            if ((!String.IsNullOrEmpty(tbFirstName.Text)) && (!String.IsNullOrEmpty(tbLastName.Text)) && ((dtpEmployee.Value!=null)) && (!String.IsNullOrEmpty(tbBSN.Text)) && (!String.IsNullOrEmpty(tbPosition.Text)) && (!String.IsNullOrEmpty(cbWorkingH.Text)) && (!String.IsNullOrEmpty(tbPhone.Text)) && (!String.IsNullOrEmpty(tbAddress.Text)) && (!String.IsNullOrEmpty(tbEmail.Text)) && (!String.IsNullOrEmpty(tbEmergencyN.Text)) && (!String.IsNullOrEmpty(tbContactR.Text)) && (!String.IsNullOrEmpty(tbEmergencyNr.Text)) && (!String.IsNullOrEmpty(tbCertifications.Text)) && (!String.IsNullOrEmpty(tbLanguage.Text)) && (!String.IsNullOrEmpty(dateTimeStart.Text)) && (!String.IsNullOrEmpty(dateTimeEnd.Text)))
                if((DateTime.Parse(dateTimeStart.Text) < DateTime.Parse(dateTimeEnd.Text))&& BSNmatch.Success && int.TryParse(tbSalary.Text, out int value))
                {
                    //MessageBox.Show("Success!");
                    employeeManagement.AddEmployee(tbFirstName.Text, tbLastName.Text, dtpEmployee.Value, tbBSN.Text, tbPosition.Text, Convert.ToInt32(cbWorkingH.Text), tbPhone.Text, tbAddress.Text, tbEmail.Text, tbEmergencyN.Text, tbContactR.Text, tbEmergencyNr.Text, tbCertifications.Text, tbLanguage.Text, dateTimeStart.Value, dateTimeEnd.Value, Convert.ToInt32(tbSalary.Text));
                    tbAddress.Text = tbBSN.Text = tbCertifications.Text = tbContactR.Text = tbEmail.Text = tbEmergencyN.Text = tbEmergencyNr.Text = tbFirstName.Text = tbLanguage.Text = tbLastName.Text = tbPhone.Text = tbPhoneNumber.Text = tbPosition.Text = tbSalary.Text = string.Empty;
                    dateTimeStart.Value = DateTime.Now;
                    cbWorkingH.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Some details are invalid. (Check BSN,Salary syntax, make sure a start date is before an end date!)");
                }
            else
            {
                MessageBox.Show("Please make sure all information fields have been filled in.");
            }

            lbEmployees.Items.Clear();
            employeeManagement = new Employee_Management();
            UpdateList();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }


        private void btnPassVisible_Click_1(object sender, EventArgs e)
        {
            if (tbPassword.PasswordChar == '*')
                tbPassword.PasswordChar = '\0';
            else
                tbPassword.PasswordChar = '*';
        }
    }
}
