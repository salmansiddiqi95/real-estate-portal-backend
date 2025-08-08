using Microsoft.EntityFrameworkCore;
using RealEstate.API.Data;
using RealEstate.API.Models;

namespace RealEstate.API.Repos
{
    public class UserRepository : IUserRepo
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) { _context = context; }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.Favorites).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task RegisterUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
