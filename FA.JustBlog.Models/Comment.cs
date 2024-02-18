using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Models
{
    public class Comment
    {
        [Key]
        public int Id {  get; set; }
        [DisplayName("Comment Date")]

        public DateTime CommentDate { get; set; }
        [Required]
        [DisplayName("Comment Description")]
        public string CommentDescription { get; set; }

        [ForeignKey(nameof(Post))]
        [DisplayName("Post")]
        public int PostId {  get; set; }
        [ValidateNever]
        public Post? Post { get; set; }    
        [ForeignKey(nameof(ApplicationUser))]
        [DisplayName("User")]
        public string UserId {  get; set; }
        [ValidateNever]
        public ApplicationUser? User { get; set; }

    }
}
