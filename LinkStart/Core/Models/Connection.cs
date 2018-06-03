using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkStart.Core.Models
{
    public class Connection
    {
        public int Id { get; set; }

        public string ConnectionId { get; set; }

        public string ChatName { get; set; }

        public bool  IsOnline { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }


    }
}