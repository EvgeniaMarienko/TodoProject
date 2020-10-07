using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBuisness.Services;
using TodoDataBase;
using TodoDataBase.Models;

namespace ToDoProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemController:ControllerBase
    {
        private ITodoItemService _todoItemService;
        public TodoItemController(ITodoItemService context)
        {
            _todoItemService = context;
        }

        [HttpGet]        
        public async Task<IEnumerable<TodoItemModel>> GetAll()
        {
            var result = await _todoItemService.GetAll();
            return result;
        }

        //[HttpGet]
        //public async Task<ActionResult<TodoItemModel>> GetById(int id)
        //{
        //    var result = await _todoItemService.GetById(id);
        //    return result;
        //}


    }
}
