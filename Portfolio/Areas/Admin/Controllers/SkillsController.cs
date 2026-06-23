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
        public IActionResult Skills(string searchText)
        {
            //var result = _skillService.GetAllSkills();
            //return View(result);
            ViewBag.searchText = searchText;

            List<Skills> skills;

            if (!string.IsNullOrEmpty(searchText))
            {
                skills = _skillService.SearchSkills(searchText);

                if(!skills.Any())
                {
                    ViewBag.Message = "Not Found Data ...";
                    skills = _skillService.GetAllSkills();
                }

            }
            else
            {
                skills = _skillService.GetAllSkills();
            }

            return View(skills);

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

            if (file != null)
            {
                string filename = file.FileName;
                string path = Path.Combine(_env.WebRootPath, "img", filename);

                using (var path_file = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(path_file);
                }

                model.Image = "/img/" + filename;

            }

            _skillService.AddSkill(model);
            return RedirectToAction("Skills");

        }


        [HttpGet]
        [Route("/admin/skills/edit/{id}")]

        public IActionResult SkillEdit(int id)
        {

            var result = _skillService.GetSkill(id);
            return View(result);
        }

        [HttpPost]
        [Route("/admin/skills/edit/{id}")]
        
        public IActionResult SkillEdit(Skills model , IFormFile file)
        {

            var get_skill = _skillService.GetSkill(model.Id);

            if(get_skill != null)
            {
                if (file != null)
                {
                    string filename = file.FileName;
                    string path = Path.Combine(_env.WebRootPath, "img", filename);

                    using (var path_file = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(path_file);
                    }

                    model.Image = "/img/" + filename;

                }
                else
                {
                    model.Image = get_skill.Image;
                }
            }

            _skillService.UpdateSkill(model);
            return RedirectToAction("Skills");

        }


        [HttpPost]
        [Route("/admin/skills/delete/{id}")]
        public IActionResult DelteSkill(int id)
        {

            var get_skill = _skillService.GetSkill(id);

            if(get_skill != null)
            {
                _skillService.DeleteSkill(id);
            }

            return RedirectToAction("Skills");

        }


    }
}
