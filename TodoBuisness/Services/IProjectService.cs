using System.Collections.Generic;
using System.Threading.Tasks;
using TodoBusiness.ViewModels;
﻿using TodoDatabase.Models;

namespace TodoBusiness.Services
{
    public interface IProjectService : ICrudService<Project>
    {
        Task<IEnumerable<ProjectTasksModel>> GetAllProjectTasks(int id);
    }
}