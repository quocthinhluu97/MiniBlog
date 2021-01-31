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

            //newBlogPost.Id = _appDbContext.BlogPosts.OrderByDescending(x => x.Id).First().Id + 1;
            _appDbContext.BlogPosts.Add(newBlogPost);
            _appDbContext.SaveChanges();

            return newBlogPost;
        }

        public BlogPost UpdateBlogPost(BlogPost blogPost)
        {
            var foundBlogPost = _appDbContext.BlogPosts.SingleOrDefault(p => p.Id == blogPost.Id);

            if (foundBlogPost == null) {
                return null;
            }
            else
            {
                foundBlogPost.Title = blogPost.Title;
                foundBlogPost.Post = blogPost.Post;
                //PropertiesCopy(foundBlogPost, blogPost);
                _appDbContext.SaveChanges();
                return foundBlogPost;
            }
        }

        public void DeleteBlogPost(int postId) {
            var foundBlogPost = _appDbContext.BlogPosts.SingleOrDefault(p => p.Id == postId);
            if (foundBlogPost == null) {
                return;
            }
            else
            {
                _appDbContext.BlogPosts.Remove(foundBlogPost);
                _appDbContext.SaveChanges();
            }
        }

        public static void PropertiesCopy<T>(T parent, T child) where T : class
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                    {
                        childProperty.SetValue(child, parentProperty.GetValue(parent));
                        break;
                    }
                }
            }
        }
    }
}
