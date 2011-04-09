using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;

namespace Omu.ProDinner.Data
{
    public class DelRepo<T> : IDelRepo<T> where T : DelEntity
    {
        protected readonly DbContext c;

        public DelRepo(IDbContextFactory f)
        {
            c = f.GetContext();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false)
        {
            var res = c.Set<T>().Where(predicate);
            if (!showDeleted) res = res.Where(o => o.IsDeleted == false);
            return res;
        }

        public IEnumerable<T> GetAll()
        {
            return c.Set<T>().Where(o => o.IsDeleted == false);
        }

        public void Restore(T o)
        {
            o.IsDeleted = false;
        }
    }
}