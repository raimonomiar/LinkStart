using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkStart.Core.Dtos
{
    public class PostDto
    {
        public int PostId { get; set; }

        public string UserId { get; set; }

        public string Message { get; set; }

        public DateTime DateTime { get; set; }
    }
}