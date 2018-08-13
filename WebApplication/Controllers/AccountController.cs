namespace WebApplication.Controllers
{
    using System.Threading.Tasks;
    using Database.Entities;
    using Logic.Services.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IGameUserService gameUserService;

        public AccountController(IGameUserService gameUserService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.gameUserService = gameUserService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<object> Register(RegisterUser user)
        {
            var au = new ApplicationUser {UserName = user.UserName};
            var result = await userManager.CreateAsync(au, user.Password);

            if (result.Succeeded)
            {
                var u = user.MapToDto();
                gameUserService.Register(u);
            }

            return Task.FromResult(result.Errors);
        }

        [HttpPost]
        public async Task<object> Login(LoginUser model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (result.Succeeded)
            {
                return Ok(new {Result = "Success"});
            }
            if (result.IsLockedOut)
            {
                return Ok(new { Result = "Failed", Error = "Account Locked"});
            }
            else
            {
                return Ok(new {Result = "Failed", Error = "Wrong password and/or login"});
            }
        }

        [HttpGet]
        public ActionResult GetMyResultForRound(int roundId, int userId)
        {
            var result = gameUserService.GetResultForUserInRound(roundId, userId);
            return Ok(result);
        }
    }

    public class LoginUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}