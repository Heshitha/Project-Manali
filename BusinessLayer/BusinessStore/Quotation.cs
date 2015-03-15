using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessStore
{
    public class Quotation
    {
        public static List<QuotationItemDTO> GetQuotationitemList()
        {
            return DataAccessLayer.Datastore.QuotationDataStore.GetQuotationItems();
        }

        public static QuotationDTO GetQuotationByID(int quotationID)
        {
            return DataAccessLayer.Datastore.QuotationDataStore.GetQuotaionDetails(quotationID);
        }

        public static List<QuotationDTO> GetAllQuotation()
        {
            return DataAccessLayer.Datastore.QuotationDataStore.GetAllQuotations();
        }

        public static bool SaveQuotationDetails(ref QuotationDTO quotation)
        {
            try 
            {
                return DataAccessLayer.Datastore.QuotationDataStore.SaveQuotation(ref quotation);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
