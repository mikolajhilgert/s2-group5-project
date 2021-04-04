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


        public Shift(int shiftID, int DoW, int employeeID, string empName, bool morning, bool afternoon, bool evening, int year , int cWeek)
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
        public Shift(int employeeID, string empName)
        {
            this.employeeID = employeeID;
            this.empName = empName;
            //this.afternoon = false;
            //this.morning = false;
            //this.evening = false;
        }

        public Shift(int employeeID, string empName, int contractH, int workedH)
        {
            this.employeeID = employeeID;
            this.empName = empName;
            this.contractHours = contractH;
            this.workedHours = workedH;
        }
    }
}
