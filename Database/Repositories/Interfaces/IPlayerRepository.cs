namespace Database.Repositories.Interfaces
{
    using System.Collections.Generic;
    using Entities;

    public interface IPlayerRepository : IRepository<Player>
    {
        IEnumerable<Player> GetPlayerByIds(IEnumerable<int> ids);
    }
}
