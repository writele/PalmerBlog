using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PalmerBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTimeOffset Date { get; set; }

        public virtual ApplicationUser Author { get; set; }
        public virtual Post Post { get; set; }
    }
}