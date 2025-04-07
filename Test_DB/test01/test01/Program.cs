using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test01
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                var blog = new Blog { Url = "http://sample.com", Rating = 5 };
                blog.Posts = new List<Post>
                {
                    new Post { Title = "Test1", Content = "Hello."},
                    new Post { Title = "Test2", Content = "Hello."}
                };
                db.Blogs.Add(blog);
                db.SaveChanges();
            }

            using(var db = new BloggingContext())
            {
                var post = new Post { Title = "Test3", Content = "Hello." , BlogId = 1};
                db.Entry(post).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
            using(var context = new BloggingContext())
            {
                var blog = context.Blogs.SingleOrDefault(b => b.BlogId == 1);
                if (blog != null) Console.WriteLine($"Blog URL: {blog.Url}");
            }
            using (var db = new BloggingContext())
            {
                var query = db.Blogs
                    .Where(b => b.BlogId > 1)
                    .OrderBy(b => b.Url);
                foreach (var b in query)
                {
                    Console.WriteLine(b.BlogId);
                }
            }


        }
    }
}
