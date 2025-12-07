using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TikTakToe.Core.Enums;

namespace TikTakToe.Repositories.Models;

public class GameItem
{
    public GameItem()
    {
        Id = Guid.CreateVersion7();
    }

    public GameItem(int gridSizeX, int gridSizeY, List<Engines> engines, List<Squares> boardSquares)
    {
        Id = Guid.CreateVersion7();
        Move = 0;
        GridSizeX = gridSizeX;
        GridSizeY = gridSizeY;
        Engines = engines;
        BoardSquares = boardSquares;
    }

    [Key]
    public Guid Id { get; set; }
    public int Move { get; set; } = 0;
    public int GridSizeX { get; set; }
    public int GridSizeY { get; set; }
    [NotMapped]
    public ICollection<Engines> Engines { get; set; } = [];
    [NotMapped]
    public ICollection<Squares> BoardSquares { get; set; } = [];
    public ICollection<MoveItem> Moves { get; set; } = [];
}
