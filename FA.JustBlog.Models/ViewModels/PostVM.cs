using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Models.ViewModels
{
    public class PostVM
    {
        public Post Post { get; set; }
        [ValidateNever]
        [DisplayName("Tags")]
        public List<int>? ListTagAdd { get; set; }
        [ValidateNever]

        public IEnumerable<SelectListItem> CategoryList { get; set; }
        [ValidateNever]

        public IEnumerable<SelectListItem> TagList { get; set; }
   
        
    }
}
