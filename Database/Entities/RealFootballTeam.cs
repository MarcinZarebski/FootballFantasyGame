namespace Database.Entities
{
    using Dapper.Contrib.Extensions;

    public class RealFootballTeam
    {
        [Key]
        public int RealFootballTeamId { get; set; }

        public int PlayerId { get; set; }
    }
}
