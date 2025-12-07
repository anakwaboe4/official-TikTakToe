using System.ComponentModel.DataAnnotations;
using TikTakToe.Core.Enums;

namespace TikTakToe.Repositories.Models;

public class MoveItem
{
    public MoveItem()
    {
        MoveId = Guid.CreateVersion7();
    }

    [Key]
    public Guid MoveId { get; set; }
    public int Index { get; set; }
    public Squares Square { get; set; }
    public Engines Engine { get; set; }
}
