using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using TodoDataBase.Models;

namespace TodoDataBase
{
    public class TodoContext:DbContext
    {
        public TodoContext()
        {

        }
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<TodoItemModel> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TodoItemDataBase;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
