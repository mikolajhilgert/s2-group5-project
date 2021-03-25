using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Alpha_1._0
{
    public class Statistics
    {
        protected MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;database=dbi456096;uid=dbi456096;password=logixtic;");//sql connector
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

        public int GetEmpTotalTime(int empID)
        {
            int count = 0;
            int year = Convert.ToInt32(DateTime.Now.Year);
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            int calendarWeek = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            int day = (int)DateTime.Now.DayOfWeek;
            //System.Windows.Forms.MessageBox.Show(day.ToString() + calendarWeek.ToString() + year.ToString());

            TimeSpan startMorningShift = new TimeSpan(8, 0, 0); 
            TimeSpan endMorningShift = new TimeSpan(16, 0, 0);
            TimeSpan startEveningShift = new TimeSpan(16, 0, 0);
            TimeSpan endEveningShift = new TimeSpan(24, 0, 0);
            TimeSpan startNightShift = new TimeSpan(24, 0, 0);
            TimeSpan endNightShift = new TimeSpan(8, 0, 0);
            TimeSpan now = DateTime.Now.TimeOfDay;
            if ((now > startMorningShift) && (now < endMorningShift))
            {
                //match found
            }
            else if ((now > startEveningShift) && (now < endEveningShift)){
            
            }
            else if((now > startNightShift) && (now < endNightShift)){

            }
            //UNION ALL SELECT count(afternoon) FROM `shifts` WHERE `EmpID` = '{empID}' AND `Year` <= '{year}' AND `DOfW <= '{day}' AND `cWeek` <= '{calendarWeek}' AND `afternoon` = '1' UNION ALL SELECT count(evening) FROM `shifts` WHERE `EmpID` = '{empID}' AND `Year` <= '{year}' AND `DOfW <= '{day}' AND `cWeek` <= '{calendarWeek}' AND `evening` = '1';";
            string sql = $@"SELECT count(morning) FROM `shifts` WHERE `EmpID` = '{empID}' AND `Year` <= '{year}' AND `DOfW` <= '{day}' AND `cWeek` <= '{calendarWeek}' AND `morning` = '1'
                        UNION ALL SELECT count(afternoon) FROM `shifts` WHERE `EmpID` = '{empID}' AND `Year` <= '{year}' AND `DOfW` <= '{day}' AND `cWeek` <= '{calendarWeek}' AND `afternoon` = '1'
                        UNION ALL SELECT count(evening) FROM `shifts` WHERE `EmpID` = '{empID}' AND `Year` <= '{year}' AND `DOfW` <= '{day}' AND `cWeek` <= '{calendarWeek}' AND `evening` = '1';";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                count = count + Convert.ToInt32(dr[0]);
            }
            conn.Close();
            return count*8;
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Clear();
            string sql = "SELECT * FROM employee where `ID` != '4';";
            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                employees.Add(new Employee(Convert.ToInt32(dr[0]), Convert.ToString(dr[1]), Convert.ToString(dr[2]), Convert.ToString(dr[18]), Convert.ToString(dr[19])));
            }
            if (employees.Count() >= 1)

            {
                conn.Close();

                return employees;
            }
            else
            {
                conn.Close();

                return null;
            }

        }

        public int GetActiveEmployees()
        {
            int count = 0;
            string sql = "SELECT COUNT(*) FROM employee WHERE `Status` = 'Active';";
            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                count = Convert.ToInt32(dr[0]);
            }
            conn.Close();
            return count;
        }
    }
}
