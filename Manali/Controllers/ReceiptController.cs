using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manali.Controllers
{
    public class ReceiptController : Controller
    {
        //
        // GET: /Receipt/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdvanceReceipt(int quotationID = 0)
        {
            ViewBag.QuotationID = quotationID;
            QuotationDTO quotation = BusinessLayer.BusinessStore.Quotation.GetQuotationByID(quotationID);
            return View(quotation);
        }

        public ActionResult ReceiptList()
        {
            List<ReceiptDTO> lstReceiptList = BusinessLayer.BusinessStore.Receipt.GetReceiptList();
            return View(lstReceiptList);
        }

        public ActionResult EditReceipt(int ReceiptID)
        {
            ReceiptDTO Receipt = BusinessLayer.BusinessStore.Receipt.GetReceiptByID(ReceiptID);

            return View(Receipt);
        }
        public JsonResult SaveAdvanceReceipt(ReceiptDTO Receipt)
        {
            int receiptID = 0;
            receiptID = BusinessLayer.BusinessStore.Receipt.SaveAdvanceReceiptDetails(Receipt);
            
            ActionDetailsDTO actionDetails = new ActionDetailsDTO
            {
                Status = receiptID > 0 ? 1 : 0,
                Content = receiptID.ToString()
            };
            
            return Json(actionDetails, JsonRequestBehavior.AllowGet);
        }
	}
}