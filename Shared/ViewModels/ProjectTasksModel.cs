using System.Collections.Generic;


namespace Shared.ViewModels
{
    public class ProjectTasksModel
    {
        public string StatusName { get; set; }
        public List<TodoItemViewModel> Tasks { get; set; }
    }
}
