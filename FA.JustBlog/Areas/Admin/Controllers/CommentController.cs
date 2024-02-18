using FA.JustBlog.DataAccess.Repository.IRepository;
using FA.JustBlog.Models;
using FA.JustBlog.Models.ViewModels;
using FA.JustBlog.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.Role_Blog_Owner}, {SD.Role_Contributor}")]
    public class CommentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public CommentController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            List<Comment> commentList = _unitOfWork.Comment.GetWithPostAndUser();

            return View(commentList);
        }
        public IActionResult GetData()
        {
            var data = _unitOfWork.Comment.GetWithPostAndUser();
            var result = new List<CommentJson>();
            foreach (var item in data)
            {
                result.Add(new CommentJson() { Id = item.Id, CommentDescription = item.CommentDescription, CommentDate = item.CommentDate.ToString("dd/MM/yyyy hh:mm"), PostTitle = item.Post.Title, UserEmail = item.User.UserName });
            }
            return Json(result);
        }
        [Authorize(Roles = $"{SD.Role_Blog_Owner}")]

        public IActionResult Create()
        {
            var commentVM = new CommentVM()
            {
                Comment = new Comment(),
                PostList = _unitOfWork.Post.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Id.ToString() + ". " + c.Title,
                }),
                UserList = _userManager.Users.OfType<ApplicationUser>().OrderBy(u=>u.UserName).Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.UserName,
                })
            };
            return View(commentVM);
        }
        [HttpPost]
        public IActionResult Create(CommentVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Comment.Add(obj.Comment);
                _unitOfWork.Save();
                TempData["success"] = "Create comment successfully!!!";
                return RedirectToAction("Index");
            }
            else
            {
                obj.PostList = _unitOfWork.Post.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Id.ToString() + ". " + c.Title,
                });
                obj.UserList = _userManager.Users.OfType<ApplicationUser>().OrderBy(u => u.UserName).Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.UserName,
                });
                return View(obj);
            }
        }
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            Comment commentFromDb = _unitOfWork.Comment.FindCommentWithPostAndUser(id);
            if (commentFromDb == null)
            {
                return NotFound();
            }
            var commentVM = new CommentVM()
            {
                Comment = commentFromDb,
                PostList = _unitOfWork.Post.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Id.ToString() + ". " + c.Title,
                }),
                UserList = _userManager.Users.OfType<ApplicationUser>().OrderBy(u => u.UserName).Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.UserName,
                })
            };
            return View(commentVM);
        }
        [HttpPost]
        public IActionResult Edit(CommentVM obj)
        {
            
            if (ModelState.IsValid)
            {
                
                _unitOfWork.Comment.Update(obj.Comment);
                _unitOfWork.Save();
                TempData["success"] = "Update comment successfully!!!";
                return RedirectToAction("Index");
            }
            else
            {
                obj.PostList = _unitOfWork.Post.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Id.ToString() + ". " + c.Title,
                });
                obj.UserList = _userManager.Users.OfType<ApplicationUser>().OrderBy(u => u.UserName).Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.UserName,
                });
                return View(obj);
            }
        }
        [Authorize(Roles = $"{SD.Role_Blog_Owner}")]
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            Comment commentFromDb = _unitOfWork.Comment.FindCommentWithPostAndUser(id);
            if (commentFromDb == null)
            {
                return NotFound();
            }
            var commentVM = new CommentVM()
            {
                Comment = commentFromDb,
                PostList = _unitOfWork.Post.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Id.ToString() + ". " + c.Title,
                }),
                UserList = _userManager.Users.OfType<ApplicationUser>().OrderBy(u => u.UserName).Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.UserName,
                })
            };
            return View(commentVM);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            Comment categoryFromDb = _unitOfWork.Comment.FindCommentWithPostAndUser(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Comment.Remove(categoryFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Delete comment successfully!!!";
            return RedirectToAction("Index");
        }
    }
}
