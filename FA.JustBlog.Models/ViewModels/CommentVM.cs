using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Models.ViewModels
{
    public class CommentVM
    {
        public Comment Comment { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> PostList { get; set; }  
        [ValidateNever]
        public IEnumerable<SelectListItem> UserList { get; set; }
    }
}
