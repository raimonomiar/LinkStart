using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<User>> GetUsers() => await _context.Users.ToListAsync();

        public async Task<User>  GetSingleUser(string id) =>  await  _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}