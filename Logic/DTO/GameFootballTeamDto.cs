namespace Logic.DTO
{
    using System.Collections.Generic;

    public class GameFootballTeamDto
    {
        public int UserId { get; set; }

        public IEnumerable<int> PlayerIds { get; set; }
    }
}
