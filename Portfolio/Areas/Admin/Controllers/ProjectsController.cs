using Entites;
using Microsoft.AspNetCore.Mvc;
using ServiceContract;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectsController : Controller
    {

        private readonly IWebHostEnvironment _env;
        protected readonly IProjectService _projectService;
        protected readonly ISkillService _skillService;
        protected readonly IProjectSkillService _psService;

        public ProjectsController(IProjectService p , ISkillService s , IProjectSkillService ps ,  IWebHostEnvironment env)
        {
            _projectService = p;
            _skillService = s;
            _psService = ps;
            _env = env;
        }

        [Route("/admin/projects")]
        public IActionResult Projects(string searchText)
        {

            ViewBag.searchText = searchText;

            List<Projects> projects;

            if(!string.IsNullOrEmpty(searchText))
            {
                projects = _projectService.ProjectSearch(searchText);
            }
            else
            {
                projects = _projectService.GetAllProjects();
            }

            return View(projects);
        }

        [Route("/admin/projects/{id}")]
        public IActionResult Proje(int id)
        {
            var result = _projectService.GetProject(id);
            return View(result);
        }


        [HttpGet]
        [Route("/admin/projects/create")]
        public IActionResult ProjectCreate()
        {
            var skills = _skillService.GetAllSkills();
            ViewBag.skills = skills;

            return View();
        }


        [HttpPost]
        [Route("/admin/projects/create")]
        public IActionResult ProjectCreate(Projects model , IFormFile file , List<int> skillIds)
        {

            if (file != null)
            {

                string fileName = file.FileName;
                string path = Path.Combine(_env.WebRootPath , "img" , fileName);

                using (var path_file = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(path_file);
                }

                model.Image = "/img/" + fileName;

            }

            _projectService.AddProject(model);

            foreach (var skillId in skillIds)
            {
                _psService.AddProjectSkill(model.Id, skillId);
            }

            return RedirectToAction("Projects");
        }


        [HttpGet]
        [Route("/admin/projects/edit/{id}")]
        public IActionResult ProjectEdit(int id)
        {
            var result = _projectService.GetProject(id);
            return View(result);
        }


        [HttpPost]
        [Route("/admin/projects/edit/{id}")]
        public IActionResult ProjectEdit(Projects model , IFormFile file)
        {

            var get_proje = _projectService.GetProject(model.Id);

            if(get_proje != null)
            {
                if (file != null)
                {

                    string fileName = file.FileName;
                    string path = Path.Combine(_env.WebRootPath, "img", fileName);

                    using (var path_file = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(path_file);
                    }

                    model.Image = "/img/" + fileName;

                }
                else
                {
                    model.Image = get_proje.Image;
                }
            }

            _projectService.UpdateProject(model);

            return RedirectToAction("Projects");

        }


        [HttpPost]
        [Route("/admin/projects/delete/{id}")]
        public IActionResult ProjectDelete(int id)
        {

            var get_proje = _projectService.GetProject(id);

            if(get_proje != null)
            {

                _projectService.DeleteProject(id);

            }

            return RedirectToAction("Projects");

        }

    }
}
