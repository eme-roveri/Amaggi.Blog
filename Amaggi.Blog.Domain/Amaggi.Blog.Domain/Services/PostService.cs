using Amaggi.Blog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaggi.Blog.Domain.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<bool> PostPertenceOutroUsuario(int postId, int usuarioIdLogado)
        {
            var post = await _postRepository.GetByIdAsync(postId);

            return post.UsuarioId != usuarioIdLogado;
        }
    }
}
