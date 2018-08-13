namespace Logic.Services.Interfaces
{
    using DTO;

    public interface IGameUserService
    {
        void Register(GameUserDto user);
        int GetResultForUserInRound(int roundId, int userId);
    }
}