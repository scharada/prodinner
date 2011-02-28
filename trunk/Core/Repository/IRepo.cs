using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Omu.ProDinner.Core.Model;

namespace Omu.ProDinner.Core.Repository
{
    public interface IRepo<T>
    {
        T Get(long id);
        IEnumerable<T> GetAll();
        int Count();
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);
        void Insert(T o);
        void Save();
        void Delete(T o);
        void Delete(IEnumerable<T> oo);
        void Insert(IEnumerable<T> oo);
    }

    public interface IUniRepo
    {
        void Insert<T>(T o) where T : Entity;
        void Save();
        T Get<T>(int id) where T : Entity;
    }
}