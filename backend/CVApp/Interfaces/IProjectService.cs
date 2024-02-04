using CVApp.Dto.Project;
using CVApp.Models;
using CVApp.Params;

namespace CVApp.Interfaces;

public interface IProjectService
{
    public Task<IEnumerable<Project>> GetProjects(ProjectParams @params);
    public Task<Project> GetProject(int id);
    public Task<Project> AddProject(ProjectCreateDto project);
    public Task<Project> UpdateProject(ProjectUpdateDto project, int id);
    public Task<Project> RemoveProject(int id);
}