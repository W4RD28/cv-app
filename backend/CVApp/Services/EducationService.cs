using CVApp.Context;
using CVApp.Dto.Education;
using CVApp.Models;
using CVApp.Interfaces;
using CVApp.Params;
using Microsoft.EntityFrameworkCore;

namespace CVApp.Services;

public class EducationService : IEducationService
{
    private readonly ApplicationDbContext _context;
    public EducationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Education>> GetEducations(EducationParams @params)
    {
        var query = _context.Educations.AsQueryable();
        if (@params.UserId != null)
        {
            query = query.Where(e => e.UserId == @params.UserId);
        }
        if (@params.Institution != null)
        {
            query = query.Where(e => e.Institution == @params.Institution);
        }
        if (@params.Area != null)
        {
            query = query.Where(e => e.Area == @params.Area);
        }
        if (@params.StudyType != null)
        {
            query = query.Where(e => e.StudyType == @params.StudyType);
        }

        query = query.OrderByDescending(e => e.StartDate);

        return await query.ToListAsync();
    }

    public async Task<Education> GetEducation(int id)
    {
        return await _context.Educations
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Education> AddEducation(EducationCreateDto education)
    {
        var newEducation = new Education
        {
            UserId = education.UserId,
            Institution = education.Institution,
            Area = education.Area,
            StudyType = education.StudyType,
            GPA = education.Gpa != null ? float.Parse(education.Gpa) : null,
            StartDate = education.StartDate,
            EndDate = education.EndDate
        };
        await _context.Educations.AddAsync(newEducation);
        await _context.SaveChangesAsync();
        return newEducation;
    }

    public async Task<Education> UpdateEducation(EducationUpdateDto education, int id)
    {
        var educationToUpdate = await _context.Educations
            .FirstOrDefaultAsync(e => e.Id == id);
        if (educationToUpdate == null)
        {
            return null;
        }

        educationToUpdate.Institution = education.Institution;
        educationToUpdate.Area = education.Area;
        educationToUpdate.StudyType = education.StudyType;
        educationToUpdate.GPA = education.Gpa != null ? float.Parse(education.Gpa) : null;
        educationToUpdate.StartDate = education.StartDate;
        educationToUpdate.EndDate = education.EndDate;
        await _context.SaveChangesAsync();
        return educationToUpdate;
    }

    public async Task<Education> RemoveEducation(int id)
    {
        var education = await _context.Educations
            .FirstOrDefaultAsync(e => e.Id == id);
        _context.Educations.Remove(education);
        await _context.SaveChangesAsync();
        return education;
    }
}