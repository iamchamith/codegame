using System;
using System.Threading.Tasks;
using BlocklyPro.Core.Domain;
using BlocklyPro.Core.Domain.Play;
using Microsoft.EntityFrameworkCore;

namespace BlocklyPro.Core.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private bool disposed;
        private Repository<Game> gameRepository;
        private Repository<GameMap> gameMapRepository;
        private Repository<User> userRepository;
        private Repository<PlayGame> playGameRepository;
        private Repository<GameCode> gameCodeRepository;

        public Repository<Game> GameRepository => gameRepository ?? (gameRepository = new Repository<Game>(Context));
        public Repository<GameMap> GameMapRepository => gameMapRepository ?? (gameMapRepository = new Repository<GameMap>(Context));
        public Repository<User> UserRepository => userRepository ?? (userRepository = new Repository<User>(Context));
        public DbContext Context { get; set; }
        public string ConnectionString => Context.Database.GetDbConnection().ConnectionString;

        public Repository<PlayGame> PlayGameRepository => playGameRepository ?? (playGameRepository = new Repository<PlayGame>(Context));
        public Repository<GameCode> GameCodeRepository => gameCodeRepository ?? (gameCodeRepository = new Repository<GameCode>(Context));

        public UnitOfWork(IBlocklyDbContext dbcontext)
        {
            Context = (BlocklyDbContext) dbcontext;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
