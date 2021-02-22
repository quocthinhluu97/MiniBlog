using Markdig;
using Microsoft.AspNetCore.Components;
using MiniBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniBlog.Client.Pages
{
    public class BlogPostPreviewBase : ComponentBase
    {
        [Parameter]
        public BlogPost BlogPost { get; set; }

        protected override void OnInitialized()
        {
            LoadBlogPreview();
        }
        private void LoadBlogPreview()
        {
            BlogPost.Post = Markdown.ToHtml(BlogPost.Post);
        }
    }
}
