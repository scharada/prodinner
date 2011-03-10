using System;
using System.Web.Mvc;
using Omu.ProDinner.Core;
using Omu.ProDinner.Infra.Dto;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(Exception error)
        {
            ViewBag.Message = error.Message;
            if(Request.IsAjaxRequest())
            {
                if (error is ProDinnerException)
                    return View("Expectedp");
                return View("Errorp");
            }

            if (error is ProDinnerException)
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