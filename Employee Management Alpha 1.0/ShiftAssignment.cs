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
    public partial class ShiftAssignment : Form
    {

        ShiftManagement sm;

        private int tod;
        private int dow;
        private int year;
        private int cWeek;

        const string pattern = @"([^\s]+)"; //pattern to get the first string before a space
        Regex rg = new Regex(pattern);

        public ShiftAssignment(int year, int cWeek, int dow, int tod)
        {
            InitializeComponent();
            sm = new ShiftManagement(year, cWeek);
            this.tod = tod;
            this.dow = dow;
            this.year = year;
            this.cWeek = cWeek;
            ViewAssignedEmp();
            ViewFreeEmp();
            SetTitle();
        }

        private void bttnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedID;
                if(gdvAvailable.CurrentCell != null)
                {
                    string ID = gdvAvailable.Rows[gdvAvailable.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    Match match = Regex.Match(ID, pattern);
                    if (match.Success)
                    {
                        selectedID = Convert.ToInt32(match.Value);
                        sm.AssignEmployeeToShift(selectedID, tod, dow);
                    }
                }
                else
                {
                    MessageBox.Show("No available employee was selected!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            RefreshDGV();
        }

        private void bttnUnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedID;
                if(dgvAssigned.CurrentCell != null)
                {
                    string ID = dgvAssigned.Rows[dgvAssigned.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    Match match = Regex.Match(ID, pattern);
                    if (match.Success)
                    {
                        selectedID = Convert.ToInt32(match.Value);
                        sm.UnAssignEmployeeToShift(selectedID, tod, dow);
                    }
                }
                else
                {
                    MessageBox.Show("No assigned employee was selected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            RefreshDGV();
        }

        private void ViewAssignedEmp()
        {
            List<Shift> items = sm.ReturnEmployeesByShift(this.tod, this.dow);
            
            //MessageBox.Show(items.Count.ToString());
            if (items != null)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    dgvAssigned.Rows.Add(1);
                    dgvAssigned.Rows[i].Cells[0].Value = $"{items[i].employeeID} {items[i].empName}";
                }
            }
            dgvAssigned.ClearSelection();
        }
        private void ViewFreeEmp()
        {
            List<Shift> items = sm.ReturnAvailableEmployees(this.tod, this.dow);
            if (items != null)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    gdvAvailable.Rows.Add(1);
                    gdvAvailable.Rows[i].Cells[0].Value = $"{items[i].employeeID} {items[i].empName}";
                }
            }
            dgvAssigned.ClearSelection();
        }

        public void RefreshDGV()
        {
            gdvAvailable.Rows.Clear();
            dgvAssigned.Rows.Clear();
            ViewFreeEmp();
            ViewAssignedEmp();
        }

        private void ShiftAssignment_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewShedule.Instance.PopulateSchedule();           
        }

        private void SetTitle()
        {
            string[] d = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturaday", "Sunday" };
            string[] t = { "morning", "afternoon", "evening" };
            lblTitle.Text = $"Assign shifts for {d[dow - 1]} {t[tod - 1]} of calendar week {cWeek} in {year}";
        }

        
    }
}
