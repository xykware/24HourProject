using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Models
{
    public class PostCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter a title.")]
        [MaxLength(100, ErrorMessage = "Title too long.")]
        public string Title { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter a message.")]
        [MaxLength(1000, ErrorMessage = "Too many characters")]
        public string Text { get; set; }
    }
}
