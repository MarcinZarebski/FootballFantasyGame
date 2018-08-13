namespace Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Database;
    using Database.Entities;

    public class MatchStatisticsBuilder
    {
        private readonly List<PlayerStatisticsInMatch> statistics;
        private readonly List<GameFootballTeam> team;
        private int roundId;
        private const int UserId = 1;
        private int currentPlayerId;
        private const int MatchId = 1;

        public MatchStatisticsBuilder()
        {
            statistics = new List<PlayerStatisticsInMatch>();
            team = new List<GameFootballTeam>();
            currentPlayerId = -1;
        }

        public MatchStatisticsBuilder WithNewPlayer()
        {
            currentPlayerId++;
            statistics.Add(new PlayerStatisticsInMatch{PlayerId = currentPlayerId, MatchId = MatchId});
            team.Add(new GameFootballTeam{PlayerId = currentPlayerId, RoundId = roundId, UserId = UserId});

            return this;
        }

        public MatchStatisticsBuilder WhoScored(int goals)
        {
            var playerStatisticsInMatch = statistics.First(x => x.PlayerId == currentPlayerId);
            playerStatisticsInMatch.GoalsScored = goals;

            return this;
        }

        public MatchStatisticsBuilder WhoPlayedFor(int minutes)
        {
            var playerStatisticsInMatch = statistics.First(x => x.PlayerId == currentPlayerId);
            playerStatisticsInMatch.MinutesPlayed = minutes;

            return this;
        }

        public void Build(InMemoryDatabase db)
        {
            db.Insert(statistics);
            db.Insert(team);
        }

        public MatchStatisticsBuilder ForRound(int id)
        {
            roundId = id;

            return this;
        }

        public MatchStatisticsBuilder WhoWasBooked(Booking booking)
        {
            var playerStatisticsInMatch = statistics.First(x => x.PlayerId == currentPlayerId);
            playerStatisticsInMatch.Booking = booking;

            return this;
        }
    }
}