using FA.JustBlog.DataAccess.Repository.IRepository;
using FA.JustBlog.Models;
using FA.JustBlog.Models.ViewModels;
using FA.JustBlog.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.Role_Blog_Owner}, {SD.Role_Contributor}")]

    public class TagController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TagController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Tag> tagList = _unitOfWork.Tag.GetAll().ToList();

            return View(tagList);
        }
        public IActionResult GetData()
        {
            var data = _unitOfWork.Tag.GetAll().ToList();
          
            return Json(data);
        }
        public IActionResult Create()
        {
            var Tag = new Tag();
            return View(Tag);
        }
        [HttpPost]
        [Authorize(Roles = $"{SD.Role_Blog_Owner}")]
        public IActionResult Create(Tag obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Tag.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Create tag successfully!!!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            Tag tagFromDb = _unitOfWork.Tag.Get(ct => ct.Id == id);
            if (tagFromDb == null)
            {
                return NotFound();
            }
            return View(tagFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Tag obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Tag.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Update tag successfully!!!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            Tag tagFromDb = _unitOfWork.Tag.Get(ct => ct.Id == id);
            if (tagFromDb == null)
            {
                return NotFound();
            }
            return View(tagFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Tag categoryFromDb = _unitOfWork.Tag.Get(ct => ct.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Tag.Remove(categoryFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Delete tag successfully!!!";
            return RedirectToAction("Index");
        }
    }
}
