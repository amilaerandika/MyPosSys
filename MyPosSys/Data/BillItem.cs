using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPosSys.Data
{
    public class BillItem
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal Total => Price * Quantity;
    }
}
