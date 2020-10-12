using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoBuisness.ViewModels
{
    public class AddEmployeeToTaskModel
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int TaskId { get; set; }
    }
}
