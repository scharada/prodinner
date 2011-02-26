using System;
using System.Web.Mvc;
using Omu.AwesomeDemo.Infra.Dto;
using Omu.AwesomeDemo.Core;

namespace Omu.AwesomeDemo.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(Exception error)
        {
            if(Request.IsAjaxRequest())
            {
                if (error is AwesomeDemoException)
                    return PartialView("Expectedp", new ErrorDisplay { Message = error.Message });
                return PartialView("Errorp", new ErrorDisplay { Message = error.Message });
            }

            if (error is AwesomeDemoException)
                return View("Expected", new ErrorDisplay { Message = error.Message });
            return View("Error", new ErrorDisplay{Message = error.Message});
        }

        public ActionResult HttpError404(Exception error)
        {
            return View();
        }

        public ActionResult HttpError505(Exception error)
        {
            return View();
        }
    }
}