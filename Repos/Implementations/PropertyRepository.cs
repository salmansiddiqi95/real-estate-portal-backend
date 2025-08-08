using Microsoft.EntityFrameworkCore;
using RealEstate.API.Data;
using RealEstate.API.DTOs;
using RealEstate.API.Models;

namespace RealEstate.API.Repos.Implementations
{
    public class PropertyRepository : IPropertyRepo
    {
        private readonly AppDbContext _context;
        public PropertyRepository(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<Property>> GetAllAsync(PropertyFilterDto filters)
        {
            var query = _context.Properties.AsQueryable();

            if (!string.IsNullOrEmpty(filters.Suburb))
                query = query.Where(p => p.Address.Contains(filters.Suburb));

            if (filters.Bedrooms > 0)
                query = query.Where(p => p.Bedrooms == filters.Bedrooms);

            if (filters.PriceMin > 0)
                query = query.Where(p => p.Price >= filters.PriceMin);

            if (filters.PriceMax > 0)
                query = query.Where(p => p.Price <= filters.PriceMax);

            return await query.ToListAsync();
        }

        public async Task<Property> GetByIdAsync(int id)
        {
            return await _context.Properties.FindAsync(id);
        }
    }
}
