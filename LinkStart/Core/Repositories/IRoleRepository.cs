using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LinkStart.Core.Repositories
{
    public interface IRoleRepository
    {
        void Add(IdentityRole role);

        void Update(IdentityRole role);
        Task<IEnumerable<IdentityRole>> GetRoles();
        Task<IdentityRole> GetSingleRole(string id);
        void Delete(IdentityRole role);
    }
}
