using Amaggi.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaggi.Blog.Application.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public List<PostDTO> Posts { get; set; } = new();
    }
}
