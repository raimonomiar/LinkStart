using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkStart.Core.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime PosteDateTime { get; set; }




    }
}