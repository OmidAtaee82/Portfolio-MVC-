using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract
{
    public interface IProjectService
    {

        List<Projects> GetAllProjects();
        Projects GetProject(int id);
        void AddProject(Projects model);
        void UpdateProject(Projects model);
        void DeleteProject(int id);

    }
}
