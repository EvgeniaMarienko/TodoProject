using System.ComponentModel.DataAnnotations;

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
