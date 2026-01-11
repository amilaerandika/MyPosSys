using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPosSys.Data
{
    public class PosProduct
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal? CostPrice { get; set; }

        public int StockQty { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public decimal? ProductOrder { get; set; }
    }
}
