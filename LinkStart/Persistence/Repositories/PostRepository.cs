    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}