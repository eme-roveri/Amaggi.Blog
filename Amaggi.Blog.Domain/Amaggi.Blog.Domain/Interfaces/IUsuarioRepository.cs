using Amaggi.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaggi.Blog.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AddAsync(Usuario entity);
        Task<Usuario> GetByIdAsync(int id);
        Task<Usuario> GetByEmail(string email);
        Task UpdateAsync(Usuario entity);
    }
}
