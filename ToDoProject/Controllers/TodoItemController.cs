using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoBuisness.Services;
using TodoDatabase.Models;

namespace ToDoProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemController : ControllerBase
    {
        private ITodoItemService _todoItemService;
        public TodoItemController(ITodoItemService context)
        {
            _todoItemService = context;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetAllTasks()
        {
            var result = await _todoItemService.GetAll();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTaskById(int id)
        {
            var result = await _todoItemService.GetById(id);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _todoItemService.Delete(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TodoItem todoItem)
        {
            await _todoItemService.Update(id, todoItem);
            return StatusCode(204);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TodoItem todoItem)
        {
            await _todoItemService.Add(todoItem);
            return StatusCode(201);
        }


    }
}
