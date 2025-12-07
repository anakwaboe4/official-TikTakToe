using TikTakToe.Core.Enums;

namespace TikTakToe.API.Models.Games;

public record MoveAiPutBody
{
    public Squares Square { get; set; }
    public int Participant { get; set; }
}
