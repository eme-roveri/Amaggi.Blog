using Amaggi.Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaggi.Blog.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(post => post.Id);

            builder.Property(p => p.Id)
                .UseIdentityColumn(seed: 1, increment: 1);

            builder.Property(p => p.Titulo)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Conteudo)
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            builder.Property(p => p.UsuarioId)
                .IsRequired();

            builder.HasOne(p => p.Usuario)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
