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
            PostService
        }

        [HttpPost]
        public IHttpActionResult CreatePostService(PostCreate post)
        {

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
