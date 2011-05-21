using Omu.ProDinner.Core;
using Omu.ProDinner.Core.Repository;
using Omu.ValueInjecter;

namespace Omu.ProDinner.WebUI.Mappers
{
    public class Mapper<TEntity, TInput> : IMapper<TEntity, TInput>
        where TEntity : class, new()
        where TInput : new()
    {
        private readonly IRepo<TEntity> repo;

        public Mapper(IRepo<TEntity> repo)
        {
            this.repo = repo;
        }

        public virtual TInput ToInput(TEntity entity)
        {
            var input = new TInput();
            input.InjectFrom(entity)
                .InjectFrom<NormalToNullables>(entity)
                .InjectFrom<EntitiesToInts>(entity);
            return input;
        }

        public virtual TEntity ToEntity(TInput input, int? id = null)
        {
            var e = id.HasValue ? repo.Get(id.Value) : new TEntity();
            if (e == null)
                throw new ProDinnerException("this entity doesn't exist anymore");

            e.InjectFrom(input)
               .InjectFrom<IntsToEntities>(input)
               .InjectFrom<NullablesToNormal>(input);
            return e;
        }
    }
}