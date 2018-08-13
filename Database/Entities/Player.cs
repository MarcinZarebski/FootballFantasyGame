namespace Database.Entities
{
    using System;
    using Dapper.Contrib.Extensions;

    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public PlayingPosition Position { get; set; }
    }
}
