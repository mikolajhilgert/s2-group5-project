using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_Alpha_1._0
{
    public partial class CashierMachine : Form
    {
        ProductManager productManager = new ProductManager();
        public CashierMachine()
        {
            InitializeComponent();
            RefreshProducts();
        }

        private void RefreshProducts()
        {
            dgSell.Rows.Clear();
            List<Product> products = productManager.RefreshProducts();
            foreach (Product p in products)
            {
                dgSell.Rows.Add(p.GetCashierInfoArray());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            var checkedRows = from DataGridViewRow r in dgSell.Rows
                              where Convert.ToBoolean(r.Cells[5].Value) == true
                              select r;

            foreach (var row in checkedRows)
            {
                Product p = productManager.GetProductByID(Convert.ToInt32(row.Cells[0].Value));
                try
                {
                    int sellAmount = Convert.ToInt32(row.Cells[4].Value);
                    if (sellAmount > 0)
                    {
                        if (p.Sell(sellAmount))
                        {
                            productManager.SellProduct(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(row.Cells[4].Value));
                        }
                        else
                        {
                            MessageBox.Show($"There is not enough of product ID:{row.Cells[0].Value} in the store!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You cannot sell 0 or less of an item!");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Insert correct value");
                    Console.WriteLine(exception);
                }   
            }
            RefreshProducts();
        }

        private void dgvSell_SelectionChanged(object sender, EventArgs e)
        {
            dgSell.ClearSelection();
        }
    }
}
