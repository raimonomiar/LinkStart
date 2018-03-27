using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using LinkStart.Core.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LinkStart.Persistence.Repositories
{
    public class RoleRepository:IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(IdentityRole role)
        {
            _context.Roles.Add(role);
        }

        public void Update(IdentityRole role)
        {
            _context.Entry(role).State = EntityState.Modified;
        }

        public async Task<IEnumerable<IdentityRole>> GetRoles() => await _context.Roles.ToListAsync();

        public async Task<IdentityRole> GetSingleRole(string id) => await _context.Roles.SingleOrDefaultAsync(x => x.Id == id);

        public void Delete(IdentityRole role)
        {
            _context.Roles.Remove(role);
        }

        
    }
}