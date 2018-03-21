using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LinkStart.Core.Repositories
{
    public interface IRoleRepository
    {
        void Add(IdentityRole role);

        void Update(IdentityRole role);
        IEnumerable<IdentityRole> GetRoles();
        IdentityRole GetSingleRole(string id);
        void Delete(IdentityRole role);
    }
}
