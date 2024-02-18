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
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(IUnitOfWork unitOfWork, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;

        }
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {

            List<IdentityRole> roleList = _roleManager.Roles.ToList();
            ViewData["CurrentSort"] = sortOrder;

            ViewData["NameRoleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_role_desc" : "";
            ViewData["ConcurrencyStampSortParm"] = sortOrder == "ConcurrencyStamp" ? "concurrency_stamp_desc" : "ConcurrencyStamp";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                roleList = roleList.Where(s => s.Name.Contains(searchString)
                                       || s.ConcurrencyStamp.Contains(searchString)).ToList();
            }
            switch (sortOrder)
            {
                case "name_role_desc":
                    roleList = roleList.OrderByDescending(s => s.Name).ToList();
                    break;
                case "ConcurrencyStamp":
                    roleList = roleList.OrderBy(s => s.ConcurrencyStamp).ToList();
                    break;
                case "concurrency_stamp_desc":
                    roleList = roleList.OrderByDescending(s => s.ConcurrencyStamp).ToList();
                    break;
                default:
                    roleList = roleList.OrderBy(s => s.Name).ToList();
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<IdentityRole>.CreateAsync(roleList, pageNumber ?? 1, pageSize));
        }
        public IActionResult GetData()
        {
            var data = _roleManager.Roles.ToList();
          
            return Json(data);
        }
        public IActionResult Create()
        {
            var Role = new IdentityRole();
            
         
            return View(Role);
        }
        [HttpPost]
        public IActionResult Create(IdentityRole obj)
        {
            if (ModelState.IsValid)
            {
                _roleManager.CreateAsync(obj).GetAwaiter().GetResult();
                TempData["success"] = "Create role successfully!!!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();

            }
            IdentityRole roleFromDb = await _roleManager.FindByIdAsync(id);
            if (roleFromDb == null)
            {
                return NotFound();
            }
           
            return View(roleFromDb);
        }
        [HttpPost]
        public IActionResult Edit(IdentityRole obj)
        {
            if (ModelState.IsValid)
            {
                _roleManager.UpdateNormalizedRoleNameAsync(obj).GetAwaiter().GetResult();
                _roleManager.UpdateAsync(obj).GetAwaiter().GetResult();
                TempData["success"] = "Update role successfully!!!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        [Authorize(Roles = $"{SD.Role_Blog_Owner}")]
        public async Task<IActionResult> Delete(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();

            }
            IdentityRole roleFromDb = await _roleManager.FindByIdAsync(id);
            if (roleFromDb == null)
            {
                return NotFound();
            }
           
            return View(roleFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePOST(string? id)
        {
            IdentityRole roleFromDb = await _roleManager.FindByIdAsync(id);
            if (roleFromDb == null)
            {
                return NotFound();
            }
            _roleManager.DeleteAsync(roleFromDb).GetAwaiter().GetResult();
            TempData["success"] = "Delete role successfully!!!";
            return RedirectToAction("Index");
        }
    }
}
