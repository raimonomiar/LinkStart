using System;
using System.Collections.Generic;
using System.Linq;
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

        }

        public IRoleRepository RoleRepository { get; private set; }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}