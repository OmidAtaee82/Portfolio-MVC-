using Entites;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ExperienceService:IExperienceService
    {

        private readonly PortfolioDB _portfolioDb;

        public ExperienceService(PortfolioDB portfolio)
        {
            _portfolioDb = portfolio;
        }

        public List<Experience> GetAllExperience()
        {

            var result = _portfolioDb.Experience.Select(x=>new Experience
            {
                Id = x.Id , 
                Expertise = x.Expertise , 
                Description = x.Description , 
                NameCompany = x.NameCompany , 
                StartData = x.StartData , 
                EndDate = x.EndDate
            }).ToList();

            return result;

        }


        public Experience GetExperience(int id)
        {

            var experiecne = _portfolioDb.Experience.FirstOrDefault(x => x.Id == id);
            return experiecne;

        }


        public void AddExperience(Experience model)
        {

            _portfolioDb.Experience.Add(model);
            _portfolioDb.SaveChanges();

        }


        public void UpdateExperience(Experience model)
        {

            var experience = _portfolioDb.Experience.FirstOrDefault(x=>x.Id == model.Id);

            if(experience != null)
            {
                experience.Id = model.Id;
                experience.Expertise = model.Expertise;
                experience.NameCompany = model.NameCompany;
                experience.Description = model.Description;
                experience.StartData = model.StartData;
                experience.EndDate = model.EndDate;
            }

            _portfolioDb.SaveChanges();

        }


        public void DeleteExperience(int id)
        {

            var experience = _portfolioDb.Experience.FirstOrDefault(x => x.Id == id);

            if(experience != null)
            {
                _portfolioDb.Experience.Remove(experience);
            }

            _portfolioDb.SaveChanges();

        }


        public List<Experience> ExperienceSearch(string searchText)
        {

            if (!string.IsNullOrEmpty(searchText))
            {
                return _portfolioDb.Experience.Where(x=>x.Expertise.Contains(searchText)).ToList();
            }
            else
            {
                return GetAllExperience();
            }

        }

    }
}
