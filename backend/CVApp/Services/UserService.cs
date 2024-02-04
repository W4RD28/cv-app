using CVApp.Context;
using CVApp.Dto.User;
using CVApp.Interfaces;
using CVApp.Models;
using CVApp.Params;
using Microsoft.EntityFrameworkCore;

namespace CVApp.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUser(int id)
    {
        return await _context.Users
            .Include(u => u.Works)
            .Include(u => u.Educations)
            .Include(u => u.Skills)
            .Include(u => u.Languages)
            .Include(u => u.Projects)
            .Include(u => u.Certifications)
            .Include(u => u.Socials)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<User>> GetUsers(UserParams @params)
    {
        var query = _context.Users.AsQueryable();

        if (@params.UserId != null)
        {
            query = query.Where(u => u.Id == @params.UserId);
        }

        if (@params.Name != null)
        {
            query = query.Where(u => u.Name == @params.Name);
        }

        if (@params.Email != null)
        {
            query = query.Where(u => u.Email == @params.Email);
        }

        return await query.ToListAsync();
    }

    public async Task<User> AddUser(UserCreateDto user)
    {
        var newUser = new User
        {
            Name = user.Name,
            Label = user.Label,
            Email = user.Email,
            Location = user.Location,
            Phone = user.Phone,
            Website = user.Website,
            Summary = user.Summary
        };
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
        return newUser;
    }

    public async Task<User> UpdateUser(UserUpdateDto user, int id)
    {
        var userToUpdate = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
        if (userToUpdate == null)
        {
            return null;
        }

        userToUpdate.Name = user.Name;
        userToUpdate.Label = user.Label;
        userToUpdate.Email = user.Email;
        userToUpdate.Location = user.Location;
        userToUpdate.Phone = user.Phone;
        userToUpdate.Website = user.Website;
        userToUpdate.Summary = user.Summary;
        _context.Users.Update(userToUpdate);
        await _context.SaveChangesAsync();
        return userToUpdate;
    }

    public async Task<User> DeleteUser(int id)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public bool UserExists(int id)
    {
        return _context.Users.Any(e => e.Id == id);
    }
}