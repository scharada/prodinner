using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Omu.Awesome.Mvc;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class MealsLookupController : LookupController
    {
        private readonly IRepo<Meal> r;

        public MealsLookupController(IRepo<Meal> r)
        {
            this.r = r;
        }
        [HttpPost]
        public ActionResult Search(string search, IEnumerable<int> selected)
        {
            var result = r.GetAll().Where(o => o.Name.Contains(search));

            return View(@"Awesome\LookupList", result.Where(o => selected == null || !selected.Contains(o.Id)).ToList());
        }

        public ActionResult Selected(IEnumerable<int> selected)
        {
            return View(@"Awesome\LookupList", r.GetAll().Where(o => selected != null && selected.Contains(o.Id)));
        }

        public ActionResult GetMultiple(IEnumerable<int> selected)
        {
            return Json(r.GetAll().Where(o => selected.Contains(o.Id)).Select(v => new
            {
                Text = @"<img  src='" + 
                Url.Content("~/pictures/Meals/" + (v.HasPic ? v.Id : 0) + "m.jpg") + 
                "' class='mthumb' />" + 
                v.Name
            }));
        }

    }
}