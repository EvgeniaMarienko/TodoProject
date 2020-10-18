using Shared.ViewModels;
using System.Threading.Tasks;
using TodoDatabase.Models;

namespace TodoBusiness.Services
{
    public interface IUserService : ICrudService<User>
    {
        Task AddUserToTask(AddUserToTaskModel model);
    }
}
