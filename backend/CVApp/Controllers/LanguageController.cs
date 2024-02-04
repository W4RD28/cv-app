using CVApp.Dto.Language;
using CVApp.Interfaces;
using CVApp.Models;
using CVApp.Params;
using Microsoft.AspNetCore.Mvc;

namespace CVApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LanguageController : ControllerBase
{
    private readonly ILanguageService _languageService;
    public LanguageController(ILanguageService languageService)
    {
        _languageService = languageService;
    }

    [HttpGet]
    public async Task<IEnumerable<Language>> GetLanguages([FromQuery] LanguageParams @params)
    {
        return await _languageService.GetLanguages(@params);
    }

    [HttpGet("{id}")]
    public async Task<Language> GetLanguage(int id)
    {
        return await _languageService.GetLanguage(id);
    }

    [HttpPost]
    public async Task<Language> AddLanguage([FromBody] LanguageCreateDto language)
    {
        return await _languageService.AddLanguage(language);
    }

    [HttpPut("{id}")]
    public async Task<Language> UpdateLanguage([FromBody] LanguageUpdateDto language, int id)
    {
        return await _languageService.UpdateLanguage(language, id);
    }

    [HttpDelete("{id}")]
    public async Task<Language> RemoveLanguage(int id)
    {
        return await _languageService.RemoveLanguage(id);
    }
}