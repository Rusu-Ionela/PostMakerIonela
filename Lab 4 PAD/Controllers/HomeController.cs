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

        // GET: /Home/Index
        [HttpGet]
        public IActionResult Index()
        {
            // luăm postările din serviciu (BLL)
            var dtos = _postService.GetPosts();

            // le mapăm la ViewModel pentru view
            var model = dtos.Select(x => new PostViewModel
            {
                Author = x.Author,
                Content = x.Content,
                Created = x.Created.ToString("g") // format data/ora
            }).ToList();

            // trimitem lista către Views/Home/Index.cshtml
            return View(model);
        }

        // GET: /Home/CreatePost
        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        // POST: /Home/CreatePost
        [HttpPost]
        public IActionResult CreatePost(CreatePostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // dacă nu e valid, rămânem pe aceeași pagină cu erorile
                return View(model);
            }

            var dto = new PostDto
            {
                Author = model.Author,
                Content = model.Content
            };

            _postService.CreatePost(dto);

            // după creare, mergem înapoi la listă (Index)
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
