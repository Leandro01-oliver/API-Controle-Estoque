using Bussines.Repositories.Interfaces;
using Data.Context;
using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DataContext db) : base(db)
        {
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Equals(email));
        }

        public async Task<Usuario> GetByEmailEPassordAsync(string email, string password)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Senha.Equals(password));
        }
    }
}
