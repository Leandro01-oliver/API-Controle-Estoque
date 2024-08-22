using Businnes.Data.Models;

namespace Bussines.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioVm> GetByEmailEPassordAsync(string email, string senha);
        Task<UsuarioVm> GetByEmailAsync(string email);
        Task AddAsync(UsuarioVm usuario);
        void Update(UsuarioVm usuario);
        Task<UsuarioVm?> GetByIdAsync(Guid id);
    }
}
