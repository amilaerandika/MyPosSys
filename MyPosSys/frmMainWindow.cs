using Microsoft.Data.SqlClient;
using MyPosSys.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;
using System.Drawing;
using System.Drawing.Printing;

namespace MyPosSys
{
    public partial class frmMainWindow : Form
    {
        private string _connectionString;
        List<PosProduct> freqproducts;
        List<BillProduct> billproducts;
        PrintDocument billDoc;

        public frmMainWindow(string connectionString)
        {
            InitializeComponent();
            billDoc = new PrintDocument();

            //dataGridView1.ColumnCount = 0;

            _connectionString = connectionString;
            Load_FrequentProducts();
            Bind_FrequestProducts();

            billproducts = new List<BillProduct>();

            billDoc.PrintPage += BillDoc_PrintPage;

            for (int i = 0; i < 33; i++)
            {
                Button btn = this.Controls["btnProd" + i] as Button;
                if (btn != null)
                {
                    btn.Click += BtnProduct_Click;
                }
            }
        }

        public void Load_FrequentProducts()
        {
            freqproducts = new List<PosProduct>();

            using SqlConnection conn = new SqlConnection(_connectionString);
            using (SqlCommand cmd = new SqlCommand("SELECT ProductID, ProductCode, ProductName, UnitPrice FROM dbo.PosProduct", conn))
            {
                conn.Open();

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        freqproducts.Add(new PosProduct
                        {
                            ProductID = r.GetInt32(0),
                            ProductCode = r.GetString(1),
                            ProductName = r.GetString(2),
                            UnitPrice = r.GetDecimal(3)
                        });
                    }
                }
            }
        }

        public void Bind_FrequestProducts()
        {
            if (freqproducts.Count == 0)
                return;

            for (int i = 0; i < 33; i++)
            {
                Button btn = this.Controls["btnProd" + i] as Button;
                if (btn != null)
                {
                    btn.Text = string.Empty;
                }
            }

            for (int i = 0; i < freqproducts.Count; i++)
            {
                Button btn = this.Controls["btnProd" + i] as Button;
                if (btn != null)
                {
                    btn.Text = freqproducts[i].ProductName;
                }
            }

        }

        private void BtnProduct_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            string productName = clickedButton.Text; // or Name to identify

            if (productName == string.Empty) return;

            Add_ItemsToBillProducts(productName);

            Add_ProductsToGrid();
        }

        private void Add_ItemsToBillProducts(string text, decimal? qty = 0)
        {
            PosProduct prod = new PosProduct();
            prod = (freqproducts.Where(i => i.ProductName == text).First());

            if (billproducts.Count(i => i.ProductName == text) == 0)
            {
                billproducts.Add(
                    new BillProduct
                    {
                        ProductID = prod.ProductID,
                        ProductCode = prod.ProductCode,
                        ProductName = prod.ProductName,
                        UnitPrice = prod.UnitPrice,
                        Qty = 1
                    }
                );
            }
            else
            {
                var existingProduct = billproducts.Where(i => i.ProductID == prod.ProductID).FirstOrDefault();
                if (existingProduct != null) existingProduct.Qty += 1;
            }

            CalculateBillTotal();
        }

        private void CalculateBillTotal()
        {
            decimal sum = billproducts.Sum(i => i.Total);
            lblTotalValue.Text = sum.ToString("C2");

            lblBalance.Text = (sum - (txtPaidAmount.Text == string.Empty ? 0 : decimal.Parse(txtPaidAmount.Text))).ToString("C2");
        }

        public void Add_ProductsToGrid()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = billproducts; // or DataTable
            dataGridView1.DataSource = bs;
            dataGridView1.Columns["ProductID"].Visible = false;

            if (dataGridView1.Columns["Increase"] == null)
            {
                DataGridViewButtonColumn btnIncrease = new DataGridViewButtonColumn();
                btnIncrease.Name = "Increase";
                btnIncrease.HeaderText = "";
                btnIncrease.Text = "+"; // you can use an icon too
                btnIncrease.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(btnIncrease);
            }

            if (dataGridView1.Columns["Decrease"] == null)
            {
                DataGridViewButtonColumn btnDecrease = new DataGridViewButtonColumn();
                btnDecrease.Name = "Decrease";
                btnDecrease.HeaderText = "";
                btnDecrease.Text = "−"; // you can use an icon too
                btnDecrease.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(btnDecrease);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // ignore header clicks
            if (e.ColumnIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Increase")
            {
                string productName = row.Cells["ProductName"].Value?.ToString() ?? "";
                Update_ItemsToBillProducts(productName, 1);

                Add_ProductsToGrid();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Decrease")
            {
                string productName = row.Cells["ProductName"].Value?.ToString() ?? "";
                Update_ItemsToBillProducts(productName, -1);

                Add_ProductsToGrid();
            }
        }

        private void Update_ItemsToBillProducts(string text, decimal qty)
        {
            if (billproducts.Count > 0)
            {
                var existingProduct = billproducts.Where(i => i.ProductName == text).First();
                if (existingProduct == null) return;

                else
                {
                    existingProduct.Qty += qty;
                }

                billproducts.RemoveAll(i => i.Qty == 0);

                CalculateBillTotal();
            }
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            billDoc.Print();


        }

        private void frmMainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                billDoc.Print();   // or any logic you need
                e.Handled = true;
            }
        }

        private void BillDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            float y = 10;
            Font normal = new Font("Consolas", 9);
            Font bold = new Font("Consolas", 10, FontStyle.Bold);

            e.Graphics.DrawString("MY SHOP NAME", bold, Brushes.Black, 60, y);
            y += 20;
            e.Graphics.DrawString("Colombo, Sri Lanka", normal, Brushes.Black, 40, y);
            y += 15;
            e.Graphics.DrawString("--------------------------------", normal, Brushes.Black, 10, y);
            y += 15;

            decimal grandTotal = 0;

            foreach (var p in billproducts)
            {
                string nameText = $"{p.ProductCode} {p.ProductName}";
                int nameWidth = 14;

                // Split name into chunks of 14 chars
                List<string> nameLines = new List<string>();

                for (int i = 0; i < nameText.Length; i += nameWidth)
                {
                    nameLines.Add(
                        nameText.Substring(
                            i,
                            Math.Min(nameWidth, nameText.Length - i)
                        )
                    );
                }

                // ----- First line (with qty & prices)
                string firstLine =
                    nameLines[0].PadRight(nameWidth) +
                    p.Qty.ToString().PadLeft(3) +
                    p.UnitPrice.ToString("0.00").PadLeft(7) +
                    p.Total.ToString("0.00").PadLeft(8);

                e.Graphics.DrawString(firstLine, normal, Brushes.Black, 10, y);
                y += 15;

                // ----- Remaining name lines (name only)
                for (int i = 1; i < nameLines.Count; i++)
                {
                    e.Graphics.DrawString(
                        nameLines[i],
                        normal,
                        Brushes.Black,
                        10,
                        y
                    );
                    y += 15;
                }

                grandTotal += p.Total;
            }

            y += 10;
            e.Graphics.DrawString("--------------------------------", normal, Brushes.Black, 10, y);
            y += 15;
            e.Graphics.DrawString($"TOTAL: {grandTotal:0.00}", bold, Brushes.Black, 10, y);
            
            if(txtPaidAmount.Text != null || decimal.Parse(txtPaidAmount.Text) != 0)
            {
                y += 15;
                e.Graphics.DrawString($"Paid: {txtPaidAmount.Text:0.00}", bold, Brushes.Black, 10, y);
                y += 15;
                e.Graphics.DrawString($"Balance: {lblBalance.Text:0.00}", bold, Brushes.Black, 10, y);
            }
            y += 10;
            e.Graphics.DrawString("================================", normal, Brushes.Black, 10, y);

            SaveBillAsPdf_PrintDocument();
        }

        private void SaveBillAsPdf_PrintDocument()
        {
            string folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "POS_Bills"
            );

            Directory.CreateDirectory(folder);

            string pdfPath = Path.Combine(
                folder,
                $"Bill_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            );

            billDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            billDoc.PrinterSettings.PrintToFile = true;
            billDoc.PrinterSettings.PrintFileName = pdfPath;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            frmProduct frmProduct = new frmProduct(_connectionString);
            frmProduct.Show();
        }

        private void frmMainWindow_Activated(object sender, EventArgs e)
        {
            Load_FrequentProducts();
            Bind_FrequestProducts();
        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateBillTotal();
        }
    }
}
