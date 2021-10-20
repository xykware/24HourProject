using _24HourProject.Data;
using _24HourProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    AuthorId = _userId,
                    Text = model.Text,
                    CommentId = model.CommentId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
