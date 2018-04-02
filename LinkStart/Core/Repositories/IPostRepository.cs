using System;
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

        Task<Post> GetSingleRole(int id);

    }
}
