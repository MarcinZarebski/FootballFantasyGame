namespace WebApplication.Controllers
{
    using Logic.DTO;
    using Logic.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameTypeController : ControllerBase
    {
        public GameTypeController(IUserBetsService userBetsService)
        {
            this.userBetsService = userBetsService;
        }

        private readonly IUserBetsService userBetsService;

        [HttpPost]
        public ActionResult AddType(UserTypeModel model)
        {
            var type = new UserTypeDto
            {
                AwayTeamGoals = model.AwayTeamGoals,
                HomeTeamGoals = model.HomeTeamGoals,
                UserId = model.UserId
            };

            userBetsService.AddType(type);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateType(UserTypeModel model)
        {
            var type = new UserTypeDto
            {
                AwayTeamGoals = model.AwayTeamGoals,
                HomeTeamGoals = model.HomeTeamGoals,
                UserId = model.UserId
            };

            userBetsService.UpdateType(type);
            return Ok();
        }

        [HttpDelete]
        public ActionResult CancelType(int typeId)
        {
            userBetsService.RemoveType(typeId);
            return Ok();
        }

        [HttpPost]
        public ActionResult AddUserTeam(GameFootballTeamModel model)
        {
            var team = new GameFootballTeamDto
            {
                PlayerIds = model.PlayerIds,
                UserId = model.UserId
            };

            userBetsService.AddTeam(team);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateUserTeam(GameFootballTeamModel model)
        {
            var team = new GameFootballTeamDto
            {
                PlayerIds = model.PlayerIds,
                UserId = model.UserId
            };

            userBetsService.UpdateTeam(team);
            return Ok();
        }

        [HttpPatch]
        public ActionResult UpdateMemberOfUserTeam(GameFootballMemberModel model)
        {
            var teamMember = new GameFootballMemberDto
            {
                GameFootballTeamId = model.GameFootballTeamId,
                PlayerId = model.PlayerId,
                UserId = model.UserId
            };

            userBetsService.UpdateTeamMember(teamMember);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteUserTeam(int userId)
        {
            userBetsService.RemoveUserTeam(userId);
            return Ok();
        }
    }
}