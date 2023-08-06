using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TikTakToe.API.Models;
using TikTakToe.API.Models.Games;
using TikTakToe.Core.Participants;

namespace TikTakToe.API.Controllers
{
    public class GamesController : ControllerBase
    {
        private Controller.Controller _controller;

        public GamesController(Controller.Controller controller) => _controller = controller;

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
                var newGame = new Controller.Controller(new List<Participant>() { new Player(), new Player() }, new Core.Boards.Board(game.LengthX, game.LengthY));
                _controller = newGame;
                return Ok(new GamesResponse() { Squares = newGame.Board.GetBoard()});
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
