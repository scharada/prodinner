using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;
using Omu.ProDinner.Core.Service;

namespace Omu.ProDinner.Service
{
    public class MealService : CrudService<Meal>, IMealService
    {
        private readonly IFileManagerService fileManagerService;

        public MealService(IRepo<Meal> repo, IFileManagerService fileManagerService) : base(repo)
        {
            this.fileManagerService = fileManagerService;
        }

        public void SetPicture(int id, string filename, int x,int y, int w, int h)
        {
            fileManagerService.MakeImages(filename, x, y, w, h);
            var o = repo.Get(id);
            if (o.Picture == filename) return;
            
            var old = o.Picture;
            o.Picture = filename;
            repo.Save();

            if(!string.IsNullOrWhiteSpace(old)) fileManagerService.DeleteImages(old);
        }
    }
}