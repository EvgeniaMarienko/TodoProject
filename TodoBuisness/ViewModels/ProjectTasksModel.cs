using System.Collections.Generic;
using TodoDatabase.Models;

namespace TodoBusiness.ViewModels
{
    public class ProjectTasksModel
    {
        public string ProjectName { get; set; }
        public List<TodoItem> Tasks { get; set; }
    }
}
