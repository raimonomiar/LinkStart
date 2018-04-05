using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LinkStart.Core.Models;

namespace LinkStart.Core.ViewModels
{
    public class PostViewModel
    {
        public int PostId { get; set; }

        public string UserId { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime DateTime { get; set; }

        public IEnumerable<Post> PostList { get; set; }

    }
}