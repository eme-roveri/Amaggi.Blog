using Amaggi.Blog.Application.DTO;
using Amaggi.Blog.Domain.Entities;
using Amaggi.Blog.Domain.Interfaces;
using AutoMapper;

namespace Amaggi.Blog.Application.Services
{
    public class UsuarioService
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IRepository<Usuario> usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task RegisterUserAsync(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            // Adicione validação e lógica de registro aqui

            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task<UsuarioDTO> LoginAsync(string nome, string senha)
        {
            var usuario = await _usuarioRepository.GetAllAsync();
            
            usuario.FirstOrDefault(u => u.Nome == nome && u.Senha == senha);

            return _mapper.Map<UsuarioDTO>(usuario);
        }
    }
}
