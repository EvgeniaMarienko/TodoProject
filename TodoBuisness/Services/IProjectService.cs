using System.Threading.Tasks;
using TodoBusiness.ViewModels;
﻿using TodoDatabase.Models;

namespace TodoBusiness.Services
{
    public interface IProjectService : ICrudService<Project>
    {
        Task<ProjectTasksModel> GetAllProjectTasks(int id);
    }
}