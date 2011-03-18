using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Omu.Awesome.Mvc;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class DinnerAutocompleteController : Controller
    {
        private readonly IRepo<Dinner> r;

        public DinnerAutocompleteController(IRepo<Dinner> r)
        {
            this.r = r;
        }

        public JsonResult Search(string searchText, int maxResults, int? chef, IEnumerable<int> meals)
        {
            var res = r.Where(o => o.Name.Contains(searchText));
            if (chef.HasValue) res = res.Where(o => o.ChefId == chef);
            if (meals != null) res = res.Where(o => meals.All(m => o.Meals.Select(g => g.Id).Contains(m)));

            return Json(res.Select(i => new IdTextItem { Text = i.Name, Id = i.Id })
                            .Take(maxResults));
        }
    }
}