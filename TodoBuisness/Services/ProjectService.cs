using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBuisness.Exceptions;
using TodoDataBase;
using TodoDataBase.Models;

namespace TodoBuisness.Services
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
    }
}
