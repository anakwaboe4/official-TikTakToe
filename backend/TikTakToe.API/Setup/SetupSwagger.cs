using Microsoft.OpenApi;
using TikTakToe.Core;

namespace TikTakToe.API.Setup
{
    public static class SetupSwagger
    {
        public static void BuildSwaggerSetup(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            var instance = configuration.GetValue<string>(Globals.AppSettings.Instance);
            var tenantId = configuration.GetValue<string>(Globals.AppSettings.TenantId);
            var audience = configuration.GetValue<string>(Globals.AppSettings.ClientAppUri);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "TicTacToe.API",
                        Description = "An ASP.NET Core Web API in support of the TicTacToe project"
                    }
                );
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = new Uri($"{instance}{tenantId}/oauth2/v2.0/authorize"),
                            TokenUrl = new Uri($"{instance}{tenantId}/oauth2/v2.0/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                { $"{audience}/access_as_user", "TicTacToe.API" }
                            }
                        }
                    }
                });
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                //        },
                //        new[] { configuration["ApiScope"] }
                //    }
                //});
            });
        }
        public static void UseSwaggerSetup(this WebApplication app, IConfiguration configuration, bool isDevelop = true)
        {
            var clientId = configuration.GetValue<string>(Globals.AppSettings.ClientId);

            if(isDevelop)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TicTacToe.API v1");
                    c.OAuthClientId(clientId);
                    c.OAuthUsePkce();
                    c.OAuthScopeSeparator(" ");
                });
            }
        }
    }
}
