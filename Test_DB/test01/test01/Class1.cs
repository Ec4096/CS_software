using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test01
{
    public class Blog {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }

    public class Post {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Comment { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

}
