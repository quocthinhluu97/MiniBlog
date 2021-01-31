using Microsoft.AspNetCore.Mvc;
using MiniBlog.Data.Repositories;
using MiniBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniBlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostController(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        [HttpGet]
        public IActionResult GetBlogPosts()
        {
            return Ok(_blogPostRepository.GetBlogPosts());
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogPostById(int id)
        {
            var blogPost = _blogPostRepository.GetBlogPostById(id);

            if (blogPost == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blogPost);
            }
        }

        [HttpPost]
        public IActionResult AddBlogPost([FromBody] BlogPost newBlogPost)
        {
            if (newBlogPost == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdBlogPost = _blogPostRepository.AddPost(newBlogPost);

            return Created($"api/blogpost/{newBlogPost.Id}", createdBlogPost);
        }

        [HttpPut]
        public IActionResult UpdateBlogPost([FromBody] BlogPost blogPost)
        {
            if (blogPost == null)
            {
                return BadRequest();
            }

            if (blogPost.Title == string.Empty || blogPost.Post == string.Empty)
            {
                ModelState.AddModelError("Title/Post", "Title or post must not be empty");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogPostToUpdate = _blogPostRepository.GetBlogPostById(blogPost.Id);

            if (blogPostToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_blogPostRepository.UpdateBlogPost(blogPost));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlogPost(int id)
        {
            var blogPostToDelete = _blogPostRepository.GetBlogPostById(id);
            if (blogPostToDelete == null) {
                return NotFound();
            }
            else
            {
                _blogPostRepository.DeleteBlogPost(id);
                return Ok();
            }


        }
    }
}
