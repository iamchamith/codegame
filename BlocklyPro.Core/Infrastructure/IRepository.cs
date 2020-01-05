using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BlocklyPro.Core.Domain;

namespace BlocklyPro.Core.Infrastructure
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Create(T entity);
        Task Delete(int id);
        Task Delete(Expression<Func<T, bool>> filter);
        Task Update(T entity);
        Task<T> Read(int id);
        IQueryable<T> TableAsNoTracking { get;}
        IQueryable<T> Table { get; }
    }
}
