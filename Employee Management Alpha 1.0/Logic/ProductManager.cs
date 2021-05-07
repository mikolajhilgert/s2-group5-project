using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Alpha_1._0
{
    public class ProductManager
    {
        private List<Product> products = new List<Product>();
        private StockDAL db = new StockDAL();

        public List<Product> RefreshProducts()
        {
            this.products = db.GetAllProducts();
            return this.products;
        }

        public void AddProduct(string name, decimal pricepreunit, string categ)
        {
            Enum.TryParse(categ, out ProductCategory category);

            Product temp = new Product(name, 0, 0, pricepreunit, category);

            db.AddProduct(name, pricepreunit, categ);
        }

        public void EditProduct(int id,string name, decimal pricepreunit, string categ)
        {
            db.EditProduct(id,name, pricepreunit, categ);
        }

        public void DeleteProduct(int id)
        {
            db.DeleteProduct(id);
        }

        public void SellProduct(int id, int amount)
        {
            db.SellProduct(id, amount);
        }

        public Product GetProductByID(int id)
        {
            RefreshProducts();
            foreach (Product product in products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }

            return null;
        }
    }
}
