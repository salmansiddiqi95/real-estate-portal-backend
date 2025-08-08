using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.API.Data;
using RealEstate.API.DTOs;
using RealEstate.API.Models;

namespace RealEstate.API.Controllers
{
    [ApiController]
    [Route("properties")]
    public class Properties : ControllerBase
    {
        private readonly AppDbContext _context;
        public Properties(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PropertyFilterDto filter)
        {

            // Example: apply filters
            var query = _context.Properties.AsQueryable();

            if (filter == null || (
                string.IsNullOrEmpty(filter.Suburb) &&
                filter.Bedrooms <= 0 &&
                filter.PriceMin <= 0 &&
                filter.PriceMax <= 0
            ))
            {
                var allProperties = await query.ToListAsync();
                return Ok(allProperties);
            }

            if (!string.IsNullOrEmpty(filter.Suburb))
                query = query.Where(p => p.Title.Contains(filter.Suburb));

            if (filter.Bedrooms > 0)
                query = query.Where(p => p.Bedrooms == filter.Bedrooms);

            if (filter.PriceMin > 0)
                query = query.Where(p => p.Price >= filter.PriceMin);

            if (filter.PriceMax > 0)
                query = query.Where(p => p.Price <= filter.PriceMax);

            var result = await query.ToListAsync();

            return Ok(result); 
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var property = await _context.Properties.FindAsync(id);
            return property == null ? NotFound() : Ok(property);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProperty dto)
        {
            var property = new Property
            {
                Title = dto.Title,
                Address = dto.Address,
                Price = dto.Price,
                ListingType = dto.ListingType,
                Bedrooms = dto.Bedrooms,
                Bathrooms = dto.Bathrooms,
                CarSpots = dto.CarSpots,
                Description = dto.Description,
                ImageUrls = dto.ImageUrls ?? new List<string>()
            };

            _context.Properties.Add(property);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = property.Id }, property);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Property property)
        {
            var existing = await _context.Properties.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Title = property.Title;
            existing.Price = property.Price;
            existing.Bedrooms = property.Bedrooms;
            existing.Address = property.Address;
            

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null) return NotFound();

            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
