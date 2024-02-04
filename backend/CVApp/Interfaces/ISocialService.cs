using CVApp.Dto.Social;
using CVApp.Models;
using CVApp.Params;

namespace CVApp.Interfaces;

public interface ISocialService
{
    public Task<IEnumerable<Social>> GetSocials(SocialParams @params);
    public Task<Social> GetSocial(int id);
    public Task<Social> AddSocial(SocialCreateDto social);
    public Task<Social> UpdateSocial(SocialUpdateDto social, int id);
    public Task<Social> RemoveSocial(int id);
}