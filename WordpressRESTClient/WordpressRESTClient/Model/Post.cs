using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordpressAPI.Model
{
    public class Post
    {
        public int id { get; set; }
        public title title { get; set; }
        public int featured_media { get; set; }

        public string imagePath { get; set; } 
    }

    public class title
    {
        public string rendered { get; set; }
    }
    public class PostDetail
    {
        public int id { get; set; }
        public Content content { get; set; }
    }

    public class Content
    {
        public string rendered { get; set; }
    }
}
