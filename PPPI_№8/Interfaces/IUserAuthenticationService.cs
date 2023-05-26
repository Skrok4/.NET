using Fitness_Tracking.Models;

namespace Fitness_Tracking.Interfaces
{
    public interface IUserAuthenticationService
    {
        Task<bool> Register(UserModel user);
        Task<string> Login(UserModel user);
        Task<UserModel> GetUserProfile(int userId);
        Task<List<UserModel>> GetAllUsers();
    }
}
