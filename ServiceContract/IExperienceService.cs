using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract
{
    public interface IExperienceService
    {

        List<Experience> GetAllExperience();
        Experience GetExperience(int id);
        void AddExperience(Experience model);
        void UpdateExperience(Experience model);
        void DeleteExperience(int id);
        List<Experience> ExperienceSearch(string searchText);

    }
}
