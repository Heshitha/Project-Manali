using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class AppointmentDTO
    {
        public int AppointmentID { get; set; }
        public QuotationDTO Quotation { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public WorkerDTO ResponsibleWorker { get; set; }
        public bool IsBrideVisited { get; set; }
        public double Duration { get; set; }
        public string Notes { get; set; }
        public int Status { get; set; }
    }
}
