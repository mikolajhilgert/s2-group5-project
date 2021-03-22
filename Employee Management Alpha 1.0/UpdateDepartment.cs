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
    public partial class UpdateDepartment : Form
    {
        public UpdateDepartment()
        {
            InitializeComponent();
            UpdateListbox();
        }

        private void UpdateListbox()
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
        private void UpdateTextboxes(Department d)
        {
            lblID.Text = $"Department ID: {d.Id}";
            tbName.Text = d.Name;
            tbHead.Text = d.HeadOfDepartment;
            tbAddress.Text = d.Address;
            tbPhone.Text = d.Phone.ToString();
            tbEmail.Text = d.Email;
            tbLanguage.Text = d.Language;
        }
        private void ClearTextboxes()
        {
            this.tbAddress.Clear();
            this.tbEmail.Clear();
            this.tbHead.Clear();
            this.tbLanguage.Clear();
            this.tbName.Clear();
            this.tbPhone.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Department department = new Department();
            if (lbDepartments.SelectedIndex >= 0 && lbDepartments.SelectedItem != null)
            {
                string inputFromListBox = lbDepartments.SelectedItem.ToString();
                Match match = Regex.Match(inputFromListBox, @"([^\s]+)");

                if ((!String.IsNullOrEmpty(tbName.Text)) && (!String.IsNullOrEmpty(tbHead.Text)) && (!String.IsNullOrEmpty(tbAddress.Text)) && (!String.IsNullOrEmpty(tbPhone.Text)) && (!String.IsNullOrEmpty(tbEmail.Text)) && (!String.IsNullOrEmpty(tbLanguage.Text)))
                    DepartmentManagement.UpdateDepartment(Convert.ToInt32(match.Value),tbName.Text, tbHead.Text, tbAddress.Text, Convert.ToInt32(tbPhone.Text), tbEmail.Text, tbLanguage.Text);
                else
                {
                    MessageBox.Show("Please make sure all information fields have been filled in.");
                }
            }
            else
                MessageBox.Show("Invalid employee selected");
            UpdateListbox();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            if (lbDepartments.SelectedIndex >= 0 && lbDepartments.SelectedItem != null)
            {
                string inputFromListBox = lbDepartments.SelectedItem.ToString();
                Match match = Regex.Match(inputFromListBox, @"([^\s]+)");

                foreach (var d in DepartmentManagement.GetAllDepartments())
                {
                    {
                        if (d.Id == Convert.ToInt32(match.Value))
                        {
                            DepartmentManagement.ChangeStatus(d);
                            break;
                        }
                            
                    }
                }
            }
            else
                MessageBox.Show("Invalid employee selected");
            UpdateListbox();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbDepartments.SelectedIndex >= 0 && lbDepartments.SelectedItem != null)
            {
                string inputFromListBox = lbDepartments.SelectedItem.ToString();
                Match match = Regex.Match(inputFromListBox, @"([^\s]+)");

                foreach (var d in DepartmentManagement.GetAllDepartments())
                {
                    {
                        if (d.Id == Convert.ToInt32(match.Value))
                        {
                            DepartmentManagement.DeleteDepartment(d.Id);
                            ClearTextboxes();
                            break;
                        }

                    }
                }
            }
            else
                MessageBox.Show("Invalid employee selected");
            UpdateListbox();
        }

        private void lbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            Department department = new Department();
            if (lbDepartments.SelectedIndex >= 0 && lbDepartments.SelectedItem != null)
            {
                string inputFromListBox = lbDepartments.SelectedItem.ToString();
                Match match = Regex.Match(inputFromListBox, @"([^\s]+)");

                int id = Convert.ToInt32(match.Value);
                department = DepartmentManagement.GetDepartmentByID(id);
                UpdateTextboxes(department);
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
