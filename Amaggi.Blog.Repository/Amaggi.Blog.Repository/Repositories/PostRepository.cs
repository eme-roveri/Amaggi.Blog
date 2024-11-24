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
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Post> AddAsync(Post post)
        {
            await _dbSet.AddAsync(post);

            await _context.SaveChangesAsync();

            return post;
        }

        public async Task UpdateAsync(Post post)
        {
            _dbSet.Update(post);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var post = await _dbSet.FindAsync(id);
            _dbSet.Remove(post);

            await _context.SaveChangesAsync();
        }
    }
}
