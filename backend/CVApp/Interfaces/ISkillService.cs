using CVApp.Dto.Skill;
using CVApp.Models;
using CVApp.Params;

namespace CVApp.Interfaces;

public interface ISkillService
{
    public Task<IEnumerable<Skill>> GetSkills(SkillParams @params);
    public Task<Skill> GetSkill(int id);
    public Task<Skill> AddSkill(SkillCreateDto skill);
    public Task<Skill> UpdateSkill(SkillUpdateDto skill, int id);
    public Task<Skill> RemoveSkill(int id);
}