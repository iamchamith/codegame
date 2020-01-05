using BlocklyPro.Core.Domain;
using BlocklyPro.Core.Domain.Play;
using Microsoft.EntityFrameworkCore;

namespace BlocklyPro.Core.Infrastructure
{
    public class BlocklyDbContext : DbContext, IBlocklyDbContext
    {
        private string connectionString;
        public DbSet<Game> Game { get; set; }
        public DbSet<GameMap> GameMap { get; set; }

        public DbSet<PlayGame> PlayGame { get; set; }

        public DbSet<GameCode> GameCode { get; set; }

        public BlocklyDbContext()
        {
            connectionString = GlobalConfig.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasIndex(p => p.Name).IsUnique();
        }
    }
}
