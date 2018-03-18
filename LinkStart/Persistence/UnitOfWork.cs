using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkStart.Persistence
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

        }
    }
}