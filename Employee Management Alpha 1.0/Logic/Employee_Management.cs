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
    public class Employee_Management
    {
        MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;database=dbi456096;uid=dbi456096;password=logixtic;");//sql connector
        //attributes
        private List<Employee> employees;
        private Employee employee; //temporary storage for adding to the list

        //constructor
        public Employee_Management()
        {
            this.employees = new List<Employee>();
        }

        //methods

        public Employee GetEmployeebyID(int itemId)
        {


            if (GetAllEmployees().Count > 0)//For cycle runs into an error if list is empty, so we check it here and skip the cycle if it's empty
            {
                for (int i = 0; i < GetAllEmployees().Count; i++)
                {
                    if (GetAllEmployees()[i].Id == itemId)
                    {
                        return GetAllEmployees()[i];
                    }
                }
            }
            return null;
        }



        public List<Employee> GetAllEmployees()
        {
            employees.Clear();
            string sql = "SELECT * FROM employee;";
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

        public Employee ReturnEmployeeByID(int ID)
        {
            employees.Clear();
            string sql = $"SELECT * FROM employee WHERE `ID` = {ID};";
            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                employee = new Employee(Convert.ToString(dr["FirstName"]), Convert.ToString(dr["LastName"]), Convert.ToDateTime(dr["DOB"]), Convert.ToString(dr["BSN"]), Convert.ToString(dr["Position"]), Convert.ToInt32(dr["WorkingHours"]), Convert.ToString(dr["PhoneNr"]), Convert.ToString(dr["Address"]), Convert.ToString(dr["Email"]), Convert.ToString(dr["EmergencyC"]), Convert.ToString(dr["EmergencyR"]), Convert.ToString(dr["EmergencyNr"]), Convert.ToString(dr["Certifications"]), Convert.ToString(dr["Languages"]), Convert.ToString(dr["ContractType"]), Convert.ToString(dr["ContractDuration"]), Convert.ToInt32(dr["Salary"]));
                conn.Close();
                return employee;
            }
            return null;
        }

        public List<Employee> GetAllActiveEmployees()
        {
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


        public void RemoveEmployeebyId(string id)
        {
            string sql = $"DELETE FROM `employee` WHERE `employee`.`ID` = {id};";
            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            try
            {
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        public void ChangeEmployeeStatus(string id, EmployeeStatus status)
        {
            //this.employee = new Employee(); //instantiate a new object of type employee
            //this.employees.Add(employee); //add it to list of type employee
            MySqlConnection connection;
            string connectionString;
            connectionString = "server=studmysql01.fhict.local;database=dbi456096;uid=dbi456096;password=logixtic;";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    //MessageBox.Show("Data entered succesfully.");
                    MySqlCommand cmd = new MySqlCommand($"UPDATE `employee` SET `Status` = '{status}' WHERE ID = {id}", connection);
                    cmd.ExecuteNonQuery();


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }
        

        public void AddEmployee(string first_name, string last_name, DateTime date_of_birth, string bsn, string postion, int workinghours, string phoneNr, string address, string email, string emergencyC, string emergencyR, string emergencyNr, string certifications, string languages, string contract, string duration, int salary)
        {
            this.employee = new Employee(first_name, last_name, date_of_birth, bsn, postion, workinghours, phoneNr, address, email, emergencyC, emergencyR, emergencyNr, certifications, languages, contract, duration, salary); //instantiate a new object of type employee
            this.employees.Add(employee); //add it to list of type employee
            MySqlConnection connection;
            string connectionString;
            connectionString = "server=studmysql01.fhict.local;database=dbi456096;uid=dbi456096;password=logixtic;";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    //MessageBox.Show("Data entered succesfully.");
                    MySqlCommand cmd = new MySqlCommand($@"INSERT INTO employee (FirstName, LastName, DOB, BSN, Position, WorkingHours, PhoneNr, Address, Email, EmergencyC, EmergencyR, EmergencyNr, Certifications, Languages, ContractType, ContractDuration, Salary) VALUES (@FirstName, @LastName, @DOB, @BSN, @Position, @WorkingHours, @PhoneNr, @Address, @Email, @EmergencyC, @EmergencyR, @EmergencyNr, @Certifications, @Languages, @ContractType, @ContractDuration, @Salary);", connection);
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
                    cmd.Parameters.AddWithValue("@EmergencyC", emergencyC);
                    cmd.Parameters.AddWithValue("@EmergencyR", emergencyR);
                    cmd.Parameters.AddWithValue("@EmergencyNr", emergencyNr);
                    cmd.Parameters.AddWithValue("@Certifications", certifications);
                    cmd.Parameters.AddWithValue("@Languages", languages);
                    cmd.Parameters.AddWithValue("@ContractType", contract);
                    cmd.Parameters.AddWithValue("@ContractDuration", duration);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.ExecuteNonQuery();


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }
        
        public void ChangeEmployeeTest(int id, string first_name, string last_name, DateTime date_of_birth, string bsn, string postion, int workinghours, string phoneNr, string address, string email, string emergencyC, string emergencyR, string emergencyNr, string certifications, string languages, string contract, string duration, int salary)
        {
            this.employee = new Employee(first_name, last_name, date_of_birth, bsn, postion, workinghours, phoneNr, address, email, emergencyC, emergencyR, emergencyNr, certifications, languages, contract, duration, salary); //instantiate a new object of type employee
            this.employees.Add(employee); //add it to list of type employee
            MySqlConnection connection;
            string connectionString;
            connectionString = "server=studmysql01.fhict.local;database=dbi456096;uid=dbi456096;password=logixtic;";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    //MessageBox.Show("Data entered succesfully.");
                    MySqlCommand cmd = new MySqlCommand($"UPDATE `employee` SET `FirstName` = '{first_name}', `LastName` = '{last_name}', `BSN` = '{bsn}', `Position` = '{postion}', `WorkingHours` = '{Convert.ToInt32(workinghours)}', `PhoneNr` = '{phoneNr}', `Address` = '{address}', `Email` = '{email}', `EmergencyC` = '{emergencyC}', `EmergencyR` = '{emergencyR}', `EmergencyNr`= '{emergencyNr}', `Certifications`= '{certifications}', `Languages` = '{languages}', `ContractType`= '{contract}', `ContractDuration` = '{duration}, `Salary` = '{salary}' WHERE `ID` = {id};", connection);
                    cmd.Parameters.AddWithValue("@FirstName", first_name);
                    cmd.Parameters.AddWithValue("@LastName", last_name);
                    cmd.Parameters.AddWithValue("@DOB", date_of_birth);
                    cmd.Parameters.AddWithValue("@BSN", bsn);
                    cmd.Parameters.AddWithValue("@Position", postion);
                    cmd.Parameters.AddWithValue("@WorkingHours", workinghours);
                    cmd.Parameters.AddWithValue("@PhoneNr", phoneNr);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@EmergencyC", emergencyC);
                    cmd.Parameters.AddWithValue("@EmergencyR", emergencyR);
                    cmd.Parameters.AddWithValue("@EmergencyNr", emergencyNr);
                    cmd.Parameters.AddWithValue("@Certifications", certifications);
                    cmd.Parameters.AddWithValue("@Languages", languages);
                    cmd.Parameters.AddWithValue("@ContractType", contract);
                    cmd.Parameters.AddWithValue("@ContractDuration", duration);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.ExecuteNonQuery();



                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }
        

    }
}


