using System.ComponentModel.DataAnnotations;

namespace TodoBusiness.ViewModels
{
    public class AddUserToTaskModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TaskId { get; set; }
    }
}
