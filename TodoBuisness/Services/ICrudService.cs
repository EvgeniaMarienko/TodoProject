using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TodoBuisness.Services
{
    public interface ICrudService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task AddItem(T todoItem);
        Task DeleteItem(int id);
        Task UpdateId(int id, T todoItem);
        Task<T> GetById(int id);
    }
}
