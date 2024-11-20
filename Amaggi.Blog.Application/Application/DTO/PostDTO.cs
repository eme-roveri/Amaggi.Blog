using Amaggi.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaggi.Blog.Application.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataPostagem { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}
