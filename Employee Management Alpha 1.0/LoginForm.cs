using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_Alpha_1._0
{
    
    public partial class LoginForm : Form
    {
        public static string userType;
        EmployeeManagement employeeManagement;
        MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;database=dbi456096;uid=dbi456096;password=logixtic;");
        public LoginForm()
        {
            InitializeComponent();
            employeeManagement = new EmployeeManagement();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT Email, Password, Position FROM employee";
                bool correct = false;
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read() && !correct)
                {
                    if (txtUsername.Text == dr[0].ToString() && txtPassword.Text == dr[1].ToString())
                    {
                        correct = true;
                        userType = dr[2].ToString();
                    }
                }
                if (correct)
                {
                    this.Hide();
                    Form1 main = new Form1();
                    main.Closed += (s, args) => this.Close();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect login credentials! Check username/password!");
                }
            }
            finally
            {
                conn.Close();
            }            
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
