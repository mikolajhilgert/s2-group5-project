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
    public partial class ViewStore : Form
    {
        DepoManager dm = new DepoManager();
        public ViewStore()
        {
            InitializeComponent();
            RefreshProducts();

            if (Form1.loggedUser != "Admin")
            {
                label1.Visible = false;
                nRestockAmount.Visible = false;
                dgStore.Columns[5].Visible = false;
                for (int i = 0; i <= 4; i++)
                {
                    dgStore.Columns[i].Width += 20;
                }
            }
        }

        private void RefreshProducts()
        {
            dgStore.Rows.Clear();
            List<Product> products = dm.RefreshProducts();

            for (int i = 0; i < products.Count; i++)
            {
                dgStore.Rows.Add(products[i].GetStoreInfoArray());

                if (Convert.ToInt32(products[i].GetStoreQuantity()) < 5)
                {
                    dgStore.Rows[i].Cells[3].Style.BackColor = Color.Red;
                    dgStore.Rows[i].Cells[3].Style.ForeColor = Color.White;
                }
                else if (Convert.ToInt32(products[i].GetStoreQuantity()) < 10)
                {
                    dgStore.Rows[i].Cells[3].Style.BackColor = Color.Yellow;
                    dgStore.Rows[i].Cells[3].Style.ForeColor = Color.Black;
                }

            }

        }

        private void dgStore_SelectionChanged(object sender, EventArgs e)
        {
            dgStore.ClearSelection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgDepo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (nRestockAmount.Text != "" && Convert.ToInt32(nRestockAmount.Text) >= 5)
                {
                    dm.AddStockRequest(Convert.ToInt32(dgStore.Rows[e.RowIndex].Cells[0].Value), Convert.ToInt32(nRestockAmount.Text));
                    MessageBox.Show("Restock request sent successfuly!");
                }
                else
                {
                    MessageBox.Show("You may only make requests of atleast 5 items!");
                }
            }
            RefreshProducts();
        }
    }
}
