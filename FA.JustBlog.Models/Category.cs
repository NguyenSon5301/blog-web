using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Title {  get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        [ValidateNever]
        public List<Post> Posts { get; }
    }
}
