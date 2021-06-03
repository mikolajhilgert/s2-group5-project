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
    public partial class CRUDProduct : Form
    {
        ProductManager productManager = new ProductManager();
        public CRUDProduct()
        {
            InitializeComponent();
            RefreshProducts();
            RefreshCategories();
            InAddMode();
        }

        private void btnAddStockItem_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && tbPricePerUnit.Text != "" && cbCategory.SelectedIndex > -1)
            {
                productManager.AddProduct(tbName.Text, Convert.ToDecimal(tbPricePerUnit.Text), (Department)cbCategory.SelectedItem);
                tbName.Text = tbPricePerUnit.Text = "";
                cbCategory.SelectedIndex = -1;
                RefreshProducts();
            }
            else
            {
                MessageBox.Show("Please check input fields!");
            }
        }

        private void RefreshProducts()
        {
            dgProducts.Rows.Clear();
            List<Product> products = productManager.RefreshProducts();
            foreach (Product p in products)
            {
                dgProducts.Rows.Add(p.GetBasicInfoArray());
            }
        }

        private void RefreshCategories()
        {
            cbCategory.Items.Clear();
            //foreach (ProductCategory category in (ProductCategory[])Enum.GetValues(typeof(ProductCategory)))
            //{
            //    cbCategory.Items.Add(category.ToString());
            //}
            cbCategory.Items.AddRange(DepartmentManagement.GetAllDepartments().ToArray());
        }

        private void dgProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            InEditMode();
            int index = dgProducts.SelectedRows[0].Index;
            int id = Convert.ToInt32(dgProducts.Rows[index].Cells[0].Value);
            labelID.Text = id.ToString();
            Product product = productManager.GetProductByID(id);
            tbName.Text = product.Name;
            tbPricePerUnit.Text = product.PricePerUnit.ToString();
            cbCategory.SelectedItem = product.Department;
            MessageBox.Show(product.Department.ToString());
            //tbName.Text = dgProducts.Rows[index].Cells[1].Value.ToString();
            //tbPricePerUnit.Text = dgProducts.Rows[index].Cells[2].Value.ToString();
            //cbCategory.Text = dgProducts.Rows[index].Cells[3].Value.ToString();
        }

        private void btnEditStockItem_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && tbPricePerUnit.Text != "" && cbCategory.SelectedIndex > -1)
            {
                productManager.EditProduct(Convert.ToInt32(labelID.Text), tbName.Text, Convert.ToDecimal(tbPricePerUnit.Text), (Department)cbCategory.SelectedItem);
                tbName.Text = tbPricePerUnit.Text = "";
                cbCategory.SelectedIndex = -1;
                RefreshProducts();
            }
            else
            {
                MessageBox.Show("Please check input fields!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            labelID.Text = "///";
            tbName.Text = tbPricePerUnit.Text = "";
            cbCategory.SelectedIndex = -1;
            InAddMode();
        }

        private void btnDeleteStockItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this product?.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (tbName.Text != "" && tbPricePerUnit.Text != "" && cbCategory.SelectedIndex > -1)
                {
                    productManager.DeleteProduct(Convert.ToInt32(labelID.Text));
                    tbName.Text = tbPricePerUnit.Text = "";
                    cbCategory.SelectedIndex = -1;
                    RefreshProducts();
                    InAddMode();
                }
            }
        }

        private void InEditMode()
        {
            btnAddStockItem.Enabled = false;
            btnEditStockItem.Enabled = true;
            btnDeleteStockItem.Enabled = true;
            btnClear.Enabled = true;
        }
        private void InAddMode()
        {
            btnAddStockItem.Enabled = true;
            btnEditStockItem.Enabled = false;
            btnDeleteStockItem.Enabled = false;
            btnClear.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
