using Amaggi.Blog.Application.DTO;
using Amaggi.Blog.Application.Interfaces;
using Amaggi.Blog.Application.Services;
using Amaggi.Blog.Application.Validation;
using Amaggi.Blog.Data.Repositories;
using Amaggi.Blog.Domain.Entities;
using Amaggi.Blog.Domain.Interfaces;
using Amaggi.Blog.Domain.Services;
using FluentValidation;

namespace Amaggi.Blog.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IValidator<Usuario>, UsuarioValidator>();
            services.AddScoped<IValidator<Post>, PostValidator>();
            services.AddScoped<IValidator<CredencialDTO>, CredencialValidator>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostAppService, PostAppService>();

            services.AddScoped<ITokenAppService, TokenAppService>();
        }
    }
}
