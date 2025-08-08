using RealEstate.API.Models;

namespace RealEstate.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> GenerateJwtToken(User user);
        void CreatePasswordHash(string password, out byte[] hash, out byte[] salt);
        bool VerifyPassword(string password, byte[] hash, byte[] salt);
    }
}
