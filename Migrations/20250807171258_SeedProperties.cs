using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstate.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Bathrooms", "Bedrooms", "CarSpots", "Description", "ImageUrls", "ListingType", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "123 Main St, Springfield", 1, 2, 1, "A nice cozy apartment in downtown.", "[\"https://example.com/img1.jpg\"]", "Sale", 120000m, "Cozy Apartment" },
                    { 2, "456 Sunset Blvd, Beverly Hills", 4, 5, 3, "A luxurious villa with a pool.", "[\"https://example.com/img2.jpg\"]", "Sale", 2500000m, "Luxury Villa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
