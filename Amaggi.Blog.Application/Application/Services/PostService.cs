using Amaggi.Blog.Application.DTO;
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
    public class PostService
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public PostService(IRepository<Post> postRepository, IMapper mapper)
        {
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

        public async Task CreatePostAsync(PostDTO PostDTO)
        {
            var post = _mapper.Map<Post>(PostDTO);
            await _postRepository.AddAsync(post);
        }

        public async Task UpdatePostAsync(PostDTO PostDTO)
        {
            var post = _mapper.Map<Post>(PostDTO);
            await _postRepository.UpdateAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
        }
    }
}
