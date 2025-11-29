using BLL.Abstract;
using DataContract;
using Lab_4_PAD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Lab_4_PAD.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
         _postService = postService;
        }

        public IActionResult Index()
        {
            var dtos = _postService.GetPosts();
            var posts = dtos.Select(x => new PostViewModel()
            {
                Author = x.Author,
                Content = x.Content,
                Created = x.Created.ToString()
            }).ToList();

            return View(posts);
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(CreatePostViewModel model) 
        
        { 
            if (ModelState.IsValid)
            {
                var dto = new PostDto()
                {
                    Author = model.Author,
                    Content = model.Content,
                };

                _postService.CreatePost(dto);
                return RedirectToAction("Index");

            }


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
