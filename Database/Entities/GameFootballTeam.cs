namespace Database.Entities
{
    using Dapper.Contrib.Extensions;

    public class GameFootballTeam
    {
        [Key]
        public int GameFootballTeamId { get; set; }

        public int UserId { get; set; }

        public int PlayerId { get; set; }

        public int RoundId { get; set; }
    }
}
