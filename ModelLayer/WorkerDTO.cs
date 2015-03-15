using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class WorkerDTO
    {
        public int WorkerID { get; set; }
        public string Name { get; set; }
        public string NIC { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Designation { get; set; }
        public List<QuotationDTO> ListOfMarketedQuotations { get; set; }
        public List<QuotationDTO> ListOfSuccessfullQuotations { get; set; }

    }
}
