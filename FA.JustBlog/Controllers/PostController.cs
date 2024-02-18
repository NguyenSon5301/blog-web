using DNTCaptcha.Core;
using FA.JustBlog.DataAccess.Repository.IRepository;
using FA.JustBlog.Models;
using FA.JustBlog.Models.ViewModels;
using FA.JustBlog.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace FA.JustBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDNTCaptchaValidatorService _validatorService;
        private readonly DNTCaptchaOptions _captchaOptions;
        private readonly IStringLocalizer<PostController> _localizer;
        public PostController(IUnitOfWork unitOfWork, IDNTCaptchaValidatorService validatorService, IOptions<DNTCaptchaOptions> captchaOptions, IStringLocalizer<PostController> localizer)
        {
            _unitOfWork = unitOfWork;
            _validatorService = validatorService;
            _captchaOptions = captchaOptions == null ? throw new ArgumentNullException(nameof(captchaOptions)) : captchaOptions.Value;
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            var postList = _unitOfWork.Post.GetWithCategoriesAndTags();
            var test = _localizer["Home"];
            return View(postList);
        }
        [HttpGet]
        public IActionResult Search(string inputSearch)
        {
            var postList = _unitOfWork.Post.GetWithCategoriesAndTags();
            if(!string.IsNullOrEmpty(inputSearch))
            {
                ViewData["Title"] = "Search Posts!";
                postList = postList.Where(p =>
                p.Title.Contains(inputSearch, StringComparison.OrdinalIgnoreCase) ||
                p.Decription.Contains(inputSearch, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }
            else
            {
                ViewData["Title"] = "All Posts!";
            }

            return PartialView("_ListPosts", postList);
        }

        public IActionResult ListPosts()
        {

            return View();
        }
        public IActionResult Details(int year, int month, string title)
        {
            var post = _unitOfWork.Post.FindPost(year, month, title);
            if (post == null)
            {
                return RedirectToAction("Index");
            }
            return View(post);
        }
        [HttpGet, AutoValidateAntiforgeryToken]
        public IActionResult AddComment([FromQuery] string commentDesc, [FromQuery] int postId)
        {
            var check = _validatorService.HasRequestValidCaptchaEntry();

            if (!check)
            {
                this.ModelState.AddModelError(_captchaOptions.CaptchaComponent.CaptchaInputName, "Please enter the security code as number.");
            }

            if (ModelState.IsValid)
            {
                var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : "Anonymous";
                _unitOfWork.Comment.Add(new Comment() { CommentDate = DateTime.Now, CommentDescription = commentDesc, PostId = postId, UserId = userId });
                _unitOfWork.Save();

                return Json(new { success = true, message = commentDesc });
            }

            return Json(new { success = false, message = commentDesc });
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment2([FromForm] Post post,[FromForm] string desc)
        {
            if (!_validatorService.HasRequestValidCaptchaEntry())
            {
                //ModelState.AddModelError("DNT_CaptchaInputText",
                //                         "Please enter the security code as a number.");
                return Json(new { success = false, message = desc });

                //return RedirectToAction(nameof(Details), new {  year = post.CreateAtDate.Year,  month = post.CreateAtDate.Month,  title = post.Title, controller = "Post"});
            }
            var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : "Anonymous";
            _unitOfWork.Comment.Add(new Comment() { CommentDate = DateTime.Now, CommentDescription = desc, PostId = post.Id, UserId = userId });
            _unitOfWork.Save();
            return Json(new { success = true, message = desc });
        }

    }
}
