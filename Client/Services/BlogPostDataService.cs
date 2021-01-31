using Microsoft.AspNetCore.Components;
using MiniBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiniBlog.Client.Services
{
    public class BlogPostDataService : IBlogPostDataService
    {
        private readonly HttpClient _httpClient;
        public BlogPostDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<BlogPost>> GetBlogPosts()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<BlogPost>>
                (await _httpClient.GetStreamAsync($"api/blogpost"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        public async Task<BlogPost> GetBlogPostById(int id)
        {
            return await JsonSerializer.DeserializeAsync<BlogPost>
                (await _httpClient.GetStreamAsync($"api/blogpost/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<BlogPost> AddBlogPost(BlogPost newBlogPost)
        {
            var content = JsonContent.Create(newBlogPost);
            var response = await _httpClient.PostAsync($"api/blogpost", content);

            if (response.IsSuccessStatusCode) {
                BlogPost model = await response.Content.ReadFromJsonAsync<BlogPost>();
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task<BlogPost> UpdateBlogPost(BlogPost blogPost)
        {
            var blogPostJson = JsonContent.Create(blogPost);

            var response = await _httpClient.PutAsync($"api/blogpost", blogPostJson);

            if (response.IsSuccessStatusCode)
            {
                BlogPost model = await response.Content.ReadFromJsonAsync<BlogPost>();
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task DeleteBlogPost(int id)
        {
            await _httpClient.DeleteAsync($"api/blogpost/{id}");
        }
    }
}
