using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkStart.Core.Models;

namespace LinkStart.Core.Repositories
{
    public interface IConnectionRepository
    {
        Connection FindUser(string userId);

        void Add(Connection connection);

        string[] GetChatnames();
    }
}
