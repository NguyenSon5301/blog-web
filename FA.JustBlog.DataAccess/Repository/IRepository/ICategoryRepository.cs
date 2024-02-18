using FA.JustBlog.Models;
using FA.JustBlog.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.DataAccess.Repository.IRepository
{
    public interface IPostTagRepository : IRepository<PostTag>
    {
        void Update(PostTag postTag);

    }
}
