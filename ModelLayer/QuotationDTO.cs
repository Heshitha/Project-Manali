using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class QuotationDTO
    {
        public int QuotationID { get; set; }
        public DateTime DateOfWedding { get; set; }
        public DateTime DateOfHomecoming { get; set; }
        public string NameOfBride { get; set; }
        public string BrideAddress { get; set; }
        public string BrideEmail { get; set; }
        public string BrideContactNo { get; set; }
        public string NameOfGroom { get; set; }
        public string GroomAddress { get; set; }
        public string GroomContactNo { get; set; }
        public UserDTO createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public List<QuotationItemDTO> SelectedItem { get; set; }
    }

    public class QuotationItemDTO
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public double Price { get; set; }
        public bool IsUpwards { get; set; }
    }
}
