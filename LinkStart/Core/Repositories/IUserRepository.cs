using System.Collections.Generic;
using System.Threading.Tasks;
using LinkStart.Core.Models;

namespace LinkStart.Core.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetSingleUser(string id);
        void Update(User user);
    }
}