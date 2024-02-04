using CVApp.Dto.User;
using CVApp.Models;
using CVApp.Params;

namespace CVApp.Interfaces;

public interface IUserService
{
    public Task<User> GetUser(int id);
    public Task<IEnumerable<User>> GetUsers(UserParams @params);
    public Task<User> AddUser(UserCreateDto user);
    public Task<User> UpdateUser(UserUpdateDto user, int id);
    public Task<User> DeleteUser(int id);
}