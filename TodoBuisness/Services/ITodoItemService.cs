using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoDataBase.Models;

namespace TodoBuisness.Services
{
    public interface ITodoItemService:ICrudService<TodoItemModel>
    {
    }
}
