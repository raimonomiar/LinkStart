using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public IEnumerable<IdentityRole> GetRoles() => _context.Roles.ToList();

        public IdentityRole GetSingleRole(string id) => _context.Roles.SingleOrDefault(x => x.Id == id);

        public void Delete(IdentityRole role)
        {
            _context.Roles.Remove(role);
        }
    }
}