using Microsoft.EntityFrameworkCore;
using TikTakToe.Repositories.Models;

namespace TikTakToe.Repositories.EntityFramework
{
    public class TikTakToeContext : DbContext
    {
        public TikTakToeContext(DbContextOptions<TikTakToeContext> options)
            : base(options)
        {}

        public DbSet<GameItem>? Games { get; set; }
    }
}
