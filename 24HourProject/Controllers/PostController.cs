using _24HourProject.Models;
using _24HourProject.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourProject.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllPost()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetPosts();
            return Ok(posts);
        }

        [HttpGet]
        public IHttpActionResult GetPostById(int id)
        {
            PostService postService = CreatePostService();
            var post = postService.GetPostById(id);
            return Ok(post);
        }

        [HttpPost]
        public IHttpActionResult CreatePostService(PostCreate post)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Didnt meet requirements.");
            }

            var service = CreatePostService();

            if(!service.CreatePost(post))
            {
                return InternalServerError();
            }
            return Ok("Successfully posted.");
        }

        [HttpPut]
        public IHttpActionResult EditPost(PostEdit post)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var service = CreatePostService();

            if(!service.UpdatePost(post))
            {
                return InternalServerError();
            }
            return Ok("Successfully updated.");
        }

        [HttpDelete]
        public IHttpActionResult DeletePostById(int id)
        {
            var service = CreatePostService();

            if(!service.DeletePost(id))
            {
                return InternalServerError();
            }

            return Ok();
        }

        //Helper Method
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }
    }
}
