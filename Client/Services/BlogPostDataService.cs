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
            //var newBlogPostJson = new StringContent(JsonSerializer.Serialize(newBlogPost), Encoding.UTF8, "application/json");

            //var response = await _httpClient.PostAsync($"api/blogpost", newBlogPostJson);

            var content = JsonContent.Create(newBlogPost);
            var response = await _httpClient.PostAsync($"api/blogpost", content);

            if (response.IsSuccessStatusCode) {
                return await JsonSerializer.DeserializeAsync<BlogPost>(await response.Content.ReadAsStreamAsync());
            }
            else
            {
                return null;
            }
        }
    }
}
