using Shared.ViewModels;
using System.Collections.Generic;

namespace TodoBusiness.ViewModels
{
    public class ProjectTasksModel
    {
        public string StatusName { get; set; }
        public List<TodoItemViewModel> Tasks { get; set; }
    }
}
