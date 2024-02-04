using CVApp.Dto.Social;
using CVApp.Interfaces;
using CVApp.Models;
using CVApp.Params;
using Microsoft.AspNetCore.Mvc;

namespace CVApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SocialController : ControllerBase
{
    private readonly ISocialService _socialService;
    public SocialController(ISocialService socialService)
    {
        _socialService = socialService;
    }

    [HttpGet]
    public async Task<IEnumerable<Social>> GetSocials([FromQuery] SocialParams @params)
    {
        return await _socialService.GetSocials(@params);
    }

    [HttpGet("{id}")]
    public async Task<Social> GetSocial(int id)
    {
        return await _socialService.GetSocial(id);
    }

    [HttpPost]
    public async Task<Social> AddSocial([FromBody] SocialCreateDto social)
    {
        return await _socialService.AddSocial(social);
    }

    [HttpPut("{id}")]
    public async Task<Social> UpdateSocial([FromBody] SocialUpdateDto social, int id)
    {
        return await _socialService.UpdateSocial(social, id);
    }

    [HttpDelete("{id}")]
    public async Task<Social> RemoveSocial(int id)
    {
        return await _socialService.RemoveSocial(id);
    }
}