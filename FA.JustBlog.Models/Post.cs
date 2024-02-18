using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Models
{
    public class Post
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime CreateAtDate { get; set; }
        [Required]

        public double Rate { get; set; }
        [Required]

        public int NumberView { get; set; }

        public string Decription { get; set; }
        [ForeignKey(nameof(Category))]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [ValidateNever]

        public Category Category { get; set; }
        [ValidateNever]
        public List<PostTag> PostTags { get; set; }
        [ValidateNever]
        public List<Comment> Comments { get; }

        public override string ToString()
        {
             
            TimeSpan timeDifference = DateTime.Now - CreateAtDate;  

            if (timeDifference.TotalDays < 1)
            {
                return $"Posted Today at {CreateAtDate.TimeOfDay.ToString("hh\\:mm")} with rate {Rate} by {NumberView} view(s)";
            }
            else if (timeDifference.TotalDays < 2)
            {
                return $"Posted Yesterday at {CreateAtDate.TimeOfDay.ToString("hh\\:mm")} with rate {Rate} by {NumberView} view(s)";
            }
            else
            {
                return $"Posted on {CreateAtDate.ToString("dd/MM/yyyy")} at {CreateAtDate.TimeOfDay.ToString("hh\\:mm")} with rate {Rate} by {NumberView} view(s)";
            }
        }
    }
}
