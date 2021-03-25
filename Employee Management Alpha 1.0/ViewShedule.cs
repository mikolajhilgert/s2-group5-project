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
    public partial class ViewShedule : Form
    {
        ShiftManagement sm;

        public static int dow = 7;
        public static int tod = 3;
        public static List<int> dID;
        public static string DepName = "?";
        public static ViewShedule Instance = null;
        public static int year;
        public static int cWeek;

        public ViewShedule()
        {
            ViewShedule.Instance = this;
            InitializeComponent();
            InsertCurrentDates();
            PopulateSchedule();
        }

        public void PopulateSchedule()
        {
            ClearShiftLabels();
            ClearShiftColors();
            //reset variables
            dow = 7;
            tod = 3;
            sm = new ShiftManagement(year, cWeek);

            List<Shift> Items = new List<Shift>();
            Items = sm.ReturnScheduledEmployees();
            try
            {
                //Traversal through each groupbox from right to left -> https://stackoverflow.com/questions/18895864/how-to-use-foreach-for-the-textboxes-in-a-panel
                foreach (GroupBox gb in pnlDates.Controls.OfType<GroupBox>())
                {
                    //Traversal through each panel&label from bottom to top 
                    foreach (Panel pnl in gb.Controls.OfType<Panel>())
                    {
                        foreach (Label label in pnl.Controls.OfType<Label>())
                        {
                            if (dow != 0)
                            {
                                bool shiftFound = false;
                                if (Items != null)
                                {
                                    int a=0, b =0, c = 0;
                                    switch (tod)
                                    {
                                        case 1:
                                            foreach (Shift item in Items)
                                            {
                                                if (item.morning && item.DoW == dow && item.cWeek == cWeek)
                                                {
                                                    label.Text += $"ID: {item.employeeID} {item.empName}{Environment.NewLine}";
                                                    shiftFound = true;
                                                    a++;
                                                    if (a == 1)
                                                    {
                                                        pnl.BackColor = Color.Yellow;
                                                    }
                                                    else if (a >= 2)
                                                    {
                                                        pnl.BackColor = Color.LightGreen;
                                                    }
                                                }
                                            }
                                            break;
                                        case 2:
                                            foreach (Shift item in Items)
                                            {
                                                if (item.afternoon && item.DoW == dow && item.cWeek == cWeek)
                                                {
                                                    label.Text += $"ID: {item.employeeID} {item.empName}{Environment.NewLine}";
                                                    shiftFound = true;
                                                    b++;
                                                    if (b == 1)
                                                    {
                                                        pnl.BackColor = Color.Yellow;
                                                    }
                                                    else if (b >= 2)
                                                    {
                                                        pnl.BackColor = Color.LightGreen;
                                                    }
                                                }
                                            }
                                            break;
                                        default:
                                            foreach (Shift item in Items)
                                            {
                                                if (item.evening && item.DoW == dow && item.cWeek == cWeek)
                                                {
                                                    label.Text += $"ID: {item.employeeID} {item.empName}{Environment.NewLine}";
                                                    shiftFound = true;
                                                    c++;
                                                    if (c == 1)
                                                    {
                                                        pnl.BackColor = Color.Yellow;
                                                    }
                                                    else if (c >= 2)
                                                    {
                                                        pnl.BackColor = Color.LightGreen;
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                    if (tod == 1)
                                    {
                                        tod = 3;
                                        dow--;
                                    }
                                    else
                                    {
                                        tod--;
                                    }
                                }
                                if (shiftFound == false)
                                {
                                    label.Text = "///";
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ClearShiftLabels()
        {
            foreach (GroupBox gb in pnlDates.Controls.OfType<GroupBox>())
            {
                foreach (Panel pnl in gb.Controls.OfType<Panel>())
                {
                    foreach (Label label in pnl.Controls.OfType<Label>())
                    {
                        label.Text = string.Empty;
                    }
                }
            }
        }

        public void ClearShiftColors()
        {
            foreach (GroupBox gb in pnlDates.Controls.OfType<GroupBox>())
            {
                foreach (Panel pnl in gb.Controls.OfType<Panel>())
                {
                    pnl.BackColor = Color.WhiteSmoke;
                }
            }
        }

        //Open shift scheduler -> Monday
        private void pnlMornMonday_Click(object sender, EventArgs e)
        {
            //pnlMornMonday.BackColor = Color.DarkSeaGreen;
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year,cWeek,1, 1);
            sa.Show();
        }

        private void pnlAftMonday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek,1, 2);
            sa.ShowDialog();
        }

        private void pnlEvenMonday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 1, 3);
            sa.ShowDialog();
        }

        //Open shift scheduler -> Tuesday
        private void pnlMornTuesday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 2,1);
            sa.ShowDialog();
        }

        private void pnlAftTuesday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 2, 2);
            sa.ShowDialog();
        }

        private void pnlEvenTuesday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 2, 3);
            sa.ShowDialog();
        }

        //Open shift scheduler -> Wednesday
        private void pnlMornWednesday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 3, 1);
            sa.ShowDialog();
        }

        private void pnlAftWednesday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 3, 2);
            sa.ShowDialog();
        }

        private void pnlEvenWednesday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 3, 3);
            sa.ShowDialog();
        }

        //Open shift scheduler -> Thursday
        private void pnlMornThursday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 4, 1);
            sa.ShowDialog();
        }

        private void pnlAftThursday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 4, 2);
            sa.ShowDialog();
        }

        private void pnlEvenThursday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 4, 3);
            sa.ShowDialog();
        }

        //Open shift scheduler -> Friday
        private void pnlMornFriday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 5, 1);
            sa.ShowDialog();
        }

        private void pnlAftFriday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 5, 2);
            sa.ShowDialog();
        }

        private void pnlEvenFriday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 5, 3);
            sa.ShowDialog();
        }

        //Open shift scheduler -> Saturday
        private void pnlMornSaturday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 6, 1);
            sa.ShowDialog();
        }

        private void pnlAftSaturday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 6, 2);
            sa.ShowDialog();
        }

        private void pnlEvenSaturday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 6, 3);
            sa.ShowDialog();
        }

        //Open shift scheduler -> Sunday
        private void pnlMornSunday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 7, 1);
            sa.ShowDialog();
        }

        private void pnlAftSunday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 7, 2);
            sa.ShowDialog();
        }

        private void pnlEvenSunday_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShiftAssignment sa = new ShiftAssignment(year, cWeek, 7, 3);
            sa.ShowDialog();
        }

        private void buttonClearWeek_Click(object sender, EventArgs e)
        {
            sm.ClearWeekSchedule();
            PopulateSchedule();
        }

        private void buttonLoadSchedule_Click(object sender, EventArgs e)
        {
            year = ReturnSelectedYear();
            cWeek = ReturnSelectedCalWeek();
            //MessageBox.Show(ReturnSelectedYear().ToString());
            //MessageBox.Show(ReturnSelectedCalWeek().ToString());
            PopulateSchedule();
        }

        public int ReturnCurrentYear()
        {
            return Convert.ToInt32(DateTime.Now.Year);
        }

        public int ReturnCurrentCalWeek()
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            return cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }
        public int ReturnSelectedYear()
        {
            return Convert.ToInt32(cbYear.Text);
        }

        public int ReturnSelectedCalWeek()
        {
            return Convert.ToInt32(cbCWeek.Text);
        }

        public void InsertCurrentDates()
        {
            cbYear.Text = ReturnCurrentYear().ToString();
            cbCWeek.Text = ReturnCurrentCalWeek().ToString();
            year = ReturnCurrentYear();
            cWeek = ReturnCurrentCalWeek();
        }

        private void buttonCurrentWeek_Click(object sender, EventArgs e)
        {
            cbYear.Text = ReturnCurrentYear().ToString();
            cbCWeek.Text = ReturnCurrentCalWeek().ToString();

            year = ReturnSelectedYear();
            cWeek = ReturnSelectedCalWeek();
            //MessageBox.Show(ReturnSelectedYear().ToString());
            //MessageBox.Show(ReturnSelectedCalWeek().ToString());
            PopulateSchedule();

        }
    }
}
