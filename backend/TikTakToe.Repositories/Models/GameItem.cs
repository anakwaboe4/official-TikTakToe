using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TikTakToe.Core.Enums;
using UUIDNext;

namespace TikTakToe.Repositories.Models
{
    public class GameItem
    {
        public GameItem() { }

        public GameItem(int gridSizeX, int gridSizeY, List<Engines> engines, List<Squares> boardSquares)
        {
            Id = Uuid.NewDatabaseFriendly(Database.SQLite);
            Move = 0;
            GridSizeX = gridSizeX;
            GridSizeY = gridSizeY;
            Engines = engines;
            BoardSquares = boardSquares;
        }

        [Key]
        public Guid Id { get; set; } = Uuid.NewDatabaseFriendly(Database.SQLite);
        public int Move { get; set; } = 0;
        public int GridSizeX { get; set; }
        public int GridSizeY { get; set; }
        [NotMapped]
        public List<Engines> Engines { get; set; } = [];
        [NotMapped]
        public List<Squares> BoardSquares { get; set; } = [];
        public ICollection<MoveItem> Moves { get; set; } = [];
    }
}
