using Microsoft.EntityFrameworkCore;
using TikTakToe.API.Setup;
using TikTakToe.Repositories.EntityFramework;
using TikTakToe.Services;

var corsPolicy = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.BuildAuthenticationSetup(config);
builder.BuildSwaggerSetup(config);
builder.Services.AddDbContext<TikTakToeContext>(//options =>
                                                //options.UseSqlite("Data Source=Database.db")
);
builder.Services.AddScoped<IGameServiceOld, GameServiceOld>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
var app = builder.Build();

app.UseSwaggerSetup(config, true);

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<TikTakToeContext>();

    context.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseCors(corsPolicy);

app.UseAuthenticationSetup();

app.MapControllers();

app.Run();
