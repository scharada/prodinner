using System.Linq;
using Omu.Encrypto;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;
using Omu.ProDinner.Core.Service;
using Omu.ValueInjecter;

namespace Omu.ProDinner.Service
{
    public class UserService : CrudService<User>, IUserService
    {
        private readonly IHasher hasher;

        public UserService(IRepo<User> repo, IHasher hasher)
            : base(repo)
        {
            this.hasher = hasher;
            hasher.SaltSize = 10;
        }

        public override int Create(User e)
        {
            e.Password = hasher.Encrypt(e.Password);
            return base.Create(e);
        }

        public override void Save(User e)
        {
            var o = repo.Get(e.Id);
            o.InjectFrom(new Same("Password"), e);
            repo.Save();
        }

        public bool IsUnique(string login)
        {
            return repo.Where(o => o.Login == login).Count() == 0;
        }

        public User Get(string Login, string password)
        {
            var user = repo.Where(o => o.Login == Login && o.IsDeleted == false).SingleOrDefault();
            if (user == null || !hasher.CompareStringToHash(password, user.Password)) return null;
            return user;
        }

        public void ChangePassword(int id, string password)
        {
            repo.Get(id).Password = hasher.Encrypt(password);
            repo.Save();
        }
    }
}