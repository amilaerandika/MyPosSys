using Microsoft.Data.SqlClient;
using MyPosSys.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPosSys
{
    public partial class frmProduct : Form
    {
        string _connectionString;
        private SqlDataAdapter _adapter;
        private DataTable _dt;
        private BindingSource _bs;

        public frmProduct(string connectionString)
        {
            InitializeComponent();

            _connectionString = connectionString;

            LoadAllProducts();

            dataGridView1.RowValidated += dataGridView1_RowValidated;
        }

        private void LoadAllProducts()
        {
            string sql = "SELECT ProductID, ProductCode, ProductName, UnitPrice, CostPrice, StockQty, IsActive, CreatedDate, ProductOrder FROM dbo.PosProduct";

            SqlConnection conn = new SqlConnection(_connectionString);

            _adapter = new SqlDataAdapter(sql, conn);

            SqlCommandBuilder builder = new SqlCommandBuilder(_adapter);

            _dt = new DataTable();
            _adapter.Fill(_dt);

            _bs = new BindingSource();
            _bs.DataSource = _dt;

            dataGridView1.DataSource = _bs;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.ReadOnly = false;
            dataGridView1.Columns["ProductID"].Visible = false;

        }

        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            PosProduct pro = new PosProduct();
            pro.ProductCode = txtProCode.Text;
            pro.ProductName = txtProName.Text;
            pro.UnitPrice = decimal.Parse(txtProUnitPrice.Text);
            pro.CostPrice = decimal.Parse(txtProUnitCost.Text);
            pro.StockQty = int.Parse(txtProStock.Text);
            pro.IsActive = ckbProIsactive.Checked;
            pro.CreatedDate = DateTime.Now;
            pro.ProductOrder = Convert.ToDecimal(cmbOrder.SelectedItem);


            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(@"
                            INSERT INTO dbo.PosProduct
                            (ProductCode, ProductName, UnitPrice, CostPrice, StockQty, IsActive, CreatedDate, ProductOrder)
                            VALUES
                            (@ProductCode, @ProductName, @UnitPrice, @CostPrice, @StockQty, @IsActive, @CreatedDate, @ProductOrder)", conn))
                {
                    // Add parameters safely
                    cmd.Parameters.AddWithValue("@ProductCode", pro.ProductCode);
                    cmd.Parameters.AddWithValue("@ProductName", pro.ProductName);
                    cmd.Parameters.AddWithValue("@UnitPrice", pro.UnitPrice);
                    cmd.Parameters.AddWithValue("@CostPrice", pro.CostPrice);
                    cmd.Parameters.AddWithValue("@StockQty", pro.StockQty);
                    cmd.Parameters.AddWithValue("@IsActive", pro.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedDate", pro.CreatedDate);
                    cmd.Parameters.AddWithValue("@ProductOrder", pro.ProductOrder);

                    cmd.ExecuteNonQuery(); // Insert row
                }
            }

            LoadAllProducts();

        }


        private void SearchProducts(string text)
        {
            string sql = "SELECT ProductID, ProductCode, ProductName, UnitPrice, CostPrice, StockQty, IsActive, CreatedDate, ProductOrder " +
                "FROM dbo.PosProduct" +
                " WHERE ProductName like '%" + text.ToLower() + "%'" +
                " OR ProductCode like '%" + text.ToLower() + "%'";

            SqlConnection conn = new SqlConnection(_connectionString);

            _adapter = new SqlDataAdapter(sql, conn);

            SqlCommandBuilder builder = new SqlCommandBuilder(_adapter);

            _dt = new DataTable();
            _adapter.Fill(_dt);

            _bs = new BindingSource();
            _bs.DataSource = _dt;

            dataGridView1.DataSource = _bs;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.ReadOnly = false;
            dataGridView1.Columns["ProductID"].Visible = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                LoadAllProducts();
                return;
            }

            SearchProducts(textBox1.Text);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (_dt.GetChanges() != null)
            {
                try
                {
                    _adapter.Update(_dt);
                    _dt.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Save failed: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;

            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show(
                                "Are you sure you want to delete this item?",
                                "Confirm Delete",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
