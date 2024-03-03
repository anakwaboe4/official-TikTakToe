using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TikTakToe.Core.Enums;

namespace TikTakToe.Repositories.Models
{
    public class GameItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int Move { get; set; }
        public int GridSizeX { get; set; }
        public int GridSizeY { get; set; }
        [NotMapped]
        public List<Engines> Engines { get; set; } = new List<Engines>();
        [NotMapped]
        public List<Squares> BoardSquares { get; set; } = new List<Squares>();
        public ICollection<MoveItem> Moves { get; set; } = new List<MoveItem>();
    }
}
