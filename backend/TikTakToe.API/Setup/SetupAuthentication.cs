using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using TikTakToe.API.Models;

namespace TikTakToe.API.Setup
{
    public static class SetupAuthentication
    {
        public static void BuildAuthenticationSetup(this WebApplicationBuilder builder, IConfiguration configuration)
        {

            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(configuration)
                .EnableTokenAcquisitionToCallDownstreamApi()
                .AddInMemoryTokenCaches();
        }
        public static void UseAuthenticationSetup(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                await next();

                if(context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    context.Response.ContentType = "application/json";
                    var error = new ErrorResponse { Message = "Unauthorized" };
                    var response = JsonSerializer.Serialize(error);
                    await context.Response.WriteAsync(response);
                }
            });
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
