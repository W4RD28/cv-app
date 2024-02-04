using CVApp.Context;
using CVApp.Dto.Social;
using CVApp.Interfaces;
using CVApp.Models;
using CVApp.Params;
using Microsoft.EntityFrameworkCore;

namespace CVApp.Services;

public class SocialService : ISocialService
{
    private readonly ApplicationDbContext _context;
    public SocialService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Social>> GetSocials(SocialParams @params)
    {
        var socials = _context.Socials.AsQueryable();
        if (@params.UserId.HasValue)
        {
            socials = socials.Where(s => s.UserId == @params.UserId);
        }
        if (!string.IsNullOrEmpty(@params.Name))
        {
            socials = socials.Where(s => s.Name.Contains(@params.Name));
        }
        return await socials.ToListAsync();
    }

    public async Task<Social> GetSocial(int id)
    {
        return await _context.Socials
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Social> AddSocial(SocialCreateDto social)
    {
        var newSocial = new Social
        {
            UserId = social.UserId,
            Name = social.Name,
            Url = social.Url
        };
        await _context.Socials.AddAsync(newSocial);
        await _context.SaveChangesAsync();
        return newSocial;
    }

    public async Task<Social> UpdateSocial(SocialUpdateDto social, int id)
    {
        var socialToUpdate = await _context.Socials
            .FirstOrDefaultAsync(s => s.Id == id);
        if (socialToUpdate == null)
        {
            return null;
        }

        socialToUpdate.Name = social.Name;
        socialToUpdate.Url = social.Url;
        _context.Socials.Update(socialToUpdate);
        await _context.SaveChangesAsync();
        return socialToUpdate;
    }

    public async Task<Social> RemoveSocial(int id)
    {
        var social = await _context.Socials
            .FirstOrDefaultAsync(s => s.Id == id);
        _context.Socials.Remove(social);
        await _context.SaveChangesAsync();
        return social;
    }
}