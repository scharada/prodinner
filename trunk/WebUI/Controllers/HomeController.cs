using System;
using System.Web;
using System.Web.Mvc;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private IRepo<Country> r;

        public HomeController(IRepo<Country> r)
        {
            this.r = r;
        }

        [HttpPost]
        public ActionResult Cl(string l)
        {
            var aCookie = new HttpCookie("lang") {Value = l, Expires = DateTime.Now.AddYears(1)};
            Response.Cookies.Add(aCookie);
 
            return Content("");
        }

        public ActionResult Index()
        {
            
            return View(r.GetAll());
        }

        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult CreateCountry()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateCountry(Country c)
        {
            if (!ModelState.IsValid)
            {
                return View(c);
            }
            r.Insert(c);
            r.Save();
            return RedirectToAction("Index");
        }
    }
}
