using Fitness_Tracking.Models;

namespace Fitness_Tracking.Interfaces
{
    public interface IGoalService
    {
        Task<GoalModel> GetGoal(int userId);
        Task AddGoal(GoalModel goal);
        Task UpdateGoal(int userId, GoalModel goal);
        Task DeleteGoal(int userId);
    }
}
