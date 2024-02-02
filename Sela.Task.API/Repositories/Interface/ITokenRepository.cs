using Microsoft.AspNetCore.Identity;

namespace Sela.Task.API.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJWTToken(string userName);
    }
}
