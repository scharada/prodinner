using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Omu.Awesome.Mvc;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Service;
using Omu.ProDinner.Infra.Builder;
using Omu.ProDinner.Infra.Dto;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class DinnerController: Cruder<Dinner,DinnerInput>
    {
        public DinnerController(ICrudService<Dinner> s, IBuilder<Dinner, DinnerInput> v) : base(s, v)
        {
        }

        public override ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Search(string search, int? chef, IEnumerable<int> meals, int page = 1, int ps = 5)
        {
            var src = s.Where(o => o.Name.StartsWith(search));
            if (chef.HasValue) src = src.Where(o => o.Chef.Id == chef.Value);
            if (meals != null) src = src.Where(o => meals.All(m => o.Meals.Select(g => g.Id).Contains(m)));

            var rows = this.RenderView("rows", src.OrderByDescending(u => u.Id).Skip((page - 1) * ps).Take(ps));

            return Json(new { rows, more = src.Count() > page * ps });
        }
    }
}