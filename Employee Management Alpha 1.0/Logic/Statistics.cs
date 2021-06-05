using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Employee_Management_Alpha_1._0
{
    public class Statistics
    {
        protected StatisticsDAL db = new StatisticsDAL();

        public int GetEmpShiftStats(int empID)
        {
            return db.GetEmpShiftStats(empID);
        }
        public int GetEmpSalary(int empID)
        {
            return db.GetEmpSalary(empID);
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