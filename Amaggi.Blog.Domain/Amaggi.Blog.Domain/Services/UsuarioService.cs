using Amaggi.Blog.Domain.Entities;
using Amaggi.Blog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaggi.Blog.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> EmailJaCadastrado(string email)
        {
            var usuarioCadastrado = _usuarioRepository.GetByEmail(email);

            return await usuarioCadastrado != null;
        }
    }
}
