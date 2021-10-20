using _24HourProject.Data;
using _24HourProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public CreatePost(PostCreate post)
        {
            var entity =
                new Post()
                {
                    AuthorId = _userId,
                    Title = post.Title,
                    Text = post.Text,
                };
            using (var ctx = new ApplicationDbContext())
            {
                
            }
        }
    }
}
