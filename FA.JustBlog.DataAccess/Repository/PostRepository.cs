using Bulky.DataAccess.Repository.IRepository;
using FA.JustBlog.DataAccess.Data;
using FA.JustBlog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private ApplicationDbContext _db;
        public PostRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Post post)
        {
            _db.Posts.Update(post);
        }

        public Post FindPost(int year, int month, string title)
        {
            var post = _db.Posts.Where(p => p.CreateAtDate.Year == year && p.CreateAtDate.Month == month && p.Title.Equals(title)).Include(p=>p.Comments).ThenInclude(c=>c.User).FirstOrDefault();
            return post;
        }

        public List<Post> GetWithCategoriesAndTags()
        {
            var posts = _db.Posts.Include(p=>p.Category).Include(p => p.PostTags).ThenInclude(p => p.Tag).ToList();
            return posts;
        }
        public int GetMaxId()
        {
            // Use LINQ to query the DbSet and find the maximum ID
            int maxId = _db.Posts.Max(entity => (int?)entity.Id) ?? 0;

            return maxId;
        }
        public Post GetPostWithTag(int id)
        {
            var post = _db.Posts.Include(p => p.PostTags).FirstOrDefault(p => p.Id == id);
            return post;
        }
    }
}
