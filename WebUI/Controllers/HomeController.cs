using System.Web.Mvc;
namespace Omu.AwesomeDemo.WebUI.Controllers
{
    public class HomeController : BaseController
    {        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
