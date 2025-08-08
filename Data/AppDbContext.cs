using Microsoft.EntityFrameworkCore;
using RealEstate.API.Models;

namespace RealEstate.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Favourite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    Id = 1,
                    Title = "Cozy Apartment",
                    Address = "123 Main St, Springfield",
                    Price = 120000,
                    ListingType = "Sale",
                    Bedrooms = 2,
                    Bathrooms = 1,
                    CarSpots = 1,
                    Description = "A nice cozy apartment in downtown.",
                    ImageUrls = new List<string> { "https://example.com/img1.jpg" }
                },
                new Property
                {
                    Id = 2,
                    Title = "Luxury Villa",
                    Address = "456 Sunset Blvd, Beverly Hills",
                    Price = 2500000,
                    ListingType = "Sale",
                    Bedrooms = 5,
                    Bathrooms = 4,
                    CarSpots = 3,
                    Description = "A luxurious villa with a pool.",
                    ImageUrls = new List<string> { "https://example.com/img2.jpg" }
                }
            );

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Favourite>()
                .HasKey(f => new { f.UserId, f.PropertyId });

            modelBuilder.Entity<Favourite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Favourite>()
                .HasOne(f => f.Property)
                .WithMany(p => p.Favorites)
                .HasForeignKey(f => f.PropertyId);
        }
    }
}
