using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPosSys.Data
{
    public class Bill
    {
        public int BillId { get; set; }
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }

        public string Cashier { get; set; }
        public string CustomerName { get; set; }

        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal GrandTotal { get; set; }

        public string PaymentMethod { get; set; }   // Cash, Card, QR
        public decimal PaidAmount { get; set; }
        public decimal Balance
        {
            get { return PaidAmount - GrandTotal; }
        }

        public List<BillItem> BillItems = new List<BillItem>();
    }

}
