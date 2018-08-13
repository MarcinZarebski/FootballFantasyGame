namespace Database.Repositories.Interfaces
{
    using System.Collections.Generic;
    using Entities;

    public interface IGameFootballTeamRepository : IRepository<GameFootballTeam>
    {
        IEnumerable<GameFootballTeam> GetPlayerTeam(int userId, int roundId);
    }
}
