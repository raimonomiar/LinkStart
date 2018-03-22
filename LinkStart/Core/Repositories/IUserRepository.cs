﻿using System.Collections.Generic;
using LinkStart.Core.Models;

namespace LinkStart.Core.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetSingleUser(string id);
        void Update(User user);
    }
}