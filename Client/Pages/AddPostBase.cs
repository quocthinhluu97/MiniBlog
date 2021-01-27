using Microsoft.AspNetCore.Components;
using MiniBlog.Client.Services;
using MiniBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniBlog.Client.Pages
{
    public class AddPostBase : ComponentBase
    {
        [Inject]
        public IBlogPostDataService BlogPostDataService { get; set; }
        private readonly NavigationManager _navigationManager;

        public string Title { get; set; }
        public string Post { get; set; }
        public string Author { get; set; }
        public async Task SavePost()
        {
            var newPost = new BlogPost
            {
                Title = Title,
                Post = Post,
                Author = Author
            };

            var result = await BlogPostDataService.AddBlogPost(newPost);

            //_navigationManager.NavigateTo("https://google.com");
        }

    }
}
