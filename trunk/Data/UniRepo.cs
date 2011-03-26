using System.Collections.Generic;
using System.Data.Entity;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;

namespace Omu.ProDinner.Data
{
    public class UniRepo : IUniRepo
    {
        private readonly DbContext c;

        public UniRepo(IDbContextFactory a)
        {
            c = a.GetContext();
        }

        public void Insert<T>(T o) where T : Entity
        {
            c.Set<T>().Add(o);
        }

        public void Save()
        {
            c.SaveChanges();
        }

        public T Get<T>(int id) where T : Entity
        {
            return c.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return c.Set<T>();
        }
    }
}