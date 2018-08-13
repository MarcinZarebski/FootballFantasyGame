namespace Database.Entities
{
    using System;
    using Dapper.Contrib.Extensions;

    public class Match
    {
        [Key]
        public int MatchId { get; set; }

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public DateTime MatchDate { get; set; }

        public string StadiumId { get; set; }

        public int HomeTeamStatisticsId { get; set; }

        public int AwayTeamStatisticsId { get; set; }

        public int RoundId { get; set; }
    }
}
