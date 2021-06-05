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
    static class DepartmentManagement
    {
        private static List<Department> departments = DepartmentDAL.GetAllDepartments();
        public static void CreateDepartment(string name, string headOfDepartment, string address, int phone, string email, string language)
        {
            DepartmentDAL.CreateDepartment(name,headOfDepartment,address,phone,email,language);
        }
        public static Department GetDepartmentByID(int id)
        {
            //return DepartmentDAL.GetDepartmentByID(id);
            foreach (Department department in departments)
            {
                if (department.Id == id)
                    return department;
            }
            return null;
        }
        public static List<Department> GetAllDepartments()
        {
            departments = DepartmentDAL.GetAllDepartments();
            return departments;
        }
        public static List<Department> GetAllActiveDepartments()
        {
            return DepartmentDAL.GetAllActiveDepartments();
        }
        public static void UpdateDepartment(int id, string name, string headOfDepartment, string address, int phone, string email, string language)
        {
            DepartmentDAL.UpdateDepartment(id, name, headOfDepartment, address, phone, email, language);
        }
        public static void DeleteDepartment(int id)
        {
            DepartmentDAL.DeleteDepartment(id);
        }
        public static void AssignEmployee(Employee e, Department d)
        {
            DepartmentDAL.AssignEmployee(e, d);
        }
        public static void UnassignEmployee(Employee e)
        {
            DepartmentDAL.UnassignEmployee(e);
        }
        public static List<Employee> GetAllAvailableEmployeesForDepartment(Department d)
        {
            return DepartmentDAL.GetAllAvailableEmployeesForDepartment(d);
        }
        public static List<Employee> GetAllAssignedEmployeesForDepartment(Department d)
        {
            return DepartmentDAL.GetAllAssignedEmployeesForDepartment(d);
        }
        public static List<Product> GetProductsForDepartment(Department d)
        {
            return DepartmentDAL.GetProductsForDepartment(d);
        }
        public static decimal GetProfitForDepartment(Department d)
        {
            ProductManager productManager = new ProductManager();
            decimal totalProfit = 0;
            foreach (Product product in GetProductsForDepartment(d))
            {
                int sales = productManager.GetAmountOfSales(product);
                decimal price = product.PricePerUnit;

                totalProfit += sales * price;
            }
            return totalProfit;
        }
        public static void ChangeStatus(Department d)
        {
            DepartmentDAL.ChangeStatus(d);
        }
    }
}
