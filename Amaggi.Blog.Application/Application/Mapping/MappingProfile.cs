using Amaggi.Blog.Application.DTO;
using Amaggi.Blog.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Amaggi.Blog.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();

            CreateMap<Post, PostDTO>().ReverseMap();
        }
    }
}
