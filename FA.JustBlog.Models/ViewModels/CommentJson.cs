using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Models.ViewModels
{
    public class CommentJson
    {
        public int Id { get; set; }
        public string CommentDate { get; set; }
        public string CommentDescription { get; set; }
        public string PostTitle { get; set; }

        public string UserEmail {  get; set; }
    }
}
