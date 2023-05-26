namespace Fitness_Tracking.Models
{
    public class GoalModel
    {
        public int UserId { get; set; }
        public string GoalDescription { get; set; }
        public DateTime Deadline { get; set; }
    }
}
