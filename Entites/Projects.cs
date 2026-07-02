using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class Projects
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name Required")]
        [StringLength(300)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description Required")]
        [MaxLength(700)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Image Required")]
        public string Image { get; set; }

    }
}
