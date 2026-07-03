using Entites;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProjectSkillService:IProjectSkillService
    {

        private readonly PortfolioDB _portfolioDb;

        public ProjectSkillService(PortfolioDB db)
        {
            _portfolioDb = db;
        }

        public void AddProjectSkill(int projectId , int skillId)
        {

            ProjectSkill projectSkill = new ProjectSkill()
            {
                ProjectId = projectId,
                SkillId = skillId
            };

            _portfolioDb.ProjectSkill.Add(projectSkill);
            _portfolioDb.SaveChanges();

        }

    }
}
