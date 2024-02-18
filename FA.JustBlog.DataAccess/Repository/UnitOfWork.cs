using Bulky.DataAccess.Repository.IRepository;
using FA.JustBlog.DataAccess.Data;
using FA.JustBlog.DataAccess.Repository;
using FA.JustBlog.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public IPostRepository Post { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public ITagRepository Tag { get; private set; }

        public ICommentRepository Comment {  get; private set; }
        public IPostTagRepository PostTag { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Post = new PostRepository(_db);
            Category = new CategoryRepository(_db);
            Tag = new TagRepository(_db);
            Comment = new CommentRepository(_db);
            PostTag = new PostTagRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
