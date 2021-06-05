using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Alpha_1._0
{
    public class StockDAL
    {
        protected MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;database=dbi456096;uid=dbi456096;password=logixtic;");//sql connector
        public void AddProduct(string name, decimal PricePerUnit, Department department)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO product (Name,PricePerItem,DepartmentID) VALUES(@name,@price,@departmentID)", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", PricePerUnit);
                cmd.Parameters.AddWithValue("@departmentID", department.Id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        public void EditProduct(int id, string name, decimal PricePerUnit, Department department)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"UPDATE product SET Name = @name,PricePerItem = @price,DepartmentID=@departmentID WHERE ID=@ID", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", PricePerUnit);
                cmd.Parameters.AddWithValue("@departmentID", department.Id);
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM product WHERE ID=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
            
        }

        public List<Product> GetAllProducts()
        {
            List<Product> allProducts = new List<Product>();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM product", conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    allProducts.Add(new Product(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToDecimal(dr[4]), DepartmentManagement.GetDepartmentByID(Convert.ToInt32(dr[5]))));
                }
            }
            finally
            {
                conn.Close();
            }

            return allProducts;
        }
        public void AddDepoStock(int id, int requestAmount)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"UPDATE product SET DepoQuantity = DepoQuantity+@amount WHERE ID=@ID", conn);
                cmd.Parameters.AddWithValue("@amount", requestAmount);
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        public void SellProduct(int id, int amount)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"UPDATE product SET StoreQuantity = StoreQuantity-@amount WHERE ID=@ID", conn);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }


            AddToSales( id,amount);
        }

        public void AddToSales(int id, int amount)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO sales (ProductID,Quantity) VALUES(@ID,@amount)", conn);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

        }
        public int GetAmountOfSales(Product p)
        {
            int amountOfSales = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT SUM(Quantity) FROM `sales` WHERE ProductID = @ID;", conn);
                cmd.Parameters.AddWithValue("@ID", p.Id);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    amountOfSales = Convert.ToInt32(dr[0]);
                }
            }
            finally
            {
                conn.Close();
            }
            return amountOfSales;
        }

        public void AddStockRequest(int productID, int quantity)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO stockrequest (ProductID,Quantity) VALUES(@productID,@quantity)", conn);
                cmd.Parameters.AddWithValue("@productID", productID);
                cmd.Parameters.AddWithValue("@quantity", quantity);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
        public List<StockRequest> GetAllStockRequests()
        {
            List<StockRequest> allStockRequests = new List<StockRequest>();
            ProductManager pm = new ProductManager();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM stockrequest", conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    allStockRequests.Add(new StockRequest(Convert.ToInt32(dr[0]), pm.GetProductByID(Convert.ToInt32(dr[1])), Convert.ToInt32(dr[2]), (RequestStatus)Convert.ToInt32(dr[3])));
                }
            }
            finally
            {
                conn.Close();
            }           

            return allStockRequests;
        }
        public void ChangeStockRequestStatus(int id, int status)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"UPDATE stockrequest SET RequestStatus = @status WHERE ID = @ID", conn);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void MoveStock(int productID, int amount)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"UPDATE product SET DepoQuantity = DepoQuantity-@amount, StoreQuantity = StoreQuantity+@amount WHERE ID=@ID", conn);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@ID", productID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
