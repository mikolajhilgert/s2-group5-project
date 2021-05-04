using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Alpha_1._0
{
    public class DepoManager
    {
        private List<Product> products = new List<Product>();
        private StockDAL db = new StockDAL();

        public List<Product> RefreshProducts()
        {
            this.products = db.GetAllProducts();
            return this.products;
        }

        public void AddStock(int pID,int additionalStock)
        {
            db.AddDepoStock(pID,additionalStock);
        }
    }
}
