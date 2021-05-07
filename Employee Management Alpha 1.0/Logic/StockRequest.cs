using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Alpha_1._0
{
    public class StockRequest
    {
        //fields
        private int id;
        private Product product;
        private int quantity;
        private RequestStatus status;
        //properties
        public int ID
        {
            get { return this.id; }
        }
        public Product Product
        {
            get { return this.product; }
        }
        public int Quantity
        {
            get { return this.quantity; }
        }
        public RequestStatus Status
        {
            get { return this.status; }
        }
        //constructor(s)
        public StockRequest(int id,Product p,int quantity)
        {
            this.id = id;
            this.product = p;
            this.quantity = quantity;
            this.status = RequestStatus.Pending;
        }
        public StockRequest(int id, Product p, int quantity,RequestStatus status)
        {
            this.id = id;
            this.product = p;
            this.quantity = quantity;
            this.status = status;
        }
        //methods
        public void AcceptRequest()
        {
            this.product.MoveToStore(this.quantity);
            this.status = RequestStatus.Accepted;
        }
        public void RejectRequest()
        {
            this.status = RequestStatus.Rejected;
        }
    }
}
