using SimpleAPI.Models;

namespace SimpleAPI.interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}