using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoDataBase.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public DateTime CreatedData { get; set; }
        public List<TodoItem> TodoItems { get; set; }
    }
}
