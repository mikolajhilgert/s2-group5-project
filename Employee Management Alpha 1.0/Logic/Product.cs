using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Alpha_1._0
{
    public class Product
    {
        private int id;
        private string name;
        private int quantityStore;
        private int quantityDepo;
        private decimal pricePerUnit;
        private ProductCategory category;

        public Product(string name, int quantityStore, int quantityDepo, decimal PricePerUnit, ProductCategory category)
        {
            this.name = name;
            this.quantityStore = quantityStore;
            this.quantityDepo = quantityDepo;
            this.pricePerUnit = PricePerUnit;
            this.category = category;
        }
        public Product(int id,string name, int quantityShop, int quantityDepo, decimal PricePerUnit, ProductCategory category)
        {
            this.id = id;
            this.name = name;
            this.quantityStore = quantityShop;
            this.quantityDepo = quantityDepo;
            this.pricePerUnit = PricePerUnit;
            this.category = category;
        }
        public int GetStoreQuantity()
        {
            return quantityStore;
        }

        public int GetDepoQuantity()
        {
            return quantityDepo;
        }

        public bool Sell(int quantitySold)
        {
            if(this.quantityStore-quantitySold >= 0) {
                this.quantityStore -= quantitySold;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void RestockDepo(int quantityRequested)
        {
            this.quantityDepo += quantityRequested;
        }

        public bool MoveToStore(int quantityRequested)
        {
            if (this.quantityDepo >= quantityRequested)
            {
                this.quantityDepo -= quantityRequested;
                this.quantityStore += quantityRequested;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string[] GetBasicInfoArray()
        {
            string[] details = { id.ToString(), name, pricePerUnit.ToString("0.00"), category.ToString() };

            return details;
        }

        public string[] GetStoreInfoArray()
        {
            string[] details = { id.ToString(),name, pricePerUnit.ToString("0.00"),quantityStore.ToString(),category.ToString(),"Make Request" };

            return details;
        }

        public string[] GetDepoInfoArray()
        {
            string[] details = { id.ToString(), name, pricePerUnit.ToString("0.00"), quantityDepo.ToString(), category.ToString(), "Make Request" };

            return details;
        }
    }
}
