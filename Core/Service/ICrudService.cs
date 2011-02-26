using System.Collections.Generic;
using Omu.AwesomeDemo.Core.Model;

namespace Omu.AwesomeDemo.Core.Service
{
    public interface ICrudService<T> where T: Entity, new()
    {
        int Create(T e);
        void Save(T e);
        void Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
        int Count();
    }
}