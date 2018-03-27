﻿using System.Threading.Tasks;
using LinkStart.Core.Repositories;

namespace LinkStart.Core
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IRoleRepository RoleRepository { get; }
/*
        IUserRoleRepository UserRoleRepository { get}*/
        Task Complete();

    }
}