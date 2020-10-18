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
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<TodoResponseModel<IEnumerable<Employee>>>> GetAllEmployees()
        {
            var result = await _employeeService.GetAll();
            return TodoResponseModel<IEnumerable<Employee>>.Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoResponseModel<Employee>>> GetEmployeeById(int id)
        {
            var result = await _employeeService.GetById(id);
            return TodoResponseModel<Employee>.Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoResponseModel<Employee>>> DeleteEmployee(int id)
        {
            var result = await _employeeService.Delete(id);
            return StatusCode(204, TodoResponseModel<Employee>.Ok(result));
        }

        [HttpPost]
        public async Task<ActionResult<TodoResponseModel<Employee>>> CreateEmployee(Employee employee)
        {
            var result = await _employeeService.Add(employee);
            return StatusCode(201, TodoResponseModel<Employee>.Ok(result));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoResponseModel<Employee>>> UpdateEmployee(int id, Employee employee)
        {
            var result = await _employeeService.Update(id, employee);
            return TodoResponseModel<Employee>.Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddEmployeeToTask(AddEmployeeToTaskModel model)
        {
            await _employeeService.AddEmployeeToTask(model);
            return StatusCode(204);
        }
    }
}
