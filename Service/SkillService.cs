using Entites;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SkillService:ISkillService
    {

        private readonly PortfolioDB _portfolioDB;

        public SkillService(PortfolioDB db)
        {
            _portfolioDB = db;
        }


        public List<Skills> GetAllSkills()
        {

            var skills = _portfolioDB.Skills.Select(x => new Skills
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image
            }).ToList();

            return skills;

        }



        public Skills GetSkill(int id)
        {
            var skill = _portfolioDB.Skills.FirstOrDefault(x=>x.Id == id);
            return skill;
        }


        public void AddSkill(Skills model)
        {
            _portfolioDB.Skills.Add(model);
            _portfolioDB.SaveChanges();
        }


        public void UpdateSkill(Skills model)
        {

            var skill = _portfolioDB.Skills.FirstOrDefault(x=>x.Id == model.Id);

            if(skill != null)
            {
                skill.Name = model.Name;
                skill.Image = model.Image;
            }

            _portfolioDB.SaveChanges();

        }


        public void DeleteSkill(int id)
        {
            var skill = _portfolioDB.Skills.FirstOrDefault(x => x.Id == id);
            
            if(skill != null)
            {
                _portfolioDB.Skills.Remove(skill);
            }

            _portfolioDB.SaveChanges();

        }

    }
}
