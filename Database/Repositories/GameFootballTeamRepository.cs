namespace Database.Repositories
{
    using System.Collections.Generic;
    using Dapper;
    using Entities;
    using Infrastracture;
    using Interfaces;

    public class GameFootballTeamRepository : Repository<GameFootballTeam>, IGameFootballTeamRepository
    {
        public GameFootballTeamRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public IEnumerable<GameFootballTeam> GetPlayerTeam(int userId, int roundId)
        {
            var query = "SELECT GameFootballTeamId, UserId, PlayerId, RoundId " +
                        "FROM GameFootballTeam " +
                        "WHERE UserId = @userId " +
                        "AND RoundId = @roundId";

            var result = ConnectionFactory.GetConnection().Query<GameFootballTeam>(query, new { userId, roundId });

            return result;
        }
    }
}
