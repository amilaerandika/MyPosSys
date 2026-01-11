using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPosSys.Data
{
    class BillProduct
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Qty { get; set; }

        public decimal Total => UnitPrice * Qty;
    }
}
