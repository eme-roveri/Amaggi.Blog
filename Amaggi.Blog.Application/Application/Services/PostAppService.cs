using Amaggi.Blog.Application.DTO;
using Amaggi.Blog.Application.Interfaces;
using Amaggi.Blog.Application.Validation;
using Amaggi.Blog.Domain.Entities;
using Amaggi.Blog.Domain.Interfaces;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaggi.Blog.Application.Services
{
    public class PostAppService : IPostAppService
    {
        private readonly IPostService _postService;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostAppService(IPostService postService, IPostRepository postRepository, IMapper mapper)
        {
            _postService = postService;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostDTO>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PostDTO>>(posts);
        }

        public async Task<PostDTO> GetPostByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            return _mapper.Map<PostDTO>(post);
        }

        public async Task<PostDTO> CreatePostAsync(PostDTO postDTO)
        {
            var post = _mapper.Map<Post>(postDTO);
            post = await _postRepository.AddAsync(post);

            postDTO.Id = post.Id;

            return postDTO;
        }
        public async Task UpdatePostAsync(PostDTO postDTO, int usuarioIdLogado)
        {
            if (await _postService.PostPertenceOutroUsuario(postDTO.Id, usuarioIdLogado))
            {
                throw new ApplicationException("Você não tem permissão para editar este post.");
            }

            var post = _mapper.Map<Post>(postDTO);

            await _postRepository.UpdateAsync(post);
        }

        public async Task DeletePostAsync(int postId, int usuarioIdLogado)
        {
            if (await _postService.PostPertenceOutroUsuario(postId, usuarioIdLogado))
            {
                throw new ApplicationException("Você não tem permissão para excluir este post.");
            }

            await _postRepository.DeleteAsync(postId);
        }
    }
}
