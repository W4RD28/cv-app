using CVApp.Dto.Education;
using CVApp.Interfaces;
using CVApp.Models;
using CVApp.Params;
using Microsoft.AspNetCore.Mvc;

namespace CVApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EducationController : ControllerBase
{
    private readonly IEducationService _educationService;
    public EducationController(IEducationService educationService)
    {
        _educationService = educationService;
    }

    [HttpGet]
    public async Task<IEnumerable<Education>> GetEducations(EducationParams @params)
    {
        return await _educationService.GetEducations(@params);
    }

    [HttpGet("{id}")]
    public async Task<Education> GetEducation(int id)
    {
        return await _educationService.GetEducation(id);
    }

    [HttpPost]
    public async Task<Education> AddEducation([FromBody] EducationCreateDto @params)
    {
        return await _educationService.AddEducation(@params);
    }

    [HttpPut("id")]
    public async Task<Education> UpdateEducation([FromBody] EducationUpdateDto @params, int id)
    {
        return await _educationService.UpdateEducation(@params, id);
    }

    [HttpDelete("{id}")]
    public async Task<Education> RemoveEducation(int id)
    {
        return await _educationService.RemoveEducation(id);
    }
}