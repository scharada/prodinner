using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Omu.ProDinner.Core.Model;

namespace Omu.ProDinner.Core.Service
{
    public interface ICrudService<T> where T: DelEntity, new()
    {
        int Create(T e);
        void Save(T e);
        void Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
        int Count();
        IEnumerable<T> Where(Expression<Func<T, bool>> func, bool showDeleted = false);
        void Restore(int id);
    }

    public interface IMealService : ICrudService<Meal>
    {
        void HasPic(int id);
    }

    public interface IUserService : ICrudService<User>
    {
        bool IsUnique(string login);
        void ChangePassword(int id, string password);
        User Get(string Login, string password);
    }
}