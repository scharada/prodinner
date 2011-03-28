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
        public ActionResult Search(string search, IEnumerable<int> selected, int page)
        {
            const int pageSize = 9;
            var result = r.Where(o => o.Name.Contains(search)).OrderByDescending(o => o.Id)
                .Where(o => selected == null || !selected.Contains(o.Id));

            var rows = this.RenderView(@"Awesome\LookupList", result.Skip((page - 1) * pageSize).Take(pageSize));

            return Json(new { rows, more = result.Count() > page * pageSize });
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