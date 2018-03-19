using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public IEnumerable<IdentityRole> GetRoleList() => 
            _context.Roles.ToList();

    }
}