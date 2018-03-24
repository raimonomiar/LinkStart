using LinkStart.Core.Repositories;

namespace LinkStart.Core
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IRoleRepository RoleRepository { get; }

        IUserRoleRepository UserRoleRepository { get};
        void Complete();

    }
}