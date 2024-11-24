using Amaggi.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Amaggi.Blog.Application.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime DataPostagem { get; set; }

        public int UsuarioId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string NomePublicador{ get; set; }
    }
}
