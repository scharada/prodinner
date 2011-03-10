using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;
using Omu.ProDinner.Resources;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class ChefAjaxDropdownController : Controller
    {
        private IRepo<Chef> r;

        public ChefAjaxDropdownController(IRepo<Chef> r)
        {
            this.r = r;
        }

        public ActionResult GetItems(int? key)
        {
            var list = new List<SelectListItem> { new SelectListItem { Text = Mui.not_selected, Value = "" } };


            list.AddRange(r.GetAll().Select(o => new SelectListItem
                                                     {
                                                         Text = string.Format("{0} {1}",o.FName,o.LName),
                                                         Value = o.Id.ToString(),
                                                         Selected = o.Id == key
                                                     }));
            return Json(list);
        }
    }
}