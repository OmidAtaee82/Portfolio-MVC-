using Entites;
using Microsoft.AspNetCore.Mvc;
using ServiceContract;

namespace Portfolio.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ExperienceController : Controller
    {

        protected readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService p)
        {
            _experienceService = p;
        }

        [Route("/admin/experiences")]
        public IActionResult Experiences(string searchText)
        {
            //var result = _experienceService.GetAllExperience();
            //return View(result);

            ViewBag.searchText = searchText;

            List<Experience> experience = new List<Experience>();

            if(!string.IsNullOrEmpty(searchText))
            {

                experience = _experienceService.ExperienceSearch(searchText);

                if(experience.Count < 1)
                {
                    ViewBag.error = "Experience Not Found ...";
                    experience = _experienceService.GetAllExperience();
                }

            }
            else
            {
                experience = _experienceService.GetAllExperience();
            }

            return View(experience);

        }

        [Route("/admin/experience/{id}")]
        public IActionResult Experience(int id)
        {
            var result = _experienceService.GetExperience(id);
            return View(result);
        }


        [HttpGet]
        [Route("/admin/experience/create")]
        public IActionResult ExperienceCreate()
        {
            return View();
        }

        [HttpPost]
        [Route("/admin/experience/create")]
        public IActionResult ExperienceCreate(Experience model)
        {

            _experienceService.AddExperience(model);
            return RedirectToAction("Experiences");

        }


        [HttpGet]
        [Route("/admin/experience/edit/{id}")]
        public IActionResult ExperienceEdit(int id)
        {
            var get_experience = _experienceService.GetExperience(id);

            return View(get_experience);
        }

        [HttpPost]
        [Route("/admin/experience/edit/{id}")]
        public IActionResult ExperienceEdit(Experience model)
        {

            var get_experience = _experienceService.GetExperience(model.Id);

            if(get_experience != null)
            {
                _experienceService.UpdateExperience(model);
            }

            return RedirectToAction("Experiences");

        }


        [HttpPost]
        [Route("/admin/experience/delete/{id}")]
        public IActionResult ExperienceDelete(int id)
        {
            var get_experience = _experienceService.GetExperience(id);

            if(get_experience != null)
            {
                _experienceService.DeleteExperience(id);
            }

            return RedirectToAction("Experiences");

        }

    }
}
