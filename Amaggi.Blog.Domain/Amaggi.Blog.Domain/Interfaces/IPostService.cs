namespace Amaggi.Blog.Domain.Interfaces
{
    public interface IPostService
    {
        Task<bool> PostPertenceOutroUsuario(int postId, int usuarioIdLogado);
    }
}