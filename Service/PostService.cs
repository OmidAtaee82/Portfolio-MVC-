using Entites;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PostService:IPostService
    {

        private List<AboutMe> _posts;
        private readonly PortfolioDB _portfolioDB;

        public PostService(PortfolioDB portfolioDB)
        {
            _portfolioDB = portfolioDB;
        }

        public List<AboutMe> GetAll()
        {
            var result = _portfolioDB.AboutMe.Select(x => new AboutMe
            {
                Id = x.Id , 
                Name = x.Name , 
                Email = x.Email , 
                Location = x.Location , 
                Frelancer = x.Frelancer , 
                Description = x.Description
            }).ToList();

            return result;

        }


        public void CreatePost(AboutMe model)
        {
             _portfolioDB.AboutMe.Add(model);
            _portfolioDB.SaveChanges();
        }

    }
}
