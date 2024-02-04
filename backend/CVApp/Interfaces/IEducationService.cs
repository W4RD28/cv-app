using CVApp.Dto.Education;
using CVApp.Models;
using CVApp.Params;

namespace CVApp.Interfaces;

public interface IEducationService
{
    public Task<IEnumerable<Education>> GetEducations(EducationParams @params);
    public Task<Education> GetEducation(int id);
    public Task<Education> AddEducation(EducationCreateDto educationCreateDto);
    public Task<Education> UpdateEducation(EducationUpdateDto educationUpdateDto, int id);
    public Task<Education> RemoveEducation(int id);
}