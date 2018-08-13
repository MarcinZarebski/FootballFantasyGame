namespace Database.Entities
{
using System;
    public class Round
    {
        public int RoundId { get; set; }

        public DateTime Begin { get; set; }

        public DateTime End { get; set; }

        public bool IsCurrent { get; set; }
    }
}
