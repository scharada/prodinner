using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;
using Omu.ProDinner.Infra;

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
            if (o is IDel)
                (o as IDel).IsDeleted = true;
            else
                c.Set<T>().Remove(o);
        }

        public T Get(int id)
        {
            return c.Set<T>().Find(id);
        }

        public void Restore(T o)
        {
            if (o is IDel)
                IoC.Resolve<IDelRepo<T>>().Restore(o);
        }

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false)
        {
            if (typeof(IDel).IsAssignableFrom(typeof(T)))
                return IoC.Resolve<IDelRepo<T>>().Where(predicate, showDeleted);
            return c.Set<T>().Where(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            if (typeof(IDel).IsAssignableFrom(typeof(T)))
                return IoC.Resolve<IDelRepo<T>>().GetAll();
            return c.Set<T>();
        }
    }
}