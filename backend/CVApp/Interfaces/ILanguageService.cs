using CVApp.Dto.Language;
using CVApp.Models;
using CVApp.Params;

namespace CVApp.Interfaces;

public interface ILanguageService
{
    public Task<Language> GetLanguage(int id);
    public Task<IEnumerable<Language>> GetLanguages(LanguageParams @params);
    public Task<Language> AddLanguage(LanguageCreateDto language);
    public Task<Language> UpdateLanguage(LanguageUpdateDto language, int id);
    public Task<Language> RemoveLanguage(int id);
}