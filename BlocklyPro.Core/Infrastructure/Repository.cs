using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BlocklyPro.Core.Domain;
using BlocklyPro.Core.Utility;
using Microsoft.EntityFrameworkCore;

namespace BlocklyPro.Core.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public IQueryable<T> TableAsNoTracking => context.Set<T>().AsNoTracking();
        public IQueryable<T> Table => context.Set<T>();
        private readonly DbContext context;
        private readonly DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public async Task<T> Create(T entity)
        {
            await dbSet.AddAsync((T)entity);
            return entity;
        }
        public async Task<T> CreateAndSave(T entity)
        {
            await dbSet.AddAsync((T)entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Delete(int id)
        {
            var entity = await Table.FirstOrDefaultAsync(p => p.Id == id);
            dbSet.Remove(entity);
        }

        public void Delete(List<T> items)
        {
            if (items.IsNullOrEmpty())
            {
                throw new InvalidDataException("Item cannot be null or empty");
            }
            dbSet.RemoveRange(items);
        }

        public void Delete(T items)
        {
            if (items == null)
            {
                throw new InvalidDataException("Item cannot be null or empty");
            }
            dbSet.Remove(items);
        }

        public async Task Delete(Expression<Func<T, bool>> filter)
        {
            var entities = await Table.Where(filter).ToListAsync();
            dbSet.RemoveRange(entities);
        }

        public Task Update(T entity)
        {
            throw new UnauthorizedAccessException();
        }

        public Task<T> Read(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
