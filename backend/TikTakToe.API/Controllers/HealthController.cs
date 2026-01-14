using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace TikTakToe.API.Controllers
{
    public class HealthController
    {
        #region GET/health
        [HttpGet]
        [Produces("application/json")]
        [SwaggerResponse(200)]
        [Route("api/health")]
        public ActionResult GetHealthStatus()
        {
            return new OkResult();
        }
        #endregion
    }
}
