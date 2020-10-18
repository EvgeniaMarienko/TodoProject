using Microsoft.EntityFrameworkCore;
using Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoBusiness.Exceptions;
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

        public async Task<User> Add(User user)
        {
            _todoContext.Users.Add(user);
            await _todoContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Delete(int id)
        {
            if (!(await (IsUser(id))))
            {
                throw new UserNotFoundException(id);
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
                throw new UserNotFoundException(id);
            }
            return result;
        }

        public async Task<User> Update(int id, User user)
        {
            if (user.Id != id)
            {
                throw new UserBadRequestException();
            }
            if (!(await IsUser(id)))
            {
                throw new UserNotFoundException(id);
            }
            else
            {
                _todoContext.Users.Update(user);
                await _todoContext.SaveChangesAsync();
                return user;
            }
        }

        public async Task<bool> IsUser(int id)
        {
            return await _todoContext.Users.AnyAsync(e => e.Id == id);
        }

        public async Task AddUserToTask(AddUserToTaskModel model)
        {
            var user = await _todoContext.Users.FindAsync(model.UserId);
            var task = await _todoContext.TodoItems.FindAsync(model.TaskId);
            if (user == null)
            {
                throw new UserNotFoundException(model.UserId);
            }
            if (task == null)
            {
                throw new TodoItemNotFoundException(model.TaskId);
            }
            task.UserId = user.Id;
            await _todoContext.SaveChangesAsync();
        }
    }
}
