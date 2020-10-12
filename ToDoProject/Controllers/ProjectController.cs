﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBuisness.Services;
using TodoDataBase.Models;

namespace ToDoProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        public IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await _projectService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            return await _projectService.GetById(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            await _projectService.Delete(id);
            return StatusCode(204);            
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject(Project project)
        {
            await _projectService.Add(project);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject(int id, Project project)
        {
            await _projectService.Update(id, project);
            return StatusCode(200);
        }
    }
}