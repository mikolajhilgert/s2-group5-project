using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Alpha_1._0
{
    public class EmployeeDAL
    {
        protected MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;database=dbi456096;uid=dbi456096;password=logixtic;");//sql connector

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string sql = "SELECT * FROM employee;";
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

        public Employee GetEmployeeByID(int ID)
        {
            Employee employee;
            string sql = $"SELECT * FROM employee WHERE `ID` = @ID;";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    employee = new Employee(Convert.ToInt32(dr["ID"]),Convert.ToString(dr["FirstName"]), Convert.ToString(dr["LastName"]), Convert.ToDateTime(dr["DOB"]), Convert.ToString(dr["BSN"]), Convert.ToString(dr["Position"]), Convert.ToInt32(dr["WorkingHours"]), Convert.ToString(dr["PhoneNr"]), Convert.ToString(dr["Address"]), Convert.ToString(dr["Email"]), Convert.ToString(dr["Password"]), Convert.ToString(dr["EmergencyC"]), Convert.ToString(dr["EmergencyR"]), Convert.ToString(dr["EmergencyNr"]), Convert.ToString(dr["Certifications"]), Convert.ToString(dr["Languages"]), Convert.ToDateTime(dr["StartDate"]), Convert.ToDateTime(dr["EndDate"]), Convert.ToInt32(dr["Salary"]));
                    return employee;
                }
            }
            finally
            {
                conn.Close();
            }

            return null;
        }
        public List<Employee> GetAllActiveEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string sql = "SELECT * FROM employee WHERE `Status` = 'Active';";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
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
        public void RemoveEmployeebyId(string id)
        {
            string sql = $"DELETE FROM `employee` WHERE `employee`.`ID` = @ID;";
            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            cmd.Parameters.AddWithValue("@ID", id);
            try
            {
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
            }
            finally
            {
                conn.Close();
            }

        }

        public void ChangeEmployeeStatus(string id, EmployeeStatus status)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"UPDATE `employee` SET `Status` = '{status}' WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

        }

        public void AddEmployee(string first_name, string last_name, DateTime date_of_birth, string bsn, string postion, int workinghours, string phoneNr, string address, string email, string password, string emergencyC, string emergencyR, string emergencyNr, string certifications, string languages, DateTime startDate, DateTime endDate, int salary)
        {
            try
            {
                conn.Open();
                //MessageBox.Show("Data entered succesfully.");
                MySqlCommand cmd = new MySqlCommand($@"INSERT INTO employee (FirstName, LastName, DOB, BSN, Position, WorkingHours, PhoneNr, Address, Email, Password, EmergencyC, EmergencyR, EmergencyNr, Certifications, Languages, StartDate, EndDate, Salary) VALUES (@FirstName, @LastName, @DOB, @BSN, @Position, @WorkingHours, @PhoneNr, @Address, @Email, @Password, @EmergencyC, @EmergencyR, @EmergencyNr, @Certifications, @Languages, @StartDate, @EndDate, @Salary);", conn);
                //cmd.Parameters.AddWithValue("@employeeID", Convert.ToInt32(tbEmployeeID.Text));

                cmd.Parameters.AddWithValue("@FirstName", first_name);
                cmd.Parameters.AddWithValue("@LastName", last_name);
                cmd.Parameters.AddWithValue("@DOB", date_of_birth);
                cmd.Parameters.AddWithValue("@BSN", bsn);
                cmd.Parameters.AddWithValue("@Position", postion);
                cmd.Parameters.AddWithValue("@WorkingHours", workinghours);
                cmd.Parameters.AddWithValue("@PhoneNr", phoneNr);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@EmergencyC", emergencyC);
                cmd.Parameters.AddWithValue("@EmergencyR", emergencyR);
                cmd.Parameters.AddWithValue("@EmergencyNr", emergencyNr);
                cmd.Parameters.AddWithValue("@Certifications", certifications);
                cmd.Parameters.AddWithValue("@Languages", languages);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@Salary", salary);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
        public void EditEmployee(int id, string first_name, string last_name, DateTime date_of_birth, string bsn, string postion, int workinghours, string phoneNr, string address, string email, string password, string emergencyC, string emergencyR, string emergencyNr, string certifications, string languages, DateTime startDate, DateTime endDate, int salary)
        {
            try
            {
                conn.Open();
                //MessageBox.Show("Data entered succesfully.");
                MySqlCommand cmd = new MySqlCommand($"UPDATE `employee` SET `FirstName` = '{first_name}', `LastName` = '{last_name}', `BSN` = '{bsn}', `Position` = '{postion}', `WorkingHours` = '{Convert.ToInt32(workinghours)}', `PhoneNr` = '{phoneNr}', `Address` = '{address}', `Email` = '{email}', `Password` = '{password}',`EmergencyC` = '{emergencyC}', `EmergencyR` = '{emergencyR}', `EmergencyNr`= '{emergencyNr}', `Certifications`= '{certifications}', `Languages` = '{languages}', `StartDate`= '{startDate.ToString("yyyy/MM/dd")}', `EndDate` = '{endDate.ToString("yyyy/MM/dd")}', `Salary` = '{salary}' WHERE `ID` = {id};", conn);
                cmd.Parameters.AddWithValue("@FirstName", first_name);
                cmd.Parameters.AddWithValue("@LastName", last_name);
                cmd.Parameters.AddWithValue("@DOB", date_of_birth);
                cmd.Parameters.AddWithValue("@BSN", bsn);
                cmd.Parameters.AddWithValue("@Position", postion);
                cmd.Parameters.AddWithValue("@WorkingHours", workinghours);
                cmd.Parameters.AddWithValue("@PhoneNr", phoneNr);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@EmergencyC", emergencyC);
                cmd.Parameters.AddWithValue("@EmergencyR", emergencyR);
                cmd.Parameters.AddWithValue("@EmergencyNr", emergencyNr);
                cmd.Parameters.AddWithValue("@Certifications", certifications);
                cmd.Parameters.AddWithValue("@Languages", languages);
                cmd.Parameters.AddWithValue("@StartDate", startDate.ToShortDateString());
                cmd.Parameters.AddWithValue("@EndDate", endDate.ToShortDateString());
                cmd.Parameters.AddWithValue("@Salary", salary);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
