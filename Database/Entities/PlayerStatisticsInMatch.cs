namespace Database.Entities
{
    using Dapper.Contrib.Extensions;

    public class PlayerStatisticsInMatch
    {
        [Key]
        public int Id { get; set; }
        public int PlayerId { get; set; }

        public int MatchId { get; set; }

        public int MinutesPlayed { get; set; }

        public int GoalsScored { get; set; }

        public Booking Booking { get; set; }

        public bool AppearedOnPitch { get; set; }

        public bool IsSubstitute { get; set; }
    }
}
