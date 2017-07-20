using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordpressAPI.Model
{
    public class Media
    {
        public int id { get; set; }
        public MediaDetail media_details { get; set; }

    }

    public class MediaDetail
    {
        public Sizes sizes { get; set; }

    }

    public class Sizes
    {
        public Medium medium { get; set; }

    }

    public class Medium
    {
        public string source_url { get; set; }

    }
}
