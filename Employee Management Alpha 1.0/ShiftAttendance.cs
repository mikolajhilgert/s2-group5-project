using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_Alpha_1._0
{
    public partial class ShiftAttendance : Form
    {
        ShiftManagement sm;
        public ShiftAttendance()
        {
            InitializeComponent();
            PopulateDay(CurrentYear(),CurrentCalWeek(),CurrentDay()+1);
            //MessageBox.Show($"{CurrentYear()} {CurrentCalWeek()} {CurrentDay()}");
            cbYear.Text = CurrentYear().ToString();
            cbCWeek.Text = CurrentCalWeek().ToString();
            cbDay.SelectedIndex = CurrentDay();
        }
        private void PopulateDay(int year, int cWeek, int day)
        {
            sm = new ShiftManagement(year, cWeek);
            checkedList.Items.Clear();
            assignedList.Items.Clear();
            List<Tuple<int, string>> emps = sm.ReturnDayAttendence(cWeek, year, day);
            if (emps != null)
            {
                foreach (Tuple<int, string> kvp in emps)
                {
                    if (kvp.Item1 == 1)
                    {
                        checkedList.Items.Add(kvp.Item2);
                    }
                    else
                    {
                        assignedList.Items.Add(kvp.Item2);
                    }
                }
            }
        }

        private void buttonLoadSchedule_Click(object sender, EventArgs e)
        {
            if(cbYear.Text!= ""&& cbDay.Text != "" && cbCWeek.Text!= "")
            {
                PopulateDay(Convert.ToInt32(cbYear.Text), Convert.ToInt32(cbCWeek.Text), cbDay.SelectedIndex+1);
            }
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            cbYear.Text = CurrentYear().ToString();
            cbCWeek.Text = CurrentCalWeek().ToString();
            cbDay.SelectedIndex = CurrentDay();
            PopulateDay(Convert.ToInt32(cbYear.Text), Convert.ToInt32(cbCWeek.Text), cbDay.SelectedIndex+1 );
        }

        private int CurrentYear()
        {
            return Convert.ToInt32(DateTime.Now.Year);
        }

        private int CurrentCalWeek()
        {
            DateTime dt = DateTime.Now;
            Calendar cal = new CultureInfo("en-US").Calendar;
            return cal.GetWeekOfYear(dt, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
        }

        private int CurrentDay()
        {
            return (int)(DateTime.Now.DayOfWeek + 6) % 7;
        }
    }
}
