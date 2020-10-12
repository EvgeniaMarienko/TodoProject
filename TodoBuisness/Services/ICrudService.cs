using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TodoBuisness.Services
{
    public interface ICrudService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Delete(int id);
        Task Update(int id, T entity);
        Task<T> GetById(int id);
    }
}
