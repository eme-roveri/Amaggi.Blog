using Amaggi.Blog.Application.DTO;

namespace Amaggi.Blog.Application.Interfaces
{
    public interface IPostAppService
    {
        Task CreatePostAsync(PostDTO PostDTO);
        Task DeletePostAsync(int id);
        Task<IEnumerable<PostDTO>> GetAllPostsAsync();
        Task<PostDTO> GetPostByIdAsync(int id);
        Task UpdatePostAsync(PostDTO PostDTO);
    }
}