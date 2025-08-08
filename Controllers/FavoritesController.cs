using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.API.Data;
using RealEstate.API.Models;
using System.Security.Claims;

namespace RealEstate.API.Controllers
{
    [ApiController]
    [Route("favorites")]
    [Authorize]
    public class FavoritesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FavoritesController(AppDbContext context) { _context = context; }

        [HttpPost("{propertyId}")]
        public async Task<IActionResult> Toggle(int propertyId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

            var fav = await _context.Favorites.FindAsync(userId, propertyId);
            if (fav != null)
                _context.Favorites.Remove(fav);
            else
                _context.Favorites.Add(new Favourite { UserId = userId, PropertyId = propertyId });

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

            var list = await _context.Favorites
                                     .Include(f => f.Property)
                                     .Where(f => f.UserId == userId)
                                     .Select(f => f.Property)
                                     .ToListAsync();

            return Ok(list);
        }
    }
}
