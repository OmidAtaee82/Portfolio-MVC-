using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract
{
    public interface IPostService
    {

        List<AboutMe> GetAllPost();
        AboutMe GetPost(int id);
        void AddPost(AboutMe model);
        void UpdatePost(AboutMe model);
        void DeletePost(int id);

    }
}
