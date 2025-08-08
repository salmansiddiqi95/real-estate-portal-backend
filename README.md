- Update Connection String in appsettings.json 

- "ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=RealEstateDB;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
}

- Run Migrations
- dotnet tool install --global dotnet-ef
- dotnet ef database update

- Run Project
- dotnet run

- https://localhost:7192/swagger/index.html

Test Api's on Swagger UI

- User can register themselves either as admin or user
- Login
- Create Property
- Filter Property
- Filter Favorites
- Note: You have to authorize with Bearer token on Login
