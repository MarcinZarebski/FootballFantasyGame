namespace WebApplication.Models
{
    public class PlayerSummary
    {
        public int PlayerId { get; set; }

        public int PointsForGoalsScored { get; set; }

        public int PointsForGoalsConceded { get; set; }

        public int PointsForResult { get; set; }

        public int PointsForCards { get; set; }

        public int TotalPointsForRound { get; set; }
    }
}