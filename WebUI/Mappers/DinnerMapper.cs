using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;
using Omu.ProDinner.WebUI.Dto;

namespace Omu.ProDinner.WebUI.Mappers
{
    public class DinnerMapper : Mapper<Dinner, DinnerInput>
    {
        public DinnerMapper(IRepo<Dinner> repo) : base(repo)
        {
        }

        public override Dinner ToEntity(DinnerInput input, int? id = null)
        {
            var entity = base.ToEntity(input, id);

            entity.Start = entity.Start.AddHours(input.Hour).AddMinutes(input.Minute);
            entity.End = entity.Start.AddMinutes(input.Duration);
            
            return entity;
        }

        public override DinnerInput ToInput(Dinner entity)
        {
            var input = base.ToInput(entity);

            input.Minute = entity.Start.Minute;
            input.Hour = entity.Start.Hour;
            input.Duration = (int)entity.End.Subtract(entity.Start).TotalMinutes;

            return input;
        }
    }
}