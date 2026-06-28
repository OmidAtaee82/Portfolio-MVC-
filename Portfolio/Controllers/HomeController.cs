using Microsoft.AspNetCore.Mvc;
using Portfolio.models;
using ServiceContract;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {

        protected readonly IPostService _postService;
        protected readonly ISkillService _skillService;
        protected readonly IProjectService _projectService;
        protected readonly IExperienceService _experienceService;

        public HomeController(IPostService post , ISkillService skill , IProjectService project , IExperienceService experience)
        {
            _postService = post;
            _skillService = skill;
            _projectService = project;
            _experienceService = experience;
        }

        [Route("/")]
        public IActionResult Index()
        {

            HomeViewModel model = new HomeViewModel();

            model.aboutMe = _postService.GetAllPost();
            model.skills = _skillService.GetAllSkills();
            model.projects = _projectService.GetAllProjects();
            model.experiences = _experienceService.GetAllExperience();

            return View(model);
        }

    }
}
