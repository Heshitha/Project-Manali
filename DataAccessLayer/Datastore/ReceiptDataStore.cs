using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Datastore
{
    public class ReceiptDataStore
    {
        static ManaliDataStoreDataContext db = new ManaliDataStoreDataContext();
        public static int InsertNewReceipt(ReceiptDTO ReceiptDTO)
        {
            try
            {
                int? NewRecieptID = 0;

                db.Manali_Receipt_CreateReceipt(
                        ReceiptDTO.ReceiptDate,
                        ReceiptDTO.MagNo,
                        ReceiptDTO.Section,
                        ReceiptDTO.FunctionTime,
                        ReceiptDTO.IsGoingAwayIncluded,
                        ReceiptDTO.PayerName,
                        ReceiptDTO.AccountOf,
                        ReceiptDTO.Payment,
                        ReceiptDTO.CashOrCheckNo,
                        ReceiptDTO.Quotation.QuotationID,
                        ref NewRecieptID
                    );

                if (NewRecieptID != null && NewRecieptID != 0)
                {
                    return NewRecieptID.Value;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception e)
            {
                return 0;
            }
            
        }
        public static int InsertAdvanceReceipt(ReceiptDTO ReceiptDTO)
        {
            try
            {
                int? NewRecieptID = 0;

                db.Manali_Receipt_CreateAdvanceReceipt(
                        ReceiptDTO.ReceiptDate,
                        ReceiptDTO.MagNo,
                        ReceiptDTO.Section,
                        ReceiptDTO.FunctionTime,
                        ReceiptDTO.IsGoingAwayIncluded,
                        ReceiptDTO.PayerName,
                        ReceiptDTO.AccountOf,
                        ReceiptDTO.Payment,
                        ReceiptDTO.CashOrCheckNo,
                        ReceiptDTO.Quotation.QuotationID,
                        ref NewRecieptID
                    );

                if (NewRecieptID != null && NewRecieptID != 0)
                {
                    return NewRecieptID.Value;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception e)
            {
                return 0;
            }

        }

        public static List<ReceiptDTO> GetAllReceipts()
        {
            List<ReceiptDTO> lstReceiptList = new List<ReceiptDTO>();

            try
            {
                var lstReceiptListFromDB = db.Manali_Receipt_GetAllReceipts();

                foreach (var item in lstReceiptListFromDB)
                {
                    QuotationDTO quotation = new QuotationDTO
                    {
                        QuotationID = item.QuotationID,
                        DateOfWedding = item.DateOfWedding.Value,
                        NameOfBride = item.Bride,
                        BrideAddress = item.BrideAddress,
                        BrideEmail = item.BrideEmail,
                        BrideContactNo = item.BrideContactNo,
                        DateOfHomecoming = item.DateOfHomecoming.Value,
                        NameOfGroom = item.Groom,
                        GroomAddress = item.GroomAddress,
                        GroomContactNo = item.GroomContactNo,
                    };

                    ReceiptDTO receipt = new ReceiptDTO
                    {
                        ReceiptID = item.ReceiptID,
                        ReceiptDate = item.ReceiptDate.Value,
                        MagNo = item.MagNo,
                        Section = item.Section,
                        FunctionTime = item.FunctionTime.Value,
                        IsGoingAwayIncluded = item.IsGoingAwayIncluded.Value,
                        PayerName = item.PayerName,
                        AccountOf = item.AccountOf,
                        Payment = item.Payment.Value,
                        CashOrCheckNo = item.CashOrCheckNo,
                        Quotation = quotation
                    };

                    lstReceiptList.Add(receipt);
                }

            }
            catch (Exception)
            {
                
            }

            return lstReceiptList;
        }

        public static ReceiptDTO GetReceiptByID(int ReceiptID)
        {
            try
            {
                var ReceiptObject = db.Manali_Receipt_GetReceiptByID(ReceiptID).FirstOrDefault();

                if (ReceiptObject != null)
                {
                    QuotationDTO quotation = new QuotationDTO
                    {
                        QuotationID = ReceiptObject.QuotationID,
                        DateOfWedding = ReceiptObject.DateOfWedding.Value,
                        NameOfBride = ReceiptObject.Bride,
                        BrideAddress = ReceiptObject.BrideAddress,
                        BrideEmail = ReceiptObject.BrideEmail,
                        BrideContactNo = ReceiptObject.BrideContactNo,
                        DateOfHomecoming = ReceiptObject.DateOfHomecoming.Value,
                        NameOfGroom = ReceiptObject.Groom,
                        GroomAddress = ReceiptObject.GroomAddress,
                        GroomContactNo = ReceiptObject.GroomContactNo,
                    };

                    ReceiptDTO receipt = new ReceiptDTO
                    {
                        ReceiptID = ReceiptObject.ReceiptID,
                        ReceiptDate = ReceiptObject.ReceiptDate.Value,
                        MagNo = ReceiptObject.MagNo,
                        Section = ReceiptObject.Section,
                        FunctionTime = ReceiptObject.FunctionTime.Value,
                        IsGoingAwayIncluded = ReceiptObject.IsGoingAwayIncluded.Value,
                        PayerName = ReceiptObject.PayerName,
                        AccountOf = ReceiptObject.AccountOf,
                        Payment = ReceiptObject.Payment.Value,
                        CashOrCheckNo = ReceiptObject.CashOrCheckNo,
                        Quotation = quotation
                    };

                    return receipt;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
    }
}
