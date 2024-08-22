using AutoMapper;
using Businnes.Data.Models;
using Businnes.Helpers.Custons;
using Bussines.Repositories.Interfaces;
using Bussines.Services.Interfaces;
using Data.Entity;

namespace Bussines.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(UsuarioVm usuario)
        {
            PaswordExtrasion paswordExtrasion = new PaswordExtrasion();

            usuario.Senha = paswordExtrasion.EncodePassword(usuario.Senha);

            await _usuarioRepository.AddAsync(_mapper.Map<Usuario>(usuario));
        }

        public async Task<UsuarioVm> GetByEmailAsync(string email)
        {
            return _mapper.Map<UsuarioVm>(await _usuarioRepository.GetByEmailAsync(email));
        }

        public async Task<UsuarioVm> GetByEmailEPassordAsync(string email, string senha)
        {
            return _mapper.Map<UsuarioVm>(await _usuarioRepository.GetByEmailEPassordAsync(email, senha));
        }

        public async Task<UsuarioVm?> GetByIdAsync(Guid id)
        {
            return _mapper.Map<UsuarioVm>(await _usuarioRepository.GetByIdAsync(id));
        }

        public void Update(UsuarioVm usuario)
        {
            _usuarioRepository.Update(_mapper.Map<Usuario>(usuario));
        }
    }
}
