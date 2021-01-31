using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MiniBlog.Client.Services;
using MiniBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniBlog.Client.Pages
{
    public class PostEditorBase : ComponentBase
    {
        [Inject]
        public IBlogPostDataService BlogPostDataService { get; set; }

        [Inject]
        private NavigationManager navigationManager { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public string PostId { get; set; }
        protected BlogPost ExistingBlogPost { get; set; } = new BlogPost();

        public bool IsEdit => string.IsNullOrEmpty(PostId) ? false : true;

        public string Title { get; set; }
        public string Post { get; set; }
        public string Author { get; set; }

        protected int CharacterCount { get; set; }
        public ElementReference editor;

        public async Task UpdateCharacterCount()
        {
            CharacterCount = await JSRuntime.InvokeAsync<int>("MiniBlog.getCharacterCount", editor);
        }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(PostId)) {
                await LoadPost();
            }
        }

        public async Task LoadPost()
        {
            ExistingBlogPost = await BlogPostDataService.GetBlogPostById(Int32.Parse(PostId));
            CharacterCount = ExistingBlogPost.Post.Length;
        }

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

        public async Task UpdatePost()
        {
            var updatedBlogPost = await BlogPostDataService.UpdateBlogPost(ExistingBlogPost);

            if (updatedBlogPost != null) {
                navigationManager.NavigateTo($"viewpost/{updatedBlogPost.Id}");
            }
        }

        public async Task DeletePost()
        {
            await BlogPostDataService.DeleteBlogPost(ExistingBlogPost.Id);

            navigationManager.NavigateTo($"/");
        }
    }
}
