using System.Linq;
using System.Web.Mvc;
using Omu.Awesome.Mvc;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Service;
using Omu.ProDinner.Infra.Builder;
using Omu.ProDinner.Infra.Dto;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class ChefController : Cruder<Chef, ChefInput>
    {
        public ChefController(ICrudService<Chef> s, IBuilder<Chef, ChefInput> v)
            : base(s, v)
        {
        }
        public virtual ActionResult Search(string search, int? sCountry, int page = 1, int ps = 5)
        {
            var src = s.Where(o => o.FName.StartsWith(search) || o.LName.StartsWith(search));
            if (sCountry != null) src = src.Where(o => o.Country.Id == sCountry);
            var rows = this.RenderView("rows", src.OrderBy(u => u.Id).Skip((page - 1) * ps).Take(ps));

            return Json(new { rows, more = src.Count() > page * ps });
        }
    }
}