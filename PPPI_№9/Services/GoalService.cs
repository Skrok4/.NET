using Fitness_Tracking.Interfaces;
using Fitness_Tracking.Models;
using static Fitness_Tracking.Services.GoalService;

namespace Fitness_Tracking.Services
{
    public class GoalService : IGoalService
    {
        private readonly List<GoalModel> _goalList;

        public GoalService()
        {
            _goalList = new List<GoalModel>
            {
                new GoalModel { UserId = 1, GoalDescription = "Lose 10 pounds", Deadline = DateTime.Today.AddMonths(3) },
                new GoalModel { UserId = 2, GoalDescription = "Increase bench press by 50 lbs", Deadline = DateTime.Today.AddMonths(6) },
                new GoalModel { UserId = 3, GoalDescription = "Run a 5k", Deadline = DateTime.Today.AddMonths(4) },
                new GoalModel { UserId = 4, GoalDescription = "Complete 10 pull-ups", Deadline = DateTime.Today.AddMonths(5) },
                new GoalModel { UserId = 5, GoalDescription = "Squat 200 lbs", Deadline = DateTime.Today.AddMonths(7) },
                new GoalModel { UserId = 6, GoalDescription = "Run a half marathon", Deadline = DateTime.Today.AddMonths(8) },
                new GoalModel { UserId = 7, GoalDescription = "Achieve a six-pack abs", Deadline = DateTime.Today.AddMonths(7) },
                new GoalModel { UserId = 8, GoalDescription = "Complete 100 push-ups daily for 30 days", Deadline = DateTime.Today.AddMonths(2) },
                new GoalModel { UserId = 9, GoalDescription = "Reduce body fat percentage by 5%", Deadline = DateTime.Today.AddMonths(4) },
                new GoalModel { UserId = 10, GoalDescription = "Complete a 24-hour fasting challenge", Deadline = DateTime.Today.AddMonths(1) },
                new GoalModel { UserId = 11, GoalDescription = "Squat 200 lbs", Deadline = DateTime.Today.AddMonths(7) }
            };
        }
        // Retrieves the goal for a specific user
        public async Task<GoalModel> GetGoal(int userId)
        {
            return await Task.FromResult(_goalList.FirstOrDefault(g => g.UserId == userId));
        }
        // Adds a goal for a specific user
        public async Task AddGoal(GoalModel goal)
        {
            _goalList.Add(goal);
            await Task.CompletedTask;
        }
        // Updates a goal for a specific user
        public async Task UpdateGoal(int userId, GoalModel goal)
        {
            var index = _goalList.FindIndex(g => g.UserId == userId);
            if (index != -1)
            {
                _goalList[index] = goal;
            }
            await Task.CompletedTask;
        }
        // Deletes a goal for a specific user
        public async Task DeleteGoal(int userId)
        {
            var goal = _goalList.FirstOrDefault(g => g.UserId == userId);
            if (goal != null)
            {
                _goalList.Remove(goal);
            }
            await Task.CompletedTask;
        }
    }
}
