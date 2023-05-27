using Fitness_Tracking.Interfaces;
using Fitness_Tracking.Models;

namespace Fitness_Tracking.Services
{
    public class ExerciseLogService : IExerciseLogService
    {
        private readonly List<ExerciseLogModel> _exerciseLogList;

        public ExerciseLogService()
        {
            _exerciseLogList = new List<ExerciseLogModel>
            {
                new ExerciseLogModel { UserId = 1, ExerciseName = "Bench Press", Sets = 4, Reps = 12 },
                new ExerciseLogModel { UserId = 1, ExerciseName = "Squats", Sets = 3, Reps = 10 },
                new ExerciseLogModel { UserId = 1, ExerciseName = "Deadlifts", Sets = 3, Reps = 8 },
                new ExerciseLogModel { UserId = 2, ExerciseName = "Push-ups", Sets = 3, Reps = 15 },
                new ExerciseLogModel { UserId = 2, ExerciseName = "Sit-ups", Sets = 3, Reps = 20 },
                new ExerciseLogModel { UserId = 2, ExerciseName = "Planks", Sets = 3, Reps = 60 },
                new ExerciseLogModel { UserId = 3, ExerciseName = "Cardio", Sets = 1, Reps = 30 },
                new ExerciseLogModel { UserId = 3, ExerciseName = "Running", Sets = 1, Reps = 30 },
                new ExerciseLogModel { UserId = 4, ExerciseName = "Pull-ups", Sets = 3, Reps = 8 },
                new ExerciseLogModel { UserId = 4, ExerciseName = "Rows", Sets = 3, Reps = 12 },
                new ExerciseLogModel { UserId = 4, ExerciseName = "Bicep Curls", Sets = 3, Reps = 12 },
                new ExerciseLogModel { UserId = 4, ExerciseName = "Dumbbell Curls", Sets = 3, Reps = 10 },
                new ExerciseLogModel { UserId = 5, ExerciseName = "Sprints", Sets = 3, Reps = 30 },
                new ExerciseLogModel { UserId = 6, ExerciseName = "Jumping Jacks", Sets = 3, Reps = 20 },
                new ExerciseLogModel { UserId = 6, ExerciseName = "Mountain Climbers", Sets = 3, Reps = 12 },
                new ExerciseLogModel { UserId = 7, ExerciseName = "Burpees", Sets = 3, Reps = 10 },
                new ExerciseLogModel { UserId = 8, ExerciseName = "Hip Thrusts", Sets = 4, Reps = 12 },
                new ExerciseLogModel { UserId = 8, ExerciseName = "Leg Curls", Sets = 3, Reps = 10 },
                new ExerciseLogModel { UserId = 5, ExerciseName = "Leg Press", Sets = 4, Reps = 12 },
                new ExerciseLogModel { UserId = 5, ExerciseName = "Lunges", Sets = 3, Reps = 10 }
            };
        }

        // Retrieves the exercise log for a specific user
        public async Task<List<ExerciseLogModel>> GetExerciseLog(int userId)
        {
            return await Task.FromResult(_exerciseLogList.Where(el => el.UserId == userId).ToList());
        }

        // Adds an exercise log entry for a specific user
        public async Task AddExerciseLog(ExerciseLogModel exerciseLog)
        {
            _exerciseLogList.Add(exerciseLog);
            await Task.CompletedTask;
        }

        // Updates an exercise log entry for a specific user
        public async Task UpdateExerciseLog(int userId, ExerciseLogModel exerciseLog)
        {
            var index = _exerciseLogList.FindIndex(el => el.UserId == userId);
            if (index != -1)
            {
                _exerciseLogList[index] = exerciseLog;
            }
            await Task.CompletedTask;
        }

        // Deletes an exercise log entry for a specific user
        public async Task DeleteExerciseLog(int userId)
        {
            //var exerciseLog = _exerciseLogList.FirstOrDefault(el => el.UserId == userId);
            //if (exerciseLog != null)
            //{
            //    _exerciseLogList.Remove(exerciseLog);
            //}
            //await Task.CompletedTask;

            var exerciseLogs = _exerciseLogList.Where(el => el.UserId == userId).ToList();
            foreach (var exerciseLog in exerciseLogs)
            {
                _exerciseLogList.Remove(exerciseLog);
            }
            await Task.CompletedTask;
        }
    }
}