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

        public List<AboutMe> GetAllPost()
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

        public AboutMe GetPost(int id)
        {
            var result = _portfolioDB.AboutMe.FirstOrDefault(x=>x.Id == id);
            return result;
        }


        public void AddPost(AboutMe model)
        {
             _portfolioDB.AboutMe.Add(model);
            _portfolioDB.SaveChanges();
        }

        
        public void UpdatePost(AboutMe model)
        {
            var post = _portfolioDB.AboutMe.First(x=>x.Id == model.Id);

            if(post != null)
            {
                post.Name = model.Name;
                post.Email = model.Email;
                post.Location = model.Location;
                post.Frelancer = model.Frelancer;
                post.Description = model.Description;
            }

            _portfolioDB.SaveChanges();

        }


        public void DeletePost(int id)
        {
            var post = _portfolioDB.AboutMe.First(x=>x.Id == id);
            
            if(post != null)
            {
                _portfolioDB.AboutMe.Remove(post);
            }

            _portfolioDB.SaveChanges();
        }

    }
}
