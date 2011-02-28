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

        public void Insert(IEnumerable<T> oo)
        {
            foreach (var o in oo)
                Insert(o);
        }

        public virtual void Delete(T o)
        {
            c.Set<T>().Remove(o);
        }

        public virtual void Delete(IEnumerable<T> oo)
        {
            foreach (var o in oo)
                Delete(o);
        }

        public T Get(long id)
        {
            return c.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return c.Set<T>().Where(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return c.Set<T>();
        }

        public int Count()
        {
            return c.Set<T>().Count();
        }
    }
}