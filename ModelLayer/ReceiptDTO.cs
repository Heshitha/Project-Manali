using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ReceiptDTO
    {
        public int ReceiptID { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string MagNo { get; set; }
        public string Section { get; set; }
        public int FunctionTime { get; set; }
        public bool IsGoingAwayIncluded { get; set; }
        public string PayerName { get; set; }
        public string AccountOf { get; set; }
        public double Payment { get; set; }
        public string CashOrCheckNo { get; set; }
        public QuotationDTO Quotation{get; set;}
    }
}
