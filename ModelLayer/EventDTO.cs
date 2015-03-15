using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class EventDTO
    {
        public QuotationDTO Quotation { get; set; }
        public ReceiptDTO AdvanceRecipt { get; set; }
    }
}
