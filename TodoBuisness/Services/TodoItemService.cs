using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBuisness.Exceptions;
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
        public async Task Add(TodoItem todoItem)
        {
            _todoContext.Add(todoItem);
            await _todoContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if (await IsItem(id))
            {
                var item = await GetById(id);
                _todoContext.TodoItems.Remove(item);
                await _todoContext.SaveChangesAsync();
            }
            else
                throw new TodoItemNotFoundException(id);

        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            return await _todoContext.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetById(int id)
        {
            var result = await _todoContext.TodoItems.FindAsync(id);
            if (result == null)
            {
                throw new TodoItemNotFoundException(id);
            }
            return result;
        }

        public async Task<bool> IsItem(int id)
        {
            return await _todoContext.TodoItems.AnyAsync(i => i.Id == id);
        }

        public async Task Update(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                throw new TodoItemBadRequestException();
            }
            if (!(await IsItem(id)))
            {
                throw new TodoItemNotFoundException(id);
            }
            _todoContext.TodoItems.Update(todoItem);
            await _todoContext.SaveChangesAsync();
        }
    }
}
