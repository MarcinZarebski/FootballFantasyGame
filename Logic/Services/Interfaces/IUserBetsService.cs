namespace Logic.Services.Interfaces
{
    using DTO;

    public interface IUserBetsService
    {
        void AddType(UserTypeDto type);
        void AddTeam(GameFootballTeamDto team);
        void UpdateType(UserTypeDto type);
        void RemoveType(int typeId);
        void UpdateTeam(GameFootballTeamDto team);
        void RemoveUserTeam(int userId);
        void UpdateTeamMember(GameFootballMemberDto teamMember);
    }
}
