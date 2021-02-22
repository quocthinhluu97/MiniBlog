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
    
        protected List<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();

        protected override async Task OnInitializedAsync()
        {
            await LoadBlogPosts();
        }
        private async Task LoadBlogPosts()
        {
            BlogPosts = (await BlogPostDataService.GetBlogPosts()).ToList();
        }
    }
}
