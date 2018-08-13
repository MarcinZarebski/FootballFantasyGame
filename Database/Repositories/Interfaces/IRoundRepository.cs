namespace Database.Repositories.Interfaces
{
    using Entities;

    public interface IRoundRepository : IRepository<Round>
    {
        int GetCurrentRoundId();
    }
}
