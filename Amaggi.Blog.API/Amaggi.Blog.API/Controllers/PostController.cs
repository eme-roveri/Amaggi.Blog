using Amaggi.Blog.Application.DTO;
using Amaggi.Blog.Application.Services;
using Amaggi.Blog.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amaggi.Blog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostAppService _postService;

        public PostController(PostAppService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var postsDTO = await _postService.GetAllPostsAsync();

            return Ok(postsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var postDTO = await _postService.GetPostByIdAsync(id);
            if (postDTO == null)
            {
                return NotFound();
            }

            return Ok(postDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostDTO PostDTO)
        {
            await _postService.CreatePostAsync(PostDTO);

            return Ok("Post criado com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, PostDTO postDTO)
        {
            if (id != postDTO.Id)
            {
                return BadRequest("O ID fornecido não corresponde ao ID do Post.");
            }
            await _postService.UpdatePostAsync(postDTO);


            return Ok(new { message = "Post atualizado com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postService.DeletePostAsync(id);

            return Ok(new { message = "Post excluido com sucesso." });
        }
    }
}
