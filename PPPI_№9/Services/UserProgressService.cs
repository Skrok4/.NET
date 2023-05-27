using Fitness_Tracking.Interfaces;
using Fitness_Tracking.Models;

namespace Fitness_Tracking.Services
{
    public class UserProgressService : IUserProgressService
    {
        private List<UserProgressModel> _userProgressList;
        public UserProgressService()
        {
            _userProgressList = new List<UserProgressModel>
            {
                new UserProgressModel { UserId = 1, Weight = 150, Height = 68, Age = 30 },
                new UserProgressModel { UserId = 1, Weight = 150, Height = 68, Age = 30 },
                new UserProgressModel { UserId = 2, Weight = 180, Height = 72, Age = 35 },
                new UserProgressModel { UserId = 3, Weight = 140, Height = 62, Age = 28 },
                new UserProgressModel { UserId = 4, Weight = 160, Height = 70, Age = 36 },
                new UserProgressModel { UserId = 5, Weight = 170, Height = 64, Age = 29 },
                new UserProgressModel { UserId = 6, Weight = 155, Height = 71, Age = 32 },
                new UserProgressModel { UserId = 7, Weight = 130, Height = 60, Age = 25 },
                new UserProgressModel { UserId = 8, Weight = 190, Height = 76, Age = 40 },
                new UserProgressModel { UserId = 9, Weight = 150, Height = 65, Age = 27 },
                new UserProgressModel { UserId = 10, Weight = 175, Height = 69, Age = 33 },
                new UserProgressModel { UserId = 11, Weight = 145, Height = 63, Age = 26 },
                new UserProgressModel { UserId = 12, Weight = 170, Height = 72, Age = 37 },
                new UserProgressModel { UserId = 13, Weight = 160, Height = 67, Age = 31 },
                new UserProgressModel { UserId = 14, Weight = 155, Height = 68, Age = 29 },
                new UserProgressModel { UserId = 15, Weight = 180, Height = 74, Age = 38 }
            };
        }

        // Retrieves the user progress for a specific user
        public async Task<UserProgressModel> GetUserProgress(int userId)
        {
            return await Task.FromResult(_userProgressList.FirstOrDefault(up => up.UserId == userId));
        }

        // Adds user progress for a specific user
        public async Task AddUserProgress(UserProgressModel userProgress)
        {
            _userProgressList.Add(userProgress);
            await Task.CompletedTask;
        }

        // Updates user progress for a specific user
        public async Task UpdateUserProgress(int userId, UserProgressModel userProgress)
        {
            var index = _userProgressList.FindIndex(up => up.UserId == userId);
            if (index != -1)
            {
                _userProgressList[index] = userProgress;
            }
            await Task.CompletedTask;
        }

        // Deletes user progress for a specific user
        public async Task DeleteUserProgress(int userId)
        {
            var userProgress = _userProgressList.FirstOrDefault(up => up.UserId == userId);
            if (userProgress != null)
            {
                _userProgressList.Remove(userProgress);
            }
            await Task.CompletedTask;
        }

        // Filters the user progress based on specific conditions
        public async Task<List<UserProgressModel>> GetFilteredUserProgress(int userId)
        {
            var filteredProgress = _userProgressList.Where(up => up.UserId == userId).ToList();
            return await Task.FromResult(filteredProgress);
        }
    }
}