using Entites;

namespace Portfolio.models
{
    public class HomeViewModel
    {

        public List<AboutMe> aboutMe { get; set; }
        public List<Skills> skills { get; set; }
        public List<Projects> projects { get; set; }
        public List<Experience> experiences { get; set; }

    }
}
