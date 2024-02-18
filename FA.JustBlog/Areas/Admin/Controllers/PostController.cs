using FA.JustBlog.DataAccess.Repository.IRepository;
using FA.JustBlog.Models;
using FA.JustBlog.Models.ViewModels;
using FA.JustBlog.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Diagnostics;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.Role_Blog_Owner}, {SD.Role_Contributor}")]
    public class PostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Post> postList = _unitOfWork.Post.GetWithCategoriesAndTags();

            return View(postList);
        }
        public IActionResult GetData()
        {
            var data = _unitOfWork.Post.GetWithCategoriesAndTags();
            var result = new List<PostJson>();
            foreach (var item in data)
            {
                var tags = new List<string>();
                if (item.PostTags.Count() > 0)
                {
                    foreach (var tagString in item.PostTags)
                    {
                        tags.Add(tagString.Tag.Title);
                    }
                }
                result.Add(new PostJson() { Id = item.Id, Title = item.Title, CreateAtDate = item.CreateAtDate, Rate = item.Rate, NumberView = item.NumberView, Decription = item.Decription, CategoryTitle = item.Category.Title, Tags = tags });
            }
            return Json(result);
        }
        
        public IActionResult Create()
        {
            var postVM = new PostVM()
            {
                Post = new Post(),
                CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title,
                }),
                TagList = _unitOfWork.Tag.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title,
                })
            };
            return View(postVM);
        }
        [HttpPost]
        public IActionResult Create(PostVM obj)
        {
            
            if (ModelState.IsValid)
            {
                List<PostTag> postTags = new List<PostTag>();
                if (obj.ListTagAdd != null && obj.ListTagAdd.Count() > 0)
                {
                    foreach (var idTag in obj.ListTagAdd)
                    {
                        postTags.Add(new PostTag() { PostId = obj.Post.Id, TagId = idTag });
                    }
                }
                obj.Post.PostTags = postTags;
                _unitOfWork.Post.Add(obj.Post);
                _unitOfWork.Save();
                TempData["success"] = "Create post successfully!!!";
                return RedirectToAction("Index");
            }
            else
            {
                obj.CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title,
                });
                obj.TagList = _unitOfWork.Tag.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title,
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
            Post postFromDb = _unitOfWork.Post.GetPostWithTag(id);
            if (postFromDb == null)
            {
                return NotFound();
            }
            var postVM = new PostVM()
            {
                Post = postFromDb,
                CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title,
                }),
                TagList = _unitOfWork.Tag.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title,
                }),
                ListTagAdd = postFromDb.PostTags != null ? postFromDb.PostTags.Select(pt => pt.TagId).ToList() : new List<int>(),
            };
            return View(postVM);
        }
        [HttpPost]
        public IActionResult Edit(PostVM obj)
        {
            if (ModelState.IsValid)
            {
                var postLoad = _unitOfWork.Post.GetPostWithTag(obj.Post.Id);
                postLoad.Title = obj.Post.Title;
                postLoad.CreateAtDate = obj.Post.CreateAtDate;
                postLoad.Rate = obj.Post.Rate;
                postLoad.NumberView = obj.Post.NumberView;
                postLoad.Decription = obj.Post.Decription;
                postLoad.CategoryId = obj.Post.CategoryId;
                // Step 1: Clear existing tags
                postLoad.PostTags.Clear();

                if (obj.ListTagAdd != null && obj.ListTagAdd.Count() > 0)
                {
                    foreach (var tagId in obj.ListTagAdd)
                    {
                        var tag = _unitOfWork.Tag.Get(t => t.Id == tagId);
                        if (tag != null)
                        {
                            postLoad.PostTags.Add(new PostTag { Post = postLoad, Tag = tag });
                        }
                    }
                }
                _unitOfWork.Post.Update(postLoad);
                _unitOfWork.Save();
                TempData["success"] = "Update post successfully!!!";
                return RedirectToAction("Index");
            }
            else
            {
                obj.CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title,
                });
                obj.TagList = _unitOfWork.Tag.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title,
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
            Post postFromDb = _unitOfWork.Post.GetPostWithTag(id);
            if (postFromDb == null)
            {
                return NotFound();
            }
            var postVM = new PostVM()
            {
                Post = postFromDb,
                CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title,
                }),
                TagList = _unitOfWork.Tag.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title,
                }),
                ListTagAdd = postFromDb.PostTags != null ? postFromDb.PostTags.Select(pt => pt.TagId).ToList() : new List<int>(),
            };
            return View(postVM);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            Post categoryFromDb = _unitOfWork.Post.GetPostWithTag(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Post.Remove(categoryFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Delete post successfully!!!";
            return RedirectToAction("Index");
        }
    }
}
