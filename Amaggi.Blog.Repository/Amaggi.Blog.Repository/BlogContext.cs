namespace Amaggi.Blog.Data
{
    using Amaggi.Blog.Domain.Entities;
    using Amaggi.Blog.Data.Configurations;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class BlogContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Post> Posts { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("BlogConnString");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioConfiguration());

            modelBuilder.ApplyConfiguration<Post>(new PostConfiguration());
        }
    }
}
