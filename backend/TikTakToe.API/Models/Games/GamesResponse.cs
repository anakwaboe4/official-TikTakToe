using TikTakToe.Core.Enums;

namespace TikTakToe.API.Models.Games
{
    public class GamesResponse
    {
        public List<List<Squares>> Squares { get; set; }
    }
}
