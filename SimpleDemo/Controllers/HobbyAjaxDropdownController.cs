using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SimpleDemo.Models;

namespace SimpleDemo.Controllers
{
    public class HobbyAjaxDropdownController : Controller
    {
        //data storage, for demo purposes
        private static readonly IEnumerable<Hobby> Data = new[] {
            new Hobby {Id = 1, Name = "coding"},
            new Hobby {Id = 2, Name = "sleeping"},
            new Hobby {Id = 3, Name = "cooking"},
            new Hobby {Id = 5, Name = "running"},
            new Hobby {Id = 6, Name = "gaming"},
            new Hobby {Id = 7, Name = "legos"},
        };

        //this returns a json result of an IEnumerable<SelectListItem>
        //the key is the selected value
        public ActionResult GetItems(int? key)
        {
            //construct the list
            var list = new List<SelectListItem> { new SelectListItem { Text = "not selected", Value = "0" } };
            list.AddRange(Data.Select(o => new SelectListItem { Text = o.Name, Value = o.Id.ToString(), Selected = o.Id == key }));

            return Json(list);
        }
    }
}