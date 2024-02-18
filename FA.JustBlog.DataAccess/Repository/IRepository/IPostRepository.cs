using FA.JustBlog.Models;
using FA.JustBlog.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IPostRepository : IRepository<Post>
    {
        void Update(Post post);
        Post FindPost(int year, int month, string title);
        List<Post> GetWithCategoriesAndTags();
        int GetMaxId();
        public Post GetPostWithTag(int id);

    }
}
