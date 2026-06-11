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


        [HttpGet]
        [Route("/admin/posts/edit/{id}")]
        public IActionResult PostEdit(int id)
        {
            var result = _postService.GetPost(id);
            return View(result);
        }

        [HttpPost]
        [Route("/admin/posts/edit/{id}")]
        public IActionResult PostEdit(AboutMe model)
        {
            var getPost = _postService.GetPost(model.Id);

            if(getPost != null)
            {
                _postService.UpdatePost(model);
            }

            return RedirectToAction("Posts");

        }

        [HttpPost]
        [Route("/admin/posts/delete/{id}")]
        public IActionResult PostDelete(int id)
        {

            _postService.DeletePost(id);
            return RedirectToAction("Posts");
            
        }

    }
}
