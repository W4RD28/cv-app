using CVApp.Context;
using CVApp.Dto.Work;
using CVApp.Interfaces;
using CVApp.Models;
using CVApp.Params;
using Microsoft.EntityFrameworkCore;

namespace CVApp.Services;

public class WorkService : IWorkService
{
    private readonly ApplicationDbContext _context;
    public WorkService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Work>> GetWorks(WorkParams @params)
    {
        var query = _context.Works.AsQueryable();

        if (@params.UserId != null)
        {
            query = query.Where(w => w.UserId == @params.UserId);
        }

        if (@params.Company != null)
        {
            query = query.Where(w => w.Company.Contains(@params.Company));
        }

        if (@params.Position != null)
        {
            query = query.Where(w => w.Position.Contains(@params.Position));
        }

        if (@params.Location != null)
        {
            query = query.Where(w => w.Location.Contains(@params.Location));
        }

        query = query.OrderByDescending(w => w.StartDate);

        return await query.ToListAsync();
    }

    public async Task<Work> GetWork(int id)
    {
        return await _context.Works
            .FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<Work> AddWork(WorkCreateDto work)
    {
        var newWork = new Work
        {
            UserId = work.UserId,
            Company = work.Company,
            Position = work.Position,
            Description = work.Description,
            Location = work.Location,
            StartDate = work.StartDate,
            EndDate = work.EndDate
        };
        await _context.Works.AddAsync(newWork);
        await _context.SaveChangesAsync();
        return newWork;
    }

    public async Task<Work> UpdateWork(WorkUpdateDto work, int id)
    {
        var workToUpdate = await _context.Works
            .FirstOrDefaultAsync(w => w.Id == id);
        if (workToUpdate == null)
        {
            return null;
        }

        workToUpdate.Company = work.Company;
        workToUpdate.Position = work.Position;
        workToUpdate.Description = work.Description;
        workToUpdate.Location = work.Location;
        workToUpdate.StartDate = work.StartDate;
        workToUpdate.EndDate = work.EndDate;
        _context.Works.Update(workToUpdate);
        await _context.SaveChangesAsync();
        return workToUpdate;
    }

    public async Task<Work> RemoveWork(int id)
    {
        var work = await _context.Works
            .FirstOrDefaultAsync(w => w.Id == id);
        _context.Works.Remove(work);
        await _context.SaveChangesAsync();
        return work;
    }

}