using System;

namespace LinkStart.Core.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }


        public string Text { get; set; }

        public DateTime PosteDateTime { get; set; }
    }
}