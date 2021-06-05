using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Alpha_1._0
{
    public class StatisticsDAL
    {
        protected MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;database=dbi456096;uid=dbi456096;password=logixtic;");//sql connector
        public DateTime GetEmpWorkingDuration(int empID)
        {
            DateTime startDate = DateTime.Now;
            try
            {
                string sql = $@"SELECT StartDate FROM `employee` WHERE `ID` = '{empID}';";

                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    return startDate = Convert.ToDateTime(dr[0]);
                }
            }
            finally
            {
                conn.Close();
            }
            return startDate;

        }

        public int GetEmpTotalTime(int calendarWeek,int year,int empID,int day)
        {
            int count = 0;
            string sql = $@"SELECT count(morning)
                        FROM `shifts`
                        WHERE `EmpID` = '{empID}' AND
                        (`Year` = '{year}'
                        AND `cWeek` < '{calendarWeek}'
                        AND `morning` = '1'
                        ) OR (`EmpID` = '{empID}' AND `Year` < '{year}' AND `morning` = '1')
                        UNION ALL
                        SELECT count(afternoon)
                        FROM `shifts`
                        WHERE `EmpID` = '{empID}' AND
                        (`Year` = '{year}'
                        AND `cWeek` < '{calendarWeek}'
                        AND `afternoon` = '1'
                        ) OR (`EmpID` = '{empID}' AND `Year` < '{year}' AND `afternoon` = '1')
                        UNION ALL
                        SELECT count(evening)
                        FROM `shifts`
                        WHERE `EmpID` = '{empID}' AND
                        (`Year` = '{year}'
                        AND `cWeek` < '{calendarWeek}'
                        AND `evening` = '1'
                        ) OR (`EmpID` = '{empID}' AND `Year` < '{year}' AND `evening` = '1');";

            string sql1 = $@"SELECT count(morning) 
                        FROM `shifts` 
                        WHERE `EmpID` = '{empID}' 
                        AND `Year` = '{year}' 
                        AND `DOfW` <= '{day}' 
                        AND `cWeek` = '{calendarWeek}' 
                        AND `morning` = '1'

                        UNION ALL SELECT count(afternoon) 
                        FROM `shifts` 
                        WHERE `EmpID` = '{empID}' 
                        AND `Year` = '{year}' 
                        AND `DOfW` <= '{day}' 
                        AND `cWeek` = '{calendarWeek}' 
                        AND `afternoon` = '1'

                        UNION ALL SELECT count(evening) 
                        FROM `shifts` 
                        WHERE `EmpID` = '{empID}' 
                        AND `Year` = '{year}' 
                        AND `DOfW` <= '{day}' 
                        AND `cWeek` = '{calendarWeek}' 
                        AND `evening` = '1';";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            MySqlCommand cmd1 = new MySqlCommand(sql1, this.conn);
            try 
            {
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    count = count + Convert.ToInt32(dr[0]);
                }
            }
            finally
            {
                conn.Close();
            }
            try
            {
                conn.Open();
                MySqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    count = count + Convert.ToInt32(dr1[0]);
                }
            }
            finally
            {
                conn.Close();
            }
            return count;
        }
        public int GetActiveEmpsNum()
        {
            int count = 0;
            string sql = "SELECT COUNT(*) FROM employee WHERE `Status` = 'Active';";
            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            try
            {
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    count = Convert.ToInt32(dr[0]);
                }
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string sql = "SELECT * FROM employee WHERE `Position` != 'Admin';";
            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            try
            {
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    employees.Add(new Employee(Convert.ToInt32(dr[0]), Convert.ToString(dr[1]), Convert.ToString(dr[2]), Convert.ToString(dr[18]), Convert.ToString(dr[19])));
                }
                if (employees.Count() >= 1)
                {

                    return employees;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                conn.Close();
            }

        }
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


    }

}
