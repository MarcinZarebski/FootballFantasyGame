namespace Database.Entities
{
    using Dapper.Contrib.Extensions;

    public class UserType
    {
        [Key]
        public int UserId { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }
    }
}
