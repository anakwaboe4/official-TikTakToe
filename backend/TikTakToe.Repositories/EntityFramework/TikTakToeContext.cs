using Microsoft.EntityFrameworkCore;
using System.IO;
using TikTakToe.Repositories.Models;

namespace TikTakToe.Repositories.EntityFramework
{
    public class TikTakToeContext : DbContext
    {
        public string DbDirectory { get; }
        public string DbPath { get; }


        public TikTakToeContext(DbContextOptions<TikTakToeContext> options)
            : base(options)
        {
            var folder = Environment.SpecialFolder.ApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbDirectory = Path.Join(path, Path.Join("TikTakToe", "Data"));
            DbPath = Path.Join(DbDirectory, "TikTakToe.db");
            Directory.CreateDirectory(DbDirectory);
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<GameItem> Games { get; set; }
        public DbSet<MoveItem> Moves { get; set; }
    }
}
