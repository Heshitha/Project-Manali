using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manali.Controllers
{
    public class AppointmentController : Controller
    {
        //
        // GET: /Appointment/
        public ActionResult Index()
        {
            List<AppointmentDTO> lstAppointments = BusinessLayer.BusinessStore.Appointment.GetAllAppointments();
            return View(lstAppointments);
        }
        public ActionResult CreateAppointment(int QuotationID = 0)
        {
            QuotationDTO quotation = BusinessLayer.BusinessStore.Quotation.GetQuotationByID(QuotationID);
            ViewBag.WorkersList = BusinessLayer.BusinessStore.Worker.GetAllWorkers();
            return View(quotation);
        }
        public JsonResult SaveAppointment(AppointmentDTO Appointment)
        {
            int result = BusinessLayer.BusinessStore.Appointment.CreateNewAppointment(Appointment);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditAppointment(int AppoinmentID)
        {
            AppointmentDTO appointment = BusinessLayer.BusinessStore.Appointment.GetAppointmentDetailsByID(AppoinmentID);
            ViewBag.WorkersList = BusinessLayer.BusinessStore.Worker.GetAllWorkers();
            return View(appointment);
        }
	}
}