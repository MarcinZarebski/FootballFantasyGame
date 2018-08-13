namespace Database.Repositories
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Dapper;
    using Entities;
    using Infrastracture;
    using Interfaces;
    public class GameUserRepository : Repository<GameUser>, IGameUserRepository
    {
        public GameUserRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public IEnumerable<PlayerStatisticsInMatch> GetPlayersStaticsForRound(int roundId, int userId)
        {
            var query = "SELECT ps.PlayerId," +
                        "ps.MatchId," +
                        "ps.MinutesPlayed," +
                        "ps.GoalsScored," +
                        "ps.Booking," +
                        "ps.AppearedOnPitch," +
                        "ps.IsSubstitute " +
                        "FROM " +
                        "PlayerStatisticsInMatch ps " +
                        "join GameFootballTeam g " +
                        "on ps.PlayerId = g.PlayerId " +
                        "WHERE g.RoundId = @roundId " +
                        "and g.UserId = @userId";

            var result = ConnectionFactory.GetConnection().Query<PlayerStatisticsInMatch>(query, new {roundId, userId});

            return result;
        }
    }
}
