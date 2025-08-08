using RealEstate.API.Models;

namespace RealEstate.API.Repos
{
    public interface IUserRepo
    {
        Task<User> GetByEmailAsync(string email);
        Task RegisterUserAsync(User user);
    }
}
