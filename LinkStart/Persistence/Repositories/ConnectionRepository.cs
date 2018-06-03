using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LinkStart.Core.Models;
using LinkStart.Core.Repositories;
using Microsoft.AspNet.SignalR;

namespace LinkStart.Persistence.Repositories
{
    public class ConnectionRepository:IConnectionRepository
    {
        private readonly ApplicationDbContext _context;

        public ConnectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public Connection FindUser(string userId)
        {
           return _context.Connections.SingleOrDefault(x => x.UserId == userId);
        }

        public void Add(Connection connection)
        {
            _context.Connections.Add(connection);
        }

        public string[] GetChatnames()
        {
            return _context.Connections.Where(x => x.IsOnline).Select(x => x.ChatName).ToArray();
        }
    }
}