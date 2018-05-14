    using System;
using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using LinkStart.Core.Models;
    using LinkStart.Core.Repositories;

namespace LinkStart.Persistence.Repositories
{
    public class PostRepository:IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Post post)
        {
            _context.Posts.Add(post);
        }

        public void Remove(Post post) => _context.Posts.Remove(post);


        public async Task<Post> GetSinglePost(int id) => await _context.Posts.Include(x=>x.User).SingleOrDefaultAsync(x=>x.Id == id);

        public int GetId(Post post) => post.Id;

        public async Task<IEnumerable<Post>> GetPostList() =>
            await _context.Posts.Include(u => u.User).OrderByDescending(x => x.PosteDateTime).ToListAsync();
    }
}