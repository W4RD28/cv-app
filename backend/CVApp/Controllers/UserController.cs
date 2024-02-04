using CVApp.Dto.User;
using CVApp.Interfaces;
using CVApp.Models;
using CVApp.Params;
using Microsoft.AspNetCore.Mvc;

namespace CVApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IEnumerable<User>> GetUsers([FromQuery] UserParams @params)
    {
        return await _userService.GetUsers(@params);
    }


    [HttpGet("{id}")]
    public async Task<User> GetUser(int id)
    {
        return await _userService.GetUser(id);
    }

    [HttpPost]
    public async Task<User> AddUser([FromBody] UserCreateDto user)
    {
        return await _userService.AddUser(user);
    }

    [HttpPut("{id}")]
    public async Task<User> UpdateUser([FromBody] UserUpdateDto user, int id)
    {
        return await _userService.UpdateUser(user, id);
    }

    [HttpDelete("{id}")]
    public async Task<User> RemoveUser(int id)
    {
        return await _userService.DeleteUser(id);
    }
}