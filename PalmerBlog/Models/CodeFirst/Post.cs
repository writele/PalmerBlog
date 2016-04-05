using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PalmerBlog.Models
{
    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset? Modified { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        [AllowHtml]
        public string Content { get; set; }
        public string Slug { get; set; }
        public string MediaURL { get; set; }
        public bool Published { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostCategory> Categories { get; set; }
    }
}