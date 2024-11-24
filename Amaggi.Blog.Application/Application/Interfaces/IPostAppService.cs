using Amaggi.Blog.Application.DTO;

namespace Amaggi.Blog.Application.Interfaces
{
    public interface IPostAppService
    {
        Task<PostDTO> CreatePostAsync(PostDTO PostDTO);
        Task DeletePostAsync(int id, int usuarioIdLogado);
        Task<IEnumerable<PostDTO>> GetAllPostsAsync();
        Task<PostDTO> GetPostByIdAsync(int id);
        Task UpdatePostAsync(PostDTO PostDTO, int usuarioIdLogado);
    }
}