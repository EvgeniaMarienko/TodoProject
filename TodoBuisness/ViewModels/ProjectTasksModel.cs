using System.Collections.Generic;
using TodoDataBase.Models;

namespace TodoBusiness.ViewModels
{
    public class ProjectTasksModel
    {
        public string ProjectName { get; set; }
        public List<TodoItem> Tasks { get; set; }
    }
}
