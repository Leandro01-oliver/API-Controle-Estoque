using Data.Entity;

namespace Data.Repositories.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> GetByEmailEPassordAsync(string email, string password);
        Task<Usuario> GetByEmailAsync(string email);
        Task AddAsync(Usuario usuario);
        void Update(Usuario usuario);
        Task<Usuario?> GetByIdAsync(Guid id);
    }
}
