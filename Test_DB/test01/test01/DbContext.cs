using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace test01
{
    public class BloggingContext : DbContext
    {
        public BloggingContext() : base("BlogDataBase")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BloggingContext>());
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
  
}
