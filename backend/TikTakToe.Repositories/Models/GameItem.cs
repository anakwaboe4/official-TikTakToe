using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TikTakToe.Core.Enums;
using UUIDNext;

namespace TikTakToe.Repositories.Models
{
    public class GameItem(int gridSizeX, int gridSizeY, List<Engines> engines, List<Squares> boardSquares)
    {
        [Key]
        public Guid Id { get; set; } = Uuid.NewDatabaseFriendly(Database.SQLite);
        public int Move { get; set; } = 0;
        public int GridSizeX { get; set; } = gridSizeX;
        public int GridSizeY { get; set; } = gridSizeY;
        [NotMapped]
        public List<Engines> Engines { get; set; } = engines;
        [NotMapped]
        public List<Squares> BoardSquares { get; set; } = boardSquares;
        public ICollection<MoveItem> Moves { get; set; } = [];
    }
}
