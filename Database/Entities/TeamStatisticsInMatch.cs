namespace Database.Entities
{
    using Dapper.Contrib.Extensions;

    public class TeamStatisticsInMatch
    {
        [Key]
        public int TeamStatisticsInMatchId { get; set; }

        public int PlayerStatistics { get; set; }
    }
}