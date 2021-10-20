using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Models
{
    public class PostList
    {
        public int NoteId { get; set; }

        public string Title { get; set; }

        public Guid AuthorId { get; set; }
    }
}
