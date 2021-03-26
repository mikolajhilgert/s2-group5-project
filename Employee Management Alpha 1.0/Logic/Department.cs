using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Alpha_1._0
{
    public class Department : IComparable<Department>
    {
        //fields
        private int id;
        private string name;
        private string headOfDepartment;
        private string address;
        private int phone;
        private string email;
        private string language;
        private int status;
        //properties
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string HeadOfDepartment
        {
            get { return this.headOfDepartment; }
            set { this.headOfDepartment = value; }
        }
        public string Address
        {
            get { return this.address; }
            set { this.address  = value; }
        }
        public int Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string Language
        {
            get { return this.language; }
            set { this.language = value; }
        }
        public int Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        //constructor(s)
        public Department(int id, string name, string headOfDepartment, string address, int phone, string email, string language, int status)
        {
            this.id = id;
            this.name = name;
            this.headOfDepartment = headOfDepartment;
            this.address = address;
            this.phone = phone;
            this.email = email;
            this.language = language;
            this.status = status;
        }
        public Department() { }
        //methods
        public override string ToString()
        {
            string temp;
            if (Status == 1)
                temp = "Active";
            else
                temp = "Inactive";

            return $"{Id} - {Name}  ({temp})";
            //add head of department
        }

        public int CompareTo(Department other)
        {
            switch (this.Status.CompareTo(other.Status))
            {
                case 1:
                    return -1;
                case -1:
                    return 1;
                case 0:
                    return this.Id.CompareTo(other.Id);
                default:
                    return 0;
            }
        }
    }
}
