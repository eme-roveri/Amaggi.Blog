using Amaggi.Blog.Application.DTO;
using Amaggi.Blog.Application.Interfaces;
using Amaggi.Blog.Application.Services;
using Amaggi.Blog.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.IdentityModel.Tokens.Jwt;

namespace Amaggi.Blog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostAppService _postService;

        public PostController(IPostAppService postService)
        {
            _postService = postService;
        }

        [AllowAnonymous]
        [HttpGet("visualizar")]
        public async Task<IActionResult> ObterTodos()
        {
            var postsDTO = await _postService.GetAllPostsAsync();

            return Ok(CustomResponse.Success($"Foram encontrados {postsDTO.Count()} posts.", postsDTO));
        }

        [Authorize]
        [HttpGet("visualizar/{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var postDTO = await _postService.GetPostByIdAsync(id);

            if (postDTO == null)
            {
                return NotFound(CustomResponse.Error("Post não encontrado."));
            }

            return Ok(postDTO);
        }

        [Authorize]
        [HttpPost("criar")]
        public async Task<IActionResult> Adicionar(PostDTO postDTO)
        {
            postDTO = await _postService.CreatePostAsync(postDTO);

            return CreatedAtAction(nameof(ObterPorId), 
                new { id = postDTO.Id, }, 
                CustomResponse.Success("Post criado com sucesso.", postDTO)
            );
        }

        [Authorize]
        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Editar(int id, PostDTO postDTO)
        {
            if (id != postDTO.Id)
            {
                return BadRequest(CustomResponse.Error("O ID fornecido não corresponde ao ID do Post."));
            }

            var userId = ObterIdUsuarioLogado();

            if (userId is null)
            {
                return Unauthorized(CustomResponse.Error("Usuário não autenticado."));
            }

            try
            {
                await _postService.UpdatePostAsync(postDTO, userId.Value);

                return Ok(CustomResponse.Success("Post atualizado com sucesso.", postDTO));
            }
            catch (Exception exc)
            {
                return BadRequest(CustomResponse.Error(exc.Message));
            }
        }

        [Authorize]
        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var userId = ObterIdUsuarioLogado();

            if (userId is null)
            {
                return Unauthorized(CustomResponse.Error("Usuário não autenticado."));
            }

            try
            {
                await _postService.DeletePostAsync(id, userId.Value);

                return Ok(CustomResponse.Success("Post excluido com sucesso.", id));
            }
            catch (Exception exc)
            {
                return BadRequest(CustomResponse.Error(exc.Message));
            }        
        }

        private int? ObterIdUsuarioLogado()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type.Contains("nameidentifier"))?.Value;

            return Convert.ToInt32(userId);
        }
    }
}
