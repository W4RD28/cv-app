using CVApp.Dto.Skill;
using CVApp.Interfaces;
using CVApp.Models;
using CVApp.Params;
using Microsoft.AspNetCore.Mvc;

namespace CVApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillController : ControllerBase
{
    private readonly ISkillService _skillService;
    public SkillController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpGet]
    public async Task<IEnumerable<Skill>> GetSkills([FromQuery] SkillParams @params)
    {
        return await _skillService.GetSkills(@params);
    }

    [HttpGet("{id}")]
    public async Task<Skill> GetSkill(int id)
    {
        return await _skillService.GetSkill(id);
    }

    [HttpPost]
    public async Task<Skill> AddSkill([FromBody] SkillCreateDto skill)
    {
        return await _skillService.AddSkill(skill);
    }

    [HttpPut("{id}")]
    public async Task<Skill> UpdateSkill([FromBody] SkillUpdateDto skill, int id)
    {
        return await _skillService.UpdateSkill(skill, id);
    }

    [HttpDelete("{id}")]
    public async Task<Skill> RemoveSkill(int id)
    {
        return await _skillService.RemoveSkill(id);
    }
}