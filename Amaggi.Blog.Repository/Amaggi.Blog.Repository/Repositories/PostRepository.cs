using Amaggi.Blog.Domain.Entities;
using Amaggi.Blog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaggi.Blog.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogContext _context;
        private readonly DbSet<Post> _dbSet;

        public PostRepository(BlogContext context)
        {
            _context = context;
            _dbSet = _context.Set<Post>();
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(Post entity)
        {
            await _dbSet.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Post entity)
        {
            _dbSet.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
