using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBusiness.ViewModels;
using TodoDatabase;
using TodoBusiness.Exceptions;
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
        public async Task Add(Project project)
        {
            _todoContext.Projects.Add(project);
            await _todoContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
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

        public async Task Update(int id, Project project)
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
            }
        }

        public async Task<bool> IsProject(int id)
        {
            return await _todoContext.Projects.AnyAsync(p => p.Id == id);
        }

        public async Task<ProjectTasksModel> GetAllProjectTasks(int id)
        {
            var project = _todoContext.Projects.Where(i => i.Id == id);
            if (project == null)
            {
                throw new ProjectNotFoundException(id);
            }
            var tasks = await project.Include(t => t.TodoItems).SelectMany(t => t.TodoItems).ToListAsync();
            return new ProjectTasksModel
            {
                ProjectName = (await project.FirstOrDefaultAsync()).Name,
                Tasks = tasks
            };
        }
    }
}
