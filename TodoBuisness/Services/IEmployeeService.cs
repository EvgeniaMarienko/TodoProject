using System.Threading.Tasks;
using TodoBuisness.ViewModels;
using TodoDatabase.Models;

namespace TodoBuisness.Services
{
    public interface IEmployeeService : ICrudService<Employee>
    {
        Task AddEmployeeToTask(AddEmployeeToTaskModel model);
    }
}
