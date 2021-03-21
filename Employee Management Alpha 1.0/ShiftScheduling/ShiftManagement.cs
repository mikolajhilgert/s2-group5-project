using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Employee_Management_Alpha_1._0
{
    public class ShiftManagement
    {
        protected MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;database=dbi456096;uid=dbi456096;password=logixtic;");//sql connector
        protected int year;
        protected int cWeek;
        protected int empsAssigned = 0;

        public ShiftManagement(int year, int cWeek)
        {
            this.year = year;
            this.cWeek = cWeek;
        }

        public List<Shift> ReturnAllEmps()
        {
            List<Shift> items = new List<Shift>();

            string sql = $@"SELECT e.ID,e.Status as EmpStatus, CONCAT(e.FirstName, ' ' , e.LastName) AS Name
                            FROM employee AS e
                            HAVING e.Status = 'Active'";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                items.Add(new Shift(Convert.ToInt32(dr["ID"]), Convert.ToString(dr["Name"])));
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

        public List<Shift> ReturnAvailableEmployees(int tod, int dow)
        {
            List<Shift> Scheduled = this.ReturnScheduledEmployees();
            List<Shift> All = this.ReturnAllEmps();
            List<Shift> isAvailable = new List<Shift>();
            foreach (Shift person in All)
            {
                bool wasScheduled = false;
                if(Scheduled != null)
                {
                    foreach (Shift scheduledPerson in Scheduled)
                    {

                        if (person.employeeID == scheduledPerson.employeeID)
                        {
                            if ((tod==1 && CheckPreviousEvening(scheduledPerson.employeeID, dow, cWeek)) || (tod == 3 && CheckNextMorning(scheduledPerson.employeeID, dow, cWeek)))
                            {
                                wasScheduled = true;
                            }

                            if (scheduledPerson.DoW == dow && scheduledPerson.cWeek == cWeek && wasScheduled == false )
                            {
                                if ((tod == 1) && (scheduledPerson.morning == false) && (scheduledPerson.afternoon == false))
                                {
                                    isAvailable.Add(person);
                                }
                                if ((tod == 2) && (scheduledPerson.afternoon == false) && (scheduledPerson.morning == false))
                                {
                                    isAvailable.Add(person);
                                }
                                if ((tod == 3) && (scheduledPerson.evening == false) && (scheduledPerson.afternoon == false))
                                {
                                    isAvailable.Add(person);
                                }
                                wasScheduled = true;
                            }
                        }
                    }
                }
                if (wasScheduled == false) { isAvailable.Add(person);}
            }
            return isAvailable;
        }



        private bool CheckPreviousEvening(int empID, int dow, int cWeek)
        {
            int CWeek = cWeek;
            List<Shift> Scheduled = this.ReturnScheduledEmployees();
            foreach (Shift scheduledPerson in Scheduled)
            {
                if (empID == scheduledPerson.employeeID)
                {
                    if(dow-1 == 0)
                    {
                        CWeek = CWeek - 1;
                        dow = 8;
                    }
                    if (scheduledPerson.DoW == dow-1 && scheduledPerson.cWeek == CWeek)
                    {
                        if (scheduledPerson.evening == true) { return true; }
                    }
                }
            }
            return false;
        }

        private bool CheckNextMorning(int empID, int dow, int cWeek)
        {
            int CWeek = cWeek;
            List<Shift> Scheduled = this.ReturnScheduledEmployees();
            foreach (Shift scheduledPerson in Scheduled)
            {
                if (empID == scheduledPerson.employeeID)
                {
                    if (dow + 1 == 8)
                    {
                        CWeek = CWeek + 1;
                        dow = 0;
                    }
                    //MessageBox.Show(dow.ToString());
                    if (scheduledPerson.DoW == dow + 1 && scheduledPerson.cWeek == CWeek)
                    {
                        if (scheduledPerson.morning == true) { return true; }
                    }
                }
            }
            return false;
        }
        public List<Shift> ReturnScheduledEmployees()
        {
            List<Shift> items = new List<Shift>();

            string sql = $@"SELECT e.Status as EmpStatus, s.ShiftID, s.EmpID, CONCAT(e.FirstName, ' ' , e.LastName) AS Name, s.DofW,s.morning, s.afternoon, s.evening, e.Department, s.Year, s.cWeek
                            FROM shifts as s 
                            INNER JOIN employee as e ON s.EmpID = e.ID
                            WHERE s.Year = {year} AND s.cWeek = {cWeek} OR (s.Year = {year} AND s.cWeek = {cWeek - 1} AND s.DofW = '7' AND evening = '1') OR (s.Year = {year} AND s.cWeek = {cWeek + 1} AND s.DofW = '1' AND morning = '1')
                            HAVING e.Status = 'Active'";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                items.Add(new Shift(Convert.ToInt32(dr["ShiftID"]), Convert.ToInt32(dr["DofW"]), Convert.ToInt32(dr["EmpID"]), Convert.ToString(dr["Name"]), Convert.ToBoolean(dr["morning"]), Convert.ToBoolean(dr["afternoon"]), Convert.ToBoolean(dr["evening"]), Convert.ToString(dr["Department"]), Convert.ToInt32(dr["Year"]), Convert.ToInt32(dr["cWeek"])));
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

        public List<Shift> ReturnEmployeesByShift(int tod, int dow)
        {
            List<Shift> employees = new List<Shift>();
            List<Shift> scheduledEmployees = this.ReturnScheduledEmployees();
            //MessageBox.Show(scheduledEmployees.Count.ToString());
            if (scheduledEmployees != null)
            {
                switch (tod)
                {
                    case 1:
                        foreach (Shift e in scheduledEmployees)
                        {
                            if (e.DoW == dow && e.morning && e.cWeek == cWeek)
                            {
                                employees.Add(e);
                            }
                        }
                        break;
                    case 2:
                        foreach (Shift e in scheduledEmployees)
                        {
                            if (e.DoW == dow && e.afternoon && e.cWeek == cWeek)
                            {
                                employees.Add(e);
                            }
                        }
                        break;
                    default:
                        foreach (Shift e in scheduledEmployees)
                        {
                            if (e.DoW == dow && e.evening && e.cWeek == cWeek)
                            {
                                employees.Add(e);
                            }
                        }
                        break;
                }
                return employees;
            }
            return null;
        }

        public void AssignEmployeeToShift(int employeeID, int tod, int dow)
        {
            string sql_insert;
            string sql_check;
            string shiftTimeToDb;
            string toEdit;
            int duplicateID = -1;

            switch (tod)
            {
                case 1:
                    shiftTimeToDb = "'1', '0', '0'";
                    toEdit = "Morning";
                    break;
                case 2:
                    shiftTimeToDb = "'0', '1', '0'";
                    toEdit = "Afternoon";
                    break;
                default:
                    shiftTimeToDb = "'0', '0', '1'";
                    toEdit = "Evening";
                    break;
            }
            sql_check = $@"SELECT ShiftID FROM `shifts` WHERE DofW = {dow} AND Year = {year} AND cWeek = {cWeek} AND EmpID = {employeeID};";


            MySqlCommand cmd = new MySqlCommand(sql_check, this.conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                duplicateID = Convert.ToInt32(dr["ShiftID"]);
            }
            conn.Close();

            if (duplicateID == -1)
            {
                sql_insert = $@"INSERT INTO `shifts` (EmpID, DofW, morning, afternoon, evening, Year, cWeek)
                            VALUES ('{employeeID}', '{dow}', {shiftTimeToDb}, {year}, {cWeek});";
            }
            else
            {
                sql_insert = $@"UPDATE `shifts` SET {toEdit} = '1' WHERE ShiftID = {duplicateID}";
            }

            conn.Open();
            MySqlCommand cmd1 = new MySqlCommand(sql_insert, this.conn);
            cmd1.ExecuteNonQuery();
            conn.Close();
        }

        public void UnAssignEmployeeToShift(int employeeID, int tod, int dow)
        {
            string shiftTimeToDb;
            switch (tod)
            {
                case 1:
                    shiftTimeToDb = "morning";
                    break;
                case 2:
                    shiftTimeToDb = "afternoon";
                    break;
                default:
                    shiftTimeToDb = "evening";
                    break;
            }

            string sql_update = $@"UPDATE `shifts` SET {shiftTimeToDb} = '0' WHERE `DofW` = '{dow}' AND `EmpID` = '{employeeID}' AND `{shiftTimeToDb}` = '1' AND `Year` = {year} AND `cWeek` = {cWeek};";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql_update, this.conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void ClearWeekSchedule()
        {
            string sql_update = $@"UPDATE `shifts` SET Status = '0';";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql_update, this.conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}