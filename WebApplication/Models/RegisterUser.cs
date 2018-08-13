namespace WebApplication.Models
{
    using System.ComponentModel.DataAnnotations;
    using Logic.DTO;

    public class RegisterUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string TeamName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string ConfirmPassword { get; set; }

        public RegisterUser(GameUserDto user)
        {
            Email = user.Email;
            UserName = user.UserName;
            TeamName = user.TeamName;
            Password = user.Password;
        }

        public GameUserDto MapToDto()
        {
            var dto = new GameUserDto
            {
                Email = Email,
                UserName = UserName,
                TeamName = TeamName,
                Password = Password
            };


            return dto;
        }
    }
}