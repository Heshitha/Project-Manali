using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manali.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }
        

        public JsonResult  CreateUser(UserDTO userDTO)
        {
            int messageType = BusinessLayer.BusinessStore.User.CreateUser(userDTO);
            return Json(messageType, JsonRequestBehavior.AllowGet);

        }
	}
}