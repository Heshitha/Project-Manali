using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessStore
{
    public class Receipt
    {
        public static List<ReceiptDTO> GetReceiptList()
        {
            return DataAccessLayer.Datastore.ReceiptDataStore.GetAllReceipts();
        }

        public static int SaveReceiptDetails(ReceiptDTO Receipt)
        {
            return DataAccessLayer.Datastore.ReceiptDataStore.InsertNewReceipt(Receipt);
        }

        public static ReceiptDTO GetReceiptByID(int ReceiptID)
        {
            return DataAccessLayer.Datastore.ReceiptDataStore.GetReceiptByID(ReceiptID);
        }

        public static int SaveAdvanceReceiptDetails(ReceiptDTO Receipt)
        {
            return DataAccessLayer.Datastore.ReceiptDataStore.InsertAdvanceReceipt(Receipt);
        }
    }
}
