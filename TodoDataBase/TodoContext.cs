﻿using Microsoft.EntityFrameworkCore;
using TodoDatabase.Models;

namespace TodoDatabase
{
    public class TodoContext : DbContext
    {
        public TodoContext()
        {

        }
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TodoItemDataBase;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
