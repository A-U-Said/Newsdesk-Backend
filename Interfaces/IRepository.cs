using System.Collections.Generic;
using NewsDesk.Models;

namespace NewsDesk.Interfaces
{
    public interface IRepository<T>
    {
        T Find(int id);
        List<T> GetAll();
        T Add(T newItem);
        T Update(T editItem);
        void Remove(int id);
    }

    public interface IRepository<T, TExt>
    {
        TExt Find(int id);
        List<T> GetAll();
        T Add(T newItem);
        T Update(T editItem);
        void Remove(int id);
    }
}
