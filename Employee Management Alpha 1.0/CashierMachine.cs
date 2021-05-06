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
            dataGridView1.Rows.Clear();
            List<Product> products = productManager.RefreshProducts();
            foreach (Product p in products)
            {
                dataGridView1.Rows.Add(p.GetCashierInfoArray());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Product p = productManager.GetProductByID(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value));
                try
                {
                    int sellAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                    if (p.Sell(sellAmount))
                    {
                        productManager.SellProduct(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value), Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value));
                        MessageBox.Show("Sold!");
                    }
                    else
                    {
                        MessageBox.Show("Not enough in the stock!");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Insert correct value");
                    Console.WriteLine(exception);
                    throw;
                }
                   
                    
                
             
            }
            RefreshProducts();
        }
    }
}
