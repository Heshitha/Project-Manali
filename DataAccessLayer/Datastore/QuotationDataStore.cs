using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Datastore
{
    public class QuotationDataStore
    {
        static ManaliDataStoreDataContext db = new ManaliDataStoreDataContext();

        public static List<QuotationItemDTO> GetQuotationItems()
        {
            try
            {
                var result = db.Manali_Quotation_GetQuotationItemPriceList();

                List<QuotationItemDTO> lstQuotationItems = new List<QuotationItemDTO>();

                foreach (var item in result)
                {
                    QuotationItemDTO quotationItem = new QuotationItemDTO
                    {
                        ItemID = item.ItemID,
                        ItemName = item.ItemName,
                        Price = item.Price.Value,
                        IsUpwards = item.isUpwards.Value
                    };

                    lstQuotationItems.Add(quotationItem);
                }

                return lstQuotationItems;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static QuotationDTO GetQuotaionDetails(int QuotationID)
        {
            try
            {
                var QuotationResult = db.Manali_Quotation_SelectAQuotation(QuotationID).SingleOrDefault();

                var SelectedItems = db.Manali_Quotation_SelectQuotationSelectedItems(QuotationID);

                WorkerDTO marketer = new WorkerDTO
                {
                    WorkerID = QuotationResult.WorkerID,
                    Name = QuotationResult.Name,
                    NIC = QuotationResult.NIC,
                    Mobile = QuotationResult.Mobile,
                    Address = QuotationResult.Address,
                    Designation = QuotationResult.Designation,
                    Image = QuotationResult.Image
                };

                QuotationDTO Quotation = new QuotationDTO
                {
                    QuotationID = QuotationResult.QuotationID,
                    DateOfWedding = QuotationResult.DateOfWedding.Value,
                    NameOfBride = QuotationResult.Bride,
                    BrideAddress = QuotationResult.BrideAddress,
                    BrideEmail = QuotationResult.BrideEmail,
                    BrideContactNo = QuotationResult.BrideContactNo,
                    DateOfHomecoming = QuotationResult.DateOfHomecoming.Value,
                    NameOfGroom = QuotationResult.Groom,
                    GroomAddress = QuotationResult.GroomAddress,
                    GroomContactNo = QuotationResult.GroomContactNo,
                    marketedBy = marketer
                };

                List<QuotationItemDTO> lstQuotationItems = new List<QuotationItemDTO>();

                foreach (var item in SelectedItems)
                {
                    QuotationItemDTO quotationItem = new QuotationItemDTO
                    {
                        ItemID = item.ItemID.Value
                    };

                    lstQuotationItems.Add(quotationItem);
                }

                Quotation.SelectedItem = lstQuotationItems;

                return Quotation;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<QuotationDTO> GetAllQuotations()
        {
            try
            {
                var QuotationList = db.Manali_Quotation_GetAllQuotation();

                List<QuotationDTO> lstQuotations = new List<QuotationDTO>();

                foreach (var item in QuotationList)
                {
                    WorkerDTO marketer = new WorkerDTO
                    {
                        WorkerID = item.WorkerID,
                        Name = item.Name,
                        NIC = item.NIC,
                        Mobile = item.Mobile,
                        Address = item.Address,
                        Designation = item.Designation,
                        Image = item.Image
                    };

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
                        marketedBy = marketer
                    };

                    lstQuotations.Add(quotation);
                }

                return lstQuotations;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool SaveQuotation(ref QuotationDTO quotation)
        {
            try 
            {
                string selectedItems = "";

                foreach(var item in quotation.SelectedItem){
                    if(selectedItems == "")
                    {
                        selectedItems = item.ItemID.ToString();
                    }
                    else
                    {
                        selectedItems = item.ItemID + "," + selectedItems;
                    }
                }

                int? quotationID = 0;

                db.Manali_Quotation_SaveQuotation(
                        quotation.DateOfWedding,
                        quotation.NameOfBride,
                        quotation.BrideAddress,
                        quotation.BrideEmail,
                        quotation.BrideContactNo,
                        quotation.DateOfHomecoming,
                        quotation.NameOfGroom,
                        quotation.GroomAddress,
                        quotation.GroomContactNo,
                        selectedItems,
                        quotation.createdBy.userID,
                        quotation.marketedBy.WorkerID,
                        ref quotationID
                    );

                if (quotationID != null && quotationID != 0)
                {
                    quotation.QuotationID = quotationID.Value;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
