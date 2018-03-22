using System.Collections.Generic;
using System.Data.Entity;
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

        public User GetSingleUser(string id) => _context.Users.FirstOrDefault(x => x.Id == id);
        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}