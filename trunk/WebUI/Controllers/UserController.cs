using System.Linq;
using System.Web.Mvc;
using Omu.Awesome.Mvc;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Service;
using Omu.ProDinner.WebUI.Dto;
using Omu.ProDinner.WebUI.Builder;

namespace Omu.ProDinner.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Crudere<User, UserCreateInput, UserEditInput>
    {
        private new readonly IUserService s;

        public UserController(IBuilder<User, UserCreateInput> v, IBuilder<User, UserEditInput> ve, IUserService s) : base(s, v, ve)
        {
            this.s = s;
        }

        public virtual ActionResult Search(string search, int page = 1, int ps = 5)
        {
            var src = s.Where(o => o.Login.StartsWith(search), User.IsInRole("admin"));
            var rows = this.RenderView("rows", src.OrderByDescending(u => u.Id).Skip((page - 1) * ps).Take(ps));

            return Json(new { rows, more = src.Count() > page * ps });
        }

        public ActionResult ChangePassword(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordInput input)
        {
            if (!ModelState.IsValid) return View(input);
            s.ChangePassword(input.Id, input.Password);
            return Content("ok");
        }
    }
}