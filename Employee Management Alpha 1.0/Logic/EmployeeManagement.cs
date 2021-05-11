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
    public class EmployeeManagement
    {
        protected EmployeeDAL db = new EmployeeDAL();
        public List<Employee> GetAllEmployees()
        {
            return db.GetAllEmployees();
        }

        public Employee GetEmployeeByID(int ID)
        {
            return db.GetEmployeeByID(ID);
        }
        public List<Employee> GetAllActiveEmployees()
        {
            return db.GetAllActiveEmployees();
        }

        public void RemoveEmployeebyId(string id)
        {
            db.RemoveEmployeebyId(id);
        }
        public void ChangeEmployeeStatus(string id, EmployeeStatus status)
        {
            db.ChangeEmployeeStatus(id, status);
        }

        public void AddEmployee(string first_name, string last_name, DateTime date_of_birth, string bsn, string postion, int workinghours, string phoneNr, string address, string email, string password, string emergencyC, string emergencyR, string emergencyNr, string certifications, string languages, DateTime startDate, DateTime endDate, int salary)
        {
            db.AddEmployee(first_name,last_name,date_of_birth,bsn,postion,workinghours,phoneNr,address, email, password, emergencyC,emergencyR,emergencyNr,certifications,languages,startDate,endDate,salary);
        }

        public void EditEmployee(int id, string first_name, string last_name, DateTime date_of_birth, string bsn, string postion, int workinghours, string phoneNr, string address, string email, string password, string emergencyC, string emergencyR, string emergencyNr, string certifications, string languages, DateTime startDate, DateTime endDate, int salary)
        {
            db.EditEmployee(id,first_name, last_name, date_of_birth, bsn, postion, workinghours, phoneNr, address, email, password, emergencyC, emergencyR, emergencyNr, certifications, languages, startDate, endDate, salary);
        }
    }
}


