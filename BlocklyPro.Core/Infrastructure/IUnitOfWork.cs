using System.Threading.Tasks;
using BlocklyPro.Core.Domain;
using BlocklyPro.Core.Domain.Play;
using Microsoft.EntityFrameworkCore;

namespace BlocklyPro.Core.Infrastructure
{
    public interface IUnitOfWork
    {
        Repository<Game> GameRepository { get; }
        Repository<GameMap> GameMapRepository { get; }
        Repository<User> UserRepository { get; }
        Repository<PlayGame> PlayGameRepository { get; }
        Repository<GameCode> GameCodeRepository { get; }
        void Save();
        Task SaveAsync();
        DbContext Context { get; }
        string ConnectionString { get; }
    }
}
