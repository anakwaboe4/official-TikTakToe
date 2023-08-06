using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace TikTakToe.API.Controllers
{
    public class GamesController : ControllerBase
    {
        #region GET/games+
        [HttpGet]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(List<>))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        [Route("api/games")]
        public async Task<ActionResult> GamesGetAsync()
        {
            try
            {

            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
