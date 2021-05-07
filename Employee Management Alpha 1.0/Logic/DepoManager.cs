using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Alpha_1._0
{
    public class DepoManager
    {
        private StockDAL db = new StockDAL();

        public List<Product> RefreshProducts()
        {
            return db.GetAllProducts();
        }
        public Product GetProductByID(int id)
        {
            foreach (Product product in RefreshProducts())
            {
                if (product.Id == id)
                {
                    return product;
                }
            }

            return null;
        }
    
        public void AddDepoStock(int pID,int additionalStock)
        {
            db.AddDepoStock(pID,additionalStock);
        }

        public void AddStockRequest(int productID, int quantity)
        {
            db.AddStockRequest(productID, quantity);
        }
        public List<StockRequest> GetAllStockRequests()
        {
            return db.GetAllStockRequests();
        }
        public StockRequest GetStockRequestByID(int id)
        {
            foreach (StockRequest sr in GetAllStockRequests())
            {
                if (sr.ID == id)
                    return sr;
            }
            return null;
        }
        public void AcceptStockRequest(int id)
        {
            StockRequest sr = GetStockRequestByID(id);
            Product p = sr.Product;

            db.ChangeStockRequestStatus(sr.ID,(int)RequestStatus.Accepted);
            db.MoveStock(p.Id, sr.Quantity);
        }
        public void RejectStockRequest(int id)
        {
            db.ChangeStockRequestStatus(id, (int)RequestStatus.Rejected);
        }

    }
}
