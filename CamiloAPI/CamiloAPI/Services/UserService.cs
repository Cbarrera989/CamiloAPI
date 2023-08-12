using CamiloAPI.Data.Models;
using CamiloAPI.Data;
using CamiloAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace CamiloAPI.Services
{
    public class UserService : IUserService
    {
        private readonly CamiloAPIContext _context;

        public UserService(CamiloAPIContext context)
        {
            _context = context;
        }

        public async Task<User>? GetUserAsync(string username, string password)
        {
            if (_context.Users == null)
            {
                return null;
            }
            var user = await _context.Users.FirstOrDefaultAsync(user => user.UserName == username && user.Password == password);

            return user;
        }
    }

}