using TikTakToe.Core.Enums;

namespace TikTakToe.API.Models.Games
{
    public struct MoveAiPutBody
    {
        public Squares Square { get; set; }
        public int Participant { get; set; }
    }
}
