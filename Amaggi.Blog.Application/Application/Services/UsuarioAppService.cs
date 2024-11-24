using Amaggi.Blog.Application.DTO;
using Amaggi.Blog.Application.Interfaces;
using Amaggi.Blog.Application.Validation;
using Amaggi.Blog.Domain.Entities;
using Amaggi.Blog.Domain.Interfaces;
using AutoMapper;
using FluentValidation;

namespace Amaggi.Blog.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Usuario> _usuarioValidator;
        private readonly IValidator<CredencialDTO> _credencialValidator;

        public UsuarioAppService(
            IUsuarioRepository usuarioRepository,
            IMapper mapper,
            IValidator<Usuario> usuarioValidator,
            IValidator<CredencialDTO> credencialValitador
            )
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _usuarioValidator = usuarioValidator;
            _credencialValidator = credencialValitador;
        }

        public async Task RegistrarAsync(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            var validacao = _usuarioValidator.Validate(usuario);

            if (!validacao.IsValid)
                throw new ValidationException(validacao.Errors);

            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task<UsuarioDTO> LoginAsync(CredencialDTO credencial)
        {
            var validacao = _credencialValidator.Validate(credencial);

            if (!validacao.IsValid)
            {
                throw new ValidationException(validacao.Errors);
            }

            var usuario = await _usuarioRepository.GetByEmail(credencial.Email);

            if (usuario is null)
            {
                usuario = new Usuario();
            }

            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);

            return usuarioDTO;
        }
    }
}
