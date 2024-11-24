namespace Amaggi.Blog.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Task <bool> EmailJaCadastrado(string email);
    }
}