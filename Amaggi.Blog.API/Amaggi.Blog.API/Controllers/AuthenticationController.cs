using Amaggi.Blog.Application.DTO;
using Amaggi.Blog.Application.Interfaces;
using Amaggi.Blog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amaggi.Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly ITokenAppService _tokenAppService;

        public AuthenticationController(IUsuarioAppService usuarioAppService, ITokenAppService tokenService)
        {
            _usuarioAppService = usuarioAppService;
            _tokenAppService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(UsuarioDTO usuarioDTO)
        {
            await _usuarioAppService.RegistrarAsync(usuarioDTO);

            return Ok("Usuário registrado com sucesso");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(CredencialDTO credencial)
        {
            var usuario = await _usuarioAppService.LoginAsync(credencial);

            if (usuario.Id != 0)
            {
                var jwToken = _tokenAppService.GenerateJwtToken(usuario);

                return Ok(jwToken);
            }

            return Unauthorized("As credenciais fornecidas não são válidas");
        }
    }
}
