using TroveApi.Models;

namespace TroveApi.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}