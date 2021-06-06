using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Alpha_1._0
{
    public class Shift
    {
        public int shiftID { get; set; }
        public int DoW { get; set; }
        public string empName { get; set; }
        public int employeeID { get; set; }
        public bool morning { get; set; }
        public bool afternoon { get; set; }
        public bool evening { get; set; }
        public int year { get; set; }
        public int cWeek { get; set; }
        public int contractHours { get; set; }
        public int workedHours { get; set; }
        public int bannedDay1 { get; set; }
        public int bannedDay2 { get; set; }
        public bool status { get; set; }


        public Shift(int shiftID, int DoW, int employeeID, string empName, bool morning, bool afternoon, bool evening, int year, int cWeek)
        {
            this.shiftID = shiftID;
            this.DoW = DoW;
            this.employeeID = employeeID;
            this.empName = empName;
            this.morning = morning;
            this.afternoon = afternoon;
            this.evening = evening;
            this.cWeek = cWeek;
            this.year = year;
        }
        public Shift(int employeeID, string empName, string bannedDays)
        {
            this.employeeID = employeeID;
            this.empName = empName;
            string[] values = bannedDays.Split(',');
            this.bannedDay1 = Convert.ToInt32(values[0]);
            this.bannedDay2 = Convert.ToInt32(values[1]);
        }

        public Shift(int employeeID, string empName, int contractH, int workedH, string bannedDays)
        {
            this.employeeID = employeeID;
            this.empName = empName;
            this.contractHours = contractH;
            this.workedHours = workedH;
            string[] values = bannedDays.Split(',');
            this.bannedDay1 = Convert.ToInt32(values[0]);
            this.bannedDay2 = Convert.ToInt32(values[1]);
        }

        public Shift(int employeeID, string empName, bool morning, bool afternoon, bool evening, bool status)
        {
            this.employeeID = employeeID;
            this.empName = empName;
            this.morning = morning;
            this.afternoon = afternoon;
            this.evening = evening;
            this.status = status;
        }
    }
}
