using CVApp.Dto.Project;
using CVApp.Interfaces;
using CVApp.Models;
using CVApp.Params;
using Microsoft.AspNetCore.Mvc;

namespace CVApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;
    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<IEnumerable<Project>> GetProjects([FromQuery] ProjectParams @params)
    {
        return await _projectService.GetProjects(@params);
    }

    [HttpGet("{id}")]
    public async Task<Project> GetProject(int id)
    {
        return await _projectService.GetProject(id);
    }

    [HttpPost]
    public async Task<Project> AddProject([FromBody] ProjectCreateDto project)
    {
        return await _projectService.AddProject(project);
    }

    [HttpPut("{id}")]
    public async Task<Project> UpdateProject([FromBody] ProjectUpdateDto project, int id)
    {
        return await _projectService.UpdateProject(project, id);
    }

    [HttpDelete("{id}")]
    public async Task<Project> RemoveProject(int id)
    {
        return await _projectService.RemoveProject(id);
    }
}