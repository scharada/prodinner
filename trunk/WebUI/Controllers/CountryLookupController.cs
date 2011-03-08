using System.Web.Mvc;
using Omu.Awesome.Mvc;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class CountryLookupController : LookupController
    {
        private readonly IRepo<Country> r;

        public CountryLookupController(IRepo<Country> r)
        {
            this.r = r;
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            return View(@"Awesome\LookupList", r.Where(o => o.Name.StartsWith(search)));
        }

        public ActionResult Get(int id)
        {      
            return Content((r.Get(id) ?? new Country()).Name);
        }
    }
}