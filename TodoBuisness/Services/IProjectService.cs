using System.Threading.Tasks;
using TodoBusiness.ViewModels;
using TodoDataBase.Models;

namespace TodoBuisness.Services
{
    public interface IProjectService : ICrudService<Project>
    {
        Task<ProjectTasksModel> GetAllProjectTasks(int id);
    }
}
