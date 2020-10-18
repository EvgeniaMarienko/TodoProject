using Shared.ViewModels;
using TodoDatabase.Models;

namespace Shared.Extensions
{
    public static class ModelToViewModelExtension
    {
        public static TodoItemViewModel ToViewModel(this TodoItem todoItem)
        {
            var result = new TodoItemViewModel
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                Description = todoItem.Description,
                Status = todoItem.Status
            };
            return result;
        }
    }
}
