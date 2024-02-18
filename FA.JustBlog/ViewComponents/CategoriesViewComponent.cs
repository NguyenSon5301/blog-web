using FA.JustBlog.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesViewComponent(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        public IViewComponentResult Invoke() => View(_unitOfWork.Category.GetAll().ToList());
    }
}
