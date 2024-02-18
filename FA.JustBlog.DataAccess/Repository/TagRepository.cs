using Bulky.DataAccess.Repository.IRepository;
using FA.JustBlog.DataAccess.Data;
using FA.JustBlog.DataAccess.Repository.IRepository;
using FA.JustBlog.Models;
using FA.JustBlog.Repository;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.DataAccess.Repository
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        private ApplicationDbContext _db;
        public TagRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Tag tag)
        {
            _db.Tags.Update(tag);
        }
    }
}
