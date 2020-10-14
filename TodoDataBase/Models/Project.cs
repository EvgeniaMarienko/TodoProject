using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoDatabase.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<TodoItem> TodoItems { get; set; }
    }
}
