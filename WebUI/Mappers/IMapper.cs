namespace Omu.ProDinner.WebUI.Mappers
{
    public interface IMapper<TEntity, TInput> where TEntity : class, new() where TInput : new()
    {
        TInput ToInput(TEntity entity);
        TEntity ToEntity(TInput input, int? id = null);
    }
}