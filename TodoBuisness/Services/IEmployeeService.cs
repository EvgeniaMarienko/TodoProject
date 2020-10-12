using System.Threading.Tasks;
using TodoBusiness.ViewModels;
using TodoDatabase.Models;

namespace TodoBusiness.Services
{
    public interface IEmployeeService : ICrudService<Employee>
    {
        Task AddEmployeeToTask(AddEmployeeToTaskModel model);
    }
}
