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

        public static User ToModel(this RegistrationViewModel model)
        {
            var result = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };
            return result;
        }
    }
}
