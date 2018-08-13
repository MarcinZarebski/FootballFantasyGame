namespace Database.Entities
{
    using Dapper.Contrib.Extensions;

    public class GameUser
    {
        [Key]
        public int GameUserId { get; set; }

        public string UserName { get; set; }

        public string TeamName { get; set; }

        public byte[] Password { get; set; }

        public string Email { get; set; }
    }

}
