using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;

namespace Omu.ProDinner.Data
{
    public class Repo<T> : IRepo<T> where T : DelEntity, new()
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
        
        public void Restore(T o)
        {
            o.IsDeleted = false;
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false)
        {
            var res = c.Set<T>().Where(predicate);
            if(!showDeleted) res = res.Where(o => o.IsDeleted == false);
            return res;
        }

        public IEnumerable<T> GetAll()
        {
            return c.Set<T>().Where(o => o.IsDeleted == false);
        }

        public T Get(int id)
        {
            return c.Set<T>().Find(id);
        }

        public int Count()
        {
            return c.Set<T>().Count();
        }
    }
}