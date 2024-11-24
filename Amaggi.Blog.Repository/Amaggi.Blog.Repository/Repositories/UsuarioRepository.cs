using Amaggi.Blog.Domain.Entities;
using Amaggi.Blog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Amaggi.Blog.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BlogContext _context;
        private readonly DbSet<Usuario> _dbSet;

        public UsuarioRepository(BlogContext context)
        {
            _context = context;
            _dbSet = _context.Set<Usuario>();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task AddAsync(Usuario entity)
        {
            await _dbSet.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario entity)
        {
            _dbSet.Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
