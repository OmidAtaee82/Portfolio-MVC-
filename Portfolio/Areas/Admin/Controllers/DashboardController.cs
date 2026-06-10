using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("/admin")]
    public class DashboardController : Controller
    {

        [Route("/admin/dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }


    }
}
