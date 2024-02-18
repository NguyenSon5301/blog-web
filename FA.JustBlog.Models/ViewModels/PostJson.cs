using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Models.ViewModels
{
    public class PostJson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateAtDate { get; set; }

        public double Rate { get; set; }

        public int NumberView { get; set; }

        public string Decription { get; set; }
        public string CategoryTitle {  get; set; }

        public List<string> Tags { get; set; }
       
    }
}
