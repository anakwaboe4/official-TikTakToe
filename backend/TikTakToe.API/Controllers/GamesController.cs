using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TikTakToe.API.Models;
using TikTakToe.API.Models.Games;
using TikTakToe.Repositories.EntityFramework;
using TikTakToe.Repositories.Models;
using TikTakToe.Services;

namespace TikTakToe.API.Controllers
{
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        #region POST/games/{gameId}
        [HttpPost]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(GamesResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        [Route("api/games/{gameId}")]
        public ActionResult GamesGetAsync([FromBody] GamePostBody? body, [FromRoute] Guid? gameId)
        {
            try
            {
                var game = new GameItem();

                if(!gameId.HasValue || gameId.Value == Guid.Empty || body == null || !body.HasValue)
                {
                    game = _gameService.NewGame(body?.ParticipantsIds, body?.LengthX, body?.LengthY);
                }
                else
                {
                    game = _gameService.GetGame(gameId.Value);
                }

                return Ok(new GamesResponse() { Game = game });
            }
            catch(Exception)
            {
                return BadRequest("Failed to get (new) game, check game settings");
            }
        }
        #endregion

        #region PUT/games/{gameId}/move
        [HttpPut]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(GamesResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        [Route("api/games/{gameId}/move")]
        public ActionResult MakeMove([FromBody] MovePutBody move, [FromRoute] Guid gameId)
        {
            try
            {
                _gameService.MakeMove(move.Position, move.Square);

                return Ok(new GamesResponse() { /*Squares = _gameService.GetBoard()*/ });
            }
            catch(Exception)
            {
                return BadRequest("Failed making move for player, check game settings");
            }
        }
        #endregion

        #region PUT/games/{gameId}/aimove
        [HttpPut]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(bool))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        [Route("api/games/{gameId}/aimove")]
        public ActionResult MakeAiMove([FromBody] MoveAiPutBody move, [FromRoute] Guid gameId)
        {
            try
            {
                return Ok(_gameService.MakeAiMove(move.Participant, move.Square));
            }
            catch(Exception)
            {
                return BadRequest("Failed making move for AI, check game settings");
            }
        }
        #endregion
    }
}
