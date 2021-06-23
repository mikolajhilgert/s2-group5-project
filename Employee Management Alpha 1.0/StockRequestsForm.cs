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
    public partial class StockRequestsForm : Form
    {
        DepoManager dm = new DepoManager();
        public StockRequestsForm()
        {
            InitializeComponent();
            RefreshRequests();
            dgRequests.ClearSelection();

            if(Form1.loggedUser != "Stock worker")
            {
                btnAccept.Visible = false;
                btnReject.Visible = false;
            }
        }
        private void RefreshRequests()
        {
            dgRequests.Rows.Clear();
            List<StockRequest> stockRequests = dm.GetAllStockRequests();
            
            foreach (StockRequest sr in stockRequests)
            {
                if (sr.Status == RequestStatus.Pending && !chckResolved.Checked)
                {
                    string[] temp = sr.Product.GetRestockInfoArray();
                    temp[0] = sr.ID.ToString();
                    temp[4] = sr.Quantity.ToString();
                    dgRequests.Rows.Add(temp);
                }
                else if(sr.Status != RequestStatus.Pending && chckResolved.Checked)
                {
                    string[] temp = sr.Product.GetRestockInfoArray();
                    temp[0] = sr.ID.ToString();
                    temp[4] = sr.Quantity.ToString();
                    int rowIndex = dgRequests.Rows.Add(temp);
                    if (sr.Status == RequestStatus.Rejected)
                    {
                        dgRequests.Rows[rowIndex].Cells[0].Style.BackColor = Color.Salmon;
                        dgRequests.Rows[rowIndex].Cells[0].Style.ForeColor = Color.Black;
                    }
                    else if( sr.Status == RequestStatus.Accepted)
                    {
                        dgRequests.Rows[rowIndex].Cells[0].Style.BackColor = Color.LightSteelBlue;
                        dgRequests.Rows[rowIndex].Cells[0].Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgRequests.SelectedRows[0].Index;

                int requestId = Convert.ToInt32(dgRequests.Rows[index].Cells[0].Value);
                int requestedAmount = Convert.ToInt32(dgRequests.Rows[index].Cells[4].Value);
                int depoStock = Convert.ToInt32(dgRequests.Rows[index].Cells[5].Value);

                if (depoStock >= requestedAmount)
                    dm.AcceptStockRequest(requestId);
                else
                    MessageBox.Show("Insufficient stock in depo to accept request!");
                RefreshRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgRequests.SelectedRows[0].Index;
                int requestId = Convert.ToInt32(dgRequests.Rows[index].Cells[0].Value);
                dm.RejectStockRequest(requestId);
                RefreshRequests();
            }catch(Exception ex)
            {
                MessageBox.Show("Error");
            }

        }
        private void chckResolved_CheckedChanged(object sender, EventArgs e)
        {
            RefreshRequests();
            if (chckResolved.Checked)
            {
                btnAccept.Enabled = false;
                btnReject.Enabled = false;
            }
            else
            {
                btnAccept.Enabled = true;
                btnReject.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
