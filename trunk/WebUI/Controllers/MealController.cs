using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using Omu.Awesome.Mvc;
using Omu.Drawing;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Service;
using Omu.ProDinner.Infra.Builder;
using Omu.ProDinner.Infra.Dto;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class MealController : Cruder<Meal, MealInput>
    {
        private new readonly IMealService s;
        public MealController(IMealService s, IBuilder<Meal, MealInput> v)
            : base(s, v)
        {
            this.s = s;
        }

        public virtual ActionResult Search(string search, int? sCountry, int page = 1, int ps = 5)
        {
            var src = s.Where(o => o.Name.StartsWith(search));
            var rows = this.RenderView("rows", src.OrderByDescending(u => u.Id).Skip((page - 1) * ps).Take(ps));

            return Json(new { rows, more = src.Count() > page * ps });
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Picture(int id)
        {
            return View(s.Get(id));
        }

        [HttpPost]
        public ActionResult Picture()
        {
            var file = Request.Files["fileUpload"];
            var id = Convert.ToInt32(Request.Form["id"]);
            if (file.ContentLength > 0)
            {
                var filePath = @ConfigurationManager.AppSettings["storagePath"] + @"Meals\Temp\" + id + ".jpg";
                using (var image = Image.FromStream(file.InputStream))
                {
                    var resized = Imager.Resize(image, 640, 480, true);
                    Imager.SaveJpeg(filePath, resized);
                    return RedirectToAction("Crop", new CropInput { ImageWidth = resized.Width, ImageHeight = resized.Height, Id = id });
                }
            }

            return RedirectToAction("Index");
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Crop(CropInput cropDisplay)
        {
            return View(cropDisplay);
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Crop(int x, int y, int w, int h, int id)
        {
            using (var image = Image.FromFile(@ConfigurationManager.AppSettings["storagePath"] + @"\Meals\Temp\" + id + ".jpg"))
            {
                var img = Imager.Crop(image, new Rectangle(x, y, w, h));
                var resized = Imager.Resize(img, 200, 150, true);
                var small = Imager.Resize(img, 100, 75, true);
                var mini = Imager.Resize(img, 45, 34, true);
                Imager.SaveJpeg(@ConfigurationManager.AppSettings["storagePath"] + @"\Meals\" + id + ".jpg", resized);
                Imager.SaveJpeg(@ConfigurationManager.AppSettings["storagePath"] + @"\Meals\" + id + "s.jpg", small);
                Imager.SaveJpeg(@ConfigurationManager.AppSettings["storagePath"] + @"\Meals\" + id + "m.jpg", mini);
                s.HasPic(id);
            }
            return RedirectToAction("Picture", new { id });
        }
    }
}