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
        protected MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;database=dbi456096;uid=dbi456096;password=logixtic;default command timeout=0");//sql connector

        public List<Shift> ReturnAllEmps()
        {
            List<Shift> items = new List<Shift>();

            string sql = $@"SELECT e.ID,e.Status as EmpStatus, CONCAT(e.FirstName, ' ' , e.LastName) AS Name, BannedDays
                            FROM employee AS e
                            WHERE e.Position != 'Admin'
                            HAVING e.Status = 'Active'";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read() && (dr != null))
                {
                    items.Add(new Shift(Convert.ToInt32(dr["ID"]), Convert.ToString(dr["Name"]), Convert.ToString(dr["BannedDays"])));
                }
                return items;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Shift> ReturnAllEmpsWithHours()
        {
            List<Shift> items = new List<Shift>();

            string sql = $@"SELECT e.ID,e.Status as EmpStatus, CONCAT(e.FirstName, ' ' , e.LastName) AS Name, BannedDays
                            FROM employee AS e
                            WHERE e.Position != 'Admin'
                            HAVING e.Status = 'Active'";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read() && (dr != null))
                {
                    items.Add(new Shift(Convert.ToInt32(dr["ID"]), Convert.ToString(dr["Name"]), Convert.ToString(dr["BannedDays"])));
                }
                return items;
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
                while (dr.Read() && (dr != null))
                {
                    items.Add(new Shift(Convert.ToInt32(dr["ShiftID"]), Convert.ToInt32(dr["DofW"]), Convert.ToInt32(dr["EmpID"]), Convert.ToString(dr["Name"]), Convert.ToBoolean(dr["morning"]), Convert.ToBoolean(dr["afternoon"]), Convert.ToBoolean(dr["evening"]), Convert.ToInt32(dr["Year"]), Convert.ToInt32(dr["cWeek"])));
                }
                return items;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Shift> ReturnDayAttendence(int cWeek, int year, int dow)
        {
            List<Shift> items = new List<Shift>();

            string sql = $@"select sa.shiftID,sa.morning,sa.afternoon,sa.evening,sa.status,sa.EmpID,CONCAT(emp.FirstName, ' ' , emp.LastName) AS Name
            from shiftattendance as sa
            INNER JOIN (select ID,FirstName,LastName from employee as e)emp
            ON emp.ID = sa.EmpID
            inner JOIN (select ShiftID from shifts as s where s.Year = '{year}' AND s.cWeek = '{cWeek}' AND s.DofW = '{dow}')shift
            ON shift.ShiftID = sa.shiftID
            ORDER BY sa.morning DESC,sa.afternoon DESC,sa.evening DESC; ";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            try
            {
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    items.Add(new Shift(Convert.ToInt32(dr["EmpID"]), Convert.ToString(dr["Name"]), Convert.ToBoolean(dr["morning"]), Convert.ToBoolean(dr["afternoon"]), Convert.ToBoolean(dr["evening"]), Convert.ToBoolean(dr["status"])));
                }
                return items;
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
            string sql = $@"SELECT e.ID,CONCAT(e.FirstName, ' ' , e.LastName) AS Name,e.WorkingHours,COALESCE(SUM(c.morning), 0) + COALESCE(SUM(c.afternoon), 0) + COALESCE(SUM(c.evening), 0) AS shiftsTotal, e.Position
                            FROM employee as e
                            left JOIN (select * from shifts as s where s.Year = '{year}' AND s.cWeek = '{cWeek}')c
                            ON e.ID = c.EmpID
                            WHERE e.Position != 'Admin'
                            GROUP BY e.ID;";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            try
            {
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read() && (dr != null))
                {
                    temp = new Shift(Convert.ToInt32(dr[0]), Convert.ToString(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]) * 8);
                    //MessageBox.Show($"{temp.contractHours}   {temp.workedHours}");
                    employees.Add(temp);
                }
                return employees;
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
                while (dr.Read() && (dr != null))
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
                sql_insert = $@"
                            BEGIN;
                            INSERT INTO `shifts` (EmpID, DofW, morning, afternoon, evening, Year, cWeek)
                            VALUES ('{employeeID}', '{dow}', {shiftTimeToDb}, {year}, {cWeek});
                            INSERT INTO `shiftattendance` (shiftID,empID,morning,afternoon,evening)
                            VALUES (LAST_INSERT_ID(),'{employeeID}',{shiftTimeToDb});
                            COMMIT;";
            }
            else
            {
                sql_insert = $@"BEGIN;
                            UPDATE `shifts` SET {toEdit} = '1' WHERE ShiftID = {duplicateID};
                            INSERT INTO `shiftattendance` (shiftID,empID,morning,afternoon,evening)
                            VALUES ('{duplicateID}','{employeeID}',{shiftTimeToDb});
                            COMMIT;";
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
            DeleteAttendenceInstance( cWeek,  year,  employeeID, shiftTimeToDb,  dow);
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
            DeleteAttendenceInstance(cWeek, year);
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
                    MaxHours += Convert.ToInt32(dr[0]);
                    //if (Convert.ToInt32(dr[0]) == 0)
                    //{
                    //    MaxHours += 40;
                    //}
                    //else
                    //{
                    //    MaxHours += Convert.ToInt32(dr[0]);
                    //}
                }
                return MaxHours;
            }
            finally
            {
                conn.Close();
            }
        }
        private void DeleteAttendenceInstance(int cWeek, int year, int employeeID, string shiftTimeToDb, int dow)
        {
            string sql_delete = $@"DELETE FROM shiftattendance
                                    WHERE shiftID IN
                                    (
                                        SELECT ShiftID  
                                        FROM shifts 
                                        WHERE `DofW` = '{dow}' AND `EmpID` = '{employeeID}' AND `Year` = {year} AND `cWeek` = {cWeek} AND `{shiftTimeToDb}` = '1'
                                    )";
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
        private void DeleteAttendenceInstance(int cWeek, int year)
        {
            string sql_delete = $@"DELETE FROM shiftattendance
                                    WHERE shiftID IN
                                    (
                                        SELECT ShiftID  
                                        FROM shifts 
                                        WHERE `Year` = {year} AND `cWeek` = {cWeek}
                                    )";
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

        public int ShiftScheduledCount(int dow, string dayToDB, int year, int cWeek)
        {
            int count = 0;
            string sql = $@"SELECT count(*) FROM `shifts` WHERE DofW = {dow} AND {dayToDB} = 1 AND Year = '{year}' AND cWeek = '{cWeek}' ";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    count = Convert.ToInt32(dr[0]);
                }
                return count;
            }
            finally
            {
                conn.Close();
            }
        }
    }


}
