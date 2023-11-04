using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TikTakToe.API.Models;
using TikTakToe.API.Models.Games;
using TikTakToe.Services;

namespace TikTakToe.API.Controllers
{
    public class GamesController : ControllerBase
    {
        private IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        #region POST/games
        [HttpPost]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(GamesResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        [Route("api/games")]
        public ActionResult GamesGetAsync([FromBody] GamePostBody game)
        {
            try
            {
                _gameService.NewGame(
                    game.ParticipantsIds,
                    game.LengthX,
                    game.LengthY);
                return Ok(new GamesResponse() { Squares = _gameService.GetBoard()});
            }
            catch(Exception)
            {
                return BadRequest("Failed creating new game, check game settings");
            }
        }
        #endregion

        #region PUT/games/move
        [HttpPut]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(bool))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        [Route("api/games/move")]
        public ActionResult MakeMove([FromBody] MovePutBody move)
        {
            try
            {
                return Ok(_gameService.MakeMove(move.Position, move.Square));
            }
            catch(Exception)
            {
                return BadRequest("Failed making move for player, check game settings");
            }
        }
        #endregion

        #region PUT/games/aimove
        [HttpPut]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(bool))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        [Route("api/games/aimove")]
        public ActionResult MakeAiMove([FromBody] MoveAiPutBody move)
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
