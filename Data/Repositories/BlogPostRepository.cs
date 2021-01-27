using MiniBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBlog.Data.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly AppDbContext _appDbContext;

        public BlogPostRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<BlogPost> GetBlogPosts()
        {
            return _appDbContext.BlogPosts;
        }

        public BlogPost GetBlogPostById(int postId)
        {
            return _appDbContext.BlogPosts.SingleOrDefault(p => p.Id == postId);
        }
        public BlogPost AddPost(BlogPost newBlogPost)
        {

            newBlogPost.Id = _appDbContext.BlogPosts.OrderByDescending(x => x.Id).First().Id + 1;
            _appDbContext.BlogPosts.Add(newBlogPost);
            return newBlogPost;
        }
    }
}
