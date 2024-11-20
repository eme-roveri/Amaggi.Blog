using Amaggi.Blog.Application.DTO;
using Amaggi.Blog.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amaggi.Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public AuthenticationController(UsuarioService UsuarioService)
        {
            _usuarioService = UsuarioService;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(UsuarioDTO usuarioDTO)
        {
            await _usuarioService.RegisterUserAsync(usuarioDTO);

            return Ok("Usuário registrado com sucesso");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string nome, string senha)
        {
            var usuarioDTO = await _usuarioService.LoginAsync(nome, senha);

            if (usuarioDTO == null)
            {
                return Unauthorized("As credenciais fornecidas não são válidas");
            }

            return Ok(usuarioDTO);
        }
    }
}
