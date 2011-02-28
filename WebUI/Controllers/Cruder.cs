using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Service;
using Omu.ProDinner.Infra.Builder;
using Omu.ProDinner.Infra.Dto;

namespace Omu.ProDinner.WebUI.Controllers
{
    /// <summary>
    /// generic crud controller for entities where there is no difference between the edit and create view
    /// </summary>
    /// <typeparam name="TEntity">the entity</typeparam>
    /// <typeparam name="TInput"> viewmodel </typeparam>
    public class Cruder<TEntity, TInput> : Crudere<TEntity,TInput,TInput>
        where TInput : Input, new()
        where TEntity : Entity, new()
    {
        public Cruder(ICrudService<TEntity> s, IBuilder<TEntity, TInput> v) : base(s, v, v)
        {
        }
        
        protected override string EditView
        {
            get { return "create"; }
        }
    }
}