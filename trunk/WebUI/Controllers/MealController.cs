using System.Linq;
using System.Web;
using System.Web.Mvc;
using Omu.Awesome.Mvc;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Service;
using Omu.ProDinner.WebUI.Dto;
using Omu.ProDinner.WebUI.Builder;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class MealController : Cruder<Meal, MealInput>
    {
        private new readonly IMealService s;
        private readonly IFileManagerService fileManagerService;

        public MealController(IMealService s, IBuilder<Meal, MealInput> v, IFileManagerService fileManagerService)
            : base(s, v)
        {
            this.s = s;
            this.fileManagerService = fileManagerService;
        }

        public override ActionResult Index()
        {
            ViewBag.UseList = true;
            return base.Index();
        }

        public virtual ActionResult Search(string search, int? sCountry, int page = 1, int ps = 6)
        {
            var src = s.Where(o => o.Name.StartsWith(search), User.IsInRole("admin"));
            var rows = this.RenderView("rows", src.OrderByDescending(u => u.Id).Skip((page - 1) * ps).Take(ps));

            return Json(new { rows, more = src.Count() > page * ps });
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            int w, h;
            var name = fileManagerService.SaveTempJpeg(file.InputStream, out w, out h);
            return Json(new { name, type = file.ContentType, size = file.ContentLength, w, h });
        }

        public ActionResult Cp(int id)
        {
            return View(s.Get(id));
        }

        [HttpPost]
        public ActionResult Crop(int x, int y, int w, int h, string filename, int id)
        {
            s.SetPicture(id, filename, x, y, w, h);
            return Json(new { name = filename });
        }
    }
}