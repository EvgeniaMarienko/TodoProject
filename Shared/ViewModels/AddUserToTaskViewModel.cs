using System.ComponentModel.DataAnnotations;

namespace Shared.ViewModels
{
    public class AddUserToTaskViewModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TaskId { get; set; }
    }
}
