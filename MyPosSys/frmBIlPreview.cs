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
    public partial class frmBIlPreview : Form
    {

        string BillCode = string.Empty;
        string _connectionString;

        List<BillItem> billItems = new List<BillItem>();

        Bill bill = new Bill();

        public frmBIlPreview(string connectionString)
        {
            InitializeComponent();

            _connectionString = connectionString;
        }
    }
}
