using System.Collections.Generic;
using Omu.AwesomeDemo.Core.Model;
using Omu.AwesomeDemo.Core.Repository;
using Omu.AwesomeDemo.Core.Service;

namespace Omu.AwesomeDemo.Service
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
            return repo.Insert(e);
        }

        public virtual void Save(T e)
        {
            repo.Update(e);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }
    }
}