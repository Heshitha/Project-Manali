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
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult  SaveUser(UserDTO userDTO, HttpPostedFileBase file =null)
        {

            if (file != null && file.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/SystemData/UserImages"), userDTO.Username + Path.GetExtension(file.FileName));
                file.SaveAs(path);
                Bitmap img = new Bitmap(file.InputStream);
                var imageHeight = Convert.ToInt32(((350.0 / img.Width) * img.Height));

                Stream imagestream = GetResizedImageStream(file.InputStream, 0, 0, 160, 160, 350, imageHeight);
                Image image = Image.FromStream(imagestream);
                path = Path.Combine(Server.MapPath("~/SystemData/UserImages"), userDTO.Username + "-thumb" + Path.GetExtension(file.FileName));
                image.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                userDTO.ImagePath = "SystemData/UserImages/" + userDTO.Username + Path.GetExtension(file.FileName);
            }
            else {
                userDTO.ImagePath = "/Images/blank-profile-hi.png";
            }
            int messageType = BusinessLayer.BusinessStore.User.CreateUser(userDTO);
            return Json(messageType, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        public static Stream GetResizedImageStream(Stream inputStream, int x, int y, int w, int h, int orgWidth, int orgHeight)
        {
            var stream = new MemoryStream();

            var image = resizeImage(Image.FromStream(inputStream), new Size(orgWidth, orgHeight));
            var imageBitmap = new Bitmap(w, h, image.PixelFormat);
            var graphics = Graphics.FromImage(imageBitmap);
            graphics.DrawImage(image, new Rectangle(0, 0, w, h), new Rectangle(x, y, w, h), GraphicsUnit.Pixel);

            imageBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream;
        }

        private static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
	}
}