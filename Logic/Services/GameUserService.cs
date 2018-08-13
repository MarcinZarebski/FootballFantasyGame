namespace Logic.Services
{
    using System.Linq;
    using Database;
    using Database.Entities;
    using Database.Repositories.Interfaces;
    using DTO;
    using Interfaces;

    public class GameUserService : IGameUserService
    {
        private readonly IGameUserRepository repository;

        public GameUserService(IGameUserRepository repository)
        {
            this.repository = repository;
        }

        private GameUser MapToEntity(GameUserDto u)
        {
            var entity = new GameUser
            {
                TeamName = u.TeamName,
                UserName = u.UserName,
                Email = u.Email
            };


            return entity;
        }

        public void Register(GameUserDto user)
        {
            var u = MapToEntity(user);
            repository.Insert(u);
        }

        public int GetResultForUserInRound(int roundId, int userId)
        {
            var statiscs = repository.GetPlayersStaticsForRound(roundId, userId);

            return statiscs.Sum(CalculatePointsForPlayer);
        }

        private int CalculatePointsForPlayer(PlayerStatisticsInMatch playerStatisticsInMatch)
        {
            var total = 0;
            var pointsForMinutes = CalculatePointsForMinutes(playerStatisticsInMatch.MinutesPlayed);
            var pointsForGoals = CalculatePointsForGoals(playerStatisticsInMatch.GoalsScored);
            var pointsForBooking = CalculatePointsForBooking(playerStatisticsInMatch.Booking);

            total = pointsForMinutes + pointsForGoals + pointsForBooking;

            return total;
        }

        private int CalculatePointsForBooking(Booking booking)
        {
            switch (booking)
            {
                case Booking.NoCard:
                    return 0;
                case Booking.YellowCard:
                    return -1;
                case Booking.TwoYellowCars:
                    return -3;
                case Booking.RedCard:
                    return -4;
                default:
                    return 0;
            }
        }

        private int CalculatePointsForGoals(int goalsScored)
        {
            return goalsScored * 3;
        }

        private int CalculatePointsForMinutes(int minutesPlayed)
        {
            var points = 0;

            if (minutesPlayed >= 30)
            {
                points = 1;
            }

            if (minutesPlayed >= 60)
            {
                points = 2;
            }

            if (minutesPlayed >= 90)
            {
                points = 3;
            }

            return points;
        }
    }
}