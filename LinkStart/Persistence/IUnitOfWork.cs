using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinkStart.Core.Repositories;
using Microsoft.AspNet.Identity;

namespace LinkStart.Persistence
{
    public interface IUnitOfWork
    {
        IRoleRepository Role { get; }
        void Complete();

    }
}