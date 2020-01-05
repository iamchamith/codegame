using BlocklyPro.Core.Domain;
using BlocklyPro.Core.Domain.Play;
using Microsoft.EntityFrameworkCore;

namespace BlocklyPro.Core.Infrastructure
{
    public interface IBlocklyDbContext
    {
        DbSet<Game> Game { get; set; }
        DbSet<GameMap> GameMap { get; set; }

        DbSet<PlayGame> PlayGame { get; set; }

        DbSet<GameCode> GameCode { get; set; }
    }
}
