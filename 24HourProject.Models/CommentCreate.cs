using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Models
{
    public class CommentCreate
    {
        public int PostId { get; set; }
        [Required]
        [MinLength (1, ErrorMessage = "Comment cannot be blank.")]
        [MaxLength (8000, ErrorMessage = "Maximum characters used. Please shorten your comment.")]
        public string Content { get; set; }
    }
}
