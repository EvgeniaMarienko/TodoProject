using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoBusiness.Services;
using TodoDatabase.Models;
using TodoWeb.Models;

namespace TodoWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<TodoResponseModel<IEnumerable<User>>>> GetAllUsers()
        {
            var result = await _userService.GetAll();
            return TodoResponseModel<IEnumerable<User>>.Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoResponseModel<User>>> GetUserById(int id)
        {
            var result = await _userService.GetById(id);
            return TodoResponseModel<User>.Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoResponseModel<User>>> DeleteUser(int id)
        {
            var result = await _userService.Delete(id);
            return StatusCode(204, TodoResponseModel<User>.Ok(result));
        }

        [HttpPost]
        public async Task<ActionResult<TodoResponseModel<User>>> CreateUser(User user)
        {
            var result = await _userService.Add(user);
            return StatusCode(201, TodoResponseModel<User>.Ok(result));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoResponseModel<User>>> UpdateUser(int id, User user)
        {
            var result = await _userService.Update(id, user);
            return TodoResponseModel<User>.Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddUserToTask(AddUserToTaskViewModel model)
        {
            await _userService.AddUserToTask(model);
            return StatusCode(204);
        }
    }
}
