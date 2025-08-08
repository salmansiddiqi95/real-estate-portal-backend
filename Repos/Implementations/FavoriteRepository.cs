using Microsoft.EntityFrameworkCore;
using RealEstate.API.Controllers;
using RealEstate.API.Data;
using RealEstate.API.Models;

namespace RealEstate.API.Repos.Implementations
{
    public class FavoriteRepository : IFavoriteRepo
    {
        private readonly AppDbContext _context;
        public FavoriteRepository(AppDbContext context) { _context = context; }

        public async Task ToggleFavoriteAsync(int userId, int propertyId)
        {
            var fav = await _context.Favorites.FindAsync(userId, propertyId);
            if (fav != null)
                _context.Favorites.Remove(fav);
            else
                await _context.Favorites.AddAsync(new Favourite { UserId = userId, PropertyId = propertyId });

            await _context.SaveChangesAsync();
        }

        public async Task<List<Property>> GetFavoritesAsync(int userId)
        {
            return await _context.Favorites
                .Where(f => f.UserId == userId)
                .Include(f => f.Property)
                .Select(f => f.Property)
                .ToListAsync();
        }
    }
}
