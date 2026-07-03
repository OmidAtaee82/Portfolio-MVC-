using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class ProjectSkill
    {

        public int ProjectId { get; set; }

        public int SkillId { get; set; }

        public Projects Project { get; set; }

        public Skills Skill { get; set; }

    }

}
