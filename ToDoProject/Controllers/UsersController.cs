using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoBusiness.Services;
using TodoBusiness.ViewModels;
using TodoDatabase.Models;
using TodoWeb.Models;

namespace TodoWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserService _employeeService;
        public UsersController(IUserService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<TodoResponseModel<IEnumerable<User>>>> GetAllEmployees()
        {
            var result = await _employeeService.GetAll();
            return TodoResponseModel<IEnumerable<User>>.Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoResponseModel<User>>> GetEmployeeById(int id)
        {
            var result = await _employeeService.GetById(id);
            return TodoResponseModel<User>.Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoResponseModel<User>>> DeleteEmployee(int id)
        {
            var result = await _employeeService.Delete(id);
            return StatusCode(204, TodoResponseModel<User>.Ok(result));
        }

        [HttpPost]
        public async Task<ActionResult<TodoResponseModel<User>>> CreateEmployee(User employee)
        {
            var result = await _employeeService.Add(employee);
            return StatusCode(201, TodoResponseModel<User>.Ok(result));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoResponseModel<User>>> UpdateEmployee(int id, User employee)
        {
            var result = await _employeeService.Update(id, employee);
            return TodoResponseModel<User>.Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddEmployeeToTask(AddUserToTaskModel model)
        {
            await _employeeService.AddEmployeeToTask(model);
            return StatusCode(204);
        }
    }
}
