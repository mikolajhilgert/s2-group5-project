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

        public void ClearWeek()
        {
            db.ClearWeek(cWeek,year);
        }

        public void AutoScheduleWeek(int inputLimit, bool onePerShift)
        {
            int limit = inputLimit;
            int runAgain = 1;
            if (onePerShift)
            {
                double temp = Math.Ceiling((db.ReturnEmpHourPotential() / 8) / (double)21);
                limit = 1; runAgain = Convert.ToInt32(temp);
            }
            for (int i = 1; i <= runAgain; i++)
            {
                for (int dow = 1; dow <= 7; dow++)
                {
                    AutoScheduleDay(dow,limit);
                }
            }
        }

        private void AutoScheduleDay(int dow, int limit)
        {
            for (int tod = 1; tod <= 3; tod++)
            {
                List<Shift> availableWithContract = new List<Shift>();
                List<Shift> available = new List<Shift>();
                foreach (Shift shift in ReturnAvailableEmployees(tod, dow))
                {
                    if (shift.contractHours == 0)
                    {
                        available.Add(shift);
                    }
                    else
                    {
                        if(shift.contractHours != 0) { availableWithContract.Add(shift); }
                    }
                }

                Random rnd = new Random();
                for (int assigned = 1; assigned <= limit; assigned++)
                {
                    if (availableWithContract.Count > 0)
                    {
                        Queue<Shift> zero = new Queue<Shift>();
                        Queue<Shift> one = new Queue<Shift>();
                        Queue<Shift> two = new Queue<Shift>();
                        Queue<Shift> three = new Queue<Shift>();
                        Queue<Shift> four = new Queue<Shift>();

                        foreach (var person in availableWithContract)
                        {
                            if (person.workedHours == 0) { zero.Enqueue(person); }
                            else if (person.workedHours == 8) { one.Enqueue(person); }
                            else if (person.workedHours == 16) { two.Enqueue(person); }
                            else if (person.workedHours == 24) { three.Enqueue(person); }
                            else if (person.workedHours == 32 && person.contractHours > 32) { four.Enqueue(person); }
                        }

                        if (zero.Count != 0)
                        {
                            AssignEmployeeToShift(zero.Peek().employeeID, tod, dow);
                            zero.Dequeue().workedHours += 8;
                        }
                        else if (one.Count != 0)
                        {
                            AssignEmployeeToShift(one.Peek().employeeID, tod, dow);
                            one.Dequeue().workedHours += 8;
                        }
                        else if (two.Count != 0)
                        {
                            AssignEmployeeToShift(two.Peek().employeeID, tod, dow);
                            two.Dequeue().workedHours += 8;
                        }
                        else if (three.Count != 0)
                        {
                            AssignEmployeeToShift(three.Peek().employeeID, tod, dow);
                            three.Dequeue().workedHours += 8;
                        }
                        else if (four.Count != 0)
                        {
                            AssignEmployeeToShift(four.Peek().employeeID, tod, dow);
                            four.Dequeue().workedHours += 8;
                        }
                    }
                    else if (available.Count != 0 && ScheduledPeople(tod,dow) < limit+1)
                    {
                        int selectedEmp = rnd.Next(0, available.Count); // creates a number from available emps
                        AssignEmployeeToShift(available[selectedEmp].employeeID, tod, dow);
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

                            if (scheduledPerson.DoW == dow && scheduledPerson.cWeek == cWeek && wasScheduled == false && HoursScheduled.Count > 0)
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
                                            else if ((tod == 2) && (scheduledPerson.afternoon == false) && (scheduledPerson.morning == false))
                                            {
                                                isAvailable.Add(hours);
                                            }
                                            else if ((tod == 3) && (scheduledPerson.evening == false) && (scheduledPerson.afternoon == false))
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
                            if (hours.contractHours - hours.workedHours > 0 || (hours.contractHours == 0 && hours.workedHours < 40)) { isAvailable.Add(hours); }
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

        public List<Tuple<int, string>> ReturnDayAttendence(int cWeek, int year, int dow)
        {
            List<Tuple<int, string>> emps = new List<Tuple<int, string>>();
            List<Shift> shifts = db.ReturnDayAttendence(cWeek, year, dow);
            if (shifts != null)
            {
                foreach (var item in shifts)
                {
                    string time = "";
                    if (item.morning)
                    {
                        time = "(Morning)";
                    }else if (item.afternoon)
                    {
                        time = "(Afternoon)";
                    }
                    else if (item.evening)
                    {
                        time = "(Evening)";
                    }

                    if (item.status)
                    {
                        emps.Add(new Tuple<int, string>(1, $"{item.employeeID} {item.empName} {time}"));
                    }
                    else
                    {
                        emps.Add(new Tuple<int, string>(0, $"{item.employeeID} {item.empName} {time}"));
                    }
                }
            }
            return emps;
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

        public int ScheduledPeople(int tod, int dow)
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
            return db.ShiftScheduledCount(dow,shiftTimeToDb, year,cWeek);
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

        public string AutoScheduleAlert(bool isOnePer, int perShift)
        {
            int canAccountFor = db.ReturnEmpHourPotential() / 8;
            int wantedShifts = perShift * 21;

            List<Shift> All = db.ReturnAllEmps();

            string noEmpDays = "";
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

            for (int dow = 1; dow <= 7; dow++)
            {
                int total = All.Count;
                int counter = 0;
                foreach (Shift person in All)
                {
                    if (person.bannedDay1 == dow || person.bannedDay2 == dow)
                    {
                        if (counter == total)
                        {
                            noEmpDays += $"No employee can work on {days[dow - 1]}!\n";
                        }
                    }
                }
            }

            if (isOnePer)
            {
                return $"This option will assign atleast one employee per shift. Then continue to assign employees untill all contract hours are met.\n{noEmpDays}\nThis process is quite taxing and therefore may take a while, especially with many employees! (About a minute to process)\n\nContinue?";
            }
            else if (canAccountFor - wantedShifts >= 0)
            {
                return $"This option will assign {perShift} employee/s to each shift.\n{noEmpDays}\nThis process is quite taxing and therefore may take a while, especially with many employees!\n\nContinue?";
            }
            return $"You dont have enough active employess to accomodate for {perShift} employees per shift. This will leave you with understaffed / empty shifts. (~{wantedShifts - canAccountFor} missing shifts)\n\nContinue anyway?";
        }

    }
}