﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkStart.Core.Models;

namespace LinkStart.Core.Repositories
{
    public interface IPostRepository
    {
        void Add(Post post);

        void Remove(Post post);
        Task<Post> GetSinglePost(int id);

        int GetId(Post post);

        Task<IEnumerable<Post>> GetPostList();
    }
}
