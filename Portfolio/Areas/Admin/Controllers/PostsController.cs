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
            var result = _postService.GetAll();
            return View(result);
        }

        [HttpGet]
        [Route("/admin/posts/create")]
        public IActionResult PostCreate()
        {
            return View();
        }

    }
}
