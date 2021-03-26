using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_Alpha_1._0
{
    public partial class AddDepartment : Form
    {
        public AddDepartment()
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
        private void ClearTextboxes()
        {
            this.tbAddress.Clear();
            this.tbEmail.Clear();
            this.tbHead.Clear();
            this.tbLanguage.Clear();
            this.tbName.Clear();
            this.tbPhone.Clear();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((!String.IsNullOrEmpty(tbName.Text)) && (!String.IsNullOrEmpty(tbHead.Text)) &&  (!String.IsNullOrEmpty(tbAddress.Text)) && (!String.IsNullOrEmpty(tbPhone.Text)) && (!String.IsNullOrEmpty(tbEmail.Text)) && (!String.IsNullOrEmpty(tbLanguage.Text)))
                DepartmentManagement.CreateDepartment(tbName.Text, tbHead.Text, tbAddress.Text, Convert.ToInt32(tbPhone.Text), tbEmail.Text, tbLanguage.Text);
            else
            {
                MessageBox.Show("Please make sure all information fields have been filled in.");
            }

            UpdateListbox();
            ClearTextboxes();
        }
    }
}
