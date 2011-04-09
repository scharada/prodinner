using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Omu.Awesome.Mvc;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Service;
using Omu.ProDinner.WebUI.Dto;
using Omu.ProDinner.WebUI.Builder;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class DinnerController: Cruder<Dinner,DinnerInput>
    {
        public DinnerController(ICrudService<Dinner> s, IBuilder<Dinner, DinnerInput> v) : base(s, v)
        {
        }

        public override ActionResult Index()
        {
            ViewBag.UseList = true;
            return base.Index();
        }

        public virtual ActionResult Search(string search, int? chefId, IEnumerable<int> meals, int page = 1, int ps = 5)
        {
            var src = s.Where(o => o.Name.Contains(search), User.IsInRole("admin"));
            if (chefId.HasValue) src = src.Where(o => o.ChefId == chefId.Value);
            if (meals != null) src = src.Where(o => meals.All(m => o.Meals.Select(g => g.Id).Contains(m)));

            var rows = this.RenderView("rows", src.OrderByDescending(u => u.Id).Skip((page - 1) * ps).Take(ps));

            return Json(new { rows, more = src.Count() > page * ps });
        }

        public ActionResult About()
        {
            return View();
        }
    }
}