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
        private List<Employee> emps = new List<Employee>();
        private const string pattern = @"([^\s]+)"; //pattern to get the first string before a space
        Regex rg = new Regex(pattern);
        public ViewStatistics()
        {
            InitializeComponent();
            this.statistics = new Statistics();
            RefreshActiveEmps();
        }

        private void empList_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelTotalShift.Text = "";
            try
            {
                Match match = Regex.Match(empList.SelectedItem.ToString(), pattern);
                if (match.Success)
                {
                    //all shifts assigned to single employee
                    int numbers = statistics.GetEmpShiftStats(Convert.ToInt32(match.Value));
                    labelTotalShift.Text = $"This employee has been scheduled a total of {numbers} shifts.";

                    //total hours worked
                    int hours;

                }

            }catch(NullReferenceException)
            {
                MessageBox.Show("Select an employee in the listbox to view their statistics!");
            }

        }

        private void RefreshActiveEmps()
        {
            emps = statistics.GetAllActiveEmployees();
            if (statistics.GetAllActiveEmployees() is null)
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
    }
}
