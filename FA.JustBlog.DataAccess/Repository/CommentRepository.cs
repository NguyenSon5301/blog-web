using FA.JustBlog.DataAccess.Data;
using FA.JustBlog.DataAccess.Repository.IRepository;
using FA.JustBlog.Models;
using FA.JustBlog.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.DataAccess.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private ApplicationDbContext _db;
        public CommentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Comment comment)
        {
            _db.Comments.Update(comment);
        }
        public List<Comment> GetWithPostAndUser()
        {
            var comments = _db.Comments.Include(c=>c.Post).Include(c=>c.User).ToList();
            return comments;
        } 
        public Comment FindCommentWithPostAndUser(int id)
        {
            var comments = _db.Comments.Include(c=>c.Post).Include(c=>c.User).FirstOrDefault(c=>c.Id.Equals(id));
            return comments;
        }
    }
}
