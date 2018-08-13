namespace Database.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Dapper;
    using Entities;
    using Infrastracture;
    using Interfaces;

    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public IEnumerable<Player> GetPlayerByIds(IEnumerable<int> ids)
        {
            var query = "SELECT * FROM Players WHERE PlayerId IN @ids";
            var players = ConnectionFactory.GetConnection().Query<Player>(query, new {ids}).ToList();
            return players;
        }

        public PlayerRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}
