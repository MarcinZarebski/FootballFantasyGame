namespace Database.Repositories.Interfaces
{
    using System.Collections.Generic;
    using Entities;

    public interface IGameUserRepository : IRepository<GameUser>
    {
        IEnumerable<PlayerStatisticsInMatch> GetPlayersStaticsForRound(int roundId, int userId);
    }
}
