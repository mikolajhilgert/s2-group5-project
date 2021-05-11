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
        protected int year;
        protected int cWeek;
        protected int empsAssigned = 0;
        protected ShiftDAL db = new ShiftDAL();

        public ShiftManagement(int year, int cWeek)
        {
            this.year = year;
            this.cWeek = cWeek;
        }


        public void AutoScheduleWeek(int inputLimit, bool onePerShift)
        {
            int limit = inputLimit;
            int runAgain = 0;
            if (onePerShift)
            {
                //List<Shift> allEmps = ReturnHoursScheduledInWeek();
                //int empPotentialHours = 0;
                //foreach (var emp in allEmps)
                //{
                //    empPotentialHours += emp.contractHours;
                //}
                //if (empPotentialHours < 168) { limit = 1; runAgain = 1; }
                limit = 1; runAgain = 1;
            }
            for (int i = 0; i <= runAgain; i++)
            {
                for (int dow = 1; dow <= 7; dow++)
                {
                    for (int tod = 1; tod <= 3; tod++)
                    {
                        List<Shift> available = ReturnAvailableEmployees(tod, dow);
                        Random rnd = new Random();
                        for (int assigned = 1; assigned <= limit; assigned++)
                        {
                            if (available.Count >= 1)
                            {
                                int selectedEmp = rnd.Next(0, available.Count); // creates a number from available emps
                                AssignEmployeeToShift(available[selectedEmp].employeeID, tod, dow);
                                available.RemoveAt(selectedEmp);
                            }
                        }
                    }
                }
            }
        }

        public List<Shift> ReturnAvailableEmployees(int tod, int dow)
        {
            List<Shift> Scheduled = this.ReturnScheduledEmployees();
            List<Shift> All = db.ReturnAllEmps();
            List<Shift> HoursScheduled = db.ReturnHoursScheduledInWeek(cWeek, year);
            List<Shift> isAvailable = new List<Shift>();
            foreach (Shift person in All)
            {
                bool wasScheduled = false;

                if (person.bannedDay1 == dow || person.bannedDay2 == dow) { wasScheduled = true; }

                if (Scheduled != null && wasScheduled == false)
                {
                    foreach (Shift scheduledPerson in Scheduled)
                    {
                        if (person.employeeID == scheduledPerson.employeeID)
                        {
                            if ((tod == 1 && CheckPreviousEvening(scheduledPerson.employeeID, dow, cWeek)) || (tod == 3 && CheckNextMorning(scheduledPerson.employeeID, dow, cWeek)))
                            {
                                wasScheduled = true;
                            }

                            if (scheduledPerson.DoW == dow && scheduledPerson.cWeek == cWeek && wasScheduled == false)
                            {
                                foreach (Shift hours in HoursScheduled)
                                {
                                    if (hours.employeeID == scheduledPerson.employeeID)
                                    {
                                        if (hours.contractHours - hours.workedHours > 0 || hours.contractHours == 0 && hours.workedHours < 40)
                                        {
                                            if ((tod == 1) && (scheduledPerson.morning == false) && (scheduledPerson.afternoon == false))
                                            {
                                                isAvailable.Add(hours);
                                            }
                                            if ((tod == 2) && (scheduledPerson.afternoon == false) && (scheduledPerson.morning == false))
                                            {
                                                isAvailable.Add(hours);
                                            }
                                            if ((tod == 3) && (scheduledPerson.evening == false) && (scheduledPerson.afternoon == false))
                                            {
                                                isAvailable.Add(hours);
                                            }
                                            wasScheduled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (wasScheduled == false)
                {
                    foreach (Shift hours in HoursScheduled)
                    {
                        if (hours.employeeID == person.employeeID)
                        {
                            if (hours.contractHours - hours.workedHours > 0 || hours.contractHours == 0) { isAvailable.Add(hours); }
                        }
                    }
                }
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
                    if (dow - 1 == 0)
                    {
                        CWeek = CWeek - 1;
                        dow = 8;
                    }
                    if (scheduledPerson.DoW == dow - 1 && scheduledPerson.cWeek == CWeek)
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
            return db.ReturnScheduledEmployees(cWeek,year);
        }

        public List<Shift> ReturnEmployeesByShift(int tod, int dow)
        {
            List<Shift> employees = new List<Shift>();
            List<Shift> scheduledEmployees = this.ReturnScheduledEmployees();
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
            string shiftTimeToDb;
            string toEdit;
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
            db.AssignEmployeeToShift(shiftTimeToDb,toEdit,cWeek,year,employeeID,dow);
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

            db.UnAssignEmployeeToShift(cWeek,year,shiftTimeToDb,employeeID,tod,dow);

        }

        //public bool HasShiftsRemaining(int empID)
        //{
        //    int count = 0;
        //    int contract = 0;
        //    string sql = $@"SELECT count(morning) FROM `shifts` WHERE `EmpID` = '{empID}' AND `morning` = '1' AND `cWeek` = {cWeek} UNION ALL SELECT count(afternoon) FROM `shifts` WHERE `EmpID` = '{empID}' AND `afternoon` = '1' AND `cWeek` = {cWeek} UNION ALL SELECT count(evening) FROM `shifts` WHERE `EmpID` = '{empID}' AND `evening` = '1' AND `cWeek` = {cWeek};";
        //    string sql2 = $@"SELECT e.ContractType WHERE `EmpID` = '{empID}';";

        //    MySqlCommand cmd = new MySqlCommand(sql, this.conn);

        //    conn.Open();
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        count = count + Convert.ToInt32(dr[0]);
        //    }
        //    conn.Close();


        //    MySqlCommand cmd2 = new MySqlCommand(sql2, this.conn);
        //    conn.Open();
        //    MySqlDataReader dr2 = cmd2.ExecuteReader();
        //    while (dr2.Read())
        //    {
        //        contract = Convert.ToInt32(dr[0]);
        //    }
        //    conn.Close();
        //    if (contract - (8 * count) > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}