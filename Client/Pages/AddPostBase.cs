﻿using Microsoft.AspNetCore.Components;
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

        [Inject]
        private NavigationManager navigationManager { get; set; }

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

            BlogPost savedPost = await BlogPostDataService.AddBlogPost(newPost);

            if (savedPost != null) {
                navigationManager.NavigateTo($"viewpost/{savedPost.Id}");
            }
        }

    }
}
