using TikTakToe.Core.Enums;

namespace TikTakToe.API.Models.Games;

public record MovePutBody
{
    public Squares Square { get; set; }
    public int Position { get; set; }
}
