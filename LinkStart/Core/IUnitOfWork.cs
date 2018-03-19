using LinkStart.Core.Repositories;

namespace LinkStart.Core
{
    public interface IUnitOfWork
    {
        IRoleRepository RoleRepository { get; }
        void Complete();
    }
}