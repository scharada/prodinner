using System.Web.Mvc;
using Omu.Awesome.Mvc;
using SimpleDemo.Models;

namespace SimpleDemo.Controllers
{
    [WhiteSpaceFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PopupForm(int country, int hobby)
        {
            return View(new Person { Country = country, Hobby = hobby });
        }        
        
        [HttpPost]
        public ActionResult PopupForm(Person input)
        {
            return Content("ok");
        }

        public ActionResult Hi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Hi(string name)
        {
            return Json(new{name});
        }

        public ActionResult Ido()
        {
            ViewBag.msg = "you do";
            return View("index");
        }

        public ActionResult SayHi()
        {
            return Content("hi");
        }
    }
}
