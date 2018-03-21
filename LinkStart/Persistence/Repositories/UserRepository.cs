using System.Collections.Generic;
using System.Linq;
using LinkStart.Core.Models;
using LinkStart.Core.Repositories;

namespace LinkStart.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers() => _context.Users.ToList();
    }
}