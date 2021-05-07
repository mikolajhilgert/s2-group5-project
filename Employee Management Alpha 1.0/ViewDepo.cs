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
    public partial class ViewDepo : Form
    {
        DepoManager depoManager = new DepoManager();
        public ViewDepo()
        {
            InitializeComponent();
            RefreshProducts();
        }

        private void RefreshProducts()
        {
            dgDepo.Rows.Clear();
            List<Product> products = depoManager.RefreshProducts();

            for (int i = 0; i < products.Count; i++)
            {
                dgDepo.Rows.Add(products[i].GetDepoInfoArray());

                if (products[i].GetDepoQuantity() < 25)
                {
                    dgDepo.Rows[i].Cells[3].Style.BackColor = Color.Red;
                    dgDepo.Rows[i].Cells[3].Style.ForeColor = Color.White;
                }
                else if (products[i].GetDepoQuantity() < 75)
                {
                    dgDepo.Rows[i].Cells[3].Style.BackColor = Color.Yellow;
                    dgDepo.Rows[i].Cells[3].Style.ForeColor = Color.Black;
                }
                else
                {
                    dgDepo.Rows[i].Cells[3].Style.BackColor = Color.White;
                    dgDepo.Rows[i].Cells[3].Style.ForeColor = Color.Black;
                }
            }
        }

        private void dgStore_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (nRestockAmount.Text != "" && Convert.ToInt32(nRestockAmount.Text) >= 100)
                {
                    if (MessageBox.Show("Are you sure you want to restock this product?.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        depoManager.AddDepoStock(Convert.ToInt32(dgDepo.Rows[e.RowIndex].Cells[0].Value), Convert.ToInt32(nRestockAmount.Text));
                        MessageBox.Show("Re-Stock Completed!");
                    }
                }
                else
                {
                    MessageBox.Show("You may only make requests of atleast 100 items!");
                }
            }
            RefreshProducts();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgStore_SelectionChanged(object sender, EventArgs e)
        {
            dgDepo.ClearSelection();
        }
    }
}
