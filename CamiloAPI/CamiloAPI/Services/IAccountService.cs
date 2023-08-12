using CamiloAPI.Data.Models;

namespace CamiloAPI.Services
{
    public interface IAccountService
    {
        string GenerateJwtToken(User user);
    }
}