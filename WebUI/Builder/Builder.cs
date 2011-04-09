using Omu.ProDinner.Core;
using Omu.ProDinner.Core.Repository;
using Omu.ValueInjecter;

namespace Omu.ProDinner.WebUI.Builder
{
    public class Builder<TEntity, TInput> : IBuilder<TEntity, TInput>
        where TEntity : class, new()
        where TInput : new()
    {
        private readonly IRepo<TEntity> repo;

        public Builder(IRepo<TEntity> repo)
        {
            this.repo = repo;
        }

        public TInput BuildInput(TEntity entity)
        {
            var input = new TInput();
            input.InjectFrom(entity)
                .InjectFrom<NormalToNullables>(entity)
                .InjectFrom<EntitiesToInts>(entity);
            MakeInput(entity, ref input);
            return input;
        }

        protected virtual void MakeInput(TEntity entity, ref TInput input)
        {
        }

        public TEntity BuildEntity(TInput input, int? id)
        {
            var e = id.HasValue ? repo.Get(id.Value) : new TEntity();
            if (e == null)
                throw new ProDinnerException("this entity doesn't exist anymore");

            e.InjectFrom(input)
               .InjectFrom<IntsToEntities>(input)
               .InjectFrom<NullablesToNormal>(input);
            MakeEntity(ref e, input);
            return e;
        }

        protected virtual void MakeEntity(ref TEntity entity, TInput input)
        {
        }

        public TInput RebuildInput(TInput input, int? id)
        {
            return BuildInput(BuildEntity(input, id));
        }
    }
}