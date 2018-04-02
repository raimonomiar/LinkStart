using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LinkStart.Core;
using LinkStart.Core.Repositories;
using LinkStart.Persistence.Repositories;

namespace LinkStart.Persistence
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            RoleRepository = new RoleRepository(context);

            UserRepository = new UserRepository(context);

            PostRepository = new PostRepository(context);
        }

        public IRoleRepository RoleRepository { get; private set; }
        public IPostRepository PostRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }
        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}