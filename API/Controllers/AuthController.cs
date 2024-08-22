using Businnes.Data.Models;
using Businnes.Helpers.Custons;
using Bussines.Data.Requests;
using Bussines.Services;
using Bussines.Services.Interfaces;
using Custom_Identity.Helpers.Custons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IConfiguration _configuration;
        public AuthController(IUsuarioService usuarioService, IUnitOfWorkService unitOfWorkService, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _unitOfWorkService = unitOfWorkService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Entrar([FromBody] AuthEntrarUsuarioRequest authEntrarUsuarioRequest)
        {
            try
            {
                UsuarioVm usuario = await _usuarioService.GetByEmailAsync(authEntrarUsuarioRequest.Email);

                if (usuario == null)
                {
                    throw new Exception("Usuário não encontrado");
                }

                PaswordExtrasion paswordExtrasion = new PaswordExtrasion();

                if (usuario.Senha != paswordExtrasion.EncodePassword(authEntrarUsuarioRequest.Senha))
                {
                    throw new Exception("Senha inválida");
                }

                usuario.Token = TokenService.GenerateToken(usuario, _configuration);

                _usuarioService.Update(usuario);

                await _unitOfWorkService.CommitAsync();

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }
    }
}
