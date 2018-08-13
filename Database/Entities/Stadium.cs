namespace Database.Entities
{
    using Dapper.Contrib.Extensions;

    public class Stadium
    {
        [Key]
        public int StadiumId { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public string City { get; set; }
    }
}
