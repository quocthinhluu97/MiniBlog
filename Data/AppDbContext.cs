using Microsoft.EntityFrameworkCore;
using MiniBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBlog.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<BlogPost>().HasData(new List<BlogPost>()
            {
                new BlogPost()
                {
                Id = 1,
                Title = "If only C# worked in the browser",
                Post = "Lorem ipsum dolor sit amet...",
                Author = "Joe Bloggs",
                PostedDate = DateTime.Now.AddDays(-30)
                },

                new BlogPost(){
                Id = 2,
                Title = "400th JS Framework released",
                Post = "Lorem ipsum dolor sit amet...",
                Author = "Joe Bloggs",
                PostedDate = DateTime.Now.AddDays(-25)
                },
                new BlogPost()
            {
                Id = 3,
                Title = "WebAssembly FTW",
                Post = "Lorem ipsum dolor sit amet...",
                Author = "Joe Bloggs",
                PostedDate = DateTime.Now.AddDays(-20)
            },
                new BlogPost()
            {
                Id = 4,
                Title = "Blazor is Awesome!",
                Post = "Lorem ipsum dolor sit amet...",
                Author = "Joe Bloggs",
                PostedDate = DateTime.Now.AddDays(-15)
            },
                new BlogPost()
            {
                Id = 5,
                Title = "Your first Blazor App",
                Post = "Lorem ipsum dolor sit amet...",
                Author = "Joe Bloggs",
                PostedDate = DateTime.Now.AddDays(-10)
            }
            });
        }
    }
}
