using System.Threading.Tasks;
using LinkStart.Core.Models;
using LinkStart.Core.Repositories;

namespace LinkStart.Core
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IRoleRepository RoleRepository { get; }

        IPostRepository PostRepository { get; }

        IConnectionRepository ConnectionRepository { get; }

        /*IUserRoleRepository UserRoleRepository { get}*/
        Task Complete();

        void CompleteNA();

    }
}