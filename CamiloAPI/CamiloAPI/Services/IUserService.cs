using CamiloAPI.Data.Models;

namespace CamiloAPI.Services
{
    public interface IUserService
    {
        Task<User>? GetUserAsync(string username, string password);
    }
}