using Microsoft.AspNetCore.Components;
using MiniBlog.Client.Services;
using MiniBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniBlog.Client.Pages
{
    public class ViewPostBase : ComponentBase
    {
        [Inject]
        public IBlogPostDataService BlogPostDataService { get; set; }

        [Parameter]
        public int postId { get; set; }

        protected BlogPost blogPost { get; set; } = new BlogPost();

        protected override async Task OnInitializedAsync()
        {
            await LoadBlogPost();
        }
        private async Task LoadBlogPost()
        {
            blogPost = await BlogPostDataService.GetBlogPostById(postId);
        }
    }
}
