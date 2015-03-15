using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manali.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            if (Session["LoggedUser"] != null)
            {
                return View();
            }
            else
            {
                Response.Redirect("/Login/", false);
                return null;
            }
        }
	}
}