using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoBuisness.ViewModels;
using TodoDataBase.Models;

namespace TodoBuisness.Services
{
    public interface IEmployeeService:ICrudService<Employee>
    {
        Task AddEmployeeToTask(AddEmployeeToTaskModel model);
    }
}
