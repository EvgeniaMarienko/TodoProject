﻿using System.Collections.Generic;

namespace TodoDatabase.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<TodoItem> TodoItems { get; set; }
    }
}
