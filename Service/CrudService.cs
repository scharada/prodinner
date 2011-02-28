using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;
using Omu.ProDinner.Core.Service;
using Omu.ValueInjecter;

namespace Omu.ProDinner.Service
{
    public class CrudService<T> : ICrudService<T> where T : Entity, new()
    {
        protected IRepo<T> repo;

        public CrudService(IRepo<T> repo)
        {
            this.repo = repo;
        }

        public IEnumerable<T> GetAll()
        {
            return repo.GetAll();
        }

        public int Count()
        {
            return repo.Count();
        }

        public T Get(int id)
        {
            return repo.Get(id);
        }

        public virtual int Create(T e)
        {
            repo.Insert(e);
            repo.Save();
            return e.Id;
        }

        public virtual void Save(T e)
        {
            var o = repo.Get(e.Id);
            o.InjectFrom(e);
            repo.Save();
        }

        public virtual void Delete(int id)
        {
            repo.Delete(repo.Get(id));
            repo.Save();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return repo.Where(predicate);
        }
    }
}