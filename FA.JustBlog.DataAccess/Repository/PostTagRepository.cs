using Bulky.DataAccess.Repository.IRepository;
using FA.JustBlog.DataAccess.Data;
using FA.JustBlog.DataAccess.Repository.IRepository;
using FA.JustBlog.Models;
using FA.JustBlog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.DataAccess.Repository
{
    public class PostTagRepository : Repository<PostTag>, IPostTagRepository
    {
        private ApplicationDbContext _db;
        public PostTagRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PostTag postTag)
        {
            _db.PostTags.Update(postTag);
        }
    }
}
