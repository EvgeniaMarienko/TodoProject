using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoBusiness.Services;
using TodoDatabase.Models;
using TodoWeb.Models;

namespace TodoWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private ITodoItemService _todoItemService;
        public TodoItemsController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet]
        public async Task<ActionResult<TodoResponseModel<IEnumerable<TodoItem>>>> GetAllTasks()
        {
            var result = await _todoItemService.GetAll();
            return TodoResponseModel<IEnumerable<TodoItem>>.Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoResponseModel<TodoItem>>> GetTaskById(int id)
        {
            var result = await _todoItemService.GetById(id);
            return TodoResponseModel<TodoItem>.Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoResponseModel<TodoItem>>> DeleteTask(int id)
        {
            var result = await _todoItemService.Delete(id);
            return StatusCode(204, TodoResponseModel<TodoItem>.Ok(result));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoResponseModel<TodoItem>>> UpdateTask(int id, TodoItem todoItem)
        {
            var result = await _todoItemService.Update(id, todoItem);
            return TodoResponseModel<TodoItem>.Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TodoResponseModel<TodoItem>>> CreateTask(TodoItem todoItem)
        {
            var result = await _todoItemService.Add(todoItem);
            return StatusCode(201, TodoResponseModel<TodoItem>.Ok(result));
        }


    }
}
