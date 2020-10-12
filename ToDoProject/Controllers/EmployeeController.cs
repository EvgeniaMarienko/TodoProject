using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoBusiness.Services;
using TodoBusiness.ViewModels;
using TodoDatabase.Models;

namespace TodoApi.Controllers
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
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _employeeService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            return await _employeeService.GetById(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _employeeService.Delete(id);
            return StatusCode(200);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee(Employee employee)
        {
            await _employeeService.Add(employee);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, Employee employee)
        {
            await _employeeService.Update(id, employee);
            return StatusCode(200);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddEmployeeToTask(AddEmployeeToTaskModel model)
        {
            await _employeeService.AddEmployeeToTask(model);
            return StatusCode(204);
        }
    }
}
