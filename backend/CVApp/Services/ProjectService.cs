using CVApp.Context;
using CVApp.Dto.Project;
using CVApp.Interfaces;
using CVApp.Models;
using CVApp.Params;
using Microsoft.EntityFrameworkCore;

namespace CVApp.Services;

public class ProjectService : IProjectService
{
    private readonly ApplicationDbContext _context;
    public ProjectService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Project>> GetProjects(ProjectParams @params)
    {
        var query = _context.Projects.AsQueryable();
        if (@params.UserId != null)
        {
            query = query.Where(p => p.UserId == @params.UserId);
        }
        if (@params.Name != null)
        {
            query = query.Where(p => p.Name == @params.Name);
        }
        if (@params.Description != null)
        {
            query = query.Where(p => p.Description == @params.Description);
        }

        query = query.OrderByDescending(p => p.StartDate);

        return await query.ToListAsync();
    }

    public async Task<Project> GetProject(int id)
    {
        return await _context.Projects
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Project> AddProject(ProjectCreateDto project)
    {
        var newProject = new Project
        {
            UserId = project.UserId,
            Name = project.Name,
            Description = project.Description,
            StartDate = project.StartDate,
            EndDate = project.EndDate
        };

        _context.Projects.Add(newProject);
        await _context.SaveChangesAsync();
        return newProject;
    }

    public async Task<Project> UpdateProject(ProjectUpdateDto project, int id)
    {
        var projectToUpdate = await _context.Projects
            .FirstOrDefaultAsync(p => p.Id == id);
        if (projectToUpdate == null)
        {
            return null;
        }

        projectToUpdate.Name = project.Name;
        projectToUpdate.Description = project.Description;
        projectToUpdate.StartDate = project.StartDate;
        projectToUpdate.EndDate = project.EndDate;
        await _context.SaveChangesAsync();
        return projectToUpdate;
    }

    public async Task<Project> RemoveProject(int id)
    {
        var project = await _context.Projects
            .FirstOrDefaultAsync(p => p.Id == id);
        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
        return project;
    }
}