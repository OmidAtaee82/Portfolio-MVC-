using Entites;
using Microsoft.AspNetCore.Mvc;
using Service;
using ServiceContract;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostsController : Controller
    {

        private readonly IPostService _postService;
        public PostsController(IPostService post)
        {
            _postService = post;
        }


        [HttpGet]
        [Route("/admin/posts")]
        public IActionResult Posts()
        {
            var result = _postService.GetAllPost();
            return View(result);
        }

        [HttpGet]
        [Route("/admin/posts/{id}")]
        public IActionResult Post(int id)
        {
            var result = _postService.GetPost(id);
            return View(result);
        }

        [HttpGet]
        [Route("/admin/posts/create")]
        public IActionResult PostCreate()
        {
            return View();
        }

        [HttpPost]
        [Route("/admin/posts/create")]
        public IActionResult PostCreate(AboutMe model)
        {

            _postService.AddPost(model);
            return RedirectToAction("Posts");

        }

    }
}
