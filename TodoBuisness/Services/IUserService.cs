using Shared.ViewModels;
using System.Threading.Tasks;
using TodoDatabase.Models;

namespace TodoBusiness.Services
{
    public interface IUserService : ICrudService<User>
    {
        Task Add(RegistrationViewModel model);
        Task AddUserToTask(AddUserToTaskViewModel model);
    }
}
