using Businnes.Data.Enums;
using Businnes.Data.Models;
using Businnes.Repositories.Interfaces;
using Bussines.Data.Requests;
using Bussines.Services.Interfaces;
using Custom_Identity.Helpers.Custons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Gerente")]
    public class UsuarioController(IUsuarioService usuarioService, IUnitOfWorkService unitOfWorkService,  IConfiguration _configuration) : Controller
    {
        private readonly IUsuarioService _usuarioService = usuarioService;
        private readonly IUnitOfWorkService _unitOfWorkService = unitOfWorkService;

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Cadastrar([FromBody] UsuarioCadastrarRequest usuarioCadastrarRequest)
        {
            try
            {

               var usuarioExiste = await _usuarioService.GetByEmailAsync(usuarioCadastrarRequest.Email);

               if (usuarioExiste is not null) return BadRequest("Usuário já cadastrado");

               UsuarioVm novoUsuario = new UsuarioVm()
               {
                   PrimeiroNome = usuarioCadastrarRequest.PrimeiroNome,
                   SegundoNome = usuarioCadastrarRequest.SegundoNome,
                   Telefone = usuarioCadastrarRequest.Telefone,
                   CPF = usuarioCadastrarRequest.CPF,
                   Email = usuarioCadastrarRequest.Email,
                   Senha = usuarioCadastrarRequest.Senha,
                   Role = Role.Colaborador,
                   Token = ""
               };

                novoUsuario.Token = TokenService.GenerateToken(novoUsuario, _configuration);

               await _usuarioService.AddAsync(novoUsuario);

               await _unitOfWorkService.CommitAsync();

               return Ok(novoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
