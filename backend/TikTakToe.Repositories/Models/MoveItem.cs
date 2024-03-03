using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TikTakToe.Core.Enums;

namespace TikTakToe.Repositories.Models
{
    public class MoveItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MoveId { get; set; }
        public int Index { get; set; }
        public Squares Square { get; set; }
        public Engines Engine { get; set; }
    }
}
