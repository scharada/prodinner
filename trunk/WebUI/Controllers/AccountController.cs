using System.Web.Mvc;
using Omu.ProDinner.Core.Security;
using Omu.ProDinner.Infra.Dto;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IFormsAuthentication formsAuth;

        public AccountController(IFormsAuthentication formsAuth)
        {
            this.formsAuth = formsAuth;
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInInput input)
        { 
            if (!ModelState.IsValid)
            {
                input.Password = null;
                input.Login = null;
                return View(input);
            }
            
            if (input.Login != "o" || input.Password != "1" )
            {
                ModelState.AddModelError("", "Numele sau parola nu sunt introduse corect, va rugam sa mai incercati o data");
                return View();
            }

            formsAuth.SignIn("o", false, new[]{"admin"});

            return RedirectToAction("index", "dinner");

        }

        public ActionResult SignOff()
        {
            formsAuth.SignOut();
            return RedirectToAction("SignIn", "Account");
        }
    }
}