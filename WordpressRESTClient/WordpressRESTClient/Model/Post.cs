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

    }

    public class title
    {
        public string rendered { get; set; }
    }
}
