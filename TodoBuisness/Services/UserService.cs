using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoBusiness.Exceptions;
using TodoBusiness.ViewModels;
using TodoDatabase;
using TodoDatabase.Models;

namespace TodoBusiness.Services
{
    public class UserService : IUserService
    {
        private TodoContext _todoContext;
        public UserService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<User> Add(User employee)
        {
            _todoContext.Users.Add(employee);
            await _todoContext.SaveChangesAsync();
            return employee;
        }

        public async Task<User> Delete(int id)
        {
            if (!(await (IsEmployee(id))))
            {
                throw new EmployeeNotFoundException(id);
            }
            else
            {
                var result = await GetById(id);
                _todoContext.Users.Remove(result);
                await _todoContext.SaveChangesAsync();
                return result;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _todoContext.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            var result = await _todoContext.Users.FindAsync(id);
            if (result == null)
            {
                throw new EmployeeNotFoundException(id);
            }
            return result;
        }

        public async Task<User> Update(int id, User employee)
        {
            if (employee.Id != id)
            {
                throw new EmployeeBadRequestException();
            }
            if (!(await IsEmployee(id)))
            {
                throw new EmployeeNotFoundException(id);
            }
            else
            {
                _todoContext.Users.Update(employee);
                await _todoContext.SaveChangesAsync();
                return employee;
            }
        }

        public async Task<bool> IsEmployee(int id)
        {
            return await _todoContext.Users.AnyAsync(e => e.Id == id);
        }

        public async Task AddEmployeeToTask(AddUserToTaskModel model)
        {
            var employee = await _todoContext.Users.FindAsync(model.UserId);
            var task = await _todoContext.TodoItems.FindAsync(model.TaskId);
            if (employee == null)
            {
                throw new EmployeeNotFoundException(model.UserId);
            }
            if (task == null)
            {
                throw new TodoItemNotFoundException(model.TaskId);
            }
            task.UserId = employee.Id;
            await _todoContext.SaveChangesAsync();
        }
    }
}
