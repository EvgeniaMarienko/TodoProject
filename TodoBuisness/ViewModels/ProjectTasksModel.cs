using System.Collections.Generic;
using TodoDatabase.Models;

namespace TodoBusiness.ViewModels
{
    public class ProjectTasksModel
    {
        public string StatusName { get; set; }
        public List<TodoItem> Tasks { get; set; }
    }
}
