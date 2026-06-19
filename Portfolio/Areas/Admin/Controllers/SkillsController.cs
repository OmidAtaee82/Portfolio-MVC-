using Entites;
using Microsoft.AspNetCore.Mvc;
using Service;
using ServiceContract;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SkillsController : Controller
    {

        private readonly IWebHostEnvironment _env;
        protected readonly ISkillService _skillService;

        public SkillsController(ISkillService skill , IWebHostEnvironment env)
        {
            _skillService = skill;
            _env = env;
        }


        [HttpGet]
        [Route("/admin/skills")]
        public IActionResult Skills()
        {
            var result = _skillService.GetAllSkills();
            return View(result);
        }


        [HttpGet]
        [Route("/admin/skills/{id}")]
        public IActionResult Skill(int id)
        {
            var result = _skillService.GetSkill(id);
            return View(result);
        }


        [HttpGet]
        [Route("/admin/skills/create")]
        public IActionResult SkillCreate()
        {
            return View();
        }

        [HttpPost]
        [Route("/admin/skills/create")]
        public IActionResult SkillCreate(Skills model , IFormFile file)
        {

            if(file != null)
            {
                string filename = file.FileName;
                string path = Path.Combine(_env.WebRootPath , "img" , filename);

                using (var path_file = new FileStream(path , FileMode.Create))
                {
                    file.CopyTo(path_file);
                }

                model.Image = "/img/" + filename;

            }

            _skillService.AddSkill(model);
            return RedirectToAction("SkillCreate");

        }

    }
}
