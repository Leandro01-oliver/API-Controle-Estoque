using Data.Entity;
using System.Linq.Expressions;

namespace Bussines.Repositories.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task AddAsync(Usuario usuario);
        void Update(Usuario usuario);
        Task<IEnumerable<Usuario>> GetAllAsync(Expression<Func<Usuario, bool>>? expression = null, int pageNumber = 1,
    int pageSize = 10, bool asNoTracking = true, params Expression<Func<Usuario, object>>[]? includes);
        Task<Usuario> GetByEmailEPassordAsync(string email, string password);
        Task<Usuario> GetByEmailAsync(string email);
        Task<Usuario?> GetByIdAsync(Guid usuarioId);
    }
}
