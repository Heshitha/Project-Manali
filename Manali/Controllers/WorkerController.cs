using ModelLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manali.Controllers
{
    public class WorkerController : Controller
    {
        //
        // GET: /Worker/
        public ActionResult Index()
        {
            List<WorkerDTO> lstWorkerList = BusinessLayer.BusinessStore.Worker.GetAllWorkers();
            return View(lstWorkerList);
        }
        public ActionResult ViewWorkerDetails(int WorkerID)
        {
            WorkerDTO worker = BusinessLayer.BusinessStore.Worker.GetWorkerWithQuotations(WorkerID);
            return View(worker);
        }

        public ActionResult CreateWorker()
        {
            return View();
        }

        public JsonResult SaveWorker(WorkerDTO Worker, HttpPostedFileBase file = null)
        {
            if (file != null && file.ContentLength > 0)
            {

                string path = Path.Combine(Server.MapPath("~/SystemData/WorkerImages"), Worker.NIC + Path.GetExtension(file.FileName));
                if (!Directory.Exists(Server.MapPath("~/SystemData/WorkerImages")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/SystemData/WorkerImages"));
                }
                file.SaveAs(path);
                Bitmap img = new Bitmap(file.InputStream);
                var imageHeight = Convert.ToInt32(((350.0 / img.Width) * img.Height));

                Stream imagestream = UserController.GetResizedImageStream(file.InputStream, 0, 0, 160, 160, 350, imageHeight);
                Image image = Image.FromStream(imagestream);
                path = Path.Combine(Server.MapPath("~/SystemData/WorkerImages"), Worker.NIC + "-thumb" + Path.GetExtension(file.FileName));
                image.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                Worker.Image = "/SystemData/WorkerImages/" + Worker.NIC + Path.GetExtension(file.FileName);
            }
            else
            {
                Worker.Image = "/Images/blank-profile-hi.png";
            }
            int result = BusinessLayer.BusinessStore.Worker.SaveNewWorker(Worker);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}