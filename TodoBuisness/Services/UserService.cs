using Microsoft.EntityFrameworkCore;
using Shared.Extensions;
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

        public async Task Add(RegistrationViewModel model)
        {
            var isUserFound = await _todoContext.Users.AnyAsync(x => x.Email == model.Email);
            if (isUserFound)
                throw new UserAlreadyExistsException(model.Email);

            CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = model.ToModel();
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _todoContext.Users.Add(user);
            _todoContext.SaveChanges();
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

        public async Task AddUserToTask(AddUserToTaskViewModel model)
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

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static (byte[],byte[]) CreatePasswordHash(string password)
        {
            byte[] salt, hash;
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            return (salt, hash);
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {            
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public Task<User> Add(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
