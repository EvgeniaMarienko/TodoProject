﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoBusiness.Exceptions;
using TodoDatabase;
using TodoDatabase.Models;

namespace TodoBusiness.Services
{
    public class TodoItemService : ITodoItemService
    {
        private TodoContext _todoContext;

        public TodoItemService(TodoContext context)
        {
            _todoContext = context;
        }
        public async Task<TodoItem> Add(TodoItem todoItem)
        {
            _todoContext.Add(todoItem);
            await _todoContext.SaveChangesAsync();
            return todoItem;
        }

        public async Task<TodoItem> Delete(int id)
        {
            if (await IsItem(id))
            {
                var item = await GetById(id);
                _todoContext.TodoItems.Remove(item);
                await _todoContext.SaveChangesAsync();
                return item;
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

        public async Task<TodoItem> Update(int id, TodoItem todoItem)
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
            return todoItem;
        }
    }
}
