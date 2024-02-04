using CVApp.Context;
using CVApp.Dto.Language;
using CVApp.Interfaces;
using CVApp.Models;
using CVApp.Params;
using Microsoft.EntityFrameworkCore;

namespace CVApp.Services;

public class LanguageService : ILanguageService
{
    private readonly ApplicationDbContext _context;
    public LanguageService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Language>> GetLanguages(LanguageParams @params)
    {
        var query = _context.Languages.AsQueryable();
        if (@params.UserId != null)
        {
            query = query.Where(l => l.UserId == @params.UserId);
        }
        if (@params.Language != null)
        {
            query = query.Where(l => l.Name == @params.Language);
        }
        if (@params.Proficiency != null)
        {
            query = query.Where(l => l.Proficiency == @params.Proficiency);
        }

        return await query.ToListAsync();
    }

    public async Task<Language> GetLanguage(int id)
    {
        return await _context.Languages
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<Language> AddLanguage(LanguageCreateDto language)
    {
        var newLanguage = new Language
        {
            UserId = language.UserId,
            Name = language.Name,
            Proficiency = language.Proficiency
        };

        _context.Languages.Add(newLanguage);
        await _context.SaveChangesAsync();
        return newLanguage;
    }

    public async Task<Language> UpdateLanguage(LanguageUpdateDto language, int id)
    {
        var languageToUpdate = await _context.Languages
            .FirstOrDefaultAsync(l => l.Id == id);
        if (languageToUpdate == null)
        {
            return null;
        }

        languageToUpdate.Name = language.Name;
        languageToUpdate.Proficiency = language.Proficiency;
        _context.Languages.Update(languageToUpdate);
        await _context.SaveChangesAsync();
        return languageToUpdate;
    }

    public async Task<Language> RemoveLanguage(int id)
    {
        var language = await _context.Languages
            .FirstOrDefaultAsync(l => l.Id == id);
        _context.Languages.Remove(language);
        await _context.SaveChangesAsync();
        return language;
    }
}