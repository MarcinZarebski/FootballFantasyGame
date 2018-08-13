namespace WebApplication.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserTypeModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer")]
        public int HomeTeamGoals { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer")]
        public int AwayTeamGoals { get; set; }
    }
}
