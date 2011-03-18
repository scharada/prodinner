using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;
using Omu.ProDinner.Resources;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class CountryIdAjaxDropdownController : Controller
    {
        private IRepo<Country> r;

        public CountryIdAjaxDropdownController(IRepo<Country> r)
        {
            this.r = r;
        }

        public ActionResult GetItems(int? key)
        {
            var list = new List<SelectListItem> { new SelectListItem { Text = Mui.not_selected, Value = "" } };

            list.AddRange(r.GetAll().Select(o => new SelectListItem
                                                 {
                                                     Text = o.Name,
                                                     Value = o.Id.ToString(),
                                                     Selected = o.Id == key
                                                 }));
            return Json(list);
        }
    }
}