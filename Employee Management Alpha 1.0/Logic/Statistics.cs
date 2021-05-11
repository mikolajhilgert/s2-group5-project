using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Employee_Management_Alpha_1._0
{
    public class Statistics
    {
        protected MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;database=dbi456096;uid=dbi456096;password=logixtic;");//sql connector
        protected StatisticsDAL db = new StatisticsDAL();

        public int GetEmpShiftStats(int empID)
        {
            int count = 0;
            string sql = $@"SELECT count(morning) FROM `shifts` WHERE `EmpID` = '{empID}' AND `morning` = '1' UNION ALL SELECT count(afternoon) FROM `shifts` WHERE `EmpID` = '{empID}' AND `afternoon` = '1' UNION ALL SELECT count(evening) FROM `shifts` WHERE `EmpID` = '{empID}' AND `evening` = '1';";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                count = count + Convert.ToInt32(dr[0]);
            }
            conn.Close();
            return count;
        }
        public int GetEmpSalary(int empID)
        {
            int salary = 0;
            string sql = $@"SELECT Salary FROM `employee` WHERE `ID` = '{empID}';";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                salary = Convert.ToInt32(dr[0]);
            }
            conn.Close();
            return salary;
        }
        public int GetEmpWorkingDuration(int empID)
        {
            DateTime currentDate = DateTime.Now;
            DateTime startDate = db.GetEmpWorkingDuration(empID);
            return (int)(currentDate - startDate).TotalDays;
        }

        public int GetEmpTotalTime(int empID)
        {
            int year = Convert.ToInt32(DateTime.Now.Year);
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            int calendarWeek = cal.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
            int day = (int)DateTime.Now.DayOfWeek;
            return db.GetEmpTotalTime(calendarWeek,year,empID,day) * 8;
        }
        public List<Employee> GetAllEmployees()
        {
            return db.GetAllEmployees();
        }

        public int GetActiveEmployees()
        {
            return db.GetActiveEmpsNum();
        }
    }
}