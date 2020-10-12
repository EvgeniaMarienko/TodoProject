﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoDataBase.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
