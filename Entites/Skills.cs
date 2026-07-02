using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class Skills
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name Required")]
        [StringLength(250)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Image Required")]
        public string Image { get; set; }

    }
}
