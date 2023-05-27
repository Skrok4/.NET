namespace Fitness_Tracking.Models
{
    public class ExerciseLogModel
    {
        public int UserId { get; set; }
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
    }
}
