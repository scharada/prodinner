using System.Web.Mvc;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class DoggyController : Controller
    {
        public ActionResult Tell(string c, string a)
        {
            return Json(new {o = "hi"});
        }
    }
}