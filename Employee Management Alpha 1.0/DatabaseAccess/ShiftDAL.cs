using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Alpha_1._0
{

    public class ShiftDAL
    {
        protected MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;database=dbi456096;uid=dbi456096;password=logixtic;");//sql connector

        public List<Shift> ReturnAllEmps()
        {
            List<Shift> items = new List<Shift>();

            string sql = $@"SELECT e.ID,e.Status as EmpStatus, CONCAT(e.FirstName, ' ' , e.LastName) AS Name, BannedDays
                            FROM employee AS e
                            HAVING e.Status = 'Active'";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    items.Add(new Shift(Convert.ToInt32(dr["ID"]), Convert.ToString(dr["Name"]), Convert.ToString(dr["BannedDays"])));
                }
                conn.Close();
                if (items.Count() < 1)
                {
                    return null;
                }
                else
                {
                    return items;
                }
            }
            finally
            {
                conn.Close();
            }

        }
        public List<Shift> ReturnScheduledEmployees(int cWeek, int year)
        {
            List<Shift> items = new List<Shift>();

            string sql = $@"SELECT e.Status as EmpStatus, s.ShiftID, s.EmpID, CONCAT(e.FirstName, ' ' , e.LastName) AS Name, s.DofW,s.morning, s.afternoon, s.evening, s.Year, s.cWeek
                            FROM shifts as s 
                            INNER JOIN employee as e ON s.EmpID = e.ID
                            WHERE s.Year = {year} AND s.cWeek = {cWeek} OR (s.Year = {year} AND s.cWeek = {cWeek - 1} AND s.DofW = '7' AND evening = '1') OR (s.Year = {year} AND s.cWeek = {cWeek + 1} AND s.DofW = '1' AND morning = '1')
                            HAVING e.Status = 'Active'";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            try
            {
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    items.Add(new Shift(Convert.ToInt32(dr["ShiftID"]), Convert.ToInt32(dr["DofW"]), Convert.ToInt32(dr["EmpID"]), Convert.ToString(dr["Name"]), Convert.ToBoolean(dr["morning"]), Convert.ToBoolean(dr["afternoon"]), Convert.ToBoolean(dr["evening"]), Convert.ToInt32(dr["Year"]), Convert.ToInt32(dr["cWeek"])));
                }
                conn.Close();

                if (items.Count() < 1)
                {
                    return null;
                }
                else
                {
                    return items;
                }
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Shift> ReturnHoursScheduledInWeek(int cWeek, int year)
        {
            List<Shift> employees = new List<Shift>();
            Shift temp;
            string sql = $@"SELECT e.ID,CONCAT(e.FirstName, ' ' , e.LastName) AS Name,e.WorkingHours,COALESCE(SUM(c.morning), 0) + COALESCE(SUM(c.afternoon), 0) + COALESCE(SUM(c.evening), 0) AS shiftsTotal
                            FROM employee as e
                            left JOIN (select * from shifts as s where s.Year = '{year}' AND s.cWeek = '{cWeek}')c
                            ON e.ID = c.EmpID
                            GROUP BY e.ID;";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            try
            {
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    temp = new Shift(Convert.ToInt32(dr[0]), Convert.ToString(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]) * 8);
                    //MessageBox.Show($"{temp.contractHours}   {temp.workedHours}");
                    employees.Add(temp);
                }
                if (employees.Count() > 0)
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
            finally
            {
                conn.Close();
            }

        }
        public void AssignEmployeeToShift(string shiftTimeToDb,string toEdit,int cWeek, int year,int employeeID, int dow)
        {
            string sql_insert;
            string sql_check;
            int duplicateID = -1;
            sql_check = $@"SELECT ShiftID FROM `shifts` WHERE DofW = {dow} AND Year = {year} AND cWeek = {cWeek} AND EmpID = {employeeID};";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql_check, this.conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    duplicateID = Convert.ToInt32(dr["ShiftID"]);
                }
            }
            finally
            {
                conn.Close();
            }

            if (duplicateID == -1)
            {
                sql_insert = $@"INSERT INTO `shifts` (EmpID, DofW, morning, afternoon, evening, Year, cWeek)
                            VALUES ('{employeeID}', '{dow}', {shiftTimeToDb}, {year}, {cWeek});";
            }
            else
            {
                sql_insert = $@"UPDATE `shifts` SET {toEdit} = '1' WHERE ShiftID = {duplicateID}";
            }
            try
            {
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand(sql_insert, this.conn);
                cmd1.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
        public void UnAssignEmployeeToShift(int cWeek, int year,string shiftTimeToDb, int employeeID, int tod, int dow)
        {
            string sql_update = $@"UPDATE `shifts` SET {shiftTimeToDb} = '0' WHERE `DofW` = '{dow}' AND `EmpID` = '{employeeID}' AND `{shiftTimeToDb}` = '1' AND `Year` = {year} AND `cWeek` = {cWeek};";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql_update, this.conn);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        public void ClearWeek(int cWeek, int year)
        {
            string sql_delete = $@"DELETE FROM `shifts` WHERE  `Year` = {year} AND `cWeek` = {cWeek};";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql_delete, this.conn);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        public int ReturnEmpHourPotential()
        {
            int MaxHours = 0;

            string sql = $@"SELECT e.WorkingHours,e.Status as EmpStatus
                            FROM employee AS e
                            HAVING e.Status = 'Active'";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr[0]) == 0)
                    {
                        MaxHours += 40;
                    }
                    else
                    {
                        MaxHours += Convert.ToInt32(dr[0]);
                    }
                }
            }
            finally
            {
                conn.Close();
            }
            return MaxHours;
        }
    }

}
