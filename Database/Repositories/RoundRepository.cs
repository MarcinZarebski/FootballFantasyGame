namespace Database.Repositories
{
using System.Linq;
using Dapper;
using Entities;
using Infrastracture;
using Interfaces;

    public class RoundRepository : Repository<Round>, IRoundRepository
    {
        public RoundRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public int GetCurrentRoundId()
        {
            var query = "SELECT RoundId FROM Rounds WHERE IsCurrent = 1";
            var players = ConnectionFactory.GetConnection().Query<int>(query).Single();
            return players;
        }
    }
}
