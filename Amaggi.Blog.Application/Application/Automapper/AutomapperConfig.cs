using Amaggi.Blog.Application.DTO;
using Amaggi.Blog.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaggi.Blog.Application.Automapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();

            CreateMap<Post, PostDTO>()
                .ForMember(dest => dest.NomePublicador, opt => opt.MapFrom(src => src.Usuario.Nome));

            CreateMap<PostDTO, Post>();
        }
    }
}
