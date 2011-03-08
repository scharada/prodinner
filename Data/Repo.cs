using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;

namespace Omu.ProDinner.Data
{
    public class Repo<T> : IRepo<T> where T : Entity, new()
    {
        protected readonly DbContext c;

        public Repo(IDbContextFactory f)
        {
            c = f.GetContext();
        }

        public void Save()
        {
            c.SaveChanges();
        }

        public void Insert(T o)
        {
            c.Set<T>().Add(o);
        }

        public void Delete(T o)
        {
            o.IsDeleted = true;
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return c.Set<T>().Where(predicate).Where(o => o.IsDeleted == false);
        }

        public IEnumerable<T> GetAll()
        {
            return c.Set<T>().Where(o => o.IsDeleted == false);
        }

        public T Get(long id)
        {
            return c.Set<T>().Find(id);
        }

        public int Count()
        {
            return c.Set<T>().Count();
        }
    }
}