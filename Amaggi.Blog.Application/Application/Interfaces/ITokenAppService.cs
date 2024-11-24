using Amaggi.Blog.Application.DTO;

namespace Amaggi.Blog.Application.Interfaces
{
    public interface ITokenAppService
    {
        string GenerateJwtToken(UsuarioDTO usuario);
    }
}