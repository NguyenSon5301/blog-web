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
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = _unitOfWork.Category.GetAll().ToList();

            return View(categoryList);
        }
        public IActionResult GetData()
        {
            var data = _unitOfWork.Category.GetAll().ToList();
          
            return Json(data);
        }
        public IActionResult Create()
        {
            var Category = new Category();
            
         
            return View(Category);
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Create category successfully!!!";
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
            Category categoryFromDb = _unitOfWork.Category.Get(ct => ct.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
           
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Update category successfully!!!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        [Authorize(Roles = $"{SD.Role_Blog_Owner}")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            Category categoryFromDb = _unitOfWork.Category.Get(ct => ct.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
           
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category categoryFromDb = _unitOfWork.Category.Get(ct => ct.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(categoryFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Delete category successfully!!!";
            return RedirectToAction("Index");
        }
    }
}
