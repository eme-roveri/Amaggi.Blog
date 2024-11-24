using Amaggi.Blog.Application.DTO;
using Amaggi.Blog.Application.Interfaces;
using Amaggi.Blog.Application.Services;
using Amaggi.Blog.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amaggi.Blog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PostController : ControllerBase
    {
        private readonly IPostAppService _postService;

        public PostController(IPostAppService postService)
        {
            _postService = postService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var postsDTO = await _postService.GetAllPostsAsync();

            return Ok(postsDTO);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var postDTO = await _postService.GetPostByIdAsync(id);
            if (postDTO == null)
            {
                return NotFound();
            }

            return Ok(postDTO);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Adicionar(PostDTO PostDTO)
        {
            await _postService.CreatePostAsync(PostDTO);

            return Ok("Post criado com sucesso.");
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, PostDTO postDTO)
        {
            if (id != postDTO.Id)
            {
                return BadRequest("O ID fornecido não corresponde ao ID do Post.");
            }

            // Acessando o ID do usuário dos claims do JWT
            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            if (userId is null)
            {
                return Unauthorized("Usuário não autenticado.");
            }

            await _postService.UpdatePostAsync(postDTO, Convert.ToInt32(userId));

            return Ok(new { message = "Post atualizado com sucesso." });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _postService.DeletePostAsync(id);

            return Ok(new { message = "Post excluido com sucesso." });
        }
    }
}
