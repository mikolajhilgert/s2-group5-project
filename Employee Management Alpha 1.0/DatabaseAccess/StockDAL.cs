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
        public void AddProduct(string name, decimal PricePerUnit, string categ)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO product (Name,PricePerItem,Category) VALUES(@name,@price,@cat)", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", PricePerUnit);
            cmd.Parameters.AddWithValue("@cat", categ);
            
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditProduct(int id, string name, decimal PricePerUnit, string categ)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"UPDATE product SET Name = @name,PricePerItem = @price,Category=@cat WHERE ID=@ID", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", PricePerUnit);
            cmd.Parameters.AddWithValue("@cat", categ);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteProduct(int id)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"DELETE FROM product WHERE ID=@ID", conn); 
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Product> GetAllProducts()
        {
            List<Product> allProducts = new List<Product>();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM product", conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                //System.Windows.Forms.MessageBox.Show($"{dr[0]} {dr[1]} {dr[2]} {dr[3]} {dr[4]} {dr[5]}");
                allProducts.Add(new Product(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToDecimal(dr[4]), (ProductCategory)Enum.Parse(typeof(ProductCategory), dr[5].ToString())));
            }
            conn.Close();

            return allProducts;
        }
        public void AddDepoStock(int id, int requestAmount)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"UPDATE product SET DepoQuantity = DepoQuantity+@amount WHERE ID=@ID", conn);
            cmd.Parameters.AddWithValue("@amount", requestAmount);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void SellProduct(int id, int amount)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"UPDATE product SET StoreQuantity = StoreQuantity-@amount WHERE ID=@ID", conn);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.ExecuteNonQuery();

            conn.Close();
            AddToSales( id,amount);
        }

        public void AddToSales(int id, int amount)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO sales (ProductID,Quantity) VALUES(@ID,@amount)", conn);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
