using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TodoDatabase.Models
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
        [JsonIgnore]
        public Project Project { get; set; }
        public int? EmployeeId { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }
        public TodoItemStatuses Status { get; set; }

    }
}
