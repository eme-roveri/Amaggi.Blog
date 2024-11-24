using Amaggi.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaggi.Blog.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task AddAsync(Post entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(int id);
        Task UpdateAsync(Post entity);
    }
}
