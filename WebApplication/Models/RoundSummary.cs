namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;

    public class RoundSummary
    {
        public List<GameFootballTeamSummary> GameFootballTeamSummaries { get; set; }

        public DateTime RoundStart { get; set; }

        public DateTime RoundEnd { get; set; }

        public int GameUserId { get; set; }

        public int PointsForGoalsScored { get; set; }

        public int PointsForGoalsConceded { get; set; }

        public int PointsForResult { get; set; }

        public int PointsForCards { get; set; }

        public int TotalPointsForRound { get; set; }
    }
}