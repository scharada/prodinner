using Omu.AwesomeDemo.Core;
using Omu.AwesomeDemo.Core.Repository;
using Omu.ValueInjecter;

namespace Omu.AwesomeDemo.Infra.Builder
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
                .InjectFrom<EntityToNullInt>(entity)
                .InjectFrom<EntitiesToInts>(entity);
            MakeInput(entity, ref input);
            return input;
        }

        protected virtual void MakeInput(TEntity entity, ref TInput input)
        {
        }

        public TEntity BuildEntity(TInput input, int? id)
        {
            var entity = id.HasValue ? repo.Get(id.Value) : new TEntity();
            if (entity == null)
                throw new AwesomeDemoException("this entity doesn't exist anymore");

            //creating a clone, since my Db is a static class, changing the entity directly will change it in the Db in my case
            var e = new TEntity();
            e.InjectFrom(entity);
            //not needed for a real app (with DB)

            e.InjectFrom(input)
               .InjectFrom<NullIntToEntity>(input)
               .InjectFrom<IntsToEntities>(input);
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