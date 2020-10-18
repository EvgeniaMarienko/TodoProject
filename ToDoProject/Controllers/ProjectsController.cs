using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoBusiness.Services;
using TodoBusiness.ViewModels;
using TodoDatabase.Models;
using TodoWeb.Models;

namespace TodoWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        public IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<TodoResponseModel<IEnumerable<Project>>>> GetAllProjects()
        {
            var result = await _projectService.GetAll();
            return TodoResponseModel<IEnumerable<Project>>.Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoResponseModel<Project>>> GetProjectById(int id)
        {
            var result = await _projectService.GetById(id);
            return TodoResponseModel<Project>.Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoResponseModel<Project>>> DeleteProject(int id)
        {
            var result = await _projectService.Delete(id);
            return StatusCode(204, TodoResponseModel<Project>.Ok(result));
        }

        [HttpPost]
        public async Task<ActionResult<TodoResponseModel<Project>>> CreateProject(Project project)
        {
            var result = await _projectService.Add(project);
            return StatusCode(201, TodoResponseModel<Project>.Ok(result));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoResponseModel<Project>>> UpdateProject(int id, Project project)
        {
            var result = await _projectService.Update(id, project);
            return TodoResponseModel<Project>.Ok(result);
        }

        [HttpGet("{id}/tasks")]
        public async Task<ActionResult<TodoResponseModel<IEnumerable<ProjectTasksModel>>>> GetProjectTasks(int id)
        {
            var result = await _projectService.GetAllProjectTasks(id);
            return TodoResponseModel<IEnumerable<ProjectTasksModel>>.Ok(result);
        }
    }
}
