using MiniBlog.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniBlog.Client.Services
{
    public interface IBlogPostDataService
    {
        Task<IEnumerable<BlogPost>> GetBlogPosts();
        Task<BlogPost> GetBlogPostById(int id);
        Task<BlogPost> AddBlogPost(BlogPost newBlogPost);
    }
}