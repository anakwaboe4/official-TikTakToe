using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TikTakToe.API.Models;
using TikTakToe.API.Models.Games;
using TikTakToe.Core.Boards;
using TikTakToe.Core.Participants;
using TikTakToe.Engines;
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

        #region GET/games
        [HttpPost]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(GamesResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        [Route("api/games")]
        public async Task<ActionResult> GamesGetAsync([FromBody] GamePostBody game)
        {
            try
            {
                _gameService.NewGame(
                    new List<IEngine>()
                    {
                        new Player(),
                        new Player()
                    },
                    new Board(game.LengthX, game.LengthY));
                return Ok(new GamesResponse() { Squares = _gameService.GetBoard()});
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
