using TodoDatabase.Models;

namespace Shared.ViewModels
{
    public class TodoItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public TodoItemStatuses Status { get; set; }
    }
}
