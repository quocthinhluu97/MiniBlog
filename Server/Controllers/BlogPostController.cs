﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult AddBlogPost([FromBody]BlogPost newBlogPost)
        {
            if (newBlogPost == null) {
                return BadRequest();
            }

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _blogPostRepository.AddPost(newBlogPost);

            return Created("new blog post", newBlogPost);
        }
    }
}