using CVApp.Context;
using CVApp.Dto.Skill;
using CVApp.Interfaces;
using CVApp.Models;
using CVApp.Params;
using Microsoft.EntityFrameworkCore;

namespace CVApp.Services;

public class SkillService : ISkillService
{
    private readonly ApplicationDbContext _context;
    public SkillService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Skill>> GetSkills(SkillParams @params)
    {
        var skills = _context.Skills.AsQueryable();
        if (@params.UserId != null)
        {
            skills = skills.Where(s => s.UserId == @params.UserId);
        }
        if (@params.Name != null)
        {
            skills = skills.Where(s => s.Name.Contains(@params.Name));
        }

        return await skills.ToListAsync();
    }

    public async Task<Skill> GetSkill(int id)
    {
        return await _context.Skills
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Skill> AddSkill(SkillCreateDto skill)
    {
        var newSkill = new Skill
        {
            UserId = skill.UserId,
            Name = skill.Name
        };

        await _context.Skills.AddAsync(newSkill);
        await _context.SaveChangesAsync();
        return newSkill;
    }

    public async Task<Skill> UpdateSkill(SkillUpdateDto skill, int id)
    {
        var skillToUpdate = await _context.Skills
            .FirstOrDefaultAsync(s => s.Id == id);
        if (skillToUpdate == null)
        {
            return null;
        }

        skillToUpdate.Name = skill.Name;
        await _context.SaveChangesAsync();
        return skillToUpdate;
    }

    public async Task<Skill> RemoveSkill(int id)
    {
        var skill = await _context.Skills
            .FirstOrDefaultAsync(s => s.Id == id);
        _context.Skills.Remove(skill);
        await _context.SaveChangesAsync();
        return skill;
    }
}