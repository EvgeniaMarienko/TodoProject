using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoBusiness.Exceptions;
using TodoBusiness.ViewModels;
using TodoDatabase;
using TodoDatabase.Models;

namespace TodoBusiness.Services
{
    public class EmployeeService : IEmployeeService
    {
        private TodoContext _todoContext;
        public EmployeeService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task Add(Employee employee)
        {
            _todoContext.Employees.Add(employee);
            await _todoContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if (!(await (IsEmployee(id))))
            {
                throw new EmployeeNotFoundException(id);
            }
            else
            {
                var result = await GetById(id);
                _todoContext.Employees.Remove(result);
                await _todoContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _todoContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            var result = await _todoContext.Employees.FindAsync(id);
            if (result == null)
            {
                throw new EmployeeNotFoundException(id);
            }
            return result;
        }

        public async Task Update(int id, Employee employee)
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
                _todoContext.Employees.Update(employee);
                await _todoContext.SaveChangesAsync();
            }
        }

        public async Task<bool> IsEmployee(int id)
        {
            return await _todoContext.Employees.AnyAsync(e => e.Id == id);
        }

        public async Task AddEmployeeToTask(AddEmployeeToTaskModel model)
        {
            var employee = await _todoContext.Employees.FindAsync(model.EmployeeId);
            var task = await _todoContext.TodoItems.FindAsync(model.TaskId);
            if (employee == null)
            {
                throw new EmployeeNotFoundException(model.EmployeeId);
            }
            if (task == null)
            {
                throw new TodoItemNotFoundException(model.TaskId);
            }
            task.EmployeeId = employee.Id;
            await _todoContext.SaveChangesAsync();
        }
    }
}
