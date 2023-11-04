using TikTakToe.Core.Enums;

namespace TikTakToe.API.Models.Games
{
    public struct GamesResponse
    {
        public List<List<Squares>> Squares { get; set; }
    }
}
