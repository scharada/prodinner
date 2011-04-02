using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class ChangeThemeController : Controller
    {
        private const string d = "blitzer";
        private const string cookie = "projqtheme";
        public ActionResult Index()
        {
            var theme = d;
            if (Request.Cookies[cookie] != null)
                theme = Request.Cookies[cookie].Value;

            var themes = new[] {"base","black-tie","blitzer","cupertino","dark-hive","dot-luv","eggplant", "excite-bike", "flick","hot-sneaks","humanity", "le-frog", "mint-choc", "overcast", "pepper-grinder", "redmond", "smoothness","south-street", "start", "sunny", "swanky-purse", "trontastic", "ui-darkness", "ui-lightness", "vader"};

            var items = themes.Select(o => new SelectListItem {Text = o, Value = o, Selected = o == theme});

            return View(items);
        }

        [HttpPost]
        public ActionResult Change(string[] themes)
        {
            var theme = themes[0];
            Response.Cookies.Add(new HttpCookie(cookie,theme){Expires = DateTime.Now.AddYears(1)});
            return new EmptyResult();
        }

        public ActionResult CurrentTheme()
        {
            var theme = d;
            if (Request.Cookies[cookie] != null)
                theme = Request.Cookies[cookie].Value;

            return Content(theme);
        }
    }
}