using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaggi.Blog.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataPostagem { get; set; } = DateTime.UtcNow;
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
