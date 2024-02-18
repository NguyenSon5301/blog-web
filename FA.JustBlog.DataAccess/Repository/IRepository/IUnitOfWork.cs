using Bulky.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPostRepository Post{ get; }
        ICategoryRepository Category { get; }
        ITagRepository Tag { get; }
        ICommentRepository Comment { get; }
        IPostTagRepository PostTag { get; }
        void Save();
    }
}
