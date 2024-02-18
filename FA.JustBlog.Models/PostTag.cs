using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Models
{
    public class PostTag
    {
        [Required]
        [ForeignKey(nameof(Post))]
        public int PostId {  get; set; }
        [Required]
        [ForeignKey(nameof(Tag))]
        public int TagId {  get; set; }
        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}
