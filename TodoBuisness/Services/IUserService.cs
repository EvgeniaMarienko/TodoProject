﻿using System.Threading.Tasks;
using TodoBusiness.ViewModels;
using TodoDatabase.Models;

namespace TodoBusiness.Services
{
    public interface IUserService : ICrudService<User>
    {
        Task AddEmployeeToTask(AddUserToTaskModel model);
    }
}