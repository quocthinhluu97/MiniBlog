using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MiniBlog.Client.Services;
using MiniBlog.Shared;

namespace MiniBlog.Client.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IBlogPostDataService BlogPostDataService{ get; set; }
    
        protected List<BlogPost> blogPosts { get; set; } = new List<BlogPost>();

        protected override async Task OnInitializedAsync()
        {
            await LoadBlogPosts();
        }
        private async Task LoadBlogPosts()
        {
            blogPosts = (await BlogPostDataService.GetBlogPosts()).ToList();
        }
    }
}
