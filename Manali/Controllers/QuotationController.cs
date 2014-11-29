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
	}
}