using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinkStart.Core.Models;

namespace LinkStart.Core.ViewModels
{
    public class PostViewModel
    {

        public int Id { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public string Text { get; set; }

        public DateTime PosteDateTime { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}