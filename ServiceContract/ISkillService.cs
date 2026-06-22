using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract
{
    public interface ISkillService
    {

        List<Skills> GetAllSkills();
        Skills GetSkill(int id);
        void AddSkill(Skills model);
        void UpdateSkill(Skills model);
        void DeleteSkill(int id);

    }
}
