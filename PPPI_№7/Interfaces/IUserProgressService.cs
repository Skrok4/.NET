using Fitness_Tracking.Models;
using Fitness_Tracking.Services;


namespace Fitness_Tracking.Interfaces
{
    public interface IUserProgressService
    {
        Task<UserProgressModel> GetUserProgress(int userId);
        Task AddUserProgress(UserProgressModel userProgress);
        Task UpdateUserProgress(int userId, UserProgressModel userProgress);
        Task DeleteUserProgress(int userId);
        Task<List<UserProgressModel>> GetFilteredUserProgress(int userId);
    }
}
