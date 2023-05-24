using Fitness_Tracking.Models;

namespace Fitness_Tracking.Interfaces
{
    public interface IExerciseLogService
    {
        Task<List<ExerciseLogModel>> GetExerciseLog(int userId);
        Task AddExerciseLog(ExerciseLogModel exerciseLog);
        Task UpdateExerciseLog(int userId, ExerciseLogModel exerciseLog);
        Task DeleteExerciseLog(int userId);
    }
}
