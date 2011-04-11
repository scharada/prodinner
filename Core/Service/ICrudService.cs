using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using Omu.ProDinner.Core.Model;

namespace Omu.ProDinner.Core.Service
{
    public interface IFileManagerService
    {
        string SaveTempJpeg(Stream inputStream, out int w, out int h);
        void MakeImages(string filename, int x, int y, int w, int h);
        void DeleteImages(string filename);
    }
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
        void SetPicture(int id, string filename, int x, int y, int w, int h);
    }

    public interface IUserService : ICrudService<User>
    {
        bool IsUnique(string login);
        void ChangePassword(int id, string password);
        User Get(string Login, string password);
    }
}