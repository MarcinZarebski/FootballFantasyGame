namespace Logic.Services
{
    using System.Linq;
    using Database.Entities;
    using Database.Repositories.Interfaces;
    using DTO;
    using Interfaces;

    public class UserBetsService : IUserBetsService
    {
        private readonly IUserTypeRepository userTypeRepository;
        private readonly IGameFootballTeamRepository gameFootballTeamRepository;
        private readonly IRoundRepository roundRepository;

        public UserBetsService(IUserTypeRepository userTypeRepository, IGameFootballTeamRepository gameFootballTeamRepository, IRoundRepository roundRepository)
        {
            this.userTypeRepository = userTypeRepository;
            this.gameFootballTeamRepository = gameFootballTeamRepository;
            this.roundRepository = roundRepository;
        }

        public void AddType(UserTypeDto type)
        {
            var t = MapToEntity(type);
            userTypeRepository.Insert(t);
        }

        public void AddTeam(GameFootballTeamDto team)
        {
            foreach (var id in team.PlayerIds)
            {
                var t = new GameFootballTeam
                {
                    PlayerId = id,
                    UserId = team.UserId,
                    RoundId = GetCurrentRoundId()
                };

                gameFootballTeamRepository.Insert(t);
            }
        }

        public void UpdateType(UserTypeDto type)
        {
            var t = MapToEntity(type);
            userTypeRepository.Update(t);
        }

        public void RemoveType(int typeId)
        {
            userTypeRepository.Delete(typeId);
        }

        public void UpdateTeam(GameFootballTeamDto team)
        {
            RemoveUserTeam(team.UserId);

            AddTeam(team);
        }

        public void RemoveUserTeam(int userId)
        {
            var oldTeam = gameFootballTeamRepository.GetPlayerTeam(userId, GetCurrentRoundId());

            foreach (var id in oldTeam)
            {
                gameFootballTeamRepository.Delete(id.GameFootballTeamId);
            }
        }

        public void UpdateTeamMember(GameFootballMemberDto teamMember)
        {
            var member = SelectMember(teamMember);

            ModifyMember(teamMember, member);

            gameFootballTeamRepository.Update(member);
        }

        private static void ModifyMember(GameFootballMemberDto teamMember, GameFootballTeam member)
        {
            member.PlayerId = teamMember.PlayerId;
        }

        private GameFootballTeam SelectMember(GameFootballMemberDto teamMember)
        {
            var players = gameFootballTeamRepository.GetPlayerTeam(teamMember.UserId, GetCurrentRoundId());

            var member = players.Single(x => x.GameFootballTeamId == teamMember.GameFootballTeamId);
            return member;
        }

        private int GetCurrentRoundId()
        {
            return roundRepository.GetCurrentRoundId();
        }

        private UserType MapToEntity(UserTypeDto type)
        {
            var t = new UserType
            {
                HomeTeamGoals = type.HomeTeamGoals,
                AwayTeamGoals = type.AwayTeamGoals,
                UserId = type.UserId
            };

            return t;
        }
    }
}