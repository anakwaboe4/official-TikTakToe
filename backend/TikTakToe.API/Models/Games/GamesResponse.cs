using TikTakToe.Repositories.Models;

namespace TikTakToe.API.Models.Games;

public record GamesResponse
{
    public GameItem? Game { get; set; }
}
