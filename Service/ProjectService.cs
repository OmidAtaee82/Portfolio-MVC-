using Entites;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProjectService:IProjectService
    {

        private readonly PortfolioDB _portfolioDb;

        public ProjectService(PortfolioDB db)
        {
            _portfolioDb = db;
        }


        public List<Projects> GetAllProjects()
        {
            
            var result = _portfolioDb.Projects.Select(x => new Projects
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image
            }).ToList();

            return result;

        }


        public Projects GetProject(int id)
        {
            var result = _portfolioDb.Projects.FirstOrDefault(x=>x.Id == id);
            return result;
        }


        public void AddProject(Projects model)
        {

            _portfolioDb.Projects.Add(model);
            _portfolioDb.SaveChanges();

        }


        public void UpdateProject(Projects model)
        {

            var proje = _portfolioDb.Projects.FirstOrDefault(x=>x.Id == model.Id);

            if(proje != null)
            {

                proje.Name = model.Name;
                proje.Description = model.Description;
                proje.Image = model.Image;

            }

            _portfolioDb.SaveChanges();

        }


        public void DeleteProject(int id)
        {

            var proje = _portfolioDb.Projects.FirstOrDefault(x=>x.Id == id);

            if(proje != null)
            {
                _portfolioDb.Projects.Remove(proje);
            }

            _portfolioDb.SaveChanges();

        }

    }
}
