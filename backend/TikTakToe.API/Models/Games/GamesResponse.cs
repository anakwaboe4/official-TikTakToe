using TikTakToe.Core.Enums;
using TikTakToe.Repositories.Models;

namespace TikTakToe.API.Models.Games
{
    public struct GamesResponse
    {
        public GameItem? Game { get; set; }
    }
}
