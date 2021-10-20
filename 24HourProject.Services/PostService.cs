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

        public bool CreatePost(PostCreate post)
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
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostList> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                        e =>
                            new PostList
                            {
                                PostId = e.PostId,
                                Title = e.Title,
                                AuthorId = _userId
                            }
                        );
                return query.ToArray();
            }
        }

        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var post =
                    ctx
                    .Posts
                    .Single(p => p.PostId == id && p.AuthorId == _userId);
                return
                    new PostDetail
                    {
                        PostId = post.PostId,
                        Title = post.Title,
                        Text = post.Text,
                        AuthorId = post.AuthorId
                    };
            }
        }

        public bool UpdateNote(PostEdit post)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Where(e => e.AuthorId == _userId)
                    .Single(e => e.PostId == post.PostId);

                entity.Title = post.Title;
                entity.Text = post.Text;
                entity.PostId = post.PostId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Where(e => e.AuthorId == _userId)
                    .Single(e => e.PostId == postId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
