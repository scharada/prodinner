using System.Web.Mvc;
using System.Web.UI;
using Omu.ProDinner.Core;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Service;
using Omu.ProDinner.WebUI.Dto;
using Omu.ProDinner.WebUI.Mappers;

namespace Omu.ProDinner.WebUI.Controllers
{
    /// <summary>
    /// generic crud controller for entities where there is difference between the edit and create view
    /// </summary>
    /// <typeparam name="TEntity"> the entity</typeparam>
    /// <typeparam name="TCreateInput">create viewmodel</typeparam>
    /// <typeparam name="TEditInput">edit viewmodel</typeparam>
    public class Crudere<TEntity, TCreateInput, TEditInput> : BaseController
        where TCreateInput : new()
        where TEditInput : Input, new()
        where TEntity : DelEntity, new()
    {
        protected readonly ICrudService<TEntity> s;
        private readonly IMapper<TEntity, TCreateInput> v;
        private readonly IMapper<TEntity, TEditInput> ve;

        protected virtual string EditView
        {
            get { return "edit"; }
        }

        public Crudere(ICrudService<TEntity> s, IMapper<TEntity, TCreateInput> v, IMapper<TEntity, TEditInput> ve)
        {
            this.s = s;
            this.v = v;
            this.ve = ve;
        }

        public virtual ActionResult Index()
        {
            return View("cruds");
        }

        public ActionResult Row(int id)
        {
            return View("rows", new[] { s.Get(id) });
        }

        public ActionResult Create()
        {
            return View(v.ToInput(new TEntity()));
        }

        [HttpPost]
        public ActionResult Create(TCreateInput o)
        {
            if (!ModelState.IsValid)
                return View(o);
            return Json(new { Id = s.Create(v.ToEntity(o)) });
        }

        [OutputCache(Location = OutputCacheLocation.None)]//for ie8
        public ActionResult Edit(int id)
        {
            var o = s.Get(id);
            if (o == null) throw new ProDinnerException("this entity doesn't exist anymore");
            return View(EditView, ve.ToInput(o));
        }

        [HttpPost]
        public ActionResult Edit(TEditInput input)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(EditView, input);
                s.Save(ve.ToEntity(input, input.Id));
            }
            catch (ProDinnerException ex)
            {
                return Content(ex.Message);
            }
            return Json(new { input.Id });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            s.Delete(id);
            return Json(new { Id = id });
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Restore(int id)
        {
            s.Restore(id);
            return Json(new { Id = id });
        }
    }
}