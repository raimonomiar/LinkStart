using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LinkStart.Core.Repositories
{
    public interface IRoleRepository
    {
        void Add(IdentityRole role);

        IEnumerable<IdentityRole> GetRoles();
        IdentityRole GetSingleRole(string id);
    }
}
