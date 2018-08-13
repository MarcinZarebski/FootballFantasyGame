namespace Tests
{
    using Database;
    using Database.Repositories;
    using Logic.Services;
    using Xunit;

    public class GameUserServiceTests
    {
        private const int RoundId = 3;

        [Theory]
        [InlineData(0, 0)]
        [InlineData(15, 0)]
        [InlineData(30, 1)]
        [InlineData(45, 1)]
        [InlineData(60, 2)]
        [InlineData(75, 2)]
        [InlineData(90, 3)]
        public void GetResultForUserInRound_PlayerGetsPointsForMinutesPlayed_Calculated(int minutes, int expected)
        {
            var db = new InMemoryDatabase();

            new MatchStatisticsBuilder()
                .ForRound(RoundId)
                .WithNewPlayer()
                .WhoPlayedFor(minutes)
                .Build(db);

            var result = Act(RoundId, db);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 3)]
        [InlineData(2, 6)]
        [InlineData(3, 9)]
        public void GetResultForUserInRound_PlayerGetsPointsForGoalsScored_Calculated(int goals, int expected)
        {
            var db = new InMemoryDatabase();

            new MatchStatisticsBuilder()
                .ForRound(RoundId)
                .WithNewPlayer()
                .WhoScored(goals)
                .Build(db);

            var result = Act(RoundId, db);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(Booking.NoCard, 0)]
        [InlineData(Booking.YellowCard, -1)]
        [InlineData(Booking.RedCard, -4)]
        [InlineData(Booking.TwoYellowCars, -3)]
        public void GetResultForUserInRound_PlayerGetsPointsForBookings_Calculated(Booking booking, int expected)
        {
            var db = new InMemoryDatabase();

            new MatchStatisticsBuilder()
                .ForRound(RoundId)
                .WithNewPlayer()
                .WhoWasBooked(booking)
                .Build(db);

            var result = Act(RoundId, db);

            Assert.Equal(expected, result);
        }

        private int Act(int roundId, InMemoryDatabase db)
        {
            var repository = new GameUserRepository(db);
            var service = new GameUserService(repository);

            var result = service.GetResultForUserInRound(roundId, 1);
            return result;
        }
    }
}