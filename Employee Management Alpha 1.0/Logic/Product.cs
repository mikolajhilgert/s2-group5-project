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
        private Department department;

        public int Id
        {
            get { return id;}
            private set { id = value; }
        }
        public string Name { get { return this.name; } }
        public decimal PricePerUnit { get { return this.pricePerUnit; } }
        public Department Department { get { return this.department; } }

        public Product(int id,string name, int quantityShop, int quantityDepo, decimal PricePerUnit, Department department)
        {
            this.id = id;
            this.name = name;
            this.quantityStore = quantityShop;
            this.quantityDepo = quantityDepo;
            this.pricePerUnit = PricePerUnit;
            this.department = department;
        }
        public Product() { }
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
            string[] details = { id.ToString(), name, pricePerUnit.ToString("0.00"), department.Name };

            return details;
        }

        public string[] GetStoreInfoArray()
        {
            string[] details = { id.ToString(),name, pricePerUnit.ToString("0.00"),quantityStore.ToString(), department.Name, "Make Request" };

            return details;
        }

        public string[] GetDepoInfoArray()
        {
            string[] details = { id.ToString(), name, pricePerUnit.ToString("0.00"), quantityDepo.ToString(), department.Name, "Make Request" };

            return details;
        }

        public string[] GetCashierInfoArray()
        {
            string[] details = { id.ToString(), name, quantityStore.ToString(), pricePerUnit.ToString("0.00"),"0" };

            return details;
        }
        public string[] GetRestockInfoArray()
        {
            string[] details = {"", department.Name, id.ToString(), name, "" , quantityDepo.ToString() };

            return details;
        }
        public override string ToString()
        {
            return $"{this.id} {this.name} ({this.department.Name})";
        }
    }
}
