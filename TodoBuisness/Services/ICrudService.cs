using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoBusiness.Services
{
    public interface ICrudService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Delete(int id);
        Task<T> Update(int id, T entity);
        Task<T> GetById(int id);
    }
}
