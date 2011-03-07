using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Omu.ProDinner.WebUI.Controllers
{
    //http://www.screwturn.eu/ResxSync.ashx
    public class MuiController : Controller
    {
        public ActionResult Index()
        {
            IDictionary<string, string> langs = new Dictionary<string, string>
                                                    {
                                                        {"en","english"},
                                                        {"fr","francais"},
                                                        {"it","italiano"},
                                                        {"ro","romana"},
                                                        {"de","deutch"},
                                                        {"ru","ruschii"},
                                                    };
            var c = Request.Cookies["lang"];
            var k = c == null ? "en" : c.Value;
            ViewBag.lang = langs[k];
            return View();
        }

        public ActionResult Langs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Change(string l)
        {
            var aCookie = new HttpCookie("lang") { Value = l, Expires = DateTime.Now.AddYears(1) };
            Response.Cookies.Add(aCookie);

            return Content("");
        }
        
    }
}