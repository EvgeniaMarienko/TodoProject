using Microsoft.EntityFrameworkCore;
using Shared.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBusiness.Exceptions;
using TodoBusiness.ViewModels;
using TodoDatabase;
using TodoDatabase.Models;

namespace TodoBusiness.Services
{
    public class ProjectService : IProjectService
    {
        private TodoContext _todoContext;
        public ProjectService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }
        public async Task<Project> Add(Project project)
        {
            _todoContext.Projects.Add(project);
            await _todoContext.SaveChangesAsync();
            return project;
        }

        public async Task<Project> Delete(int id)
        {
            if (!(await IsProject(id)))
            {
                throw new ProjectNotFoundException(id);
            }
            else
            {
                var result = await GetById(id);
                _todoContext.Projects.Remove(result);
                await _todoContext.SaveChangesAsync();
                return result;
            }
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _todoContext.Projects.ToListAsync();
        }

        public async Task<Project> GetById(int id)
        {
            var result = await _todoContext.Projects.FindAsync(id);
            if (result == null)
            {
                throw new ProjectNotFoundException(id);
            }
            return result;
        }

        public async Task<Project> Update(int id, Project project)
        {
            if (project.Id != id)
            {
                throw new ProjectBadRequestException();
            }
            if (!(await IsProject(id)))
            {
                throw new ProjectNotFoundException(id);
            }
            else
            {
                _todoContext.Projects.Update(project);
                await _todoContext.SaveChangesAsync();
                return project;
            }
        }

        public async Task<bool> IsProject(int id)
        {
            return await _todoContext.Projects.AnyAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ProjectTasksModel>> GetAllProjectTasks(int id)
        {

            var project = await _todoContext.Projects.FindAsync(id);
            if (project == null)
            {
                throw new ProjectNotFoundException(id);
            }
            var tasks = await _todoContext.TodoItems.Where(i => i.ProjectId == id).ToListAsync();
            var result = tasks.GroupBy(g => g.Status).Select(g => new ProjectTasksModel
            {
                StatusName = g.Key.ToString(),
                Tasks = g.Select(m => m.ToViewModel()).ToList()
            });
            return result;
        }
    }
}
