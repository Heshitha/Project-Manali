using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manali.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginUser(UserDTO User)
        {
            string userName = User.Username;
            string password = User.Password;
            UserDTO loggedUser = new UserDTO();

            ActionDetailsDTO actionDetails = new ActionDetailsDTO();

            if (BusinessLayer.BusinessStore.User.UserLogin(userName, password, ref loggedUser))
            {
                Session["LoggedUser"] = loggedUser;

                actionDetails.Status = 1;
                actionDetails.Message = "Successfully Logged";
            }
            else
            {
                actionDetails.Status = 0;
                actionDetails.Message = "Login Failed. Check Username & Password";
            }
            return Json(actionDetails, JsonRequestBehavior.AllowGet);
        }
	}
}