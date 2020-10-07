using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoDataBase;
using TodoDataBase.Models;

namespace TodoBuisness.Services
{
    public class TodoItemService : ITodoItemService
    {
        private TodoContext _todoContext;

        public TodoItemService(TodoContext context)
        {
            _todoContext = context;
        }
        public async Task AddItem(TodoItemModel todoItem)
        {
            _todoContext.Add(todoItem);
            await _todoContext.SaveChangesAsync();
        }

        public async Task DeleteItem(int id)
        {
            if (await IsItem(id))
            {
                var item = await GetById(id);
                _todoContext.TodoItems.Remove(item);
                await _todoContext.SaveChangesAsync();

            }
            throw new Exception("Id not exists");

        }

        public async Task<IEnumerable<TodoItemModel>> GetAll()
        {
            return await _todoContext.TodoItems.ToListAsync();
        }

        public async Task<TodoItemModel> GetById(int id)
        {
            return await _todoContext.TodoItems.FindAsync(id);
        }

        public async Task<bool> IsItem(int id)
        {
            return await _todoContext.TodoItems.AnyAsync(i => i.Id == id);
        }

        public async Task UpdateId(int id, TodoItemModel todoItem)
        {
            if (id != todoItem.Id)
            {
                throw new Exception();
            }
            if (!(await IsItem(id)))
            {
                throw new Exception();
            }
            _todoContext.TodoItems.Update(todoItem);
            await _todoContext.SaveChangesAsync();
        }
    }
}
