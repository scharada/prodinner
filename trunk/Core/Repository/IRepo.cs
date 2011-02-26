using System.Collections.Generic;
namespace Omu.AwesomeDemo.Core.Repository
{
    public interface IRepo<T>
    {
        int Insert(T o);
        void Delete(int id);
        void Update(T o);
        T Get(int id);
        IEnumerable<T> GetAll();
        int Count();
    }
}