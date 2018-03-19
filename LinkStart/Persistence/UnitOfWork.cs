using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinkStart.Core.Repositories;
using LinkStart.Persistence.Repositories;

namespace LinkStart.Persistence
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IRoleRepository Role { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Role = new RoleRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();

            Role = new RoleRepository(_context);
        }
    }
}