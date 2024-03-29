﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_Alpha_1._0
{
    public partial class RemoveEmployee : Form
    {
        EmployeeManagement employeeManagement;
        const string pattern = @"([^\s]+)"; //pattern to get the first string before a space
        Regex rg = new Regex(pattern);
        public RemoveEmployee()
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
                    if (!(employeeManagement.GetAllEmployees()[i].first_name == "Admin"))
                        lbViewEmployees.Items.Add(employeeManagement.GetAllEmployees()[i].GetEmployeeInfo());

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = tbID.Text;
            if (MessageBox.Show($"Are you sure you want to delete employee {id}?.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                employeeManagement.RemoveEmployeebyId(id);
            }
            tbID.Text = string.Empty;
            UpdateList();
        }

        private void RemoveEmployee_Load(object sender, EventArgs e)
        {

        }

        private void lbViewEmployees_Click(object sender, EventArgs e)
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
