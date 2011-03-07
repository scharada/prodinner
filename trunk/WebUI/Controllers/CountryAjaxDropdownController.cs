using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class CountryAjaxDropdownController : Controller
    {
        private IRepo<Country> r;

        public CountryAjaxDropdownController(IRepo<Country> r)
        {
            this.r = r;
        }

        public ActionResult GetItems(int? key)
        {
            var list = new List<SelectListItem> {new SelectListItem {Text = "not selected", Value = ""}};


            list.AddRange(r.GetAll().Select(o => new SelectListItem
                                                 {
                                                     Text = o.Name ,
                                                     Value = o.Id.ToString(),
                                                     Selected = o.Id == key
                                                 }));
            return Json(list);
        }
    }
}