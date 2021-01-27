using MiniBlog.Shared;
using System.Collections.Generic;

namespace MiniBlog.Data.Repositories
{
    public interface IBlogPostRepository
    {
        BlogPost AddPost(BlogPost newBlogPost);
        BlogPost GetBlogPostById(int postId);
        IEnumerable<BlogPost> GetBlogPosts();
    }
}