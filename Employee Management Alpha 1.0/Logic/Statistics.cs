using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

        public int GetEmpTimePerShift(int empID)
        {
            int count = 0;
            string sql;
            return count;
        }
        public List<Employee> GetAllActiveEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Clear();
            string sql = "SELECT * FROM employee WHERE `Status` = 'Active';";
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
    }
}
