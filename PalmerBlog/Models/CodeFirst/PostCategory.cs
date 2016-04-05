using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmerBlog.Models
{
    public class PostCategory
    {
        public PostCategory()
        {
            this.Posts = new HashSet<Post>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}