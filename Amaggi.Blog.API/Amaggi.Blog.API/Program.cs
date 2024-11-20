
using Amaggi.Blog.Application.Services;
using Amaggi.Blog.Data;
using Amaggi.Blog.Data.Repositories;
using Amaggi.Blog.Domain.Interfaces;

namespace Amaggi.Blog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<BlogContext>(); 
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); 
            builder.Services.AddScoped<UsuarioService>(); 
            builder.Services.AddScoped<PostService>(); 
            //builder.Services.AddSingleton<WebSocketServer>(); 
            builder.Services.AddControllers(); 
            //builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserValidator>());
            builder.Services.AddAutoMapper(typeof(Program));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseWebSockets();

            app.Run();
        }
    }
}
