using System.Linq.Expressions;

namespace Bussines.Services.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, int pageNumber = 1,
    int pageSize = 10, bool asNoTracking = true, params Expression<Func<TEntity, object>>[]? includes);
        Task<TEntity?> GetByIdAsync(Guid id);
    }
}
