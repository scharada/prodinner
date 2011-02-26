using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Omu.Awesome.Mvc;
using Omu.Awesome.Mvc.Helpers;
using SimpleDemo.Models;

namespace SimpleDemo.Controllers
{
    public class CountryLookupController : LookupController
    {
        //data storage, for demo purposes
        private static readonly IEnumerable<Country> Data = new[] {
            new Country {Id = 1, Name = "Austria"},
            new Country {Id = 2, Name = "Norway"},
            new Country {Id = 3, Name = "Belgium"},
            new Country {Id = 4, Name = "Australia"},
            new Country {Id = 5, Name = "New Zealand"},
            new Country {Id = 6, Name = "Brazil"},
            new Country {Id = 7, Name = "Japan"},
        };

        [HttpPost]
        public ActionResult Search(string search)
        {            
            return View(@"Awesome\LookupList", Data.Where(o => o.Name.ToLower().Contains(search.ToLower())));
        }

        //this returns the string that is shown in the disabled textbox near the lookup button
        public ActionResult Get(int id)
        {
            return Content(id == 0 ? "" : Data.Where(o => o.Id == id).Single().Name);
        }
    }
}