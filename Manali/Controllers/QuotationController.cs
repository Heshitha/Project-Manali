using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manali.Controllers
{
    public class QuotationController : Controller
    {
        //
        // GET: /Quotation/
        public ActionResult Index(int QuotationID = 0)
        {
            return View();
        }

        public ActionResult CreateQuotation()
        {
            List<QuotationItemDTO> lstQuotationItemList = BusinessLayer.BusinessStore.Quotation.GetQuotationitemList();
            return View(lstQuotationItemList);
        }

        public ActionResult QuotationList()
        {
            List<QuotationDTO> lstQuotation = BusinessLayer.BusinessStore.Quotation.GetAllQuotation();
            return View(lstQuotation);
        }

        public ActionResult EditQuotation(int quotationID = 0)
        {
            List<QuotationItemDTO> lstQuotationItemList = BusinessLayer.BusinessStore.Quotation.GetQuotationitemList();
            QuotationDTO Quotation = BusinessLayer.BusinessStore.Quotation.GetQuotationByID(quotationID);
            ViewBag.Quotation = Quotation;
            return View(lstQuotationItemList);
        }

        public JsonResult SaveQuotation(QuotationDTO quotation, string selectedItems)
        {
            bool result = true;

            string[] selectedItemIDs = selectedItems.Split(',');

            List<QuotationItemDTO> lstQuotationItems = new List<QuotationItemDTO>();

            foreach(string item in selectedItemIDs)
            {
                int ItemID = 0;
                if(int.TryParse(item, out ItemID))
                {
                    QuotationItemDTO QuotationItem = new QuotationItemDTO
                    {
                        ItemID = ItemID
                    };

                    lstQuotationItems.Add(QuotationItem);
                }
            }

            quotation.SelectedItem = lstQuotationItems;
            quotation.createdBy = new UserDTO { userID = 10 };

            result = BusinessLayer.BusinessStore.Quotation.SaveQuotationDetails(quotation);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}