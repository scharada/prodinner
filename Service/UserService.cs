using System;
using System.Linq;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;
using Omu.ProDinner.Core.Service;

namespace Omu.ProDinner.Service
{
    public class UserService : CrudService<User>, IUserService
    {
        public UserService(IRepo<User> repo) : base(repo)
        {
        }

        public bool IsUnique(string login)
        {
            return repo.Where(o => o.Login == login).Count() == 0;
        }

        public void ChangePassword(int id, string password)
        {
            repo.Get(id).Password = password;
            repo.Save();
        }
    }
}