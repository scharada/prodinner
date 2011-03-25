using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;
using Omu.ProDinner.Core.Service;

namespace Omu.ProDinner.Service
{
    public class MealService : CrudService<Meal>, IMealService
    {
        public MealService(IRepo<Meal> repo) : base(repo)
        {
        }

        public void HasPic(int id)
        {
            repo.Get(id).HasPic = true;
            repo.Save();
        }
    }
}